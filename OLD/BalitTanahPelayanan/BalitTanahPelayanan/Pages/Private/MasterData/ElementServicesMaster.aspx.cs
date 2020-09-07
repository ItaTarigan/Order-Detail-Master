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
    public partial class ElementServices : System.Web.UI.Page
    {
        string currentUser = "";
        ElementServicesControls elementServicesControl = new ElementServicesControls();
        AnalysisTypeControls analysisTypeControl = new AnalysisTypeControls();
        ComodityControls comodityControls = new ComodityControls();

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
            TxtElementCode.Text = "";
            TxtServiceGroup.Text = "";
            TxtServiceRate.Text = "";
            TxtServiceStatus.SelectedIndex = 0;
            TxtAnalysisTypeName.SelectedIndex = 0;
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = elementServicesControl.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = elementServicesControl.GetDataByContaint(param);
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
            var ret = elementServicesControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtElementCode.Text = data.elementCode;
                TxtAnalysisTypeName.SelectedIndex = TxtAnalysisTypeName.Items.IndexOf(
                        TxtAnalysisTypeName.Items.FindByValue(data.analysisTypeName.ToString()));
                TxtServiceGroup.Text = data.serviceGroup;
                TxtServiceRate.Text = Formater.ToRupiah(data.serviceRate);
                TxtServiceStatus.SelectedIndex = TxtServiceStatus.Items.IndexOf(
                        TxtServiceStatus.Items.FindByValue(data.serviceStatus.ToString()));
            }
        }

        private void DoUpdate()
        {            
            string id = TxtElementCode.Text;
            var data = new elementservicestbl
            {
                elementCode = TxtElementCode.Text,
                analysisTypeName = TxtAnalysisTypeName.SelectedValue,
                serviceGroup = TxtServiceGroup.Text ?? "",
                serviceRate = Formater.ToNumber(TxtServiceRate.Text),
                serviceStatus = TxtServiceStatus.SelectedValue,
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = elementServicesControl.UpdateData(id, data);

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
            var data = new elementservicestbl
            {
                elementCode = TxtElementCode.Text,
                analysisTypeName = TxtAnalysisTypeName.SelectedValue,
                serviceGroup = TxtServiceGroup.Text ?? "",
                serviceRate = Formater.ToNumber(TxtServiceRate.Text),
                serviceStatus = TxtServiceStatus.SelectedValue,
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = elementServicesControl.AddData(data);

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
            var ret = elementServicesControl.DeleteData(id);

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

        private void GenerateAnalysisTypeName()
        {
            TxtAnalysisTypeName.Items.Clear();

            var ret = analysisTypeControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtAnalysisTypeName.DataSource = datas;
                TxtAnalysisTypeName.DataTextField = "analysisTypeName";
                TxtAnalysisTypeName.DataValueField = "analysisTypeName";
                TxtAnalysisTypeName.DataBind();
            }

            TxtAnalysisTypeName.SelectedIndex = 0;
        }

        private void GenerateComodity()
        {
            TxtComodity.Items.Clear();

            var ret = comodityControls.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtComodity.DataSource = datas;
                TxtComodity.DataTextField = "comodityName";
                TxtComodity.DataValueField = "comodityNo";
                TxtComodity.DataBind();
            }

            TxtComodity.SelectedIndex = 0;
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
                    GenerateAnalysisTypeName();
                    GenerateComodity();
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtElementCode.Enabled = true;
                    TxtAnalysisTypeName.Enabled = true;
                    TxtServiceGroup.Enabled = true;
                    TxtServiceRate.Enabled = true;
                    TxtServiceStatus.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    GenerateAnalysisTypeName();
                    GenerateComodity();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtElementCode.Enabled = false;
                    TxtAnalysisTypeName.Enabled = true;
                    TxtServiceGroup.Enabled = true;
                    TxtServiceRate.Enabled = true;
                    TxtServiceStatus.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                case ModeForm.DetailData:
                    GenerateAnalysisTypeName();
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    TxtElementCode.Enabled = false;
                    TxtAnalysisTypeName.Enabled = false;
                    TxtServiceGroup.Enabled = false;
                    TxtServiceRate.Enabled = false;
                    TxtServiceStatus.Enabled = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    break;
            }
        }
        #endregion
    }
}