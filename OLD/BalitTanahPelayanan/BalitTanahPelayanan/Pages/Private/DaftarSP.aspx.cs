using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;

namespace BalitTanahPelayanan.Pages.Private
{
	public partial class DaftarSP : System.Web.UI.Page
	{
        string currentUser = "";
        DaftarSPControl daftarspControl = new DaftarSPControl();
        CustomerControls customerControls = new CustomerControls();
        ComodityControls comodityControls = new ComodityControls();
        EmployeeControls employeepic = new EmployeeControls();

        enum ModeForm { ViewData, EditData, DetailData, AddData }
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                RefreshGrid();
            }
            GvData.RowCommand += GvData_RowCommand1;
        }

        #region Custom
        // Clear input fields
        void ClearFields()
        {
            TxtOrderNo.Text = "Otomatis";
            DDLCustomerno.SelectedIndex = 0;
            DDLComodityNo.SelectedIndex = 0;
            TxtTotalSample.Text = "";
            TxtPriceTotal.Text = "";
            TxtStatus.Text = "";
            TxtTipePayment.Text = "";
            DDLPayed.SelectedIndex = 0;
            TxtPayedDate.Text = "";
            TxtAppr.Text = "";
            DDLPIC.SelectedIndex = 0;
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = daftarspControl.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = daftarspControl.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
        }

        void LoadDetail(string fid)
        {
            var ret = daftarspControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtOrderNo.Text = data.orderNo.ToString();
                if(data.customerNo != null)
                {
                    DDLCustomerno.SelectedIndex = DDLCustomerno.Items.IndexOf(
                        DDLCustomerno.Items.FindByValue(data.customerNo.ToString()));
                }
                else
                {
                    DDLCustomerno.SelectedIndex = 0;
                }
                if(data.comodityNo != null)
                {
                    DDLComodityNo.SelectedIndex = DDLComodityNo.Items.IndexOf(
                        DDLComodityNo.Items.FindByValue(data.comodityNo.ToString()));
                }
                else
                {
                    DDLComodityNo.SelectedIndex = 0;
                }
                TxtTotalSample.Text = data.sampleTotal.ToString();
                TxtPriceTotal.Text = data.priceTotal.ToString();
                TxtStatus.Text = data.status;
                TxtTipePayment.Text = data.paymentType;
                DDLPayed.SelectedIndex = DDLPayed.Items.IndexOf(
                    DDLPayed.Items.FindByValue(data.comodityNo.ToString()));
                TxtPayedDate.Text = data.isPayedDate.ToString();
                TxtAppr.Text = data.isAppr;
                DDLPIC.SelectedIndex = DDLPIC.Items.IndexOf(
                    DDLPIC.Items.FindByValue(data.pic.ToString()));
            }
        }

        private void DoUpdate()
        {
            string id = TxtOrderNo.Text;
            var data = new ordermastertbl
            {
                orderNo = TxtOrderNo.Text,
                customerNo = Convert.ToInt32(DDLCustomerno.SelectedValue),
                comodityNo = Convert.ToInt32(DDLComodityNo.SelectedValue),
                sampleTotal = Convert.ToInt32(TxtTotalSample.Text),
                priceTotal = Convert.ToInt32(TxtPriceTotal.Text),
                status = TxtStatus.Text,
                paymentType = TxtTipePayment.Text,
                isPayed = DDLPayed.SelectedValue,
                isPayedDate = Convert.ToDateTime(TxtPayedDate.Text),
                isAppr = TxtAppr.Text,
                pic = Convert.ToInt32(DDLPIC.SelectedValue),
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            if(DDLCustomerno.SelectedValue != "-1")
            {
                data.customerNo = ParseInt(DDLCustomerno.SelectedValue);
            }
            else if(DDLComodityNo.SelectedValue != "-1")
            {
                data.comodityNo = ParseInt(DDLComodityNo.SelectedValue);
            }
            //else if(DDLPayed.SelectedValue != "-1")
            //{
            //    data.isPayed = DDLPayed.SelectedValue;
            //}
            else if (DDLPIC.SelectedValue != "-1")
            {
                data.pic = ParseInt(DDLPIC.SelectedValue);
            }

            var ret = daftarspControl.UpdateData(id, data);

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
            var data = new ordermastertbl
            {
                orderNo = TxtOrderNo.Text,
                customerNo = Convert.ToInt32(DDLCustomerno.SelectedValue),
                comodityNo = Convert.ToInt32(DDLComodityNo.SelectedValue),
                sampleTotal = Convert.ToInt32(TxtTotalSample.Text),
                priceTotal = Convert.ToInt32(TxtPriceTotal.Text),
                status = TxtStatus.Text,
                paymentType = TxtTipePayment.Text,
                isPayed = DDLPayed.SelectedValue,
                isPayedDate = Convert.ToDateTime(TxtPayedDate.Text),
                isAppr = TxtAppr.Text,
                pic = Convert.ToInt32(DDLPIC.SelectedValue),
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            if (DDLCustomerno.SelectedValue != "-1")
            {
                data.customerNo = ParseInt(DDLCustomerno.SelectedValue);
            }
            else if (DDLComodityNo.SelectedValue != "-1")
            {
                data.comodityNo = ParseInt(DDLComodityNo.SelectedValue);
            }
            //else if (DDLPayed.SelectedValue != "-1")
            //{
            //    data.isPayed = DDLPayed.SelectedValue;
            //}
            else if (DDLPIC.SelectedValue != "-1")
            {
                data.pic = ParseInt(DDLPIC.SelectedValue);
            }

            var ret = daftarspControl.AddData(data);

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
            var ret = daftarspControl.DeleteData(id);

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

        private void GenerateCustNo()
        {
            DDLCustomerno.Items.Clear();

            var ret = daftarspControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                DDLCustomerno.DataSource = datas;
                DDLCustomerno.DataTextField = "customerNo";
                DDLCustomerno.DataValueField = "customerNo";
                DDLCustomerno.DataBind();
            }

            DDLCustomerno.SelectedIndex = 0;
        }

        private void GenerateComdNo()
        {
            DDLComodityNo.Items.Clear();

            var ret = daftarspControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                DDLComodityNo.DataSource = datas;
                DDLComodityNo.DataTextField = "comodityNo";
                DDLComodityNo.DataValueField = "comodityNo";
                DDLComodityNo.DataBind();
            }

            DDLComodityNo.SelectedIndex = 0;
        }

        private void GeneratePIC()
        {
            DDLPIC.Items.Clear();

            var ret = daftarspControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                DDLPIC.DataSource = datas;
                DDLPIC.DataTextField = "pic";
                DDLPIC.DataValueField = "pic";
                DDLPIC.DataBind();
            }

            DDLPIC.SelectedIndex = 0;
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

        #region Action
        protected void GvData_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "ubah":
                    SetLayout(ModeForm.EditData);
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

        private void SetLayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.AddData:
                    GenerateCustNo();
                    GenerateComdNo();
                    GeneratePIC();
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtOrderNo.Enabled = true;
                    DDLCustomerno.Enabled = true;
                    DDLComodityNo.Enabled = true;
                    TxtTotalSample.Enabled = true;
                    TxtPriceTotal.Enabled = true;
                    TxtStatus.Enabled = true;
                    TxtTipePayment.Enabled = true;
                    DDLPayed.Enabled = true;
                    TxtPayedDate.Enabled = true;
                    TxtAppr.Enabled = true;
                    DDLPIC.Enabled = true;
                    break;

                case ModeForm.EditData:
                    GenerateCustNo();
                    GenerateComdNo();
                    GeneratePIC();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtOrderNo.Enabled = true;
                    DDLCustomerno.Enabled = true;
                    DDLComodityNo.Enabled = true;
                    TxtTotalSample.Enabled = true;
                    TxtPriceTotal.Enabled = true;
                    TxtStatus.Enabled = true;
                    TxtTipePayment.Enabled = true;
                    DDLPayed.Enabled = true;
                    TxtPayedDate.Enabled = true;
                    TxtAppr.Enabled = true;
                    DDLPIC.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                case ModeForm.DetailData:
                    GenerateCustNo();
                    GenerateComdNo();
                    GeneratePIC();
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    TxtOrderNo.Enabled = true;
                    DDLCustomerno.Enabled = true;
                    DDLComodityNo.Enabled = true;
                    TxtTotalSample.Enabled = true;
                    TxtPriceTotal.Enabled = true;
                    TxtStatus.Enabled = true;
                    TxtTipePayment.Enabled = true;
                    DDLPayed.Enabled = true;
                    TxtPayedDate.Enabled = true;
                    TxtAppr.Enabled = true;
                    DDLPIC.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    break;
            }
        }

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

        protected void ActionImageButton(object sender, ImageClickEventArgs e)
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
        #endregion

        
    }
}