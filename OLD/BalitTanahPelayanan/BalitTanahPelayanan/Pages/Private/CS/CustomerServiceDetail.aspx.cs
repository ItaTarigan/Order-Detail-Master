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
namespace BalitTanahPelayanan.Pages.Private.CS
{
    public partial class CustomerServiceDetail : System.Web.UI.Page
    {
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
        public string ModeState
        {
            get
            {
                if (ViewState["Mode"] == null)
                    return "";
                else
                    return ViewState["Mode"].ToString();
            }
            set
            {
                ViewState["Mode"] = value;
            }
        }
        OrderListControls orderControls = new OrderListControls();
        EmployeeControls employeecontrols = new EmployeeControls();
        OrderSampleControls ordersamplecontrols = new OrderSampleControls();
        OrderAnalysisControls orderanalysisControls = new OrderAnalysisControls();
        string _orderno { get; set; }
        int _idpic { get; set; }

        void GetTranslation()
        {
            BtnKembali.Text = LanguageHelper.GetTranslation("back");
            BtnSimpan.Text = LanguageHelper.GetTranslation("save");
            BtnApprove.Text = LanguageHelper.GetTranslation("order_completed");
            BtnReject.Text = LanguageHelper.GetTranslation("order_completed");
            name.Text = LanguageHelper.GetTranslation("name");
            komoditas.Text = LanguageHelper.GetTranslation("commodity1");
            analisystype.Text = LanguageHelper.GetTranslation("analisystype");
            sampletotal.Text = LanguageHelper.GetTranslation("sampletot");
            pricetotal.Text = LanguageHelper.GetTranslation("pricetot");
            lhpresult.Text = LanguageHelper.GetTranslation("lhpresult") ;
            samplelist.Text = LanguageHelper.GetTranslation("samplelist");
            BtnTutup.Text = LanguageHelper.GetTranslation("close");
            litRincianNoPesanan.Text = LanguageHelper.GetTranslation("detail_order_no");
            BtnDownload.Text = LanguageHelper.GetTranslation("downl");
            BtnDownloadLampiran.Text = LanguageHelper.GetTranslation("downl");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GvData.RowDataBound += GvData_RowDataBound;
            
            BtnDownload.Click += BtnDownload_Click;
            BtnDownloadLampiran.Click += BtnDownloadLampiran_Click;
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["value"]))
                {
                    _orderno = Request.QueryString["value"];
                    FormState = Request.QueryString["State"];
                    var Mode = Request.QueryString["Mode"];
                    ModeState = Mode;
                    switch (Mode)
                    {
                        case "lihat":
                            BtnSimpan.Visible = false;
                            break;
                    }
                    lblorder.Text = _orderno;
                    LoadDetail();
                    RefreshGrid();
                    switch (FormState)
                    {
                        case "PesananMasuk":
                            
                            BtnSimpan.Visible = true;

                            break;
                        case "PesananDiProses":
                            //do nothing
                            break;
                        case "PesananApproval":
                            DivRow5.Visible = true;
                            DivDownload.Visible = true;
                            DivDownloadLampiran.Visible = true;
                            BtnApprove.Visible = true;
                            BtnReject.Visible = true;
                            break;
                        case "PesananSelesai":
                            DivDownload.Visible = true;
                            DivDownloadLampiran.Visible = true;
                            break;
                    }
                }
                GetTranslation();
            }
            BtnTutup.Click += BtnTutup_Click;
           
            GvData.RowCommand += GvData_RowCommand;
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                if(GvData.HeaderRow!=null)
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
            if (GvParameter != null)
            {
                this.GvParameter.DataBound += (object o, EventArgs ev) =>
                {
                    if (GvParameter.HeaderRow != null)
                        GvParameter.HeaderRow.TableSection = TableRowSection.TableHeader;

                };
                GvParameter.RowDataBound += GvParameter_RowDataBound;
                GvParameter.RowCommand += GvParameter_RowCommand;
            }
        }

        private void BtnDownloadLampiran_Click(object sender, EventArgs e)
        {
            if (ViewState["DownloadLampiranUrl"] != null)
            {
                Response.Redirect(ViewState["DownloadLampiranUrl"].ToString());
            }
        }

        private void GvParameter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DownloadParameter":
                    var urlFile = e.CommandArgument.ToString();
                    Response.Redirect(urlFile);
                    break;
            }
        }

        private void GvParameter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var lht = e.Row.FindControl("lihat") as LinkButton;

                if (lht != null) {
                    lht.Text = LanguageHelper.GetTranslation("downl");
                    if (e.Row.Cells[1].Text == "Menunggu")
                    {

                        lht.Enabled = false;
                        lht.Text = "-";
                    }
                }
                
            }else
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("test_parameter");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("testing_status");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("result");
            }
            
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            if (ViewState["LHPUrl"] != null)
            {
                Response.Redirect(ViewState["LHPUrl"].ToString());
            }
        }

        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var HidReceived = (e.Row.FindControl("HidReceived") as HiddenField).Value;
                var chk = e.Row.FindControl("ChkReceived") as CheckBox;
                var lbProgress = e.Row.FindControl("LblProgress") as Label;
                if (chk != null)
                {
                    chk.Checked = HidReceived == "1" ? true : false;
                    if (ModeState == "lihat")
                        chk.Enabled = false;
                }
                //mapping nobalittanah to progress
                var NoBalitTanah = e.Row.Cells[2].Text;
                if (ViewState["Progress"] != null)
                {
                    var dict = ViewState["Progress"] as Dictionary<string, double>;
                    if (dict != null && dict.ContainsKey(NoBalitTanah))
                    {
                        lbProgress.Text = $" {dict[NoBalitTanah].ToString("n2")} %";
                    }
                }
                //translate
                var lihatBtn = e.Row.FindControl("Lihat") as LinkButton;
                if (lihatBtn != null)
                    lihatBtn.Text = LanguageHelper.GetTranslation("test_parameter");
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                var chk = e.Row.FindControl("ChkReceivedHeader") as CheckBox;
                if (ModeState == "lihat")
                    chk.Enabled = false;

                //translate

                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("count_number");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_code");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("balittanah_no");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("gps");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("landuse");
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("progress");
                e.Row.Cells[10].Text = LanguageHelper.GetTranslation("is_received");
                e.Row.Cells[11].Text = LanguageHelper.GetTranslation("actions");

            }
        }

        private void BtnTutup_Click(object sender, EventArgs e)
        {
            DivRow7.Visible = false;
            DivRow8.Visible = false;

            DivRow1.Visible = true;
            DivRow2.Visible = true;
            DivRow3.Visible = true;
            DivRow4.Visible = true;

            DivRow6.Visible = true;

            switch (FormState)
            {
                case "PesananMasuk":

                    break;
                case "PesananDiProses":
                    //do nothing
                    break;
                case "PesananApproval":
                    DivRow5.Visible = true;

                    break;
                case "PesananSelesai":

                    break;
            }
        }

        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var NoBalitTanah = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "DetailorderList":
                    OrderListControls orderControls = new OrderListControls();
                    var ret = orderControls.GetParameter(NoBalitTanah);
                    var data = ret.Result;

                    DivRow7.Visible = true;
                    DivRow8.Visible = true;

                    DivRow1.Visible = false;
                    DivRow2.Visible = false;
                    DivRow3.Visible = false;
                    DivRow4.Visible = false;
                    DivRow5.Visible = false;
                    DivRow6.Visible = false;

                    GvParameter.DataSource = data.ToList();
                    GvParameter.DataBind();
                    if (GvParameter.Rows.Count > 0)
                    {
                        GvParameter.UseAccessibleHeader = true;
                        GvParameter.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }

                    break;
            }
        }

        void LoadDetail()
        {
            //Detail
            var ret = orderControls.DetailData(_orderno);
            var dataSample = ret.Result;
            

            if (dataSample != null)
            {
                ViewState["LHPUrl"] = dataSample.LHPAttachmentUrl;
                lblcusname.Text = dataSample.customertbl.customerName;
                lblKomoditi.Text = dataSample.comoditytbl.comodityName;
                lblanalisis.Text = dataSample.analysisType;
                lblSampel.Text = dataSample.sampleTotal.ToString();
                lblTotalHarga.Text = "Rp " + dataSample.priceTotal?.ToString("n2");
                if (!string.IsNullOrEmpty(dataSample.CalculationFileUrl))
                {
                    ViewState["DownloadLampiranUrl"] = dataSample.CalculationFileUrl;
                    DivDownloadLampiran.Visible = true;
                    
                }
                else
                {
                    DivDownloadLampiran.Visible = false;
                }
            }
        }



        void RefreshGrid()
        {
            Dictionary<string, double> Progress = new Dictionary<string, double>(); 
            var ret = ordersamplecontrols.GetDataAsync(_orderno);
            var datas = ret.Result;
            foreach (var item in datas)
            {
                using (var db = new smlpobDB())
                {
                    var itemProgress = (from x in db.orderanalysisdetailtbls
                                        where x.orderNo == lblorder.Text && x.sampleNo == item.noBalittanah
                                        select x).ToList();
                    if (itemProgress != null)
                    {
                        var total = (double)itemProgress.Count(x => x.status == "Diproses");
                        total = (total / itemProgress.Count) * 100;
                        Progress.Add(item.noBalittanah, total);
                    }
                }
            }
            ViewState["Progress"] = Progress;
            GvData.DataSource = datas;
            GvData.DataBind();
          
            if (GvData.Rows.Count > 0)
            {
                GvData.UseAccessibleHeader = true;
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void ChangeReceiveStatus()
        {
            try
            {
                bool IsSucceed = false;
                using (var db = new smlpobDB())
                {
                    foreach (GridViewRow dr in GvData.Rows)
                    {
                        var NoBalitTanah = dr.Cells[2].Text.Trim();
                        var item = db.ordersampletbls.Where(x => x.noBalittanah == NoBalitTanah && x.orderNo == lblorder.Text).FirstOrDefault();
                        var chkVal = (dr.FindControl("ChkReceived") as CheckBox).Checked;
                        if (item != null)
                        {
                            item.isReceived = chkVal ? "1" : "0";
                            db.SaveChanges();
                        }
                    }
                   
                    IsSucceed = true;
                }
                if (IsSucceed)
                {
                    CommonWeb.Alert(this, "Perubahan status penerimaan sampel berhasil.");
                    Response.Redirect("CustomerServiceBeranda.aspx");
                }
                else
                {
                    CommonWeb.Alert(this, "Gagal mengubah status penerimaan sampel");
                }


            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().ToString();
                LogHelpers.message = "Error Set Penerimaan Sampel:" + ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();
            }
        }
        //proses ke penyelia
        protected void BtnSimpan_Click(object sender, EventArgs e)
        {
            ChangeReceiveStatus();
        }

        protected void BtnKembali_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerServiceBeranda.aspx");
        }

        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            using (var db = new smlpobDB())
            {
                var data = (from x in db.ordermastertbls
                            where x.orderNo == lblorder.Text
                            select x).FirstOrDefault();
                if (data != null)
                {
                    data.status = "LHP Keluar";
                    db.SaveChanges();
                    Response.Redirect("CustomerServiceBeranda.aspx");
                }
                else
                {
                    CommonWeb.Alert(this, "Gagal approve, terjadi kesalahan system.");
                }
            }

        }
        protected void BtnReject_Click(object sender, EventArgs e)
        {
            using (var db = new smlpobDB())
            {
                var data = (from x in db.ordermastertbls.Include(c => c.employeetbl)
                            where x.orderNo == lblorder.Text
                            select x).FirstOrDefault();
                if (data != null)
                {
                    data.status = "Hitung ulang";
                    db.SaveChanges();
                    //send to penyelia
                    var email = data.employeetbl.employeeEmail;
                    //var phoneNo = data.employeetbl.employeePhone;
                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(TxtKeterangan.Text))
                    {
                        EmailService.SendEmail("Order No:" + lblorder.Text + " di Reject oleh Manager Teknis", $"Order No {lblorder.Text} di reject, dan perlu di hitung ulang dengan alasan {TxtKeterangan.Text}", email, true);
                        //SmsService.SendSms( $"Order No {lblorder.Text} di reject, dan perlu di hitung ulang dengan alasan {TxtKeterangan.Text}", PhoneNo).GetAwaiter().GetResult();

                    }
                    else
                        CommonWeb.Alert(this, "Mohon isi keterangan.");
                }
                else
                {
                    CommonWeb.Alert(this, "Gagal reject, terjadi kesalahan system.");
                }
            }
        }

        protected void ChkReceivedHeader_CheckedChanged(object sender, EventArgs e)
        {
            var Checked = (sender as CheckBox).Checked;
            foreach(GridViewRow dr in GvData.Rows)
            {
                var chk = dr.FindControl("ChkReceived") as CheckBox;
                if (chk!=null){
                    chk.Checked = Checked;
                }
            }
        }
    }
}