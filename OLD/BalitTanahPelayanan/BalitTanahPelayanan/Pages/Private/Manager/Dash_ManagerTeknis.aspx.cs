using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class Dash_ManagerTeknis : System.Web.UI.Page
    {
        void Translate()
        {
            GvData.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            BtnPesananMasuk.Text = LanguageHelper.GetTranslation("choose_pic");
            BtnProses.Text = LanguageHelper.GetTranslation("order_processed");
            BtnApproval.Text = LanguageHelper.GetTranslation("appr_order");
            BtnSelesai.Text = LanguageHelper.GetTranslation("order_complete");
            BtnStatistik.Text = LanguageHelper.GetTranslation("order_statistik");
            BtnBoardTugas.Text = LanguageHelper.GetTranslation("Board");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
            switch (FormState)
            {
                case "PesananMasuk":
                    LblStatus.Text = LanguageHelper.GetTranslation("order_new");
                   
                    break;
                case "PesananDiProses":
                    LblStatus.Text = LanguageHelper.GetTranslation("order_processed");
                   
                    break;
                case "PesananApproval":
                    LblStatus.Text = LanguageHelper.GetTranslation("appr_order");
                   
                    break;
                case "PesananSelesai":
                    LblStatus.Text = LanguageHelper.GetTranslation("order_complete");
                    
                    break;
            }
        }

        ListGridMaster listGridMaster = new ListGridMaster();
        public string FormState
        {
            get
            {
                if (ViewState["State"] == null)
                    return "";
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
            GvData.RowDataBound += GvData_RowDataBound;
            if (!IsPostBack)
            {
                FormState = "PesananMasuk";
                RefreshGrid("Pilih Penyelia");
                Translate();
            }

            GvData.RowCommand += GvData_RowCommand;
            
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                if(GvData.HeaderRow!=null)
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
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
                var linkbtn = e.Row.FindControl("BtnRincian") as Button;
                if (linkbtn != null)
                    linkbtn.Text = LanguageHelper.GetTranslation("detail");
                var PICBtn = e.Row.FindControl("BtnPilihPIC") as Button;
                if (PICBtn != null)
                    PICBtn.Text = LanguageHelper.GetTranslation("choose_pic");
                var BtnDown = e.Row.FindControl("BtnDownload") as Button;
                if (BtnDown != null)
                    BtnDown.Text = LanguageHelper.GetTranslation("downl");
                var Apprbtn = e.Row.FindControl("BtnApproval") as Button;
                if (Apprbtn != null)
                    Apprbtn.Text = LanguageHelper.GetTranslation("appr_order");

                var btnPIC = e.Row.FindControl("BtnPilihPIC");
                var btnRincian = e.Row.FindControl("BtnRincian");
                var btnDownload = e.Row.FindControl("BtnDownload");
                var btnApproval = e.Row.FindControl("BtnApproval");
                switch (FormState)
                {
                    case "PesananMasuk":
                        //LblStatus.Text = LanguageHelper.GetTranslation("order_new");
                        btnPIC.Visible = true;
                        btnRincian.Visible = false;
                        btnDownload.Visible = false;
                        btnApproval.Visible = false;
                        break;
                    case "PesananDiProses":
                        //LblStatus.Text = LanguageHelper.GetTranslation("order_processed");
                        btnPIC.Visible = false;
                        btnRincian.Visible = true;
                        btnDownload.Visible = false;
                        btnApproval.Visible = false;
                        break;
                    case "PesananApproval":
                        //LblStatus.Text = LanguageHelper.GetTranslation("appr_order");
                        btnPIC.Visible = false;
                        btnRincian.Visible = false;
                        btnDownload.Visible = false;
                        btnApproval.Visible = true;
                        break;
                    case "PesananSelesai":
                        //LblStatus.Text = LanguageHelper.GetTranslation("order_complete");
                        btnPIC.Visible = false;
                        btnRincian.Visible = true;
                        btnDownload.Visible = true;
                        btnApproval.Visible = false;
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
                    Response.Redirect("ManagerDetailOrder.aspx?value=" + IDS+"&State="+FormState);
                    break;
                case "rincian":
                    Response.Redirect("ManagerDetailOrder.aspx?value=" + IDS + "&State=" + FormState);
                    break;
                case "download":
                    using(var db = new smlpobDB())
                    {
                        var data = (from x in db.ordermastertbls where x.orderNo == IDS select x).FirstOrDefault();
                        if (data != null && !string.IsNullOrEmpty(data.LHPAttachmentUrl))
                        {
                            Response.Redirect(data.LHPAttachmentUrl);
                        }
                        else
                        {
                            CommonWeb.Alert(this, "File LHP tidak ditemukan.");
                        }
                    }
                  
                    break;
                case "approval":
                    Response.Redirect("ManagerDetailOrder.aspx?value=" + IDS + "&State=" + FormState);
                    break;
            }
        }

        void RefreshGrid(params string[] Status)
        {
            var myLab = CommonWeb.GetUserLab();
            var ret = listGridMaster.GetDataByStatus(Status, myLab);
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
            switch (btn.CommandName)
            {
                case "PesananMasuk":
                    LblStatus.Text = "Pesanan Masuk";
                    RefreshGrid("Pilih Penyelia");
                    
                    break;
                case "PesananDiProses":
                    LblStatus.Text = "Pesanan di Proses";
                    RefreshGrid("Batch Management","Proses Lab","Verifikasi Penyelia","Evaluasi Hasil","Hitung ulang");
                    break;
                case "PesananApproval":
                    LblStatus.Text = "Approval Pesanan";
                    RefreshGrid("Menunggu Approval");
                    break;
                case "PesananSelesai":
                    LblStatus.Text = "Pesanan Selesai";
                    RefreshGrid("LHP Keluar","LHP Sudah Diambil");
                    break;
                case "StatistikPesanan":
                    Response.Redirect("StatistikPesanan.aspx");
                    break;
                case "BoardTugas":
                    Response.Redirect("/Pages/Private/BoardTugas.aspx");
                    break;
            }
            Translate();
        }

        //private void GvData_RowDataBound1(object sender, GridViewRowEventArgs e)
        //{
        //    if(e.Row.RowType == DataControlRowType.Header)
        //    {
        //        e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
        //        e.Row.Cells[1].Text = LanguageHelper.GetTranslation("customer_name");
        //        e.Row.Cells[2].Text = LanguageHelper.GetTranslation("commodity");
        //        e.Row.Cells[3].Text = LanguageHelper.GetTranslation("analysis_type");
        //        e.Row.Cells[4].Text = LanguageHelper.GetTranslation("order_status");
        //        e.Row.Cells[5].Text = LanguageHelper.GetTranslation("payment_status");
        //        e.Row.Cells[6].Text = LanguageHelper.GetTranslation("payment_type");
        //        e.Row.Cells[7].Text = LanguageHelper.GetTranslation("actions");
        //    }
        //    else if(e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        var linkbtn = e.Row.FindControl("BtnRincian") as LinkButton;
        //        if (linkbtn != null)
        //            linkbtn.Text = LanguageHelper.GetTranslation("detail");
        //    }
        //}
    }
}