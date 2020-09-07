using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class Accounts : System.Web.UI.Page
    {
        string currentUser = "";
        AccountControls accountControl = new AccountControls();
        RoleControls roleControl = new RoleControls();

        enum ModeForm { ViewData, UpdateData, DetailData, AddData }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();
            }

            GvData.RowCommand += GvData_RowCommand;
        }

        #region Custom function
        // Clear input fields
        void ClearFields()
        {
            TxtAccountNo.Text = "Otomatis";
            TxtUsername.Text = "";
            TxtPassword.Text ="";
            TxtRoleName.SelectedIndex = 0;
            TxtEmailVerified.Text = "0";
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = accountControl.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = accountControl.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }

            //if (GvData.Rows.Count > 0)
            //{
            //    //This replaces <td> with <th>    
            //    GvData.UseAccessibleHeader = true;
            //    //This will add the <thead> and <tbody> elements    
            //    GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            //    //This adds the <tfoot> element. Remove if you don't have a footer row    
            //    GvData.FooterRow.TableSection = TableRowSection.TableFooter;
            //}
        }

        void LoadDetail(string fid)
        {
            var ret = accountControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtAccountNo.Text = data.accountNo.ToString();
                TxtUsername.Text = data.username;
                TxtPassword.Text = Crypto.Decrypt(data.password);
                TxtRoleName.SelectedIndex = TxtRoleName.Items.IndexOf(
                    TxtRoleName.Items.FindByValue(data.roleName.ToString()));
                TxtEmailVerified.Text = data.isEmailVerified;
            }
        }

        private void DoUpdate()
        {
            int id = ParseInt(TxtAccountNo.Text);
            var data = new accounttbl
            {
                accountNo = id,
                username = TxtUsername.Text,
                password = Crypto.Encrypt(TxtPassword.Text),
                roleName = TxtRoleName.SelectedValue,
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = accountControl.UpdateData(id.ToString(), data);

            if (ret.Result)
            {
                ClearFields();
                SetLayout(ModeForm.ViewData);
                Alert("Data berhasil diubah");
            }
            else
            {
                Alert("Gagal mengubah data");
            }
        }

        private void DoSave()
        {
            string pwd = Crypto.Encrypt(TxtPassword.Text);
            var data = new accounttbl
            {
                username = TxtUsername.Text,
                password = pwd,
                roleName = TxtRoleName.SelectedValue,
                isEmailVerified = "0",
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = accountControl.AddData(data);

            if (ret.Result)
            {
                ClearFields();
                SetLayout(ModeForm.ViewData);
                Alert("data berhasil disimpan");
            }
            else
            {
                Alert("Gagal menyimpan data");
            }
        }

        private void DoDelete(string id)
        {
            var ret = accountControl.DeleteData(id);

            if (ret.Result)
            {
                RefreshGrid();
                Alert("Data berhasil dihapus");
            }
            else
            {
                Alert("Gagal menghapus data");
            }
        }

        // DropDown Generator
        private void GenerateRole()
        {
            TxtRoleName.Items.Clear();

            var ret = roleControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtRoleName.DataSource = datas;
                TxtRoleName.DataTextField = "roleName";
                TxtRoleName.DataValueField = "roleName";
                TxtRoleName.DataBind();
            }

            TxtRoleName.SelectedIndex = 0;
        }

        // Helper function
        private int ParseInt(string param)
        {
            int ret = 0;
            int.TryParse(param, out ret);

            return ret;
        }

        // Alert
        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }
        #endregion

        #region Action function
        // Action on datagrid table
        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "ubah":
                    SetLayout(ModeForm.UpdateData);
                    LoadDetail(IDS.ToString().Trim());
                    break;

                case "hapus":
                    DoDelete(IDS.ToString().Trim());
                    break;

                case "lihat":
                    SetLayout(ModeForm.DetailData);
                    LoadDetail(IDS.ToString().Trim());
                    break;
            }
        }
        // Action Field
        protected void ActionButton(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var command = btn.CommandName;

                switch (command)
                {
                    case "save":
                        DoSave();
                        break;

                    case "add":
                        SetLayout(ModeForm.AddData);
                        break;

                    case "update":
                        DoUpdate();
                        break;

                    case "cancel":
                        SetLayout(ModeForm.ViewData);
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
            }
        }
        protected void ActionImageButton(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ImageButton;
                var command = btn.CommandName;

                switch (command)
                {
                    case "search":
                        var param = (TxtSearch.Text).Trim();
                        RefreshGrid(param);
                        break;

                    case "refresh":
                        TxtSearch.Text = "";
                        RefreshGrid();
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
            }
        }

        // Change layout
        private void SetLayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.AddData:
                    GenerateRole();
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtAccountNo.Text = "Otomatis";
                    TxtUsername.Enabled = true;
                    TxtPassword.Enabled = true;
                    TxtRoleName.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    GenerateRole();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtUsername.Enabled = false;
                    TxtPassword.Enabled = true;
                    TxtRoleName.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                case ModeForm.DetailData:
                    GenerateRole();
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    TxtUsername.Enabled = false;
                    TxtPassword.Enabled = false;
                    TxtRoleName.Enabled = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    break;
            }
        }
        #endregion
    }
}