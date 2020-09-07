using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private.Customer
{
    public partial class CustomerBuatPesananTouch : System.Web.UI.Page
    {
        static NumberCounter CounterGen;
        static LocationHelper2 location;
        string currentUser = CommonWeb.GetCurrentUser();
        PesananCustomerControls pcc = new PesananCustomerControls();
        void GetTranslation()
        {
            BtnAddSampel.Text = LanguageHelper.GetTranslation("sample_new");
            BtnBatal.Text = LanguageHelper.GetTranslation("back");
            BtnSimpan.Text = LanguageHelper.GetTranslation("process");
            BtnSimpanSampel.Text = LanguageHelper.GetTranslation("save");
            BtnBatalSampel.Text = LanguageHelper.GetTranslation("cancel");

            GvParameter.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            GvData.EmptyDataText = LanguageHelper.GetTranslation("empty_data");

            lblTambahPesananBaru.Text = LanguageHelper.GetTranslation("add_new_order");
            lblSilahkanInput.Text = LanguageHelper.GetTranslation("please_input");
            lblDaftarSample.Text = LanguageHelper.GetTranslation("sample_list");
            lblDaftarParameter.Text = LanguageHelper.GetTranslation("List_of_Test_Parameters");
            lblTanggalDiterima.Text = LanguageHelper.GetTranslation("date_received");
            cmb2Komoditas.Text = LanguageHelper.GetTranslation("commodity");
            //cmb2SubKomoditas.Text = LanguageHelper.GetTranslation("sub_commodity");
            cmb2JenisAnalisa.Text = LanguageHelper.GetTranslation("analysis_type");
            lblInputDataSample.Text = LanguageHelper.GetTranslation("input_sample_data");

            lbspta.Text = LanguageHelper.GetTranslation("choose_type_analysis");
            //lbspsk.Text = LanguageHelper.GetTranslation("select_sub_comodity");
            lbspk.Text = LanguageHelper.GetTranslation("choose_a_comodity");
            lbtp.Text = LanguageHelper.GetTranslation("order_date");
            BtnPilihCommodity.Text = LanguageHelper.GetTranslation("choose");
            Nsc.Text = LanguageHelper.GetTranslation("no_sample_customer");
            nsbt.Text = LanguageHelper.GetTranslation("no_sampel_balit_tanah");
            sits.Text = LanguageHelper.GetTranslation("fill_sampling_date");
            sptt.Text = LanguageHelper.GetTranslation("choose_type_soil");
            sikts.Text = LanguageHelper.GetTranslation("fill_detail_sample");
            TxtKeterangan.Attributes["placeholder"] = LanguageHelper.GetTranslation("desc_sample");
            sildl.Text = LanguageHelper.GetTranslation("fill_latitude_longitude");
            sknd.Text = LanguageHelper.GetTranslation("type_name_vilage");
            sknk.Text = LanguageHelper.GetTranslation("type_name_subdistrict");
            spk.Text = LanguageHelper.GetTranslation("type_name_district");
            spp.Text = LanguageHelper.GetTranslation("choose_province");

            lblNoSample.Text = LanguageHelper.GetTranslation("sample_no");
            lblNoBalittanah.Text = LanguageHelper.GetTranslation("balittanah_no");
            lblTglSampling.Text = LanguageHelper.GetTranslation("sampling_date");
            cmb2TipeTanah.Text = LanguageHelper.GetTranslation("soil_type");
            lblKeterangan.Text = LanguageHelper.GetTranslation("remark");
            cmb2Provinsi.Text = LanguageHelper.GetTranslation("province");
            cmb2Kabupaten.Text = LanguageHelper.GetTranslation("district");
            cmb2Kecamatan.Text = LanguageHelper.GetTranslation("sub_district");
            cmb2Desa.Text = LanguageHelper.GetTranslation("village");
            lblLokasi.Text = LanguageHelper.GetTranslation("gps_coordinates");

            lblJumlahParameterUji.Text = LanguageHelper.GetTranslation("total_parameter_uji");
            lblJumlahSample.Text = LanguageHelper.GetTranslation("total_sample");
            lblTotalBiaya.Text = LanguageHelper.GetTranslation("total_biaya");

            lblKonfirmasiPesananBaru.Text = LanguageHelper.GetTranslation("ConfirmNewOrder");
            lblInfoPelanggan.Text = LanguageHelper.GetTranslation("customer_info");
            name.Text = LanguageHelper.GetTranslation("name");
            instansi.Text = LanguageHelper.GetTranslation("agency");
            lblInfoPesanan.Text = LanguageHelper.GetTranslation("order_info");
            tanggal.Text = LanguageHelper.GetTranslation("date");
            noPesanan.Text = LanguageHelper.GetTranslation("ord_no");
            komoditas.Text = LanguageHelper.GetTranslation("Lit_Komoditas");
            jnsAnalisis.Text = LanguageHelper.GetTranslation("analisystype");
            infoSampel.Text = LanguageHelper.GetTranslation("sample_info");
            parameterUji.Text = LanguageHelper.GetTranslation("test_parameter");
            lblJmlParamUji.Text = LanguageHelper.GetTranslation("total_parameter_uji");
            lblJmlSampel.Text = LanguageHelper.GetTranslation("sampletot");
            lblTotBiaya.Text = LanguageHelper.GetTranslation("total_biaya");
            SayaSetuju.Text = LanguageHelper.GetTranslation("iagree");
            BtnSOP.Text = LanguageHelper.GetTranslation("SOP");
            BtnKembali.Text = LanguageHelper.GetTranslation("back");
            BtnSetuju.Text = LanguageHelper.GetTranslation("agree");
            BtnTutup.Text = LanguageHelper.GetTranslation("close");

            //Translate Tambahan Biaya
            LblTambahanBiaya.Text = LanguageHelper.GetTranslation("extra_cost");
            LblJumlahGenus.Text = LanguageHelper.GetTranslation("genus_total");
            LblHargaPerGenus.Text = LanguageHelper.GetTranslation("price_per_genus");
            LblTotalHargaGenus.Text = LanguageHelper.GetTranslation("total_add_genus");


            ChkLogamBerat.Text = LanguageHelper.GetTranslation("metal_test");
            lblHargaLogam.Text = LanguageHelper.GetTranslation("harga_logam");
            lblTotalTambahan.Text = LanguageHelper.GetTranslation("total_tambahan");

            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }
        public enum TambahanBiayaTypes { None, Genus, UjiLogamBerat };
        public TambahanBiayaTypes TambahanBiayaType
        {
            get
            {
                if (Session["TambahanBiayaType"] == null)
                {
                    var newData = TambahanBiayaTypes.None;
                    Session["TambahanBiayaType"] = newData;
                }
                return (TambahanBiayaTypes)Session["TambahanBiayaType"];
            }
            set
            {
                Session["TambahanBiayaType"] = value;
            }
        }
        public List<elementservicestbl> DataParameter
        {
            get
            {
                if (Session["DataParameter"] == null)
                {
                    var newData = new List<elementservicestbl>();
                    Session["DataParameter"] = newData;
                }
                return Session["DataParameter"] as List<elementservicestbl>;
            }
            set
            {
                Session["DataParameter"] = value;
            }
        }
        public Dictionary<int, string> ListCodeBalittanah
        {
            get
            {
                if (Session["ListCode"] == null)
                {
                    var newData = new Dictionary<int, string>();
                    Session["ListCode"] = newData;
                }
                return Session["ListCode"] as Dictionary<int, string>;
            }
            set
            {
                Session["ListCode"] = value;
            }
        }
        public List<ordersampletbl> DataSampel
        {
            get
            {
                if (Session["DataSampel"] == null)
                {
                    var newData = new List<ordersampletbl>();
                    Session["DataSampel"] = newData;
                }
                return Session["DataSampel"] as List<ordersampletbl>;
            }
            set
            {
                Session["DataSampel"] = value;
            }
        }
        public packagetbl Paket
        {
            get
            {
                if (Session["Paket"] == null)
                {
                    return null;
                }
                return Session["Paket"] as packagetbl;
            }
            set
            {
                Session["Paket"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderNav.comoditySelected += OrderNav_comoditySelected;
            OrderNav.exitNavigation += OrderNav_exitNavigation;
            BtnPilihCommodity.Click += BtnPilihCommodity_Click;
            GvData.RowDataBound += GvData_RowDataBound;
            GvParameter.RowDataBound += GvParameter_RowDataBound;
            GvSample2.RowDataBound += GvSample2_RowDataBound;
            GvParameter2.RowDataBound += GvParameter2_RowDataBound;
            TxtJmlGenus.TextChanged += TxtJmlGenus_TextChanged;
            ChkLogamBerat.CheckedChanged += ChkLogamBerat_CheckedChanged;

            GvData.Columns[3].Visible = false;
            GvData.Columns[4].Visible = false;
            GvData.Columns[5].Visible = false;
            GvData.Columns[6].Visible = false;
            GvData.Columns[7].Visible = false;
            GvData.Columns[8].Visible = false;

            GvSample2.Columns[3].Visible = false;
            GvSample2.Columns[4].Visible = false;
            GvSample2.Columns[5].Visible = false;
            GvSample2.Columns[6].Visible = false;
            GvSample2.Columns[7].Visible = false;
            GvSample2.Columns[8].Visible = false;
            if (!IsPostBack)
            {
                GetTranslation();
                CounterGen = new NumberCounter();
                var pathLoc = Server.MapPath("~/assets") + "/wilayah.csv";
                if (location == null) location = new LocationHelper2(pathLoc);
                LitTotalBiaya.Text = "0";
                LitJmlParameterUji.Text = "0";
                LitJumlahSampel.Text = "0";
                LoadPage();
                TxtNoOrder.Text = GenerateNoOrder();
                Session["DataSampel"] = null;
            }
            GvData.RowCommand += GvData_RowCommand;

        }

        private void ChkLogamBerat_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkLogamBerat.Checked)
            {
                CalculateTotal(null, null);
            }
        }

        private void TxtJmlGenus_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtJmlGenus.Text))
                CalculateTotal(null, null);
        }

        private void OrderNav_comoditySelected(int commodityNo, string commodityName)
        {
            ShowZone(1);
            HidCommodityNo.Value = commodityNo.ToString();
            TxtKomoditas.Text = commodityName;
            LoadParameterUji(commodityNo, CmbJenisAnalisa.SelectedValue);
            var comSelected = pcc.GetCommodityByNo(commodityNo);
            if (comSelected != null)
            {
                if (!string.IsNullOrEmpty(comSelected.description))
                {
                    LitKeterangan.Text = comSelected.description;
                    SpanKeterangan.Visible = true;
                }
                else
                {
                    SpanKeterangan.Visible = false;
                }
                if (comSelected.isGenusAvailable == "1")
                {
                    DivTambahanBiayaTitle.Visible = true;
                    DivTambahanBiayaGenus.Visible = true;
                    DivTambahanBiayaLogamBerat.Visible = false;

                    TambahanBiayaType = TambahanBiayaTypes.Genus;

                    TxtHargaGenus.Text = comSelected.priceGenusPerSample?.ToString("n2");
                    TxtJmlGenus.Text = "0";
                    TxtTotalHargaGenus.Text = "0";
                }
                else if (comSelected.isHeavyMetalAvailable == "1")
                {
                    TambahanBiayaType = TambahanBiayaTypes.UjiLogamBerat;
                    DivTambahanBiayaTitle.Visible = true;
                    DivTambahanBiayaGenus.Visible = false;
                    DivTambahanBiayaLogamBerat.Visible = true;
                    TxtHargaUjiLogamBerat.Text = comSelected.priceHeavyMetalPerSample?.ToString("n2");
                    TxtTotalHargaLogamBerat.Text = "0";
                    ChkLogamBerat.Checked = false;
                }
                else
                {
                    TambahanBiayaType = TambahanBiayaTypes.None;
                    DivTambahanBiayaTitle.Visible = false;
                    DivTambahanBiayaGenus.Visible = false;
                    DivTambahanBiayaLogamBerat.Visible = false;
                }
            }
        }
        void LoadParameterUji(int commodityNo, string AnalysisType)
        {
            if (commodityNo > 0)
            {

                var datas = pcc.GetParameterUjiByCommodityNo(commodityNo, AnalysisType, out var package);
                Paket = package;
                if (Paket != null)
                {
                    SpanHargaPaket.Visible = true;
                    LitTotalHargaPaket.Text = Paket.bundlePrice?.ToString("n2");
                }
                else
                {
                    SpanHargaPaket.Visible = false;
                }
                GvParameter.DataSource = datas;
                GvParameter.DataBind();
                DataParameter = datas.ToList();
                UpdateJumlahContoh();
                CalculateTotal(null, null);
                LitJmlParameterUji.Text = datas.Count().ToString();

            }
            else
            {
                GvParameter.DataSource = null;
                GvParameter.DataBind();
                LitTotalBiaya.Text = "0";
                LitJmlParameterUji.Text = "0";
            }
        }
        private void OrderNav_exitNavigation()
        {
            ShowZone(1);
        }

        private void BtnPilihCommodity_Click(object sender, EventArgs e)
        {
            ShowZone(2);
            OrderNav.Reset();
        }

        private void GvParameter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("choose");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("element_code");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("element_code");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("rates_per_example");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("total_example");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("cost");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var hidMandatory = e.Row.FindControl("HidMandatory") as HiddenField;
                var chk = e.Row.FindControl("isChecked") as CheckBox;
                if (hidMandatory != null)
                {

                    chk.Checked = hidMandatory.Value == "1";
                    if (Paket != null)
                        chk.Enabled = false;
                    else
                        chk.Enabled = true;
                }
            }
        }

        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("serial_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_no");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("balittanah_no");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("soil_type");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("gps_coordinates");
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtnUbah = e.Row.FindControl("BtnUbah") as LinkButton;
                if (linkBtnUbah != null)
                    linkBtnUbah.Text = LanguageHelper.GetTranslation("change");

                var linkBtnHapus = e.Row.FindControl("BtnHapus") as LinkButton;
                if (linkBtnHapus != null)
                    linkBtnHapus.Text = LanguageHelper.GetTranslation("delete");

                var linkBtnDuplikat = e.Row.FindControl("BtnDuplikat") as LinkButton;
                if (linkBtnDuplikat != null)
                    linkBtnDuplikat.Text = LanguageHelper.GetTranslation("duplicate");
            }
        }


        void UpdateJumlahContoh()
        {
            if (GvParameter != null && GvParameter.Rows.Count > 0)
            {
                foreach (GridViewRow e in GvParameter.Rows)
                {
                    var txt = e.FindControl("txtJumlahContoh") as TextBox;
                    if (txt != null)
                    {
                        if (DataSampel != null)
                        {
                            txt.Text = DataSampel.Count.ToString();
                        }
                    }
                }
                CalculateTotal(null, null);
            }
        }

        void UpdateJumlahContoh2()
        {
            if (GvParameter2 != null && GvParameter2.Rows.Count > 0)
            {
                foreach (GridViewRow e in GvParameter2.Rows)
                {
                    var txt = e.FindControl("txtJumlahContoh") as TextBox;
                    if (txt != null)
                    {
                        if (DataSampel != null)
                        {
                            txt.Text = DataSampel.Count.ToString();
                        }
                    }
                }
                CalculateTotal2(null, null);
            }
        }
        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                var command = e.CommandName;

                switch (command)
                {
                    case "Hapus":
                        DelRowGv(e.CommandArgument.ToString());
                        break;

                    case "Duplikat":
                        DoDuplicate(e.CommandArgument.ToString());
                        break;
                    case "Ubah":
                        ShowZone(0);
                        var NoBalit = e.CommandArgument.ToString();
                        var item = DataSampel.Where(x => x.noBalittanah == NoBalit).FirstOrDefault();
                        if (item != null)
                        {
                            TxtNoSampel.Text = item.sampleCode;

                            TxtNoBalitTanah.Text = item.noBalittanah;

                            CmbPropinsi.SelectedItem.Text = item.province;
                            CmbKabupaten.SelectedItem.Text = item.district;
                            CmbKecamatan.SelectedItem.Text = item.subDistrict;
                            CmbDesa.SelectedItem.Text = item.village;
                            TxtLatitude.Text = item.latitude.ToString();
                            TxtLongitude.Text = item.longitude.ToString();

                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi Kesalahan");
            }
        }

        private void LoadPage()
        {
            TxtTanggalDiterima.Text = DatetimeHelper.GetDatetimeNow().ToString("yyyy-MM-dd");
            CmbPropinsi.DataSource = location.GetPropinsi();
            CmbPropinsi.DataTextField = "Nama";
            CmbPropinsi.DataValueField = "Key";
            CmbPropinsi.DataBind();
            CmbPropinsi.SelectedIndex = 0;
            LoadKabupaten();
            LoadKecamatan();
            LoadDesa();

            GenerateAnalisis();
            //GenerateKomoditas();
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            DataTable table = new DataTable();

            table.Columns.Add("countNumber", typeof(int));
            table.Columns.Add("sampleCode", typeof(string));
            table.Columns.Add("noBalittanah", typeof(string));
            table.Columns.Add("village", typeof(string));
            table.Columns.Add("subDistrict", typeof(string));
            table.Columns.Add("district", typeof(string));
            table.Columns.Add("province", typeof(string));
            table.Columns.Add("landUse", typeof(string));
            table.Columns.Add("latitude", typeof(string));
            table.Columns.Add("longitude", typeof(string));

            GvData.DataSource = table;
            GvData.DataBind();
        }
        /*
        private void GenerateKomoditas()
        {
            CmbKomoditas.Items.Clear();
            CmbKomoditas.Items.Insert(0, new ListItem("Pilih", "-1"));

            var ret = pcc.GetKomodity();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                CmbKomoditas.DataSource = datas;
                CmbKomoditas.DataTextField = "comodityName";
                CmbKomoditas.DataValueField = "comodityNo";
                CmbKomoditas.DataBind();
            }
            CmbKomoditas.SelectedIndex = 0;
        }

        protected void GenerateChildKomoditas(object sender, EventArgs e)
        {
            if (CmbKomoditas.SelectedIndex != 0)
            {
                CmbSubKomoditas.Items.Clear();
                CmbSubKomoditas.Items.Insert(0, new ListItem("Pilih", "-1"));

                int id = int.Parse(CmbKomoditas.SelectedValue);
                var ret = pcc.GetKomoditiChild(id);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    CmbSubKomoditas.DataSource = datas;
                    CmbSubKomoditas.DataTextField = "comodityName";
                    CmbSubKomoditas.DataValueField = "comodityNo";
                    CmbSubKomoditas.DataBind();
                }
                CmbSubKomoditas.SelectedIndex = 0;
                GenerateParameterUji(null, null);
            }
        }
        */
        protected void CalculateTotal(object sender, EventArgs e)
        {
            decimal totalBiaya = 0;
            foreach (GridViewRow gvrow in GvParameter.Rows)
            {
                var chk = gvrow.FindControl("isChecked") as CheckBox;
                if (chk.Checked)
                {
                    var tarif = gvrow.FindControl("txtTarif") as Label;
                    var jumlah = gvrow.FindControl("txtJumlahContoh") as TextBox;
                    var biaya = gvrow.FindControl("txtBiaya") as Label;

                    decimal hasil = Formater.ToNumber(tarif.Text) * int.Parse(jumlah.Text);
                    biaya.Text = Formater.ToRupiah(hasil);
                    totalBiaya += hasil;
                }
            }
            decimal TambahanBiaya = 0;
            if (TambahanBiayaType == TambahanBiayaTypes.Genus)
            {
                decimal.TryParse(TxtHargaGenus.Text, out var HargaGenus);
                decimal.TryParse(TxtJmlGenus.Text, out var JmlGenus);
                TambahanBiaya = HargaGenus * JmlGenus * DataSampel.Count;
                TxtTotalHargaGenus.Text = TambahanBiaya.ToString("n2");
                HidTambahanBiaya.Value = $"Tambahan Biaya (Harga Genus x Jml. Genus x Jml. Sampel) Rp.{HargaGenus} x {JmlGenus.ToString("n2")} x {DataSampel.Count.ToString("n2")} = Rp. {TambahanBiaya.ToString("n2")}";
            }
            else if (TambahanBiayaType == TambahanBiayaTypes.UjiLogamBerat)
            {
                if (ChkLogamBerat.Checked)
                {
                    decimal.TryParse(TxtHargaUjiLogamBerat.Text, out var HargaLogam);
                    TambahanBiaya = HargaLogam * DataSampel.Count;
                    TxtTotalHargaLogamBerat.Text = TambahanBiaya.ToString("n2");
                    HidTambahanBiaya.Value = $"Tambahan Biaya (Harga Uji Logam Berat x Jml. Sampel) Rp.{HargaLogam} x {DataSampel.Count.ToString("n2")} = Rp. {TambahanBiaya.ToString("n2")}";

                }
                else
                {
                    TxtTotalHargaLogamBerat.Text = "0";
                }
            }
            if (Paket != null)
                LitTotalBiaya.Text = (Paket.bundlePrice * DataSampel.Count + TambahanBiaya)?.ToString("n2");
            else
                LitTotalBiaya.Text = (totalBiaya + TambahanBiaya).ToString("n2");
        }
        protected void CalculateTotal2(object sender, EventArgs e)
        {
            decimal totalBiaya = 0;
            foreach (GridViewRow gvrow in GvParameter2.Rows)
            {
                var chk = gvrow.FindControl("isChecked") as CheckBox;
                if (chk.Checked)
                {
                    var tarif = gvrow.FindControl("txtTarif") as Label;
                    var jumlah = gvrow.FindControl("txtJumlahContoh") as TextBox;
                    var biaya = gvrow.FindControl("txtBiaya") as Label;

                    decimal hasil = Formater.ToNumber(tarif.Text) * int.Parse(jumlah.Text);
                    biaya.Text = Formater.ToRupiah(hasil);
                    totalBiaya += hasil;
                }
            }

        }
        protected void DoChecked(object sender, EventArgs e)
        {
            int totalParameterUji = 0;
            foreach (GridViewRow gvrow in GvParameter.Rows)
            {
                var chkbx = gvrow.FindControl("isChecked") as CheckBox;
                if (chkbx.Checked)
                {
                    totalParameterUji++;
                }

            }
            CalculateTotal(null, null);
            LitJmlParameterUji.Text = totalParameterUji.ToString();
        }


        private void GenerateAnalisis()
        {

            CmbJenisAnalisa.Items.Clear();
            CmbJenisAnalisa.Items.Insert(0, new ListItem("Pilih", "-1"));

            var ret = pcc.GetAnalysis();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                CmbJenisAnalisa.DataSource = datas;
                CmbJenisAnalisa.DataTextField = "analysisTypeName";
                CmbJenisAnalisa.DataValueField = "analysisTypeName";
                CmbJenisAnalisa.DataBind();
            }
            CmbJenisAnalisa.SelectedIndex = 0;
        }

        protected void GenerateParameterUji(object sender, EventArgs e)
        {
            //List<GridParameter> checkedparam = new List<GridParameter>();
            if (CmbJenisAnalisa.SelectedIndex != 0 && !string.IsNullOrEmpty(HidCommodityNo.Value))
            {
                LoadParameterUji(int.Parse(HidCommodityNo.Value), CmbJenisAnalisa.SelectedValue);
            }
        }

        private void AddSampel(bool Update = false)
        {
            List<ordersampletbl> sampel = DataSampel;
            DataTable table = new DataTable();
            table.Columns.Add("countNumber", typeof(int));
            table.Columns.Add("sampleCode", typeof(string));
            table.Columns.Add("noBalittanah", typeof(string));
            table.Columns.Add("village", typeof(string));
            table.Columns.Add("subDistrict", typeof(string));
            table.Columns.Add("district", typeof(string));
            table.Columns.Add("province", typeof(string));
            table.Columns.Add("landUse", typeof(string));
            table.Columns.Add("longitude", typeof(string));
            table.Columns.Add("latitude", typeof(string));


            if (!Update)
            {
                var isDuplicateSampleCode = sampel.Any(x => x.sampleCode == TxtNoSampel.Text);
                if (isDuplicateSampleCode)
                {
                    CommonWeb.Alert(this, "No. sampel sudah dimasukan sebelumnya, mohon periksa kembali");
                    return;
                }
                sampel.Add(new ordersampletbl
                {
                    orderNo = TxtNoOrder.Text,
                    countNumber = sampel.Count + 1,
                    sampleCode = TxtNoSampel.Text,
                    noBalittanah = GenerateNoBalitTanah(sampel.Count + 1),
                    village = CmbDesa.SelectedItem.Text,
                    subDistrict = CmbKecamatan.SelectedItem.Text,
                    district = CmbKabupaten.SelectedItem.Text,
                    province = CmbPropinsi.SelectedItem.Text,
                    landUse = CmbTipeTanah.Text,
                    longitude = TxtLongitude.Text,
                    latitude = TxtLatitude.Text,
                    creaBy = currentUser,
                    creaDate = DatetimeHelper.GetDatetimeNow(),
                    modBy = currentUser,
                    modDate = DatetimeHelper.GetDatetimeNow(),
                    sampleDescription = TxtKeterangan.Text,
                    samplingDate = DateTime.Parse(TxtTglSampling.Text)
                });

            }
            else
            {
                var updatedItem = sampel.Where(x => x.noBalittanah == TxtNoBalitTanah.Text).FirstOrDefault();

                if (updatedItem != null)
                {
                    var isDuplicateSampleCode = sampel.Any(x => x.sampleCode == TxtNoSampel.Text && TxtNoSampel.Text != updatedItem.sampleCode);
                    if (isDuplicateSampleCode)
                    {
                        CommonWeb.Alert(this, "No. sampel sudah dimasukan sebelumnya, mohon periksa kembali");
                        return;
                    }
                    updatedItem.sampleCode = TxtNoSampel.Text;
                    updatedItem.village = CmbDesa.SelectedItem.Text;
                    updatedItem.subDistrict = CmbKecamatan.SelectedItem.Text;
                    updatedItem.district = CmbKabupaten.SelectedItem.Text;
                    updatedItem.province = CmbPropinsi.SelectedItem.Text;
                    updatedItem.landUse = CmbTipeTanah.Text;
                    updatedItem.longitude = TxtLongitude.Text;
                    updatedItem.latitude = TxtLatitude.Text;
                    updatedItem.sampleDescription = TxtKeterangan.Text;
                    updatedItem.samplingDate = DateTime.Parse(TxtTglSampling.Text);
                }
            }
            if (sampel.Count > 0)
            {
                var sort = sampel.OrderBy(o => o.countNumber);
                sampel = sort.ToList();

                foreach (var data in sampel)
                {
                    table.Rows.Add(data.countNumber, data.sampleCode, data.noBalittanah, data.village,
                        data.subDistrict, data.district, data.province, data.landUse,
                        data.longitude, data.latitude);
                }
            }

            LitJumlahSampel.Text = sampel.Count.ToString();

            GvData.DataSource = table;
            GvData.DataBind();
            DataSampel = sampel;
            ShowZone(1);
            UpdateJumlahContoh();
        }

        private void DelRowGv(string param)
        {
            List<ordersampletbl> sampel = DataSampel;
            DataTable table = new DataTable();
            table.Columns.Add("countNumber", typeof(int));
            table.Columns.Add("sampleCode", typeof(string));
            table.Columns.Add("noBalittanah", typeof(string));
            table.Columns.Add("village", typeof(string));
            table.Columns.Add("subDistrict", typeof(string));
            table.Columns.Add("district", typeof(string));
            table.Columns.Add("province", typeof(string));
            table.Columns.Add("landUse", typeof(string));
            table.Columns.Add("longitude", typeof(string));
            table.Columns.Add("latitude", typeof(string));

            var delItem = sampel.Where(x => x.noBalittanah == param).FirstOrDefault();
            if (delItem != null)
            {
                sampel.Remove(delItem);
                int counter = 1;
                foreach (var item in sampel)
                {
                    item.countNumber = counter++;
                }
            }
            /*
            if (GvData.Rows.Count > 0)
            {
                for (int i = 0; i < GvData.Rows.Count; i++)
                {
                    if (GvData.Rows[i].Cells[2].Text != param)
                    {
                        sampel.Add(new ordersampletbl
                        {
                            countNumber = i + 1,
                            sampleCode = GvData.Rows[i].Cells[1].Text,
                            noBalittanah = GvData.Rows[i].Cells[2].Text,
                            village = GvData.Rows[i].Cells[3].Text,
                            subDistrict = GvData.Rows[i].Cells[4].Text,
                            district = GvData.Rows[i].Cells[5].Text,
                            province = GvData.Rows[i].Cells[6].Text,
                            landUse = GvData.Rows[i].Cells[7].Text,
                            longitude = GvData.Rows[i].Cells[8].Text,
                            latitude = GvData.Rows[i].Cells[9].Text
                        });
                    }
                }
            }
            */

            if (sampel.Count > 0)
            {
                var sort = sampel.OrderBy(o => o.countNumber);
                sampel = sort.ToList();

                foreach (var data in sampel)
                {
                    table.Rows.Add(data.countNumber, data.sampleCode, data.noBalittanah, data.village,
                        data.subDistrict, data.district, data.province, data.landUse,
                        data.longitude, data.latitude);
                }
            }

            LitJumlahSampel.Text = sampel.Count.ToString();

            GvData.DataSource = table;
            GvData.DataBind();
            DataSampel = sampel;
            UpdateJumlahContoh();
        }


        private void DoSave()
        {

            List<ordersampletbl> sampel = DataSampel;
            ordermastertbl order = new ordermastertbl();
            List<orderpricedetailtbl> parameter = new List<orderpricedetailtbl>();
            var LastNum = CounterGen.Increment("BALITTANAH");
            var NewOrderNo = GenerateNoOrder(LastNum);
            foreach (var item in sampel)
            {
                item.orderNo = NewOrderNo;
                item.noBalittanah = GenerateNoBalitTanah(CounterGen.Increment("SAMPEL"), LastNum);
            }
            order = new ordermastertbl
            {
                orderNo = NewOrderNo,
                customerNo = pcc.GetCustomerNo(currentUser),
                comodityNo = int.Parse(HidCommodityNo.Value),
                analysisType = CmbJenisAnalisa.SelectedValue,
                sampleTotal = sampel.Count,
                priceTotal = Decimal.Parse(LitTotBiaya.Text),
                statusType = "Komersial",
                paymentStatus = Status.PaymentStatus[0],
                status = Status.OrderStatus[0],
                ppn = Decimal.Parse(LitTotBiaya.Text) * 10 / 100,
                receiptDate = Formater.ToDate(TxtTanggalDiterima.Text),
                isPaid = "0",
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow(),
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow(),
                packageName = Paket?.packageName,
                additionalPrice1 = Paket?.additionalPrice1,
                additionalPrice2 = Paket?.additionalPrice2,
                additionalPriceRemark = TambahanBiayaType != TambahanBiayaTypes.None ? HidTambahanBiaya.Value : ""
            };

            foreach (GridViewRow gvrow in GvParameter.Rows)
            {
                var chkbx = gvrow.FindControl("isChecked") as CheckBox;
                if (chkbx.Checked)
                {
                    var element = gvrow.FindControl("txtParameterId") as Label;
                    var price = gvrow.FindControl("txtTarif") as Label;
                    var qty = gvrow.FindControl("txtJumlahContoh") as TextBox;
                    var total = gvrow.FindControl("txtBiaya") as Label;
                    parameter.Add(new orderpricedetailtbl
                    {
                        orderNo = NewOrderNo,
                        elementId = int.Parse(element.Text),
                        price = Formater.ToNumber(price.Text),
                        quantity = int.Parse(qty.Text),
                        TotalPrice = Formater.ToNumber(total.Text)

                    });
                }
            }

            var ret = pcc.SaveOrder(order, sampel, parameter);
            if (ret.Result)
            {
                CommonWeb.Alert(this, "Berhasil menyimpan.");
                Response.Redirect("CustomerBerandaTouch.aspx");
            }
            else
            {
                CommonWeb.Alert(this, "Terjadi kesalahan saat menyimpan data. Silakan coba kembali nanti.");
            }
        }


        protected void CheckedAll(object sender, EventArgs e)
        {

            var masterchk = sender as CheckBox;

            if (masterchk.Checked)
            {
                foreach (GridViewRow gvrow in GvParameter.Rows)
                {
                    var chkbx = gvrow.FindControl("isChecked") as CheckBox;
                    chkbx.Checked = true;
                }
            }
            else if (!masterchk.Checked)
            {
                foreach (GridViewRow gvrow in GvParameter.Rows)
                {
                    var chkbx = gvrow.FindControl("isChecked") as CheckBox;
                    chkbx.Checked = false;
                }
            }
        }

        private void DoDuplicate(string NoBalitTanah)
        {
            var sampel = DataSampel.Where(x => x.noBalittanah == NoBalitTanah).FirstOrDefault();
            if (sampel != null)
            {
                DataTable table = new DataTable();
                table.Columns.Add("countNumber", typeof(int));
                table.Columns.Add("sampleCode", typeof(string));
                table.Columns.Add("noBalittanah", typeof(string));
                table.Columns.Add("village", typeof(string));
                table.Columns.Add("subDistrict", typeof(string));
                table.Columns.Add("district", typeof(string));
                table.Columns.Add("province", typeof(string));
                table.Columns.Add("landUse", typeof(string));
                table.Columns.Add("longitude", typeof(string));
                table.Columns.Add("latitude", typeof(string));

                DataSampel.Add(new ordersampletbl
                {
                    orderNo = sampel.orderNo,
                    countNumber = DataSampel.Count + 1,
                    sampleCode = "SAMPLE/" + shortid.ShortId.Generate(true, false, 10),
                    noBalittanah = GenerateNoBalitTanah(DataSampel.Count + 1),
                    village = sampel.village,
                    subDistrict = sampel.subDistrict,
                    district = sampel.district,
                    province = sampel.province,
                    landUse = sampel.landUse,
                    longitude = sampel.longitude,
                    latitude = sampel.latitude,
                    creaBy = currentUser,
                    creaDate = DatetimeHelper.GetDatetimeNow(),
                    modBy = currentUser,
                    modDate = DatetimeHelper.GetDatetimeNow()
                    ,
                    samplingDate = sampel.samplingDate,
                    sampleDescription = sampel.sampleDescription
                });

                if (DataSampel.Count > 0)
                {
                    var sort = DataSampel.OrderBy(o => o.countNumber);
                    DataSampel = sort.ToList();

                    foreach (var data in DataSampel)
                    {
                        table.Rows.Add(data.countNumber, data.sampleCode, data.noBalittanah, data.village,
                            data.subDistrict, data.district, data.province, data.landUse,
                            data.longitude, data.latitude);
                    }
                }

                LitJumlahSampel.Text = DataSampel.Count.ToString();

                GvData.DataSource = table;
                GvData.DataBind();
                UpdateJumlahContoh();
            }


        }

        void ShowZone(int Zone)
        {
            switch (Zone)
            {
                //input sampel
                case 0:
                    DivRow1.Visible = false;
                    DivRow2.Visible = false;
                    DivRow3.Visible = false;
                    DivRow4.Visible = false;
                    DivRow5.Visible = false;
                    DivRow6.Visible = false;
                    DivRow7.Visible = false;
                    DivRow8.Visible = false;
                    DivRow9.Visible = false;
                    DivRow10.Visible = true;
                    DivRow11.Visible = true;
                    DivRow12.Visible = false;

                    DivPesananBaru.Visible = false;
                    DivInfoPelanggan.Visible = false;
                    DivInfoPesanan.Visible = false;
                    DivInfoSampel.Visible = false;
                    DivInfoParameterUji.Visible = false;
                    DivHarga.Visible = false;
                    DivAgreement.Visible = false;
                    DivButton.Visible = false;

                    DivSOP.Visible = false;
                    DivBtnTutup.Visible = false;

                    DivTambahanBiayaTitle.Visible = false;
                    DivTambahanBiayaGenus.Visible = false;
                    DivTambahanBiayaLogamBerat.Visible = false;
                    break;
                //grid sampel
                case 1:
                    DivRow1.Visible = true;
                    DivRow2.Visible = true;
                    DivRow3.Visible = true;
                    DivRow4.Visible = true;
                    DivRow5.Visible = true;
                    DivRow6.Visible = true;
                    DivRow7.Visible = true;
                    DivRow8.Visible = true;
                    DivRow9.Visible = true;
                    DivRow10.Visible = false;
                    DivRow11.Visible = false;
                    DivRow12.Visible = false;

                    DivPesananBaru.Visible = false;
                    DivInfoPelanggan.Visible = false;
                    DivInfoPesanan.Visible = false;
                    DivInfoSampel.Visible = false;
                    DivInfoParameterUji.Visible = false;
                    DivHarga.Visible = false;
                    DivAgreement.Visible = false;
                    DivButton.Visible = false;

                    DivSOP.Visible = false;
                    DivBtnTutup.Visible = false;
                    if (TambahanBiayaType == TambahanBiayaTypes.None)
                    {
                        DivTambahanBiayaTitle.Visible = false;
                        DivTambahanBiayaGenus.Visible = false;
                        DivTambahanBiayaLogamBerat.Visible = false;
                    }
                    else if (TambahanBiayaType == TambahanBiayaTypes.Genus)
                    {
                        DivTambahanBiayaTitle.Visible = true;
                        DivTambahanBiayaGenus.Visible = true;
                        DivTambahanBiayaLogamBerat.Visible = false;
                    }
                    else if (TambahanBiayaType == TambahanBiayaTypes.UjiLogamBerat)
                    {
                        DivTambahanBiayaTitle.Visible = true;
                        DivTambahanBiayaGenus.Visible = false;
                        DivTambahanBiayaLogamBerat.Visible = true;
                    }
                    break;
                //paket
                case 2:
                    DivRow1.Visible = false;
                    DivRow2.Visible = false;
                    DivRow3.Visible = false;
                    DivRow4.Visible = false;
                    DivRow5.Visible = false;
                    DivRow6.Visible = false;
                    DivRow7.Visible = false;
                    DivRow8.Visible = false;
                    DivRow9.Visible = false;
                    DivRow10.Visible = false;
                    DivRow11.Visible = false;
                    DivRow12.Visible = true;

                    DivPesananBaru.Visible = false;
                    DivInfoPelanggan.Visible = false;
                    DivInfoPesanan.Visible = false;
                    DivInfoSampel.Visible = false;
                    DivInfoParameterUji.Visible = false;
                    DivHarga.Visible = false;
                    DivAgreement.Visible = false;
                    DivButton.Visible = false;

                    DivSOP.Visible = false;
                    DivBtnTutup.Visible = false;

                    DivTambahanBiayaTitle.Visible = false;
                    DivTambahanBiayaGenus.Visible = false;
                    DivTambahanBiayaLogamBerat.Visible = false;
                    break;
                //confirm
                case 3:
                    DivRow1.Visible = false;
                    DivRow2.Visible = false;
                    DivRow3.Visible = false;
                    DivRow4.Visible = false;
                    DivRow5.Visible = false;
                    DivRow6.Visible = false;
                    DivRow7.Visible = false;
                    DivRow8.Visible = false;
                    DivRow9.Visible = false;
                    DivRow10.Visible = false;
                    DivRow11.Visible = false;

                    DivPesananBaru.Visible = true;
                    DivInfoPelanggan.Visible = true;
                    DivInfoPesanan.Visible = true;
                    DivInfoSampel.Visible = true;
                    DivInfoParameterUji.Visible = true;
                    DivHarga.Visible = true;
                    DivAgreement.Visible = true;
                    DivButton.Visible = true;

                    DivSOP.Visible = false;
                    DivBtnTutup.Visible = false;

                    DivTambahanBiayaTitle.Visible = false;
                    DivTambahanBiayaGenus.Visible = false;
                    DivTambahanBiayaLogamBerat.Visible = false;
                    break;
                //SOP
                case 4:
                    DivRow1.Visible = false;
                    DivRow2.Visible = false;
                    DivRow3.Visible = false;
                    DivRow4.Visible = false;
                    DivRow5.Visible = false;
                    DivRow6.Visible = false;
                    DivRow7.Visible = false;
                    DivRow8.Visible = false;
                    DivRow9.Visible = false;
                    DivRow10.Visible = false;
                    DivRow11.Visible = false;

                    DivPesananBaru.Visible = false;
                    DivInfoPelanggan.Visible = false;
                    DivInfoPesanan.Visible = false;
                    DivInfoSampel.Visible = false;
                    DivInfoParameterUji.Visible = false;
                    DivHarga.Visible = false;
                    DivAgreement.Visible = false;
                    DivButton.Visible = false;

                    DivSOP.Visible = true;
                    DivBtnTutup.Visible = true;

                    DivTambahanBiayaTitle.Visible = false;
                    DivTambahanBiayaGenus.Visible = false;
                    DivTambahanBiayaLogamBerat.Visible = false;
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
                    case "add":
                        if (string.IsNullOrEmpty(HidCommodityNo.Value))
                        {
                            CommonWeb.Alert(this, "Silakan pilih komoditas terlebih dahulu.");
                            return;
                        }
                        ShowZone(0);
                        TxtNoSampel.Text = "";
                        TxtNoBalitTanah.Text = "";

                        break;

                    case "cancel":
                        Response.Redirect("CustomerBerandaTouch.aspx");

                        break;

                    case "save":
                        DoSave();
                        break;

                    case "add-sampel":
                        if (string.IsNullOrEmpty(TxtNoBalitTanah.Text))
                            AddSampel();
                        else
                            AddSampel(true);
                        break;
                    case "SOP":
                        ShowZone(4);
                        break;
                    case "close":
                        ShowZone(3);
                        break;
                    case "cancel-sampel":
                        ShowZone(1);
                        break;
                    case "confirm":
                        {
                            if (DataSampel.Count <= 0)
                            {
                                CommonWeb.Alert(this, "Silakan masukan data sampel terlebih dahulu.");
                                return;
                            }
                            if (Formater.ToNumber(LitTotalBiaya.Text) <= 0)
                            {
                                CommonWeb.Alert(this, "Silakan minimal pilih 1 parameter untuk diuji.");
                                return;
                            }

                            Dictionary<int, bool> checkedList = new Dictionary<int, bool>();
                            int rowCount = 0;
                            foreach (GridViewRow gvrow in GvParameter.Rows)
                            {
                                var chk = gvrow.FindControl("isChecked") as CheckBox;
                                if (chk != null)
                                {
                                    checkedList.Add(rowCount, chk.Checked);
                                    rowCount++;
                                }
                            }


                            ShowZone(3);
                            lblTanggal.Text = TxtTanggalDiterima.Text;
                            lblnoPesanan.Text = TxtNoOrder.Text;
                            lblKomoditas.Text = TxtKomoditas.Text;
                            lbljenisAnalisis.Text = CmbJenisAnalisa.Text;
                            var uname = CommonWeb.GetCurrentUser();
                            using (var db = new smlpobDB())
                            {
                                var cust = (from x in db.customertbls
                                            where x.customerEmail == uname
                                            select x).FirstOrDefault();
                                if (cust != null)
                                {
                                    lblcusname.Text = cust.customerName;
                                    lblInstansi.Text = cust.companyName;
                                }
                            }
                            GvParameter2.DataSource = DataParameter;
                            GvParameter2.DataBind();

                            rowCount = 0;
                            foreach (GridViewRow gvrow in GvParameter2.Rows)
                            {
                                var chk = gvrow.FindControl("isChecked") as CheckBox;
                                if (chk != null)
                                {
                                    chk.Checked = checkedList[rowCount];
                                    rowCount++;
                                }
                            }

                            UpdateJumlahContoh2();

                            GvSample2.DataSource = DataSampel;
                            GvSample2.DataBind();
                            if (Paket != null)
                            {
                                SpanHargaPaket2.Visible = true;
                                LitTotalHargaPaket2.Text = Paket.bundlePrice?.ToString("n2");
                            }
                            else
                            {
                                SpanHargaPaket2.Visible = false;
                            }
                            if (TambahanBiayaType != TambahanBiayaTypes.None)
                            {
                                SpanTambahanHarga.Visible = true;
                                litTambahanHarga.Text = HidTambahanBiaya.Value;
                            }
                            else
                            {
                                SpanTambahanHarga.Visible = false;
                            }
                            LitJmlParamUji.Text = LitJmlParameterUji.Text;
                            LitJmlSampel.Text = LitJumlahSampel.Text;
                            LitTotBiaya.Text = LitTotalBiaya.Text;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi Kesalahan");
            }
        }

        string GenerateNoBalitTanah(long SampelCounter, long OrderLastNumber = -1)
        {
            if (ListCodeBalittanah == null || ListCodeBalittanah.Count <= 0)
            {
                using (var db = new smlpobDB())
                {
                    var datas = (from x in db.comoditytbls
                                 select new { x.comodityNo, x.code }).ToList();
                    var newList = new Dictionary<int, string>();
                    datas.ForEach(x => newList.Add(x.comodityNo, x.code));
                    ListCodeBalittanah = newList;
                }
            }
            var Kode = string.IsNullOrEmpty(HidCommodityNo.Value) ? "K.P." : ListCodeBalittanah[int.Parse(HidCommodityNo.Value)];
            if (OrderLastNumber <= 0)
            {
                var curDate = DatetimeHelper.GetDatetimeNow();
                string FormatNo = $"{curDate.ToString("yy")}.{curDate.ToString("MM")}.{CounterGen.GetLastNumber("BALITTANAH") + 1}, {Kode}{CounterGen.GetLastNumber("SAMPEL") + SampelCounter}";
                //$"{CounterGen.GetLastNumber("SAMPEL") + SampelCounter}/PRM/POG/{curDate.ToString("MM")}/{curDate.ToString("yyyy")}";
                return FormatNo;
            }
            else
            {
                var curDate = DatetimeHelper.GetDatetimeNow();
                string FormatNo = $"{curDate.ToString("yy")}.{curDate.ToString("MM")}.{OrderLastNumber}, {Kode}{SampelCounter}";
                //$"{CounterGen.GetLastNumber("SAMPEL") + SampelCounter}/PRM/POG/{curDate.ToString("MM")}/{curDate.ToString("yyyy")}";
                return FormatNo;
            }
        }

        string GenerateNoOrder(long LastNumber = -1)
        {
            if (LastNumber <= 0)
            {
                var curDate = DatetimeHelper.GetDatetimeNow();
                string FormatNo = $"{(CounterGen.GetLastNumber("BALITTANAH") + 1).ToString("0000")}/LP Balittanah/{curDate.ToString("MM")}/{curDate.ToString("yyyy")}";
                return FormatNo;
            }
            else
            {
                var curDate = DatetimeHelper.GetDatetimeNow();
                string FormatNo = $"{(LastNumber).ToString("0000")}/LP Balittanah/{curDate.ToString("MM")}/{curDate.ToString("yyyy")}";
                return FormatNo;
            }

        }



        protected void CmbPropinsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadKabupaten();
            LoadKecamatan();
            LoadDesa();
        }

        void LoadKabupaten()
        {
            CmbKabupaten.DataSource = location.GetKabupaten(CmbPropinsi.SelectedValue);
            CmbKabupaten.DataTextField = "Nama";
            CmbKabupaten.DataValueField = "Key";
            CmbKabupaten.DataBind();
        }

        void LoadKecamatan()
        {
            CmbKecamatan.DataSource = location.GetKecamatan(CmbKabupaten.SelectedValue);
            CmbKecamatan.DataTextField = "Nama";
            CmbKecamatan.DataValueField = "Key";
            CmbKecamatan.DataBind();
        }
        void LoadDesa()
        {
            CmbDesa.DataSource = location.GetDesa(CmbKecamatan.SelectedValue);
            CmbDesa.DataTextField = "Nama";
            CmbDesa.DataValueField = "Key";
            CmbDesa.DataBind();
        }

        protected void CmbKabupaten_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadKecamatan();
            LoadDesa();
        }

        protected void CmbKecamatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDesa();
        }


        protected void ChkSetuju_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSetuju.Checked)
            {
                BtnSetuju.Enabled = true;
            }
            else
            {
                BtnSetuju.Enabled = false;
            }
        }

        private void GvSample2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("serial_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_no");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("balittanah_no");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("soil_type");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("gps_coordinates");
            }
        }

        private void GvParameter2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("choose");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("element_code");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("element_code");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("rates_per_example");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("total_example");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("cost");
            }
        }
    }


}