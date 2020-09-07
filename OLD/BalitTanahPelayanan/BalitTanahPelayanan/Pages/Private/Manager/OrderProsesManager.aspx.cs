using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class OrderProsesManager : System.Web.UI.Page
    {
        string rCurrentUser = "";
        ListGridMaster listGridMaster = new ListGridMaster();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                RefreshGrid();
            }

            GvData.RowCommand += GvData_RowCommand;
            GvData.RowCommand += GvData_RowCommand;
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "lihat":
                    Response.Redirect("../Manager/PilihDetail.aspx?value=" + IDS);
                    break;
            }
        }

        void RefreshGrid(string param = "")
        {
            var myLab = CommonWeb.GetUserLab();
            var ret = listGridMaster.GetDataProses(myLab);
            var datas = ret.Result;
            foreach (var dat in datas)
            {
                if (dat.isPaid == "1")
                {
                    dat.isPaid = "Sudah Dibayar";
                }
                else
                {
                    dat.isPaid = "Belum Dibayar";
                }
            }

            GvData.DataSource = datas;
            GvData.DataBind();


            if (GvData.Rows.Count > 0)
            {
                GvData.UseAccessibleHeader = true;
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}