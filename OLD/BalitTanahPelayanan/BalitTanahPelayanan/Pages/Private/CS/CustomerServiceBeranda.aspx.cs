using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Configuration;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Pages.Private.CS
{
    public partial class CustomerServiceBeranda : System.Web.UI.Page
    {
       
        ListGridMaster listGridMaster = new ListGridMaster();
        void GetTranslation()
        {
            BtnPesananMasuk.Text = LanguageHelper.GetTranslation("order_entry");
            BtnProses.Text = LanguageHelper.GetTranslation("order_processed");
            BtnSelesai.Text = LanguageHelper.GetTranslation("order_complete");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }    

        public string FormState
        {
            get
            {
                if (ViewState["State"] == null)
                    return "PesananMasuk";
                else
                    return ViewState["State"].ToString();
            }
            set
            {
                ViewState["State"] = value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            GvData.RowCommand += GvData_RowCommand;
            GvData.RowDataBound += GvData_RowDataBound;
            if (!IsPostBack)
            {
                FormState = "PesananMasuk";
                GoSearch();
                GetTranslation();
            }
            BtnCari.Click += BtnCari_Click;
            
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                if(GvData.HeaderRow!=null)
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }
        
        private void BtnCari_Click(object sender, EventArgs e)
        {
            GoSearch();
        }

        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("customer_name");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("commodity");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("analysis_type");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("order_status");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("payment_status");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("payment_type");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //translation
                var linkBtn1 = e.Row.FindControl("BtnTerimaSampel") as Button;
                if (linkBtn1 != null)
                    linkBtn1.Text = LanguageHelper.GetTranslation("accepted_sample");

                var linkBtn2 = e.Row.FindControl("BtnCetakBarcode") as Button;
                if (linkBtn2 != null)
                    linkBtn2.Text = LanguageHelper.GetTranslation("print_barcode");

                var linkBtn3 = e.Row.FindControl("BtnProsesLab") as Button;
                if (linkBtn3 != null)
                    linkBtn3.Text = LanguageHelper.GetTranslation("process_lab");

                var linkBtn4 = e.Row.FindControl("BtnLihat") as Button;
                if (linkBtn4 != null)
                    linkBtn4.Text = LanguageHelper.GetTranslation("detail");

                var linkBtn5 = e.Row.FindControl("BtnKirimNotif") as Button;
                if (linkBtn5 != null)
                    linkBtn5.Text = LanguageHelper.GetTranslation("send_notif");

                var linkBtn6 = e.Row.FindControl("BtnSelesai") as Button;
                if (linkBtn6 != null)
                    linkBtn6.Text = LanguageHelper.GetTranslation("finish_order");
                //translation - end

                var BtnTerimaSampel = e.Row.FindControl("BtnTerimaSampel");
                var BtnCetakBarcode = e.Row.FindControl("BtnCetakBarcode");
                var BtnProsesLab = e.Row.FindControl("BtnProsesLab");
                var BtnLihat = e.Row.FindControl("BtnLihat");
                var BtnKirimNotif = e.Row.FindControl("BtnKirimNotif");
                var BtnSelesai = e.Row.FindControl("BtnSelesai");
                switch (FormState)
                {
                    case "PesananMasuk":
                        BtnTerimaSampel.Visible = true;
                        BtnCetakBarcode.Visible = true;
                        BtnProsesLab.Visible = true;
                        BtnLihat.Visible = false;
                        BtnKirimNotif.Visible = false;
                        BtnSelesai.Visible = false;
                        break;
                    case "PesananDiProses":
                        BtnTerimaSampel.Visible = false;
                        BtnCetakBarcode.Visible = false;
                        BtnProsesLab.Visible = false;
                        BtnLihat.Visible = true;
                        BtnKirimNotif.Visible = false;
                        BtnSelesai.Visible = false;
                        break;
                   
                    case "PesananSelesai":
                        BtnTerimaSampel.Visible = false;
                        BtnCetakBarcode.Visible = false;
                        BtnProsesLab.Visible = false;
                        BtnLihat.Visible = true;
                        

                        if (e.Row.Cells[4].Text == "LHP Sudah Diambil")
                        {
                            BtnKirimNotif.Visible = false;
                            BtnSelesai.Visible = false;
                        }
                        break;

                }
            }
        }

        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "lihat":
                    Response.Redirect("CustomerServiceDetail.aspx?value=" + IDS + "&State=" + FormState + "&Mode="+e.CommandName);
                    break;
                case "terima-sampel":
                    Response.Redirect("CustomerServiceDetail.aspx?value=" + IDS + "&State=" + FormState + "&Mode=" + e.CommandName);
                    break;
                case "proses-lab":
                    using(var db = new smlpobDB())
                    {
                        var valdata = (from w in db.ordersampletbls
                                       where w.orderNo == IDS
                                       select w.isReceived).FirstOrDefault();
                        if (valdata == "1")
                        {
                            var data = (from x in db.ordermastertbls
                                        where x.orderNo == IDS
                                        select x).FirstOrDefault();
                            if (data != null)
                            {
                                data.status = Status.OrderStatus[2];
                                data.isOnLab = "1";
                                db.SaveChanges();
                                GoSearch();
                                CommonWeb.Alert(this, "Data sudah diproses ke lab.");

                            }
                        }
                        else
                        {
                            CommonWeb.Alert(this, "Proses ke Lab gagal. Harap terima sampel terlebih dahulu");
                        }
                    }
                    //Response.Redirect("CustomerServiceDetail.aspx?value=" + IDS + "&State=" + FormState + "&Mode=" + e.CommandName);
                    break;
                case "kirim-notif":
                    //Send notif tuk customer
                    using (var db = new smlpobDB())
                    {
                        var data = (from x in db.ordermastertbls.Include(c=>c.customertbl)
                                    where x.orderNo == IDS
                                    select x).FirstOrDefault();
                        if (data != null)
                        {
                            if (!string.IsNullOrEmpty(data.customertbl.customerEmail))
                            {
                                EmailService.SendEmail($"LHP dengan No: {data.orderNo} Sudah Dapat Diambil di BalitTanah", $"Yth. Bpk/Ibu {data.customertbl.customerName}, <br/>LHP dengan No: {data.orderNo} Sudah Dapat Diambil di BalitTanah. Silakan kunjungi situs web kami untuk melihat status order Anda pada tautan berikut : {ConfigurationManager.AppSettings["RootWebUrl"]} <br/> Terima Kasih <br/> Hormat Kami, <br/>Balai Penelitian Tanah", data.customertbl.customerEmail, true);
                                SmsService.SendSms( $"Yth. Bpk/Ibu {data.customertbl.customerName}, <br/>LHP dengan No: {data.orderNo} Sudah Dapat Diambil di BalitTanah. Silakan kunjungi situs web kami untuk melihat status order Anda pada tautan berikut : {ConfigurationManager.AppSettings["RootWebUrl"]} <br/> Terima Kasih <br/> Hormat Kami, <br/>Balai Penelitian Tanah", data.customertbl.companyPhone).GetAwaiter().GetResult();

                                CommonWeb.Alert(this, "Notifikasi sudah dikirim ke customer.");
                            }
                          

                        }
                    }
                    break;
                case "cetak-barcode":
                    Response.Redirect("CetakBarcodeSampel.aspx?value=" + IDS + "&State=" + FormState + "&Mode=" + e.CommandName);
                    break;
                case "ambil-lhp":
                    using (var db = new smlpobDB())
                    {
                        var data = (from x in db.ordermastertbls.Include(c => c.customertbl)
                                    where x.orderNo == IDS
                                    select x).FirstOrDefault();
                        if (data != null)
                        {
                            data.status = Status.OrderStatus[8];
                            db.SaveChanges();
                            CommonWeb.Alert(this, "Update status LHP berhasil.");
                            GoSearch();
                        }
                    }
                    break;
            }
        }

        void RefreshGrid(params string[] Status)
        {
            var ret = listGridMaster.GetDataByOrderNoAndStatus(TxtBarcode.Text, Status);
            var datas = ret.Result;
            foreach (var dat in datas)
            {
                if (dat.isPaid == "1")
                {
                    dat.isPaid = "Sudah Dibayar";
                }
                else
                {
                    dat.isPaid = "Belum Dibayar";
                }
            }

            GvData.DataSource = datas;
            GvData.DataBind();


            if (GvData.Rows.Count > 0)
            {
                GvData.UseAccessibleHeader = true;
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void ActionButtonClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            FormState = btn.CommandName;
            GoSearch();
        }

        void GoSearch() {
            switch (FormState)
            {
                case "PesananMasuk":
                    LblStatus.Text = LanguageHelper.GetTranslation("order_entry");
                    RefreshGrid("Barcode Sampel");
                    break;

                case "PesananDiProses":
                    LblStatus.Text = LanguageHelper.GetTranslation("order_processed");
                    RefreshGrid("Pilih Penyelia", "Proses Lab", "Verifikasi Penyelia", "Evaluasi Hasil", "Hitung ulang", "Menunggu Approval");
                    break;
               
                case "PesananSelesai":
                    LblStatus.Text = LanguageHelper.GetTranslation("order_complete");
                    RefreshGrid("LHP Keluar", "LHP Sudah Diambil");
                    break;

                case "ValidasiQR":
                    Session["SourceUrl"] = Request.Url.PathAndQuery;
                    Response.Redirect($"/Pages/Private/Shared/ValidasiQR.aspx");
                    break;


            }
        }
    }
}