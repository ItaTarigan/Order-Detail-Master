using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Usercontrols
{
    public partial class HeaderInfo : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            LogOutBtn.Click += LogOutBtn_Click;
            if (!IsPostBack)
            {
                
                bool isLoggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
                if (isLoggedIn)
                {
                    try
                    {
                        var uname = CommonWeb.GetCurrentUser();
                        using (var db = new smlpobDB())
                        {
                            var UserFullName = (from x in db.customertbls
                                                where x.customerEmail == uname
                                                select x.customerName).FirstOrDefault();
                            if (UserFullName != null)
                            {
                                LitUserName.Text = UserFullName;
                            }
                            else
                            {
                                UserFullName = (from x in db.employeetbls
                                                where x.employeeEmail == uname
                                                select x.employeeName).FirstOrDefault();
                                LitUserName.Text = UserFullName;
                            }
                        }
                    }
                    catch
                    {
                        LitUserName.Text = "anonymous";
                    }
                }
                GetTranslation();
            }
            
        }   
        void GetTranslation()
        {
            LitWelcome.Text = LanguageHelper.GetTranslation("welcome") + ",";
            LogOutBtn.Text = LanguageHelper.GetTranslation("logout");
        }
        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/pages/public/login.aspx", false);
        }

        protected void BtnLang_Click(object sender, EventArgs e)
        {
            LanguageHelper.CurrentLanguage = (sender as LinkButton).CommandName;
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
            //GetTranslation();
        }
    }
}