using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

namespace BalitTanahPelayanan.Pages.Private.Customer
{
    public partial class CustomerBayar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnUpload.Click += async (a, b) => {
                if (!FileUpload1.HasFile)
                {
                    CommonWeb.Alert(this, "Silakan pilih file bukti pembayaran terlebih dahulu.");
                    return;
                }
                //upload file 
                //var pathTarget = Server.MapPath("~/Document/Payment");
                //var tempFile = shortid.ShortId.Generate(true, false, 10)+Path.GetExtension(FileUpload1.FileName);
                //var fileName = pathTarget + "//" + tempFile;
                string nameFile = "payment_" + CommonWeb.GetCurrentUser()
                         + "_" + DateTime.Now.ToString("ddMMMyyyy")
                         + "_" + shortid.ShortId.Generate(true, false)
                         + Path.GetExtension(FileUpload1.FileName);
                await CloudStorage.BlobPostAsync(FileUpload1.FileBytes, nameFile);
                var fileurl = ConfigurationManager.AppSettings["DefaultBlobRootUrl"] + nameFile;
                HidUrlBukti.Value = fileurl;
                ImgLampiran.Src = fileurl;
                ImgLampiran.Visible = true;
            };
            BtnCancel.Click += (a, b) => { Response.Redirect("CustomerBeranda.aspx"); };
            BtnSave.Click += async(a, b) =>
            {
                if (string.IsNullOrEmpty(HidUrlBukti.Value))
                {
                    CommonWeb.Alert(this, "Silakan upload bukti pembayaran terlebih dahulu.");
                    return;
                }
                var LampiranUrl = "";
                if (FileUploadLampiran.HasFile)
                {
                    string nameFile = "lampiran_bayar_" + CommonWeb.GetCurrentUser()
                            + "_" + DateTime.Now.ToString("ddMMMyyyy")
                            + "_" + shortid.ShortId.Generate(true, false)
                            + Path.GetExtension(FileUploadLampiran.FileName);
                    await CloudStorage.BlobPostAsync(FileUploadLampiran.FileBytes, nameFile);
                    var urllampiran = ConfigurationManager.AppSettings["DefaultBlobRootUrl"] + nameFile;
                    LampiranUrl = urllampiran;
                   
                }
                var fileurl = HidUrlBukti.Value;


                using (var db = new smlpobDB())
                {
                    var newItem = new paymenttbl() { attachmentUrl= LampiranUrl, accountName = TxtNamaRekening.Text, accountNo = TxtNoRekening.Text, amount = Convert.ToDecimal(TxtJumlahTransfer.Text), bankName = CmbBankPengirim.SelectedValue, name = lblcusname.Text, orderNo = lblnoPesanan.Text, paymentReceiptUrl = fileurl, status = Status.PaymentStatus[1] };
                   
                    var orderNo = lblnoPesanan.Text;

                    if (!string.IsNullOrEmpty(orderNo))
                    {

                        var dataOrder = (from x in db.ordermastertbls.Include(c => c.comoditytbl)
                                         where x.orderNo == orderNo
                                         select x).FirstOrDefault();
                        if (dataOrder != null)
                        {
                            if(Convert.ToDecimal( TxtJumlahTransfer.Text) < Convert.ToDecimal(LitTotBiaya.Text))
                            {
                                CommonWeb.Alert(this, "Nilai yang ditransfer harus sesuai.");
                                return;
                            }
                            dataOrder.paymentStatus = Status.PaymentStatus[1];
                            db.paymenttbls.Add(newItem);
                            await db.SaveChangesAsync();
                            CommonWeb.Alert(this, "Pembayaran di proses");
                            BtnSave.Visible = false;
                        }
                        CommonWeb.Alert(this, "Gagal proses, terjadi kesalahan");

                    }
                }
            };

            if (!IsPostBack)
            {
                string[] Banks = {
"Bank Rakyat Indonesia (BRI)",
"Bank Mandiri",
"Bank Central Asia (BCA)",
"Bank Negara Indonesia (BNI)",
"Bank Tabungan Negara (BTN)",
"Bank CIMB Niaga",
"Bank Panin",
"Bank OCBC NISP",
"Bank Danamon Indonesia",
"Bank Permata",
"Bank Maybank Indonesia",
"Lainnya"};
                CmbBankPengirim.DataSource = Banks;
                CmbBankPengirim.DataBind();
                GetTranslation();
                var orderNo = Request.QueryString["orderNo"];
                
                if (!string.IsNullOrEmpty(orderNo))
                {
                    using (var db = new smlpobDB())
                    {
                        var dataOrder = (from x in db.ordermastertbls.Include(c=>c.comoditytbl)
                                        where x.orderNo == orderNo
                                        select x).FirstOrDefault();
                        if (dataOrder != null)
                        {
                            lblTanggal.Text = dataOrder.creaDate?.ToString("MM-dd-yyyy");
                            lblnoPesanan.Text = dataOrder.orderNo;
                            lblKomoditas.Text = dataOrder.comoditytbl.comodityName;
                            lbljenisAnalisis.Text = dataOrder.analysisType;
                            var uname = CommonWeb.GetCurrentUser();
                            
                                var cust = (from x in db.customertbls
                                            where x.customerEmail == uname
                                            select x).FirstOrDefault();
                            if (cust != null)
                            {
                                lblcusname.Text = cust.customerName;
                                lblInstansi.Text = cust.companyName;
                            }

                            var dataDetail = from x in db.orderanalysisdetailtbls
                                             where x.orderNo == orderNo
                                             select new { x.elementId };
                            var totalParam = dataDetail.Distinct().Count();

                            LitJmlParamUji.Text = totalParam.ToString("n0");
                            LitJmlSampel.Text = dataOrder.sampleTotal?.ToString("n0");
                            LitTotBiaya.Text = dataOrder.priceTotal?.ToString("n0");
                        }
                    }

                }
                else
                {
                    CommonWeb.Alert(this, "Tidak ada order no - tidak ada order yang bisa di bayar");
                }
            }
            
        }
        void GetTranslation()
        {
          
            litHeader.Text = LanguageHelper.GetTranslation("pay_transfer");
            LitBuktiPembayaran.Text = LanguageHelper.GetTranslation("payment_receipt");
            LitAttachment.Text = LanguageHelper.GetTranslation("attachment");
            LitJumlahTransfer.Text = LanguageHelper.GetTranslation("total_transfer");
            LitJumlahTransferDesc.Text = LanguageHelper.GetTranslation("total_transfer_desc");
            lblNamaPemilikRek.Text = LanguageHelper.GetTranslation("account_name");
            lbNamaPemilikRek.Text = LanguageHelper.GetTranslation("account_name_desc");
            LitNoRekening.Text = LanguageHelper.GetTranslation("account_no");
            LitNoRekDesc.Text = LanguageHelper.GetTranslation("account_no_desc");
            lblBank.Text = LanguageHelper.GetTranslation("bank_name");
            lbbank.Text = LanguageHelper.GetTranslation("bank_name");
            BtnCancel.Text = LanguageHelper.GetTranslation("back");
            BtnSave.Text = LanguageHelper.GetTranslation("save");
            BtnUpload.Text = LanguageHelper.GetTranslation("upload");

            lblInfoPelanggan.Text = LanguageHelper.GetTranslation("customer_info");
            name.Text = LanguageHelper.GetTranslation("name");
            instansi.Text = LanguageHelper.GetTranslation("agency");
            lblInfoPesanan.Text = LanguageHelper.GetTranslation("order_info");
            tanggal.Text = LanguageHelper.GetTranslation("date");
            noPesanan.Text = LanguageHelper.GetTranslation("ord_no");
            komoditas.Text = LanguageHelper.GetTranslation("Lit_Komoditas");
            jnsAnalisis.Text = LanguageHelper.GetTranslation("analisystype");
           
            lblJmlParamUji.Text = LanguageHelper.GetTranslation("total_parameter_uji");
            lblJmlSampel.Text = LanguageHelper.GetTranslation("sampletot");
            lblTotBiaya.Text = LanguageHelper.GetTranslation("total_biaya");
           
        }
    }
}