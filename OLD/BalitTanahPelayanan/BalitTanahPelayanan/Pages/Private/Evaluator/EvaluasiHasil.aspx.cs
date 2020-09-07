using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private.Evaluator
{
    public partial class EvaluasiHasil : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridvData.RowDataBound += GridData_RowDataBound;
            if (!IsPostBack)
            {
                RefreshGrid();
                GetTranslation();
            }
            GridvData.RowCommand += GridvData_RowCommand;
            this.GridvData.DataBound += (object o, EventArgs ev) =>
            {
                GridvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };

        }
        private void GridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("customer_name");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("commodity");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("type_analyst");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("order_status");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("payment_status");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("payment_type");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("actions");

            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("Lihat") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("detail");
            }
        }


        private void GridvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "lihatOrderList":
                    Response.Redirect("EvaluasiHasilDetail.aspx?orderNo=" + IDS );
                    break;
            }
        }

        private void RefreshGrid()
        {
            var myLab = CommonWeb.GetUserLab();
            var ret = orderControls.GetData(myLab);
            var datas = ret.Result;
            GridvData.DataSource = datas;
            GridvData.DataBind();


            if (GridvData.Rows.Count > 0)
            {
                GridvData.UseAccessibleHeader = true;
                GridvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        void GetTranslation()
        {
            txtevaluasihasil.Text = LanguageHelper.GetTranslation("evaluation_of_results");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }


    }
}