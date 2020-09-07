using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Controllers;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class Employees : System.Web.UI.Page
    {
        string currentUser = "";
        EmployeeControls employeeControl = new EmployeeControls();
        AccountControls accountControl = new AccountControls();

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
            TxtEmployeeNo.Text = "Otomatis";
            TxtEmployeeName.Text = "";
            TxtDerivativeEmp.SelectedIndex = 0;
            TxtEmpEmail.Text = "";
            TxtPosition.Text = "";
            TxtAccountNo.SelectedIndex = 0;
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = employeeControl.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = employeeControl.GetDataByContaint(param);
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
            var ret = employeeControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtEmployeeNo.Text = data.employeeNo.ToString();
                TxtEmployeeName.Text = data.employeeName;
                TxtPosition.Text = data.position;
                TxtEmpEmail.Text = data.employeeEmail;
                TxtDerivativeEmp.SelectedIndex = TxtDerivativeEmp.Items.IndexOf(
                    TxtDerivativeEmp.Items.FindByValue(data.derivativeToEmployee.ToString()));

                if (data.accountNo != null)
                {
                    TxtAccountNo.SelectedIndex = TxtAccountNo.Items.IndexOf(
                        TxtAccountNo.Items.FindByValue(data.accountNo.ToString()));
                }
                else
                {
                    TxtAccountNo.SelectedIndex = 0;
                }
            }
        }

        private void DoUpdate()
        {
            int id = ParseInt(TxtEmployeeNo.Text);
            var data = new employeetbl
            {
                employeeNo = id,
                employeeName = TxtEmployeeName.Text,
                position = TxtPosition.Text,
                employeeEmail = TxtEmpEmail.Text,
                derivativeToEmployee = ParseInt(TxtDerivativeEmp.SelectedValue),
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            if (TxtAccountNo.SelectedValue != "-1")
            {
                data.accountNo = ParseInt(TxtAccountNo.SelectedValue);
            }

            var ret = employeeControl.UpdateData(id.ToString(), data);

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
            var data = new employeetbl
            {
                employeeName = TxtEmployeeName.Text,
                position = TxtPosition.Text,
                employeeEmail = TxtEmpEmail.Text,
                derivativeToEmployee = ParseInt(TxtDerivativeEmp.SelectedValue),
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            if (TxtAccountNo.SelectedValue != "-1")
            {
                data.accountNo = ParseInt(TxtAccountNo.SelectedValue);
            }

            var ret = employeeControl.AddData(data);

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
            var ret = employeeControl.DeleteData(id);

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
        private void GenerateDerivative()
        {
            TxtDerivativeEmp.Items.Clear();
            TxtDerivativeEmp.Items.Insert(0, new ListItem("PIC", "-1"));

            var ret = employeeControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtDerivativeEmp.DataSource = datas;
                TxtDerivativeEmp.DataTextField = "employeeName";
                TxtDerivativeEmp.DataValueField = "employeeNo";
                TxtDerivativeEmp.DataBind();
            }

            TxtDerivativeEmp.SelectedIndex = 0;
        }

        private void GenerateAccount()
        {
            TxtAccountNo.Items.Clear();
            TxtAccountNo.Items.Insert(0, new ListItem("Tidak memiliki akun", "-1"));

            var ret = accountControl.GetDataEmployee();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtAccountNo.DataSource = datas;
                TxtAccountNo.DataTextField = "username";
                TxtAccountNo.DataValueField = "accountNo";
                TxtAccountNo.DataBind();
            }

            TxtAccountNo.SelectedIndex = 0;
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
                    GenerateDerivative();
                    GenerateAccount();
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtEmployeeNo.Text = "Otomatis";
                    TxtEmployeeName.Enabled = true;
                    TxtPosition.Enabled = true;
                    TxtEmpEmail.Enabled = true;
                    TxtDerivativeEmp.Enabled = true;
                    TxtAccountNo.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    GenerateDerivative();
                    GenerateAccount();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtEmployeeName.Enabled = true;
                    TxtPosition.Enabled = true;
                    TxtEmpEmail.Enabled = true;
                    TxtDerivativeEmp.Enabled = true;
                    TxtAccountNo.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                case ModeForm.DetailData:
                    GenerateDerivative();
                    GenerateAccount();
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    TxtEmployeeName.Enabled = false;
                    TxtPosition.Enabled = false;
                    TxtEmpEmail.Enabled = false;
                    TxtDerivativeEmp.Enabled = false;
                    TxtAccountNo.Enabled = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    break;
            }
        }
        #endregion
    }
}