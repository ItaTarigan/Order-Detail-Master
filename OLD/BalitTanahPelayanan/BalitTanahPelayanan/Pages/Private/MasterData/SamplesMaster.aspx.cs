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
    public partial class SamplesMaster : System.Web.UI.Page
    {
        string currentUser = "";
        SampleControls sampleControl = new SampleControls();
        OrderMasterControls orderControl = new OrderMasterControls();

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
            TxtNoBalittanah.Text = "";
            TxtCountNumber.Text = "";
            TxtOrderNo.SelectedIndex = 0;
            TxtSampleCode.Text = "";
            TxtDescription.Text = "";
            TxtSamplingDate.Text = "";
            TxtVillage.Text = "";
            TxtSubDistrict.Text = "";
            TxtDistrict.Text = "";
            TxtProvince.Text = "";
            TxtGps.Text = "";
            TxtLandUSe.SelectedIndex = 0;
            TxtIsReceived.SelectedIndex = 0;
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = sampleControl.GetData();
                var datas = ret.Result;

                foreach (var data in datas)
                    if (data.landUse == "0")
                    {
                        data.landUse = "Tanpa Keterangan";
                    }
                    else if (data.landUse == "1")
                    {
                        data.landUse = "Lahan Sawah";
                    }
                    else if (data.landUse == "2")
                    {
                        data.landUse = "Lahan Kering";
                    }
                    else if (data.landUse == "3")
                    {
                        data.landUse = "Lahan Hutan";
                    }
                    else if (data.landUse == "4")
                    {
                        data.landUse = "Lahan Sulfat Asam";
                    }
                    else if (data.landUse == "5")
                    {
                        data.landUse = "Lahan Lebag";
                    }
                    else if (data.landUse == "6")
                    {
                        data.landUse = "Lahan Gambut";
                    }

                foreach (var data in datas)
                    if (data.isReceived == "0")
                    {
                        data.isReceived = "Belum Diterima";
                    }
                    else
                    {
                        data.isReceived = "Sudah Diterima";
                    }

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = sampleControl.GetDataByContaint(param);
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
            var ret = sampleControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtNoBalittanah.Text = data.noBalittanah;
                TxtOrderNo.SelectedIndex = TxtOrderNo.Items.IndexOf(
                        TxtOrderNo.Items.FindByValue(data.orderNo));
                TxtCountNumber.Text = data.countNumber.ToString();
                TxtSampleCode.Text = data.sampleCode;
                TxtDescription.Text = data.sampleDescription;
                TxtSamplingDate.Text = data.samplingDate.Value.ToShortDateString();
                TxtVillage.Text = data.village;
                TxtSubDistrict.Text = data.subDistrict;
                TxtDistrict.Text = data.district;
                TxtProvince.Text = data.province;
                TxtGps.Text = data.longitude + ", " + data.latitude;
                TxtLandUSe.SelectedIndex = TxtLandUSe.Items.IndexOf(
                        TxtLandUSe.Items.FindByValue(data.landUse));
                TxtIsReceived.SelectedIndex = TxtIsReceived.Items.IndexOf(
                        TxtIsReceived.Items.FindByValue(data.isReceived));
            }
        }

        private void DoUpdate()
        {
            string id = TxtNoBalittanah.Text;
            var data = new ordersampletbl
            {
                noBalittanah = id,
                orderNo = TxtOrderNo.SelectedValue,
                sampleCode = TxtSampleCode.Text,
                countNumber = ParseInt(TxtCountNumber.Text),
                sampleDescription = TxtDescription.Text,
                samplingDate = Formater.ToDate(TxtSamplingDate.Text),
                village = TxtVillage.Text,
                subDistrict = TxtSubDistrict.Text,
                district = TxtDistrict.Text,
                province = TxtProvince.Text,
                longitude = TxtGps.Text,
                landUse = TxtLandUSe.SelectedValue,
                isReceived = TxtIsReceived.SelectedValue,
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = sampleControl.UpdateData(id.ToString(), data);

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
            string id = TxtNoBalittanah.Text;
            var data = new ordersampletbl
            {
                noBalittanah = id,
                orderNo = TxtOrderNo.SelectedValue,
                sampleCode = TxtSampleCode.Text,
                countNumber = ParseInt(TxtCountNumber.Text),
                sampleDescription = TxtDescription.Text,
                samplingDate = Formater.ToDate(TxtSamplingDate.Text),
                village = TxtVillage.Text,
                subDistrict = TxtSubDistrict.Text,
                district = TxtDistrict.Text,
                province = TxtProvince.Text,
                longitude = TxtGps.Text,
                landUse = TxtLandUSe.SelectedValue,
                isReceived = TxtIsReceived.SelectedValue,
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            var ret = sampleControl.AddData(data);

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
            var ret = sampleControl.DeleteData(id);

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
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtNoBalittanah.Text = "Otomatis";
                    TxtOrderNo.Enabled = true;
                    TxtSampleCode.Enabled = true;
                    TxtDescription.Enabled = true;
                    TxtSamplingDate.Enabled = true;
                    TxtVillage.Enabled = true;
                    TxtSubDistrict.Enabled = true;
                    TxtDistrict.Enabled = true;
                    TxtProvince.Enabled = true;
                    TxtGps.Enabled = true;
                    TxtIsReceived.Enabled = true;
                    TxtCountNumber.Enabled = true;
                    TxtLandUSe.Enabled = true;
                    BtnAdd.Visible = true;
                    BtnUpdate.Visible = false;
                    break;

                case ModeForm.UpdateData:
                    GeneratePic();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtOrderNo.Enabled = true;
                    TxtSampleCode.Enabled = true;
                    TxtDescription.Enabled = true;
                    TxtSamplingDate.Enabled = true;
                    TxtVillage.Enabled = true;
                    TxtSubDistrict.Enabled = true;
                    TxtDistrict.Enabled = true;
                    TxtProvince.Enabled = true;
                    TxtGps.Enabled = true;
                    TxtIsReceived.Enabled = true;
                    TxtCountNumber.Enabled = true;
                    TxtLandUSe.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                case ModeForm.DetailData:
                    GeneratePic();
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    TxtOrderNo.Enabled = false;
                    TxtSampleCode.Enabled = false;
                    TxtDescription.Enabled = false;
                    TxtSamplingDate.Enabled = false;
                    TxtVillage.Enabled = false;
                    TxtSubDistrict.Enabled = false;
                    TxtDistrict.Enabled = false;
                    TxtProvince.Enabled = false;
                    TxtGps.Enabled = false;
                    TxtIsReceived.Enabled = false;
                    TxtCountNumber.Enabled = false;
                    TxtLandUSe.Enabled = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    break;
            }
        }
        #endregion
    }
}