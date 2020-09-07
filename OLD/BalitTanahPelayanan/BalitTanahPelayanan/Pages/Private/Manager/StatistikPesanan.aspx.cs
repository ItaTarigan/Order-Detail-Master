using BalitTanahPelayanan.Controllers;
using System;
using BalitTanahPelayanan.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Pages.Private.Manager
{
    public partial class StatistikPesanan : System.Web.UI.Page
    {
        SampleControls sampleControls = new SampleControls();
        ListGridMaster listGridMaster = new ListGridMaster();

        void GetTranslation()
        {
            lblpenyelia.Text = LanguageHelper.GetTranslation("customer");
            lborder.Text = LanguageHelper.GetTranslation("order_list");
            lblSampel.Text = LanguageHelper.GetTranslation("sample_list");
            lblStatistik.Text = LanguageHelper.GetTranslation("order_statistik");
            BtnKembali.Text = LanguageHelper.GetTranslation("back");
            btnBalikDah.Text = LanguageHelper.GetTranslation("close");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GvCustomer.RowDataBound += GvCustomer_RowDataBound;
            GvPesanan.RowDataBound += GvPesanan_RowDataBound;
            GvData.RowDataBound += GvData_RowDataBound;
            GvData.RowCommand += GvData_RowCommand;
            GvParamuji.RowDataBound += GvParamuji_RowDataBound;
            if (!IsPostBack)
            {
                RefreshGridData();
                GetTranslation();
            }
        }

        private void GvParamuji_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("parameter_test");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("testing_status");
            }
        }

        protected void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var NoBalitTanah = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "parameterUji":
                    OrderListControls orderControls = new OrderListControls();
                    var analysisDetail = orderControls.GetParameter(NoBalitTanah);
                    var data = analysisDetail.Result;

                    GvCustomer.Visible = false;
                    lblpenyelia.Visible = false;
                    GvPesanan.Visible = false;
                    lborder.Visible = false;
                    GvData.Visible = false;
                    lblSampel.Visible = false;
                    BtnKembali.Visible = false;
                    divParamUji.Visible = true;
                    btnBalikDah.Visible = true;

                    GvParamuji.DataSource = data.ToList();
                    GvParamuji.DataBind();
                    if (GvParamuji.Rows.Count > 0)
                    {
                        GvParamuji.UseAccessibleHeader = true;
                        GvParamuji.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    break;
            }
        }
        protected void LinkButton_Click(Object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            var custNo = int.Parse(btn.CommandArgument);
            var myLab = CommonWeb.GetUserLab();
            var retPesanan = listGridMaster.GetDataByCustNo(custNo,myLab);

            var dataPesanan = retPesanan.Result;
            GvPesanan.DataSource = dataPesanan;
            GvPesanan.DataBind();
            GvPesanan.Visible = true;
            lborder.Visible = true;
            GvData.Visible = false;
            lblSampel.Visible = false;
            divParamUji.Visible = false;
            btnBalikDah.Visible = false;
        }
        protected void ViewButton_Click(Object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender);
            string orderNo = linkButton.CommandArgument;
            var retData = sampleControls.GetDataByOrderNo(orderNo);

            var dataSample = retData.Result;

            foreach (var dat in dataSample)
            {
                if (dat.isReceived == "1")
                {
                    dat.isReceived = "Sudah";
                }
                else
                {
                    dat.isReceived = "Belum";
                }
            }

            GvData.DataSource = dataSample;
            GvData.DataBind();
            GvData.Visible = true;
            lblSampel.Visible = true;
            divParamUji.Visible = false;
            btnBalikDah.Visible = false;
        }
        private void GvPesanan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("total_sample");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("actions");

            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtnView = e.Row.FindControl("btnView") as LinkButton;
                if (linkBtnView != null)
                {
                    linkBtnView.Text = LanguageHelper.GetTranslation("view");
                }
            }
        }
        private void GvCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("namee");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("lab");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("total_sample");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtnPesanan = e.Row.FindControl("btnPesanan") as LinkButton;
                if (linkBtnPesanan != null)
                {
                    linkBtnPesanan.Text = LanguageHelper.GetTranslation("order_list");
                }
            }
        }
        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_no");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("no_balittanah");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("gps");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("land_use");
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("is_received");
                e.Row.Cells[10].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkParamuji = e.Row.FindControl("btnParamUji") as LinkButton;
                if(linkParamuji != null)
                {
                    linkParamuji.Text = LanguageHelper.GetTranslation("parameter_test");
                }
            }
        }
        private void RefreshGridData()
        {
            var myLab = CommonWeb.GetUserLab();
            var retPenyelia = listGridMaster.GetDataGroupByCustomer(myLab);
            var dataPenyelia = retPenyelia.Result;
            GvCustomer.DataSource = dataPenyelia;
            GvCustomer.DataBind();

            lborder.Visible = false;
            lblSampel.Visible = false;
            GvPesanan.Visible = false;
            GvData.Visible = false;
            divParamUji.Visible = false;
            btnBalikDah.Visible = false;
        }
        protected void btnBalikManager_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Manager/Dash_ManagerTeknis.aspx");
        }

        protected void btnBalikDah_Click(object sender, EventArgs e)
        {
            GvCustomer.Visible = true;
            lblpenyelia.Visible = true;
            GvPesanan.Visible = true;
            lborder.Visible = true;
            GvData.Visible = true;
            lblSampel.Visible = true;
            BtnKembali.Visible = true;
            divParamUji.Visible = false;
            btnBalikDah.Visible = false;
        }
    }
}