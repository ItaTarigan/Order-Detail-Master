using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Pages.Private.Manager
{
    public partial class PilihPIC : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        EmployeeControls employeecontrols = new EmployeeControls();
        OrderSampleControls ordersamplecontrols = new OrderSampleControls();
        OrderAnalysisControls orderanalysisControls = new OrderAnalysisControls();
        string _orderno { get; set; }
        int _idpic { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GvData.RowDataBound += GvData_RowDataBound;
                GvParameter.RowDataBound += GvParameter_RowDataBound;
                if (!string.IsNullOrEmpty(Request.QueryString["value"]))
                {
                    _orderno = Request.QueryString["value"];
                    lblorder.Text = _orderno;
                    LoadDetail();
                    RefreshGrid();
                    GetTranslate();
                }
            }
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
            this.GvParameter.DataBound += (object o, EventArgs ev) =>
            {
                GvParameter.HeaderRow.TableSection = TableRowSection.TableHeader;
            };

        }

        private void GvParameter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("parameter_test");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("status");
            }
        }

        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("serial_number");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_no");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("balittanah_no");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("gps");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("soil_type");
            }
        }

        private void GetTranslate()
        {
            BtnKembali.Text = LanguageHelper.GetTranslation("back");
            BtnLanjut.Text = LanguageHelper.GetTranslation("");
        }



        void LoadDetail()
        {
            //Detail
            var ret = orderControls.DetailData(_orderno);
            var dataSample = ret.Result;
            //get PIC
            var myLab = CommonWeb.GetUserLab();
            var ret2 = employeecontrols.GetDataAnalis(myLab);
            var dataPIC = ret2.Result;
            //
            var ret3 = orderanalysisControls.GetData(_orderno);
            var dataParameter = ret3.Result;

            if (dataPIC != null && dataPIC.Count() > 0)
            {
                DdlPIC.DataSource = dataPIC;
                DdlPIC.DataTextField = "employeeName";
                DdlPIC.DataValueField = "employeeNo";
                DdlPIC.DataBind();
            }

            if(dataParameter != null && dataParameter.Count() > 0)
            {
                GvParameter.DataSource = dataParameter;
                GvParameter.DataBind();
            }

            if (dataSample != null)
            {
               
                lblcusname.Text = dataSample.customertbl.customerName;
                lblKomoditi.Text = dataSample.comoditytbl.comodityName;
                lblanalisis.Text = dataSample.analysisType;
                lblSampel.Text = dataSample.sampleTotal.ToString();
                lblTotalHarga.Text = "Rp "+dataSample.priceTotal?.ToString("n2");
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
                    status = "Diproses",
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

        protected void BtnLanjut_Click(object sender, EventArgs e)
        {
            DoUpdate();
        }

        protected void BtnKembali_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Manager/Dash_ManagerTeknis.aspx");
        }
    }
}