using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;

namespace BalitTanahPelayanan.Pages.Private.MasterData
{
    public partial class Comodities : System.Web.UI.Page
    {
        string currentUser = "";
        ComodityControls comodityControl = new ComodityControls();

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
            TxtComodityNo.Text = "Otomatis";
            TxtComodityName.Text = "";
            TxtDerivativeTo.SelectedIndex = 0;
            TxtDescription.Text = "";            
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = comodityControl.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = comodityControl.GetDataByContaint(param);
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
            var ret = comodityControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtComodityNo.Text = data.comodityNo.ToString();
                TxtComodityName.Text = data.comodityName;
                TxtDescription.Text = data.description;
                TxtDerivativeTo.SelectedIndex = TxtDerivativeTo.Items.IndexOf(
                    TxtDerivativeTo.Items.FindByValue(data.derivativeTo.ToString()));
            }
        }

        private void DoUpdate()
        {
            int id = ParseInt(TxtComodityNo.Text);
            var data = new comoditytbl
            {
                comodityNo = id,
                comodityName = TxtComodityName.Text,
                derivativeTo = ParseInt(TxtDerivativeTo.SelectedValue),
                description = TxtDescription.Text,
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = comodityControl.UpdateData(id.ToString(), data);

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

            var data = new comoditytbl
            {
                comodityName = TxtComodityName.Text,
                derivativeTo = ParseInt(TxtDerivativeTo.SelectedValue),
                description = TxtDescription.Text,
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = comodityControl.AddData(data);

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
            var ret = comodityControl.DeleteData(id);

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
            TxtDerivativeTo.Items.Clear();
            TxtDerivativeTo.Items.Insert(0, new ListItem("Bukan turunan", "-1"));

            var ret = comodityControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtDerivativeTo.DataSource = datas;
                TxtDerivativeTo.DataTextField = "comodityName";
                TxtDerivativeTo.DataValueField = "comodityNo";
                TxtDerivativeTo.DataBind();
            }

            TxtDerivativeTo.SelectedIndex = 0;
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
        //protected void ActionImageButton(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var btn = sender as ImageButton;
        //        var command = btn.CommandName;

        //        switch (command)
        //        {
        //            case "search":
        //                var param = (TxtSearch.Text).Trim();
        //                RefreshGrid(param);
        //                break;

        //            case "refresh":
        //                TxtSearch.Text = "";
        //                RefreshGrid();
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Alert("Terjadi Kesalahan");
        //    }
        //}

        // Change layout
        private void SetLayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.AddData:
                    GenerateDerivative();
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtComodityNo.Text = "Otomatis";
                    TxtComodityName.Enabled = true;
                    TxtDerivativeTo.Enabled = true;
                    TxtDescription.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    GenerateDerivative();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtComodityName.Enabled = true;
                    TxtDerivativeTo.Enabled = true;
                    TxtDescription.Enabled = true;
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
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    TxtComodityName.Enabled = false;
                    TxtDerivativeTo.Enabled = false;
                    TxtDescription.Enabled = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    break;
            }
        }
        #endregion
    }
}