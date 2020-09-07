using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Public
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        public object IdentityManager { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtnewpass.Attributes.Add("autocomplete", "off");
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    string message = null;
                    string username = txtuser.Value;
                    string password = txtoldpass.Value;
                    string newpassword = txtnewpass.Value;
                    MembershipUser u = Membership.GetUser(username);

                    try
                    {
                        if (u.ChangePassword(password, newpassword))
                        {
                            lblMassage.Text = "Password changed.";
                        }
                        else
                        {
                            lblMassage.Text = "Password change failed. Please re-enter your values and try again.";
                        }
                    }
                    catch (Exception e1)
                    {
                        lblMassage.Text = "An exception occurred: " + Server.HtmlEncode(e1.Message) + ". Please re-enter your values and try again.";
                    }

                }
                else
                {

                }
            }
            catch (Exception er)
            {
                System.Diagnostics.Debug.WriteLine(er);
            }

        }
    }
}