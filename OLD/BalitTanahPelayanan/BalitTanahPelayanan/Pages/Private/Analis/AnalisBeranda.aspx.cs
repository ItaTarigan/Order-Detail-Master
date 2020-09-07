using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Controllers;

namespace BalitTanahPelayanan.Pages.Private.Analis
{
    public partial class AnalisBeranda : System.Web.UI.Page
    {

        OrderListControls orderControls = new OrderListControls();
        protected void Page_Load(object sender, EventArgs e)
        {
            GvBatch.RowDataBound += GvBatch_RowDataBound;
            GvBatch.RowCommand += GridBatch_RowCommand;
           
            if (!IsPostBack)
            {
                GetTranslation();
                LoadGridBatch();
              
            }
            GvBatch.DataBound += (object o, EventArgs ev) =>
            {
                if (GvBatch.HeaderRow != null)
                    GvBatch.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }
        private void GridBatch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {

                case "lihatBatch":
                    Response.Redirect("DaftarOrder.aspx?batchId=" + IDS );
                    break;
            }
        }
        async void LoadGridBatch(string NoBalitTanah="")
        {
            var empNo = CommonWeb.GetCurrentEmployeeNo();
            var ret = await orderControls.GetBatchDataByPIC(empNo);
            var datas = ret;
            if (datas != null)
            {
                GvBatch.DataSource = datas;
                GvBatch.DataBind();
            }

            if (GvBatch.Rows.Count > 0)
            {
                GvBatch.UseAccessibleHeader = true;
                GvBatch.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        void GetTranslation()
        {
            txtdaftarbatch.Text = LanguageHelper.GetTranslation("batch_list");
            GvBatch.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }
        private void GvBatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
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
    }
}