using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Controllers;
using System.Data.Entity;
namespace BalitTanahPelayanan.Pages.Private.Kasir
{
    public partial class KasirVerifikasiPembayaran : System.Web.UI.Page
    {
        OrderMasterControls orderControls = new OrderMasterControls();

        void GetTranslation()
        {
            LitMasuk.Text = LanguageHelper.GetTranslation("title_payment_verification");
            GvData.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
            btnMasuk.Text = LanguageHelper.GetTranslation("order_entry");
            btnProses.Text = LanguageHelper.GetTranslation("order_processed");
            btnSelesai.Text = LanguageHelper.GetTranslation("order_complete");
            btnVerifikasi.Text = LanguageHelper.GetTranslation("title_payment_verification");
            litTipePembayaran.Text = LanguageHelper.GetTranslation("payment_type");
            litStatusPembayaran.Text = LanguageHelper.GetTranslation("payment_status");
            BtnSave.Text = LanguageHelper.GetTranslation("save");
            BtnCancel.Text = LanguageHelper.GetTranslation("back");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetTranslation();
            BtnCancel.Click += (a, b) => { DivPayment.Visible = false;PanelGridMasuk.Visible = true; };
            BtnSave.Click +=  (a, b) =>
            {
                var payId = Convert.ToInt32(HidPaymentID.Value);
                using (var db = new smlpobDB())
                {
                    var payment = (from x in db.paymenttbls
                                   where x.paymentId == payId
                                   select x).FirstOrDefault();
                    if (payment != null)
                    {
                        var data = (from x in db.ordermastertbls
                                    where x.orderNo == payment.orderNo
                                    select x).FirstOrDefault();
                        if (data != null)
                        {
                            data.paymentStatus = Status.PaymentStatus[2];
                            data.isPaid = "1";
                            data.paymentStatus = StatusPembayaranCmb.SelectedValue.ToString();
                            data.statusType = TipePembayaranCmb.SelectedValue.ToString();
                            data.status = Status.OrderStatus[1];
                        }
                        payment.status = "Diterima";
                        db.SaveChanges();
                        PanelGridMasuk.Visible = true;
                        DivPayment.Visible = false;
                        RefreshGrid();
                        SendMailToCS(payment,data);
                    }

                }
            };
                GvData.RowDataBound += GvData_RowDataBound;
            GvData.RowCommand += GvData_RowCommand;
            if (!IsPostBack)
            {
                StatusPembayaranCmb.Items.Clear();
              
                StatusPembayaranCmb.Items.Add(new ListItem(Status.PaymentStatus[2], Status.PaymentStatus[2]));
                StatusPembayaranCmb.Items.Add(new ListItem("DP", "DP"));
                TipePembayaranCmb.Items.Clear();
                TipePembayaranCmb.Items.Add(new ListItem("Penelitian", "Penelitian"));
                TipePembayaranCmb.Items.Add(new ListItem("PNBP", "PNBP"));
                TipePembayaranCmb.Items.Add(new ListItem("Khusus", "Khusus"));

                RefreshGrid();

            }

            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Terima":
                    {
                        var payId = Convert.ToInt32(e.CommandArgument);
                        PanelGridMasuk.Visible = false;
                        DivPayment.Visible = true;
                        HidPaymentID.Value = payId.ToString();
                    }
                    break;
                case "Tolak":
                    {
                        var payId = Convert.ToInt32(e.CommandArgument);
                        using(var db = new smlpobDB())
                        {
                            var payment = (from x in db.paymenttbls
                                          where x.paymentId == payId
                                          select x).FirstOrDefault();
                            if (payment != null)
                            {
                                var data = (from x in db.ordermastertbls
                                            where x.orderNo == payment.orderNo
                                            select x).FirstOrDefault();
                                if (data != null)
                                {
                                    data.paymentStatus = Status.PaymentStatus[0];
                                }
                                payment.status = "Ditolak";
                                db.SaveChanges();
                                RefreshGrid();
                            }

                        }
                    }
                    break;
                case "Lihat":
                    var url = e.CommandArgument.ToString();
                    Response.Write("<script>window.open ('"+url+"','_blank');</script>");
                    break;
                case "Download":
                    var DownloadUrl = e.CommandArgument.ToString();
                    if (string.IsNullOrEmpty(DownloadUrl))
                    {
                        CommonWeb.Alert(this, "Tidak ada lampiran");
                       
                    }else
                        Response.Write("<script>window.open ('" + DownloadUrl + "','_blank');</script>");
                    break;
            }
        }

        void RefreshGrid(string param = "")
        {
            string verif = Status.PaymentStatus[1];
            using (var db = new smlpobDB())
            {
                var datas = from x in db.ordermastertbls.Include(c => c.customertbl)
                            join y in db.paymenttbls on x.orderNo equals y.orderNo
                            where y.status == verif
                            select new {
                                AttachmentUrl=y.attachmentUrl, paymentId = y.paymentId, orderNo = x.orderNo, customerName=x.customertbl.customerName, priceTotal = x.priceTotal, amount = y.amount
                            , accountName = y.accountName, accountNo=y.accountNo, bankName = y.bankName, Status=y.status, ImgUrl=y.paymentReceiptUrl};
                GvData.DataSource = datas.ToList() ;
                GvData.DataBind();
            }
           

            if (GvData.Rows.Count > 0)
            {
                GvData.UseAccessibleHeader = true;
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        void SendMailToCS(paymenttbl DataPayment, ordermastertbl DataOrder)
        {
            using(var db = new smlpobDB())
            {
                var datas = from x in db.employeetbls
                            where x.position == "customer service"
                            select x;
               
                var Subject = $"Order [{DataPayment.orderNo}] Telah dibayar melalui transfer";
                foreach (var item in datas)
                {
                    var Message = $"Kepada bagian pelayanan, <br/>di mohon untuk melanjutkan penerimaan sampel dari {DataPayment.name} dengan No. Order: {DataPayment.orderNo}. Jumlah sampel sebanyak {DataOrder.sampleTotal} buah untuk analisa {DataOrder.analysisType}.<br/>Terima kasih<br/>Lampiran dari customer : <a href src='{DataPayment.attachmentUrl}'>File Lampiran</a>";
                    EmailService.SendEmail(Subject, Message, item.employeeEmail, true);
                }
            }
        }
        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("customer_name");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("price_total");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("total_transfer");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("account_name");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("account_no");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("bank_name");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("status");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("payment_receipt");
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("attachment");

                e.Row.Cells[10].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool isShow = false;
                if (e.Row.Cells[7].Text == "Verifikasi") isShow = true;
                var linkBtn = e.Row.FindControl("BtnBukti") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("view");
                linkBtn = e.Row.FindControl("BtnTerima") as LinkButton;
                if (linkBtn != null)
                {
                    if (!isShow) linkBtn.Visible = false;

                    linkBtn.Text = LanguageHelper.GetTranslation("approve");
                }
                linkBtn = e.Row.FindControl("BtnTolak") as LinkButton;
                if (linkBtn != null)
                {
                    if (!isShow) linkBtn.Visible = false;

                    linkBtn.Text = LanguageHelper.GetTranslation("reject");
                }
            }
        }
    }
}