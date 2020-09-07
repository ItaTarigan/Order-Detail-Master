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
            if (!Page.IsPostBack)
            {
                txtUsername.Attributes.Add("autocomplete", "off");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(Membership.ValidateUser(txtUsername.Value, txtPassword.Value))
            {
                FormsAuthentication.SetAuthCookie(txtUsername.Value, cbremember.Checked);
                Response.Redirect("/Pages/Private/Employees.aspx");
            }
            else
            {
                Response.Redirect("LoginError.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterForm.aspx");
        }
    }
}