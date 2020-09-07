using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using Gravicode.Library.Mail;

namespace BalitTanahPelayanan.Pages.Public
{
    public partial class ForgotPasswordForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSent_Click(object sender, EventArgs e)
        {
            MembershipUser u;
            try
            {
                if (string.IsNullOrEmpty(txtemail.Value))
                {
                    lblMessage.Text = "Silakan isi email terlebih dahulu.";
                    return;
                }
                    string newPassword=null;
                    u = Membership.GetUser(txtemail.Value, false);

                    if (u == null)
                    {
                        lblMessage.Text = Server.HtmlEncode(txtemail.Value) + " tidak ditemukan. Silakan isi dengan email yang benar.";
                        return;
                    }

                    try
                    {
                        newPassword = u.ResetPassword();
                    }
                    catch (MembershipPasswordException e1)
                    {
                        lblMessage.Text = "Gagal melakukan reset password, silakan mencoba kembali.";
                        return;
                    }


                if (!string.IsNullOrEmpty(newPassword))
                {
                    //send email
                    var subject = "Password Akun Sistem Informasi Pelayanan Online Balitanah Anda sudah berhasil di reset";
                    var message = "Password baru untuk username : " + txtemail.Value + " adalah " + newPassword;
                    EmailService.SendEmail(subject, message, txtemail.Value);
                    using(var db = new smlpobDB())
                    {
                        var emp = from x in db.customertbls
                                  where x.customerEmail == txtemail.Value
                                  select x;
                        foreach(var item in emp)
                        {
                            SmsService.SendSms(message, item.companyPhone).GetAwaiter().GetResult();
                        }
                    }
                   

                    lblMessage.Visible = true;
                    Response.Redirect("ForgotPasswordDone.aspx");
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Gagal melakukan reset password, silakan mencoba kembali.";
                }
            }
            catch(Exception ex)
            {
                LogHelpers.source = this.GetType().ToString();
                LogHelpers.message = "Gagal reset password user:" + ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();
            }
        }
    }
}

