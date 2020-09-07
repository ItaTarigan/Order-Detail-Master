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
    public partial class DaftarSuratPermohonan : System.Web.UI.Page
    {
        OrderMasterControls ordermastercontrols = new OrderMasterControls();
        OrderDetailControls orderdetailcontrols = new OrderDetailControls();
        ComodityControls comocontrols = new ComodityControls();
        AnalysisTypeControls analisiscontrols = new AnalysisTypeControls();
        SampleControls sampelcontrols = new SampleControls();
        ElementServicesControls elemencontrol = new ElementServicesControls();

        enum ModeForm { ViewData, DetailData, AddData }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridLayanan();
                RefreshGridSample();
                GenerateAnalisis();
                GenerateComodity();
                GenerateDesa();
                GenerateKec();
                GenerateKab();
                GeneratePro();
            }
        }

        #region Custom Func.
        void ClearFields()
        {
            DDLComodity.SelectedIndex = 0;
            DDLAnalysis.SelectedIndex = 0;
            TxtNoSample.Text = "";
            DDLDesa.SelectedIndex = 0;
            DDLKecamatan.SelectedIndex = 0;
            DDLKabupaten.SelectedIndex = 0;
            DDLProvinsi.SelectedIndex = 0;
        }

        void RefreshGridLayanan(string param = "")
        {
            GvDataLayanan.DataBind();

            if (param == null || param == "")
            {
                var ret = ordermastercontrols.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvDataLayanan.DataSource = datas;
                    GvDataLayanan.DataBind();
                }
            }
            else
            {
                var ret = ordermastercontrols.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvDataLayanan.DataSource = datas;
                    GvDataLayanan.DataBind();
                }
            }
        }

        void RefreshGridSample(string param = "")
        {
            GvDataSample.DataBind();

            if (param == null || param == "")
            {
                var ret = sampelcontrols.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvDataSample.DataSource = datas;
                    GvDataSample.DataBind();
                }
            }
            else
            {
                var ret = sampelcontrols.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvDataSample.DataSource = datas;
                    GvDataSample.DataBind();
                }
            }
        }

        private void DoSaveOrMas()
        {
            var data = new ordermastertbl
            {
                comodityNo = Convert.ToInt32(DDLComodity.SelectedValue),
                analysisType = DDLAnalysis.SelectedValue,
            };

            foreach (GridViewRow grow in GvDataLayanan.Rows)
            {
                var cekbox = grow.FindControl("CBLLayanan") as CheckBox;
                if (cekbox.Checked)
                {

                }
            }

            var ret = ordermastercontrols.AddData(data);

            if (ret.Result)
            {
                ClearFields();
                Alert("data berhasil disimpan");
            }
            else
            {
                Alert("Gagal menyimpan data");
            }
        }

        private void DoSaveOrTail()
        {
            var data = new orderanalysisdetailtbl
            {
                sampleNo = TxtNoSample.Text,
                elementId = Convert.ToInt32(GvDataLayanan.FindControl("CBLLayanan")),

            };

            var ret = orderdetailcontrols.AddData(data);

            if (ret.Result)
            {
                ClearFields();
                Alert("data berhasil disimpan");
            }
            else
            {
                Alert("Gagal menyimpan data");
            }
        }

        private void DoSaveSample()
        {
            var data = new ordersampletbl
            {
                noBalittanah = TxtNoSample.Text,
                village = DDLDesa.SelectedValue,
                subDistrict = DDLKecamatan.SelectedValue,
                district = DDLKabupaten.SelectedValue,
                province = DDLProvinsi.SelectedValue,
            };
            var ret = sampelcontrols.AddData(data);

            if (ret.Result)
            {
                ClearFields();
                Alert("data berhasil disimpan");
            }
            else
            {
                Alert("Gagal menyimpan data");
            }
        }

        private void DoDelete(string id)
        {
            var ret = sampelcontrols.DeleteData(id);

            if (ret.Result)
            {
                RefreshGridSample();
                Alert("Data berhasil dihapus");
            }
            else
            {
                Alert("Gagal menghapus data");
            }
        }

        private void GenerateComodity()
        {
            DDLComodity.Items.Clear();

            var ret = comocontrols.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                DDLComodity.DataSource = datas;
                DDLComodity.DataTextField = "comodityName";
                DDLComodity.DataValueField = "comodityNo";
                DDLComodity.DataBind();
            }

            DDLComodity.SelectedIndex = 0;
        }

        private void GenerateAnalisis()
        {
            DDLComodity.Items.Clear();

            var ret = analisiscontrols.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                DDLAnalysis.DataSource = datas;
                DDLAnalysis.DataTextField = "analysisTypeName";
                DDLAnalysis.DataValueField = "analysisTypeName";
                DDLAnalysis.DataBind();
            }

            DDLAnalysis.SelectedIndex = 0;
        }

        private void GenerateDesa()
        {
            DDLDesa.Items.Clear();

            var desa = sampelcontrols.GetData();
            var village = desa.Result;

            if (village != null && village.Count() > 0)
            {
                DDLDesa.DataSource = village;
                DDLDesa.DataTextField = "village";
                DDLDesa.DataValueField = "village";
                DDLDesa.DataBind();
            }

            DDLDesa.SelectedIndex = 0;
        }

        private void GenerateKec()
        {
            DDLKecamatan.Items.Clear();

            var kecamatan = sampelcontrols.GetData();
            var subDistrict = kecamatan.Result;

            if (subDistrict != null && subDistrict.Count() > 0)
            {
                DDLKecamatan.DataSource = subDistrict;
                DDLKecamatan.DataTextField = "subDistrict";
                DDLKecamatan.DataValueField = "subDistrict";
                DDLKecamatan.DataBind();
            }

            DDLKecamatan.SelectedIndex = 0;
        }

        private void GenerateKab()
        {
            DDLKabupaten.Items.Clear();

            var kabupaten = sampelcontrols.GetData();
            var district = kabupaten.Result;

            if (district != null && district.Count() > 0)
            {
                DDLKabupaten.DataSource = district;
                DDLKabupaten.DataTextField = "district";
                DDLKabupaten.DataValueField = "district";
                DDLKabupaten.DataBind();
            }

            DDLKabupaten.SelectedIndex = 0;
        }

        private void GeneratePro()
        {
            DDLProvinsi.Items.Clear();

            var provinsi = sampelcontrols.GetData();
            var province = provinsi.Result;

            if (province != null && province.Count() > 0)
            {
                DDLProvinsi.DataSource = province;
                DDLProvinsi.DataTextField = "province";
                DDLProvinsi.DataValueField = "province";
                DDLProvinsi.DataBind();
            }

            DDLProvinsi.SelectedIndex = 0;
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

        #region Action Func
        protected void ActionButton(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var command = btn.CommandName;

                switch (command)
                {
                    case "pesan":
                        DoSaveOrMas();
                        DoSaveOrTail();
                        break;

                    case "addsample":
                        DoSaveSample();
                        break;
                    case "hapus":
                        //DoDelete();
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