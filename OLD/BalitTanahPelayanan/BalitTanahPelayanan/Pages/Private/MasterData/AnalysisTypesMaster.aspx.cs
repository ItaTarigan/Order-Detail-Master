using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;

namespace BalitTanahPelayanan.Pages.Private.MasterData
{
    public partial class AnalysisTypes : System.Web.UI.Page
    {
        string currentUser = "";
        AnalysisTypeControls analysisControl = new AnalysisTypeControls();

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
            TxtAnalysisTypeName.Text = "";
            TxtDescription.Text = "";
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = analysisControl.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {        
                var ret = analysisControl.GetDataByContaint(param);
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
            var ret = analysisControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtAnalysisTypeName.Text = data.analysisTypeName;
                TxtDescription.Text = data.description;
            }
        }

        private void DoUpdate()
        {
            string id = TxtAnalysisTypeName.Text;
            var data = new analysistypetbl
            {
                analysisTypeName = TxtAnalysisTypeName.Text,
                description = TxtDescription.Text,
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = analysisControl.UpdateData(id, data);

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
            var data = new analysistypetbl
            {
                analysisTypeName = this.TxtAnalysisTypeName.Text,
                description = this.TxtDescription.Text,
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = analysisControl.AddData(data);

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
            var ret = analysisControl.DeleteData(id);

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
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtAnalysisTypeName.Enabled = true;
                    TxtDescription.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtAnalysisTypeName.Enabled = false;
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
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    TxtAnalysisTypeName.Enabled = false;
                    TxtDescription.Enabled = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    break;
            }
        }
        #endregion
    }
}