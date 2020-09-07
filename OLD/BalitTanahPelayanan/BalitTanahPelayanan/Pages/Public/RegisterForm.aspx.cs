using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using System.Configuration;

namespace BalitTanahPelayanan.Pages.Public
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        smlpobDB context = new smlpobDB();
        RegisterControls registerControls = new RegisterControls();
       
        enum ModeForm { AddToAccountTable, AddToCustomerTable }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected async void BtnDaftar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtemail.Text))
                {
                    var seldata = context.customertbls.Where(x => x.customerEmail == txtemail.Text).ToList();
                    if (seldata != null && seldata.Count > 0)
                    {
                        CommonWeb.Alert(this,"Email ini sudah terdaftar");
                    }
                    else
                    {
                        try
                        {
                            //register to asp membership first!
                            MembershipUser user = Membership.CreateUser(txtemail.Text, txtpassword.Text, txtemail.Text);
                            //account
                            string pwd = Crypto.Encrypt(txtpassword.Text);
                            var NewItem = new accounttbl()
                            {
                                username = txtemail.Text,
                                password = pwd,
                                roleName = "pelanggan",
                                creaBy = "registration system",
                                creaDate = DatetimeHelper.GetDatetimeNow(),
                                isEmailVerified = "0"
                            };

                            //customers
                            var IDS = txtemail.Text;
                            var idacc = (from x in context.accounttbls
                                         where x.username == IDS
                                         select x.accountNo).FirstOrDefault();
                            var NewItem2 = new customertbl()
                            {
                                customerName = txtusername.Text,
                                customerEmail = txtemail.Text,
                                companyName = txtcompanyname.Text,
                                companyAddress = txtaddress.Text,
                                companyPhone = txtphone.Text,
                                companyEmail = txtcompanyemail.Text,
                                accountNo = idacc,
                                creaBy = "registration system",
                                creaDate = DatetimeHelper.GetDatetimeNow()
                            };
                            context.accounttbls.Add(NewItem);
                            context.customertbls.Add(NewItem2);
                            context.SaveChanges();

                            var roleFromAccountTable = registerControls.GetRole(txtemail.Text);
                            string role = roleFromAccountTable;
                            Roles.AddUserToRole(txtemail.Text, role);

                            //kirim email

                            var subject = "Aktivasi Akun untuk Sistem Informasi Pelayanan Online Balitanah";
                            var mainMessage = "Silahkan klik link berikut untuk mengaktivasi akun anda:";
                            var message = mainMessage + $"<br> <a href='{ConfigurationManager.AppSettings["RootWebUrl"]}/Pages/Public/Activation.aspx?userId={txtemail.Text}'>Aktivasi Akun</a>";
                            var msgPhone = mainMessage  + $" { ConfigurationManager.AppSettings["RootWebUrl"]}/Pages/Public/Activation.aspx?userId={txtemail.Text}";
                            var ret = EmailService.SendEmail(subject, message, txtemail.Text);
                            await SmsService.SendSms(msgPhone, txtphone.Text);

                            //var userAdded = Membership.GetUser(txtemail.Text);
                            //if (userAdded != null)
                            //{
                            //    userAdded.IsApproved = true;
                            //    userAdded.UnlockUser();
                            //    Membership.UpdateUser(userAdded);

                            //}
                            Response.Redirect("RegisterDone.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                        catch (Exception ex)
                        {
                            TxtStatus.Text = "Gagal menyimpan data registrasi, silakan isi dengan lengkap data-data yang diperlukan.";
                            LogHelpers.source = this.GetType().ToString();
                            LogHelpers.message = "fail to register user:" + ex.Message;
                            LogHelpers.user = CommonWeb.GetCurrentUser();
                            LogHelpers.WriteLog();
                        }

                    }
                }
            }
            catch 
            {
                TxtStatus.Text = "Gagal menyimpan data registrasi, silakan isi dengan lengkap data-data yang diperlukan.";
            }

        }

        protected void ActionButton(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var command = btn.CommandName;

                switch (command)
                {
                    case "save":
                        //DoSave();
                        break;

                    case "add":
                        SetLayout(ModeForm.AddToAccountTable);
                        break;
                }
            }
            catch 
            {
                CommonWeb.Alert(this,"Terjadi Kesalahan");
            }
        }
        private void SetLayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.AddToAccountTable:
                    BtnDaftar.Visible = true;
                    txtusername.Enabled = true;
                    txtphone.Enabled = true;
                    txtcompanyname.Enabled = true;
                    txtaddress.Enabled = true;
                    txtemail.Enabled = true;
                    txtemail.Enabled = true;
                    txtcompanyemail.Enabled = true;
                    txtpassword.Enabled = true;
                   
                    break;
            }
        }      

      
    }
}