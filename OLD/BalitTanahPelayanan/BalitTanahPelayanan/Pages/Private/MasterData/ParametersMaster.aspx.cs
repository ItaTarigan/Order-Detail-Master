using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Pages.Private.MasterData
{
    public partial class ParametersMaster : System.Web.UI.Page
    {
        string currentUser = "";
        ParameterControls parameterControl = new ParameterControls();

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
            TxtParameterNo.Text = "Otomatis";
            TxtString0.Text = "";
            TxtString1.Text = "";
            TxtString2.Text = "";
            TxtString3.Text = "";
            TxtString4.Text = "";
            TxtString5.Text = "";
            TxtString6.Text = "";
            TxtString7.Text = "";
            TxtString8.Text = "";
            TxtString9.Text = "";
        }

        // Reload datagrid
        void RefreshGrid()
        {
            var ret = parameterControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                GvData.DataSource = datas;
                GvData.DataBind();
            }

            if (GvData.Rows.Count > 0)
            {
                //Allow Paging
                GvData.AllowCustomPaging = true;
                //This replaces <td> with <th>    
                GvData.UseAccessibleHeader = true;
                //This will add the <thead> and <tbody> elements    
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
                //This adds the <tfoot> element. Remove if you don't have a footer row    
                GvData.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        void LoadDetail(string fid)
        {
            var ret = parameterControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtParameterNo.Text = data.parametersNo.ToString();
                TxtString0.Text = data.string0;
                TxtString1.Text = data.string1;
                TxtString2.Text = data.string2;
                TxtString3.Text = data.string3;
                TxtString4.Text = data.string4;
                TxtString5.Text = data.string5;
                TxtString6.Text = data.string6;
                TxtString7.Text = data.string7;
                TxtString8.Text = data.string8;
                TxtString9.Text = data.string9;
            }
        }

        private void DoUpdate()
        {
            int id = 0;
            int.TryParse(TxtParameterNo.Text, out id);
            var data = new parameterstbl
            {
                parametersNo = id,
                string0 = TxtString0.Text != "" ? TxtString0.Text : "",
                string1 = TxtString1.Text != "" ? TxtString1.Text : "",
                string2 = TxtString2.Text != "" ? TxtString2.Text : "",
                string3 = TxtString3.Text != "" ? TxtString3.Text : "",
                string4 = TxtString4.Text != "" ? TxtString4.Text : "",
                string5 = TxtString5.Text != "" ? TxtString5.Text : "",
                string6 = TxtString6.Text != "" ? TxtString6.Text : "",
                string7 = TxtString7.Text != "" ? TxtString7.Text : "",
                string8 = TxtString8.Text != "" ? TxtString8.Text : "",
                string9 = TxtString9.Text != "" ? TxtString9.Text : "",
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = parameterControl.UpdateData(id.ToString(), data);

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
            var data = new parameterstbl
            {
                string0 = TxtString0.Text != "" ? TxtString0.Text : "",
                string1 = TxtString1.Text != "" ? TxtString1.Text : "",
                string2 = TxtString2.Text != "" ? TxtString2.Text : "",
                string3 = TxtString3.Text != "" ? TxtString3.Text : "",
                string4 = TxtString4.Text != "" ? TxtString4.Text : "",
                string5 = TxtString5.Text != "" ? TxtString5.Text : "",
                string6 = TxtString6.Text != "" ? TxtString6.Text : "",
                string7 = TxtString7.Text != "" ? TxtString7.Text : "",
                string8 = TxtString8.Text != "" ? TxtString8.Text : "",
                string9 = TxtString9.Text != "" ? TxtString9.Text : "",
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = parameterControl.AddData(data);

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
            var ret = parameterControl.DeleteData(id);

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
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtString0.Enabled = true;
                    TxtString1.Enabled = true;
                    TxtString2.Enabled = true;
                    TxtString3.Enabled = true;
                    TxtString4.Enabled = true;
                    TxtString5.Enabled = true;
                    TxtString6.Enabled = true;
                    TxtString7.Enabled = true;
                    TxtString8.Enabled = true;
                    TxtString9.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    TxtString0.Enabled = true;
                    TxtString1.Enabled = true;
                    TxtString2.Enabled = true;
                    TxtString3.Enabled = true;
                    TxtString4.Enabled = true;
                    TxtString5.Enabled = true;
                    TxtString6.Enabled = true;
                    TxtString7.Enabled = true;
                    TxtString8.Enabled = true;
                    TxtString9.Enabled = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                case ModeForm.DetailData:
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    TxtString0.Enabled = false;
                    TxtString1.Enabled = false;
                    TxtString2.Enabled = false;
                    TxtString3.Enabled = false;
                    TxtString4.Enabled = false;
                    TxtString5.Enabled = false;
                    TxtString6.Enabled = false;
                    TxtString7.Enabled = false;
                    TxtString8.Enabled = false;
                    TxtString9.Enabled = false;
                    break;
            }
        }
        #endregion
    }
}