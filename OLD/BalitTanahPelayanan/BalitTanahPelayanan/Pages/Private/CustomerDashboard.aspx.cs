using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class CustomerDashboard : System.Web.UI.Page
    {
        ListGridMaster listGridMaster = new ListGridMaster();
        OrderMasterControls ordermastercontrol = new OrderMasterControls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();

            }

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
                    Response.Redirect("../CustomerRincian.aspx?value=" + IDS);
                    break;
            }
        }

        void RefreshGrid()
        {
            var ret = ordermastercontrol.GetData();
            var datas = ret.Result;

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
