 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Controllers;

namespace BalitTanahPelayanan.Pages.Private.Kasir
{
    public partial class KasirSelesai : System.Web.UI.Page
    {
        OrderMasterControls orderControls = new OrderMasterControls();

        void GetTranslation()
        {
            LitSelesai.Text = LanguageHelper.GetTranslation("title_pesanan_selesai");
            GvData.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
            btnMasuk.Text = LanguageHelper.GetTranslation("order_entry");
            btnProses.Text = LanguageHelper.GetTranslation("order_processed");
            btnSelesai.Text = LanguageHelper.GetTranslation("order_complete");
            btnVerifikasi.Text = LanguageHelper.GetTranslation("title_payment_verification");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GvData.RowDataBound += GvData_RowDataBound;
            if (!IsPostBack)
            {
                
                RefreshGrid();
            }
            GetTranslation();

            
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        void RefreshGrid(string param = "")
        {
            var ret = orderControls.GetData();
            var datas = ret.Result.Where(x =>  (x.status == Status.OrderStatus[7] || x.status == Status.OrderStatus[8]));
            GvData.DataSource = datas;
            GvData.DataBind();
            if (GvData.Rows.Count > 0)
            {
                GvData.UseAccessibleHeader = true;
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
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
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("status_type");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("btnRincian") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("detail");
            }
        }
    }
}