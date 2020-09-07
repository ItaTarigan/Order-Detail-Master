using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;

namespace BalitTanahPelayanan.Pages.Private.Analis
{
    public partial class AnalisBerandaNonBatch : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadGridSample();

            }
            BtnCari.Click += BtnCari_Click;
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                if(GvData.Rows.Count>0)
                    GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        private void BtnCari_Click(object sender, EventArgs e)
        {
            LoadGridSample(TxtBarcode.Text);
        }

        void LoadGridSample(string NoBalitTanah = "")
        {
            var myLab = CommonWeb.GetUserLab();
            var dataSample =  OrderSampleControls.GetDataByStatus(Status.OrderStatus[3], myLab);
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

            

            if (GvData.Rows.Count > 0)
            {
                GvData.UseAccessibleHeader = true;
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }



    }
}