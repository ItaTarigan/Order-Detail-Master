using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Public
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(100/Convert.ToInt32("0"));
            btnLogin.Click += btnLogin_Click;
            if (!Page.IsPostBack)
            {
                var isTouch = Request.QueryString["touch"];
                if (!string.IsNullOrEmpty(isTouch) && isTouch == "1"){
                    Session["Touch"] = true;
                }

                //Membership.DeleteUser("mifmasterz@gmail.com");
                //Membership.DeleteUser("mifmasterz@outlook.com");
                //Membership.DeleteUser("mifmasterz@yahoo.com");
                /*
                var users = Membership.FindUsersByEmail("mifmasterz@gmail.com");
                foreach (MembershipUser user in users)
                {
                    user.IsApproved = true;
                    user.UnlockUser();
                    //Membership.DeleteUser(user);

                }*/

                LanguageHelper.CurrentLanguage = "en";
                txtUsername.Attributes.Add("autocomplete", "off");
            }
            //Test();
        }

        async void Test()
        {
            var xx = await SmsService.SendSms($" { System.Configuration.ConfigurationManager.AppSettings["RootWebUrl"]}/Pages/Public/Activation.aspx?userId=mifmasterz@yahoo.com", "08174810345");
        }
        /*
        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server.
            Exception exc = Server.GetLastError();

            // Handle specific exception.
            if (exc is InvalidOperationException)
            {
                // Pass the error on to the error page.
                Server.Transfer("/Pages/Public/Error/Error.aspx?handler=Page_Error%20-%20Default.aspx",
                    true);
            }
        }*/
    
    protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtUsername.Value) || string.IsNullOrEmpty(txtPassword.Value))
                {
                    TxtError.Text = "Silakan masukan username dan password";
                    DivError.Visible = true;
                    return;
                }
                MembershipUser user = Membership.GetUser(txtUsername.Value);
               
                if (Membership.ValidateUser(txtUsername.Value, txtPassword.Value))
                {
                    smlpobDB db = new smlpobDB();
                    var data = (from x in db.accounttbls
                                where x.username == txtUsername.Value
                                select x).FirstOrDefault();

                    if (data != null && !string.IsNullOrEmpty(data.isEmailVerified) && data.isEmailVerified == "0")
                    {
                     
                        TxtError.Text = "User Anda belum di aktivasi, silahkan Cek E-mail atau sms inbox Anda untuk melakukan aktivasi.";
                        DivError.Visible = true;
                        return;

                    }

                    Session["pelanggan"] = User.Identity.Name;                    
                    FormsAuthentication.RedirectFromLoginPage(txtUsername.Value, cbremember.Checked);

                }
                else
                {
                    TxtError.Text = "Login gagal, silakan ketik username dan password yang benar.";
                    DivError.Visible = true;
                }
            }
            catch(Exception ex)
            {
                LogHelpers.source = this.GetType().ToString();
                LogHelpers.message = "Login error:" + ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterForm.aspx");
        }
    }
}