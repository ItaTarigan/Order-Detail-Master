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
    public partial class Standards : System.Web.UI.Page
    {
        string currentUser = "";
        StandardControls standardControl = new StandardControls();
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
            TxtStdId.Text = "Otomatis";
            TxtStdNo.Text = "";
            TxtComodityNo.SelectedIndex = 0;
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = standardControl.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = standardControl.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }

            //if (GvData.Rows.Count > 0)
            //{
            //    //Allow Paging
            //    GvData.AllowCustomPaging = true;
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
            var ret = standardControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtStdId.Text = data.stdId.ToString();
                TxtStdNo.Text = data.stdNo;
                TxtComodityNo.SelectedIndex = TxtComodityNo.Items.IndexOf(
                        TxtComodityNo.Items.FindByValue(data.comodityNo.ToString()));
            }
        }

        private void DoUpdate()
        {
            int id = 0;
            int.TryParse(TxtStdId.Text, out id);
            var data = new standardtbl
            {
                stdId = id,
                stdNo = TxtStdNo.Text,
                comodityNo = ParseInt(TxtComodityNo.SelectedValue),
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            if (TxtComodityNo.SelectedValue == "-1")
            {
                data.comodityNo = null;
            }

            var ret = standardControl.UpdateData(id.ToString(), data);

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
            var data = new standardtbl
            {
                stdNo = TxtStdNo.Text,
                comodityNo = ParseInt(TxtComodityNo.SelectedValue),
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            if (TxtComodityNo.SelectedValue == "-1")
            {
                data.comodityNo = null;
            }

            var ret = standardControl.AddData(data);

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
            var ret = standardControl.DeleteData(id);

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

        private void GenerateComodity()
        {
            TxtComodityNo.Items.Clear();
            TxtComodityNo.Items.Insert(0, new ListItem("Tidak Digunakan", "-1"));

            var ret = standardControl.GetComodityData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtComodityNo.DataSource = datas;
                TxtComodityNo.DataTextField = "comodityName";
                TxtComodityNo.DataValueField = "comodityNo";
                TxtComodityNo.DataBind();
            }

            TxtComodityNo.SelectedIndex = 0;
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
                    GenerateComodity();
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtStdNo.Enabled = true;
                    TxtComodityNo.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    GenerateComodity();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtStdNo.Enabled = true;
                    TxtComodityNo.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                case ModeForm.DetailData:
                    GenerateComodity();
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    TxtStdNo.Enabled = false;
                    TxtComodityNo.Enabled = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    break;
            }
        }
        #endregion
    }
}