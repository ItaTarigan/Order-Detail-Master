using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private.Penyelia
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        string id { get; set; }
        enum ModeForm { ViewData, DetailData, UpdateData }

        void GetTranslation()
        {
            LblStatus.Text = LanguageHelper.GetTranslation("order_list");
            BtnFilterProses.Text = LanguageHelper.GetTranslation("order_list");
            BtnFilterSelesai.Text = LanguageHelper.GetTranslation("order_complete");
            BtnFilterBatch.Text = LanguageHelper.GetTranslation("batch");
            BtnNewBatch.Text = LanguageHelper.GetTranslation("new_batch");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridvData.RowDataBound += GridData_RowDataBound;
            GvBatch.RowDataBound += GvBatch_RowDataBound;
            if (!IsPostBack)
            {
                Session["Filter"] = "Filter1";

                

                RefreshGrid();
                GetTranslation();

            }
            BtnNewBatch.Click += (a, b) => {
                Response.Redirect("BuatBatch.aspx?Filter=" + Session["Filter"].ToString());
            };
            BtnFilterProses.Click += Filter_Click;
            BtnFilterSelesai.Click += Filter_Click;
            BtnFilterBatch.Click+= Filter_Click;
            GridvData.RowCommand += GridvData_RowCommand;

            GvBatch.RowCommand += GridBatch_RowCommand;
            GridvData.DataBound += (object o, EventArgs ev) =>
            {
                if (GridvData.HeaderRow != null)
                    GridvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
            GvBatch.DataBound += (object o, EventArgs ev) =>
            {
                if (GvBatch.HeaderRow != null)
                    GvBatch.HeaderRow.TableSection = TableRowSection.TableHeader;
            };

        }


        private void GridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("batch");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("customer_name");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("commodity");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("analysis_type");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("total_sample");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("order_status");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("actions");

            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var lihatOrderList = e.Row.FindControl("Lihat") as LinkButton;
                if (lihatOrderList != null)
                    lihatOrderList.Text = LanguageHelper.GetTranslation("detail");
            }
        }

        private void GvBatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("batch_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("PIC_Analis");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("status");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("Lihat") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("detail");
            }
        }


        private void Filter_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var Cmd = btn.CommandName;
            RefreshGrid(Cmd);
            switch (Cmd)
            {
                case "Filter1":
                    SetPanelVisibility(1);
                    LblStatus.Text = LanguageHelper.GetTranslation("order_list");
                    //BtnFilterProses.Font.Underline = true;
                    //BtnFilterSelesai.Font.Underline = false;
                    break;
                case "Filter2":
                    SetPanelVisibility(1);
                    LblStatus.Text = LanguageHelper.GetTranslation("order_complete");
                    //BtnFilterProses.Font.Underline = false;
                    //BtnFilterSelesai.Font.Underline = true;
                    break;
                case "Filter3":
                    SetPanelVisibility(2);
                    LblStatus.Text = LanguageHelper.GetTranslation("batch");
                    //BtnFilterProses.Font.Underline = false;
                    //BtnFilterSelesai.Font.Underline = true;
                    break;
            }
        }
        void SetPanelVisibility(int TypeView)
        {
            switch (TypeView)
            {
                case 1:
                    PanelOrder.Visible = true;
                    PanelBatch.Visible = false;
                    PanelBatch2.Visible = false;
                    break;
                case 2:
                    PanelOrder.Visible = false;
                    PanelBatch.Visible = true;
                    PanelBatch2.Visible = true;
                    break;
            }
           
        }
        private void GridvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "lihatOrderList":
                    using(var db = new smlpobDB())
                    {
                        var selOrder = (from x in db.ordermastertbls
                                   where x.orderNo == IDS
                                   select x).FirstOrDefault();
                        if (selOrder != null)
                        {
                            if(selOrder.analysisType=="Kimia")
                                 Response.Redirect("Rincian.aspx?orderNo=" + IDS + "&Filter=" + Session["Filter"].ToString());
                            else
                                Response.Redirect("RincianNonBatch.aspx?orderNo=" + IDS + "&Filter=" + Session["Filter"].ToString());
                        }
                    }
                    
                    break;
               
            }
        }
        private void GridBatch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
              
                case "lihatBatch":
                    Response.Redirect("BuatBatch.aspx?batchId=" + IDS + "&Filter=" + Session["Filter"].ToString());
                    break;
            }
        }

        private async void RefreshGrid(string Filter = "Filter1")
        {
            Session["Filter"] = Filter;
            var myLab = CommonWeb.GetUserLab();
            if (Filter == "Filter1")
            {
                
                var ret = await orderControls.GetDataPenyelia(myLab);
                var datas = ret;
                if (datas != null)
                {
                    GridvData.DataSource = datas;
                    GridvData.DataBind();
                }

            }
            else if (Filter == "Filter2")
            {
                var ret = await orderControls.GetDataSelesai(myLab);
                var datas = ret;
                if (datas != null)
                {
                    GridvData.DataSource = datas;
                    GridvData.DataBind();
                }
            }
            else if (Filter == "Filter3")
            {
                var ret = await orderControls.GetBatchData();
                var datas = ret;
                if (datas != null)
                {
                    GvBatch.DataSource = datas;
                    GvBatch.DataBind();
                }
            }

            if (GridvData.Rows.Count > 0 && (Filter == "Filter1" || Filter == "Filter2"))
            {
                GridvData.UseAccessibleHeader = true;
                GridvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else if (GvBatch.Rows.Count > 0 && Filter == "Filter3")
            {
                GvBatch.UseAccessibleHeader = true;
                GvBatch.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


    }
}