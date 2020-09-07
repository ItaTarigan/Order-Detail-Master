using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;


namespace BalitTanahPelayanan.Pages.Private.MasterData
{
    public partial class OrderDetailMaster : System.Web.UI.Page
    {
        string currentUser = "";
        OrderDetailControls detailControl = new OrderDetailControls();
        OrderMasterControls orderControl = new OrderMasterControls();
        EmployeeControls employeeControl = new EmployeeControls();
        SampleControls sampleControl = new SampleControls();
        ParameterControls parameterControl = new ParameterControls();
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
            TxtOrderDetailNo.Text = "Otomatis";
            TxtOrderNo.SelectedIndex = 0;
            TxtSampleNo.SelectedIndex = 0;
            TxtElementCode.SelectedIndex = 0;
            TxtParametersNo.SelectedIndex = 0;
            TxtElementValue.Text = "";
            TxtStatus.SelectedIndex = 0;
            TxtRecalculate.SelectedIndex = 0;
            TxtPic.SelectedIndex = 0;
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = detailControl.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = detailControl.GetDataByContaint(param);
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
            var ret = detailControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtOrderDetailNo.Text = data.orderDetailNo.ToString();
                TxtOrderNo.SelectedIndex = TxtOrderNo.Items.IndexOf(
                        TxtOrderNo.Items.FindByValue(data.orderNo.ToString()));
                TxtSampleNo.SelectedIndex = TxtSampleNo.Items.IndexOf(
                        TxtSampleNo.Items.FindByValue(data.sampleNo.ToString()));
                TxtElementCode.SelectedIndex = TxtElementCode.Items.IndexOf(
                        TxtElementCode.Items.FindByValue(data.elementId.ToString()));
                TxtParametersNo.SelectedIndex = TxtParametersNo.Items.IndexOf(
                        TxtParametersNo.Items.FindByValue(data.parametersNo.ToString()));
                TxtElementValue.Text = data.elementValue;
                TxtStatus.SelectedIndex = TxtStatus.Items.IndexOf(
                        TxtStatus.Items.FindByValue(data.status.ToString()));

                if (data.pic != null)
                {
                    TxtPic.SelectedIndex = TxtPic.Items.IndexOf(
                        TxtPic.Items.FindByValue(data.pic.ToString()));
                }
                else
                {
                    TxtPic.SelectedIndex = 0;
                }
            }
        }

        private void DoUpdate()
        {
            string id = TxtOrderDetailNo.Text;
            var data = new orderanalysisdetailtbl
            {
                orderDetailNo = ParseInt(id),
                orderNo = TxtOrderNo.SelectedValue,
                sampleNo = TxtSampleNo.SelectedValue,
                elementId = Convert.ToInt32(TxtElementCode),
                parametersNo = ParseInt(TxtParametersNo.Text),
                elementValue = TxtElementValue.Text,
                status = TxtStatus.SelectedValue,
                recalculate = TxtRecalculate.SelectedValue,
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            if (TxtPic.SelectedValue != "-1")
            {
                data.pic = ParseInt(TxtPic.SelectedValue);
            }

            var ret = detailControl.UpdateData(id.ToString(), data);

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
            string id = TxtOrderDetailNo.Text;
            var data = new orderanalysisdetailtbl
            {
                orderDetailNo = ParseInt(id),
                orderNo = TxtOrderNo.SelectedValue,
                sampleNo = TxtSampleNo.SelectedValue,
                elementId = Convert.ToInt32(TxtElementCode),
                parametersNo = ParseInt(TxtParametersNo.Text),
                elementValue = TxtElementValue.Text,
                status = TxtStatus.SelectedValue,
                recalculate = TxtRecalculate.SelectedValue,
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            if (TxtPic.SelectedValue != "-1")
            {
                data.pic = ParseInt(TxtPic.SelectedValue);
            }

            if (TxtSampleNo.SelectedValue != "-1")
            {
                data.sampleNo = TxtSampleNo.SelectedValue;
            }

            var ret = detailControl.AddData(data);

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
            var ret = detailControl.DeleteData(id);

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

        private void GeneratePic()
        {
            TxtPic.Items.Clear();
            TxtPic.Items.Insert(0, new ListItem("Belum ada PIC", "-1"));

            var ret = employeeControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtPic.DataSource = datas;
                TxtPic.DataTextField = "employeeName";
                TxtPic.DataValueField = "employeeNo";
                TxtPic.DataBind();
            }

            TxtPic.SelectedIndex = 0;
        }

        private void GenerateOrder()
        {
            TxtOrderNo.Items.Clear();

            var ret = orderControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtOrderNo.DataSource = datas;
                TxtOrderNo.DataTextField = "orderNo";
                TxtOrderNo.DataValueField = "orderNo";
                TxtOrderNo.DataBind();
            }

            TxtOrderNo.SelectedIndex = 0;
        }

        private void GenerateSample()
        {
            TxtSampleNo.Items.Clear();

            var ret = sampleControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtSampleNo.DataSource = datas;
                TxtSampleNo.DataTextField = "noBalittanah";
                TxtSampleNo.DataValueField = "noBalittanah";
                TxtSampleNo.DataBind();
            }

            TxtSampleNo.SelectedIndex = 0;
        }

        private void GenerateElement()
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

        private void GenerateParameter()
        {
            TxtParametersNo.Items.Clear();

            var ret = parameterControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtParametersNo.DataSource = datas;
                TxtParametersNo.DataTextField = "parametersNo";
                TxtParametersNo.DataValueField = "parametersNo";
                TxtParametersNo.DataBind();
            }

            TxtParametersNo.SelectedIndex = 0;
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
                    GeneratePic();
                    GenerateElement();
                    GenerateOrder();
                    GenerateParameter();
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtOrderDetailNo.Text = "Otomatis";
                    TxtOrderNo.Enabled = true;
                    TxtSampleNo.Enabled = true;
                    TxtElementCode.Enabled = true;
                    TxtParametersNo.Enabled = true;
                    TxtElementValue.Enabled = true;
                    TxtStatus.Enabled = true;
                    TxtRecalculate.Enabled = true;
                    TxtPic.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    GeneratePic();
                    GeneratePic();
                    GenerateElement();
                    GenerateOrder();
                    GenerateParameter();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    TxtOrderNo.Enabled = true;
                    TxtSampleNo.Enabled = true;
                    TxtElementCode.Enabled = true;
                    TxtParametersNo.Enabled = true;
                    TxtElementValue.Enabled = true;
                    TxtStatus.Enabled = true;
                    TxtRecalculate.Enabled = true;
                    TxtPic.Enabled = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                case ModeForm.DetailData:
                    GeneratePic();
                    GeneratePic();
                    GenerateElement();
                    GenerateOrder();
                    GenerateParameter();
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    TxtOrderNo.Enabled = false;
                    TxtSampleNo.Enabled = false;
                    TxtElementCode.Enabled = false;
                    TxtParametersNo.Enabled = false;
                    TxtElementValue.Enabled = false;
                    TxtStatus.Enabled = false;
                    TxtRecalculate.Enabled = false;
                    TxtPic.Enabled = false;
                    break;
            }
        }
        #endregion
    }
}