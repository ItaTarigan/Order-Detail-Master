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
using Microsoft.AspNet.SignalR;
using BalitTanahPelayanan.SignalR;
using System.Web.Security;

namespace BalitTanahPelayanan.Pages.Private.Manager
{
    public partial class ManagerDetailOrder : System.Web.UI.Page
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
        OrderListControls orderControls = new OrderListControls();
        EmployeeControls employeecontrols = new EmployeeControls();
        OrderSampleControls ordersamplecontrols = new OrderSampleControls();
        OrderAnalysisControls orderanalysisControls = new OrderAnalysisControls();
        string _orderno { get; set; }
        int _idpic { get; set; }

        void GetTranslation()
        {
            BtnDownload.Text = LanguageHelper.GetTranslation("downl");
            BtnDownloadLampiran.Text = LanguageHelper.GetTranslation("downl");
            GvData.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            LabelCus.Text = LanguageHelper.GetTranslation("customer_name");
            LabelKom.Text = LanguageHelper.GetTranslation("commodity");
            LabelAnalis.Text = LanguageHelper.GetTranslation("analisystype");
            LabelSample.Text = LanguageHelper.GetTranslation("sampletot");
            LabelHarga.Text = LanguageHelper.GetTranslation("price_total");
            litRincianNoPesanan.Text = LanguageHelper.GetTranslation("detail_order_no");
            litDaftarSampel.Text = LanguageHelper.GetTranslation("samplelist");
            litPicName.Text = LanguageHelper.GetTranslation("picname");
            BtnKembali.Text = LanguageHelper.GetTranslation("back");
            BtnLanjut.Text = LanguageHelper.GetTranslation("continue");
            BtnApprove.Text = LanguageHelper.GetTranslation("approve");
            BtnReject.Text = LanguageHelper.GetTranslation("reject");
            BtnTutup.Text = LanguageHelper.GetTranslation("close");
            litHasilLHP.Text = LanguageHelper.GetTranslation("result_lhp");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GvData.RowDataBound += GvData_RowDataBound;
            if (!IsPostBack)
            {
                GetTranslation();
                if (!string.IsNullOrEmpty(Request.QueryString["value"]))
                {
                    _orderno = Request.QueryString["value"];
                    FormState = Request.QueryString["State"];
                    lblorder.Text = _orderno;
                    LoadDetail();
                    RefreshGrid();
                    switch (FormState)
                    {
                        case "PesananMasuk":
                            DivPIC.Visible = true;
                            BtnLanjut.Visible = true;

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
            }
            BtnTutup.Click += BtnTutup_Click;
            GvData.RowCommand += GvData_RowCommand;
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
            if (GvParameter != null)
            {
                this.GvParameter.DataBound += (object o, EventArgs ev) =>
                {
                    if(GvParameter.HeaderRow!=null)
                    GvParameter.HeaderRow.TableSection = TableRowSection.TableHeader;

                };
                GvParameter.RowCommand += GvParameter_RowCommand;
                GvParameter.RowDataBound += GvParameter_RowDataBound;
            }
            BtnDownload.Click += BtnDownload_Click;
            BtnDownloadLampiran.Click += BtnDownloadLampiran_Click;
        }

        private void BtnDownloadLampiran_Click(object sender, EventArgs e)
        {
            if (ViewState["DownloadLampiranUrl"] != null)
            {
                Response.Redirect(ViewState["DownloadLampiranUrl"].ToString());
            }
        }

        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("count_number");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_number");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("balittanah_no");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("gps");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("landuse");
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("actions");
            }
            else if(e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkbtn = e.Row.FindControl("Lihat") as LinkButton;
                if (linkbtn != null)
                    linkbtn.Text = LanguageHelper.GetTranslation("element_code");
            }
        }
        private void GvParameter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var lht = e.Row.FindControl("lihat") as LinkButton;
                if (lht != null && e.Row.Cells[1].Text == "Menunggu")
                {
                    lht.Text = LanguageHelper.GetTranslation("downl");
                    lht.Enabled = false;
                    lht.Text = "-";
                }
            }
            else
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("test_parameter");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("testing_status");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("result");
            }
        }
        private void GvParameter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName) {
                case "DownloadParameter":
                    var urlFile = e.CommandArgument.ToString();
                    Response.Redirect(urlFile);
                    break;
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            if (ViewState["UrlLHP"] != null)
            {
                Response.Redirect(ViewState["UrlLHP"].ToString());
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
                    var listOrderAnalystDetail = orderControls.GetParameter(NoBalitTanah);
                    var data = listOrderAnalystDetail.Result;

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
            var dataOrder = ret.Result;
            //get PIC
            var myLab = CommonWeb.GetUserLab();
            var listAnalyst = employeecontrols.GetDataAnalis(myLab);
            var dataPIC = listAnalyst.Result;


            if (dataPIC != null && dataPIC.Count() > 0)
            {
                DdlPIC.DataSource = dataPIC;
                DdlPIC.DataTextField = "employeeName";
                DdlPIC.DataValueField = "employeeNo";
                DdlPIC.DataBind();
            }


            if (dataOrder != null)
            {
                ViewState["UrlLHP"] = dataOrder.LHPAttachmentUrl;
                lblcusname.Text = dataOrder.customertbl.customerName;
                lblKomoditi.Text = dataOrder.comoditytbl.comodityName;
                lblanalisis.Text = dataOrder.analysisType;
                lblSampel.Text = dataOrder.sampleTotal.ToString();
                lblTotalHarga.Text = "Rp " + dataOrder.priceTotal?.ToString("n2");
                if (!string.IsNullOrEmpty(dataOrder.CalculationFileUrl))
                {
                    ViewState["DownloadLampiranUrl"] = dataOrder.CalculationFileUrl;
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
            var ret = ordersamplecontrols.GetDataAsync(_orderno);
            var datas = ret.Result;

            GvData.DataSource = datas;
            GvData.DataBind();

            if (GvData.Rows.Count > 0)
            {
                GvData.UseAccessibleHeader = true;
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void DoUpdate()
        {
            try
            {
                string id = lblorder.Text;
                //master
                var rett = orderControls.MasterData(id);
                var datas = rett.Result;
                //detail
                var detor = orderControls.GetDetailOrder(id);
                var datadet = detor.Result;

                int _pic = Convert.ToInt32(DdlPIC.SelectedValue);
                _idpic = _pic;

                var data = new ordermastertbl
                {
                    orderNo = datas.orderNo,
                    customerNo = datas.customerNo,
                    comodityNo = datas.comodityNo,
                    analysisType = datas.analysisType,
                    sampleTotal = datas.sampleTotal,
                    priceTotal = datas.priceTotal,
                    statusType = datas.statusType,
                    status = datas.analysisType == "Kimia" ? "Batch Management":Status.OrderStatus[3],
                    paymentStatus = datas.paymentStatus,
                    ppn = datas.ppn,
                    receiptDate = datas.receiptDate,
                    isPaid = datas.isPaid,
                    paymentDate = datas.paymentDate,
                    pic = _pic,
                    isOnLab = datas.isOnLab,
                    ApprPenyelia = datas.ApprPenyelia,
                    ApprEvaluator = datas.ApprEvaluator,
                    ApprManagerTeknis = datas.ApprManagerTeknis,
                    LHPAttachmentUrl = datas.LHPAttachmentUrl,
                    LHPFileName = datas.LHPFileName,
                    EvaluationFileUrl = datas.EvaluationFileUrl,
                    EvaluationFileName = datas.EvaluationFileName,
                    creaBy = datas.creaBy,
                    creaDate = datas.creaDate,
                    modBy = datas.modBy,
                    modDate = datas.modDate
                };

                var ret = orderControls.UpdateData(id, data);

                if (ret.Result)
                {
                    foreach (var item in datadet)
                    {
                        var data2 = new orderanalysisdetailtbl
                        {
                            orderDetailNo = item.orderDetailNo,
                            orderNo = item.orderNo,
                            sampleNo = item.sampleNo,
                            elementId = item.elementId,
                            parametersNo = item.parametersNo,
                            elementValue = item.elementValue,
                            status = item.status,
                            recalculate = item.recalculate,
                            pic = _idpic,
                            fileAttachmentUrl = item.fileAttachmentUrl,
                            fileName = item.fileName,
                            LabToolAttachmentUrl = item.LabToolAttachmentUrl,
                            LabToolFileName = item.LabToolFileName,
                            creaBy = item.creaBy,
                            creaDate = item.creaDate,
                            modBy = item.modBy,
                            modDate = item.modDate
                        };
                        var ret2 = orderControls.UpdateDataDetail(item.orderDetailNo, data2);
                        if (ret2.Result)
                        {

                            string msg = "Pic Untuk No Order " + id + " telah dipilih";
                            CommonWeb.Alert(this, msg);
                            //send mail
                            using(var db = new smlpobDB())
                            {
                                var usr = db.employeetbls.Where(x => x.employeeNo == _pic).FirstOrDefault();
                               

                                if (!string.IsNullOrEmpty(usr.employeeEmail))
                                {
                                    Helpers.EmailService.SendEmail("Penugasan Lab", $"Anda mendapat tugas dari manager teknis ({CommonWeb.GetCurrentUserName()}) untuk mengerjakan order no: {datas.orderNo}", usr.employeeEmail, false);
                                    //SmsService.SendSms($"Anda mendapat tugas dari manager teknis ({CommonWeb.GetCurrentUserName()}) untuk mengerjakan order no: {datas.orderNo}", usr.employeePhone).GetAwaiter().GetResult();
                                }
                            }
                            
                           

                            Response.Redirect("../Manager/Dash_ManagerTeknis.aspx");
                        }
                        else
                        {
                            CommonWeb.Alert(this, "Gagal mengubah data");
                        }
                    }
                }
                else
                {
                    CommonWeb.Alert(this, "Gagal mengubah data");
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().ToString();
                LogHelpers.message = "Error Set PIC:" + ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();
            }
        }
        //proses ke penyelia
        protected void BtnLanjut_Click(object sender, EventArgs e)
        {
            DoUpdate();
        }

        protected void BtnKembali_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dash_ManagerTeknis.aspx");
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
                    data.status = Status.OrderStatus[7];
                    db.SaveChanges();

                    var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                    context.Clients.All.PushNotification("All", "Pesanan no " + lblorder.Text + " telah disetujui", "https://silpo.id");

                    Response.Redirect("Dash_ManagerTeknis.aspx");

                    
                    
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
                var data = (from x in db.ordermastertbls.Include(c=>c.employeetbl)
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
                        //SmsService.SendSms( $"Order No {lblorder.Text} di reject, dan perlu di hitung ulang dengan alasan {TxtKeterangan.Text}", phoneNo).GetAwaiter().GetResult();

                        Response.Redirect("Dash_ManagerTeknis.aspx");
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
    }
}