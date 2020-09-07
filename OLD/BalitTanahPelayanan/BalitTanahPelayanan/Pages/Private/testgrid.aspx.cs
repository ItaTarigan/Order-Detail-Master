using BalitTanahPelayanan.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class testgrid : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        protected void Page_Load(object sender, EventArgs e)
        {
            var datas = orderControls.GetAllMasterOrder();
            //var datas = ret.res;
            if (datas != null)
            {
                GridView1.DataSource = datas;
                GridView1.DataBind();
            }
        }
    }
}