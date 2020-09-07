using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Master
{
    public partial class Analis : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
                bool isLoggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
                if (!isLoggedIn)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    Response.Redirect("/pages/public/login.aspx?ReturnUrl=" + url);
                }
                
            
        }
    }
}