using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Usercontrols
{
    public partial class AuthChecker : System.Web.UI.UserControl
    {
        public string Roles { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsAuthorized())
                {
                    CommonWeb.Alert(this.Parent.Page, "Anda tidak memiliki akses ke halaman ini.");
                    Response.Redirect("/pages/public/NotAuthorized.aspx");
                }
            }
        }

        bool IsAuthorized()
        {
            if (!string.IsNullOrEmpty(Roles))
            {
               
                using (var db = new smlpobDB())
                {
                    var uname = CommonWeb.GetCurrentUser();
                    var MyRole = (from x in db.accounttbls
                                 where x.username == uname
                                 select x).ToList();
                    if (MyRole != null)
                    {
                        foreach (var item in Roles.Split(';'))
                        {
                            foreach(var my in MyRole)
                            {
                                if (item == my.roleName)
                                    return true;
                            }
                        }
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}