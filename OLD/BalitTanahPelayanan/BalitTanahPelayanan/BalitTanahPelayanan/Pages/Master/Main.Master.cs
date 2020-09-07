using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Master
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnOut.Click += btnOut_Clicked;
            //bool IsLoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            //if (!IsLoggedIn) Response.Redirect("/Pages/Public/Login.aspx");
        }

        protected void btnOut_Clicked(object sender, EventArgs e)
        {
            Session.Abandon();
            //FormsAuthentication.SignOut();
            Response.Redirect("/Pages/Public/Login.aspx");
        }
    }
}