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
    public partial class StandardDetails : System.Web.UI.Page
    {
        string currentUser = "";
        StandardDetailControls standardDetailControl = new StandardDetailControls();
        ElementServicesControls elementServiceControl = new ElementServicesControls();

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
            TxtStdDetailId.Text = "Otomatis";
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = standardDetailControl.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = standardDetailControl.GetDataByContaint(param);
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
            var ret = standardDetailControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtStdDetailId.Text = data.stdId.ToString();
                TxtStdId.SelectedIndex = TxtStdId.Items.IndexOf(
                        TxtStdId.Items.FindByValue(data.stdId.ToString()));
                TxtElementCode.SelectedIndex = TxtElementCode.Items.IndexOf(
                        TxtElementCode.Items.FindByValue(data.elementId.ToString()));
            }
        }

        private void DoUpdate()
        {
            int id = 0;
            int.TryParse(TxtStdId.Text, out id);
            var data = new standarddetailtbl
            {
                stdDetailId = id,
                stdId = ParseInt(TxtStdId.SelectedValue),
                elementId = Convert.ToInt32(TxtElementCode.SelectedValue),
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = standardDetailControl.UpdateData(id.ToString(), data);

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
            var data = new standarddetailtbl
            {
                stdId = ParseInt(TxtStdId.SelectedValue),
                elementId = Convert.ToInt32(TxtElementCode.SelectedValue),
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = standardDetailControl.AddData(data);

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
            var ret = standardDetailControl.DeleteData(id);

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

        private void GenerateStandarsId()
        {
            TxtStdId.Items.Clear();

            var ret = standardDetailControl.GetStandardData();
            var datas = ret.Result;
            if (datas != null && datas.Count() > 0)
            {
                TxtStdId.DataSource = datas;
                TxtStdId.DataTextField = "stdNo";
                TxtStdId.DataValueField = "stdId";
                TxtStdId.DataBind();
            }

            TxtStdId.SelectedIndex = 0;
        }

        private void GenerateElementCode()
        {
            TxtElementCode.Items.Clear();

            var ret = elementServiceControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtElementCode.DataSource = datas;
                TxtElementCode.DataTextField = "elementCode";
                TxtElementCode.DataValueField = "elementCode";
                TxtElementCode.DataBind();
            }

            TxtElementCode.SelectedIndex = 0;
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
                    GenerateStandarsId();
                    GenerateElementCode();
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtStdId.Enabled = true;
                    TxtElementCode.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    GenerateStandarsId();
                    GenerateElementCode();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtStdId.Enabled = true;
                    TxtElementCode.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                case ModeForm.DetailData:
                    GenerateStandarsId();
                    GenerateElementCode();
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    TxtStdId.Enabled = false;
                    TxtElementCode.Enabled = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    break;
            }
        }
        #endregion
    }
}