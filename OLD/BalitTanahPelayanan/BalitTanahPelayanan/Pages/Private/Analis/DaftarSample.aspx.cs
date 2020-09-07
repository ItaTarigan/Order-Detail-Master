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
    public partial class DaftarSample : System.Web.UI.Page
    {

        static string BatchID { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BatchID = Request.QueryString["batchId"];
            GvData.RowDataBound += GvData_RowDataBound;
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(BatchID))
                {
                    GetTranslation();
                    LoadGridSample();
                }


            }
            BtnCari.Click += BtnCari_Click;
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                if (GvData.HeaderRow != null)
                    GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        private void BtnCari_Click(object sender, EventArgs e)
        {
            LoadGridSample(TxtBarcode.Text);
        }

        void LoadGridSample(string NoBalitTanah = "")
        {
            using (var db = new smlpobDB())
            {
                var myLab = CommonWeb.GetUserLab();
                var dataSample = OrderSampleControls.GetDataByStatus(Status.OrderStatus[3],myLab); //db.ordersampletbls.Include(c => c.ordermastertbl).Where(x => x.ordermastertbl.status == "Proses Lab").ToList();
                if (!string.IsNullOrEmpty(NoBalitTanah) && dataSample != null)
                {
                    dataSample = dataSample.Where(x => x.noBalittanah == NoBalitTanah).ToList();
                }
                foreach (var data in dataSample)
                {
                    if (data.isReceived == "1")
                    {
                        data.isReceived = "Sudah";
                    }
                    else
                    {
                        data.isReceived = "Belum";
                    }
                }

                GvData.DataSource = dataSample;
                GvData.DataBind();

            }

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
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_no");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("no_balittanah");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("gps_coordinates");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("land_use");
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("is_received");
                e.Row.Cells[10].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("btnLihat") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("detail");
            }
        }

        void GetTranslation()
        {
            txtdaftarsample.Text = LanguageHelper.GetTranslation("sample_list");
            GvData.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            BtnCari.Text = LanguageHelper.GetTranslation("search");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }


    }
}