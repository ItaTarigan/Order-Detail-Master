using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Pages.Public
{
    public partial class Register : System.Web.UI.Page
    {
        SMLPOBModel context = new SMLPOBModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RefreshGrid();
            BtnAdd2.Click += BtnAdd2_Click;
            BtnSubmit.Click += BtnSubmit_Click;
            BtnCancel.Click += BtnCancel_Click;
            GvData.RowCommand += GvData_RowCommand;
        }

        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Ubah":
                    SetLayout(ModeForm.EditData);
                    LoadDetail(IDS);
                    break;

                case "Hapus":
                    var datas = from x in context.customertbls
                                where x.customerNo == IDS
                                select x;
                    foreach (var item in datas)
                    {
                        context.customertbls.Remove(item);
                    }
                    context.SaveChanges();
                    RefreshGrid();
                    break;
                case "Lihat":
                    SetLayout(ModeForm.LihatData);
                    LoadDetail(IDS);

                    break;
            }
        }

        enum ModeForm { ViewGrid, EditData, LihatData }
        void SetLayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.EditData:
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnSubmit.Visible = true;
                    break;
                case ModeForm.LihatData:
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnSubmit.Visible = false;
                    break;
                case ModeForm.ViewGrid:
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;
            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {                
            try
            {
                //update
                if (!string.IsNullOrEmpty(TxtID.Value))
                {
                    var IDS2 = int.Parse(TxtID.Value);
                    var NewItem2 = (from x in context.customertbls
                                   where x.customerNo == IDS2
                                   select x).FirstOrDefault();
                    NewItem2.customerName = txtNama.Text;
                    NewItem2.customerEmail = txtEmail.Text;
                    NewItem2.companyName = txtPerusahaan.Text;
                    NewItem2.companyAddress = txtPerusahaan.Text;
                    NewItem2.companyPhone = txtNoTelepon.Text;
                    NewItem2.companyEmail = txtCompanyEmail.Text;
                    NewItem2.creaBy = "Coba";
                    NewItem2.modBy = "Cobaa";
                    NewItem2.creaDate = DateTime.Now;
                    NewItem2.modDate = DateTime.Now;
                    //NewItem2.customerNo = Convert.ToInt32(TxtcustomerNo.Text);

                    var IDS = txtEmail.Text;
                    var idacc1 = (from x in context.customertbls
                                  where x.customerEmail == IDS
                                  select x.accountNo).FirstOrDefault();
                    var NewItem = (from x in context.accounttbls
                                   where x.accountNo == idacc1
                                   select x).FirstOrDefault();

                    //var IDS = txtemai;
                    //var NewItem = (from x in context.accounttbls
                    //               where x.accountNo == IDS
                    //               select x).FirstOrDefault();
                    NewItem.username = txtEmail.Text;
                    NewItem.password = txtPassword.Text;
                    NewItem.roleName = "Customer";
                    NewItem.creaBy = "Coba";
                    NewItem.modBy = "Cobaaa";
                    NewItem.creaDate = DateTime.Now;
                    NewItem.modDate = DateTime.Now;
                    NewItem.isEmailVerified = "0";
                    //NewItem.accountNo = Convert.ToInt32(TxtAccountNo.Text);
                }
                else //add new
                {
                    var seldata2 = context.customertbls.Select(x => x.customerEmail).ToList();
                    foreach (var item in seldata2)
                    {
                        if (txtEmail.Text == item)
                        {
                            TxtStatus.Text = "Email Sudah Terdaftar";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email Sudah Terdaftar')", true);
                        }
                        else if(txtEmail.Text != item)
                        {
                            //account
                            var NewItem = new accounttbl() { };
                            NewItem.username = txtEmail.Text;
                            NewItem.password = txtPassword.Text;
                            NewItem.roleName = "Customer";
                            NewItem.creaBy = "Coba";
                            NewItem.modBy = "Cobaaa";
                            NewItem.creaDate = DateTime.Now;
                            NewItem.modDate = DateTime.Now;
                            NewItem.isEmailVerified = "0";
                            context.accounttbls.Add(NewItem);

                            //customor
                            var IDS = txtEmail.Text;
                            var idacc = (from x in context.accounttbls
                                         where x.username == IDS
                                         select x.accountNo).FirstOrDefault();
                            var NewItem2 = new customertbl() { };
                            NewItem2.customerName = txtNama.Text;
                            NewItem2.customerEmail = txtEmail.Text;
                            NewItem2.companyName = txtPerusahaan.Text;
                            NewItem2.companyAddress = txtPerusahaan.Text;
                            NewItem2.companyPhone = txtNoTelepon.Text;
                            NewItem2.companyEmail = txtCompanyEmail.Text;
                            NewItem2.accountNo = idacc;
                            NewItem2.creaBy = "Coba";
                            NewItem2.modBy = "Cobaa";
                            NewItem2.creaDate = DateTime.Now;
                            NewItem2.modDate = DateTime.Now;
                            //data2.accountNo = Convert.ToInt32(txtAccountNo.Text);
                            context.customertbls.Add(NewItem2);
                        }
                        else
                        {
                            TxtStatus.Text = "gagal save";
                        }

                    }
                }
                context.SaveChanges();
                PanelGrid.Visible = true;
                PanelInput.Visible = false;
                RefreshGrid();
            }
            catch (Exception ex)
            {
                TxtStatus.Text = "gagal save --> " + ex.Message;
            }            
        }

        void LoadDetail(int fid)
        {
            var seldata = from x in context.customertbls
                          where x.customerNo == fid
                          select x;
            var seldata2 = from x in context.accounttbls
                          where x.accountNo == fid
                          select x;
            foreach (var item in seldata)
            {                
                txtNama.Text = item.customerName;
                txtPerusahaan.Text = item.companyName;                
                txtAlamat.Text = item.companyAddress;                
                txtNoTelepon.Text = item.companyPhone;
                txtEmail.Text = item.customerEmail;
                txtCompanyEmail.Text = item.companyEmail;                
                TxtID.Value = item.customerNo.ToString();                
                break;
            }
            foreach (var item2 in seldata2)
            {
                txtPassword.Text = item2.password;
            }
        }

        private void BtnAdd2_Click(object sender, EventArgs e)
        {
            //TxtCreated.Text = DateTime.Now.ToString();
            //TxtUpdated.Text = DateTime.Now.ToString();
            //TxtCreatedBy.Text = User.Identity.Name;
            //TxtUpdatedBy.Text = User.Identity.Name;
            PanelGrid.Visible = false;
            ClearFields();
            PanelInput.Visible = true;
        }
        void ClearFields()
        {
            //clear all field input
            TxtID.Value = "";            
            txtNama.Text = "";
            txtPerusahaan.Text = "";
            txtAlamat.Text = "";
            txtNoTelepon.Text = "";
            txtEmail.Text = "";
            txtCompanyEmail.Text = "";
            txtPassword.Text = "";

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            SetLayout(ModeForm.ViewGrid);
            RefreshGrid();
            //checkmenu();
        }                

        void RefreshGrid()
        {
            var datas = from x in context.customertbls
                        select x;
            GvData.DataSource = datas.ToList();
            GvData.DataBind();

            if (GvData.Rows.Count > 0)
            {
                //This replaces <td> with <th>    
                GvData.UseAccessibleHeader = true;
                //This will add the <thead> and <tbody> elements    
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
                //This adds the <tfoot> element. Remove if you don't have a footer row    
                GvData.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }       
    }
}