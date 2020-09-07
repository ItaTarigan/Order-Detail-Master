using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Public
{
    public partial class Activation : System.Web.UI.Page
    {
        RegisterControls registerControls = new RegisterControls();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAktif.Click += btnAktif_Click;
            if (!IsPostBack)
            {
                try
                {
                    var userId = Request.QueryString["userId"];
                    if (string.IsNullOrEmpty(userId))
                    {
                        Literal1.Text = "Tidak ada username, aktivasi tidak dapat dilakukan.";
                    }
                    else
                    {
                        if (userId.Contains("¡"))
                        {
                            userId = userId.Replace("¡", "@");
                        }
                        var user = Membership.GetUser(userId);
                        if (user != null)
                        {
                            user.IsApproved = true;
                            user.UnlockUser();
                            Membership.UpdateUser(user);
                            Literal1.Text = "User anda telah di aktivasi, sekarang Anda bisa login";
                        }
                        else
                        {
                            Literal1.Text = "User tidak terdaftar di sistem, silahkan cek kembali akun anda";
                        }
                    }
                }
                catch (Exception ex)
                {
                    TxtStatus.Text = "gagal save --> " + ex.Message;
                }
            }
        }

        protected void btnAktif_Click(object sender, EventArgs e)
        {
            DoContinue();
            
        }

        private void DoContinue()
        {
            try
            {
                string userId = Request.QueryString["userId"];
                if (userId.Contains("¡"))
                {
                    userId = userId.Replace("¡", "@");
                }

                var result = registerControls.MasterData(userId);
                var datas = result.Result;

                var data = new accounttbl
                {

                    accountNo = datas.accountNo,
                    username = datas.username,
                    password = datas.password,
                    roleName = datas.roleName,
                    isEmailVerified = "1"

                };

                var ret = registerControls.UpdateData(userId, data);

                if (ret.Result)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    CommonWeb.Alert(this, "Gagal mengubah data");
                }
                
            }
            catch(Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi kesalahan: "+ex.Message);
            }
        }

      
    }
}