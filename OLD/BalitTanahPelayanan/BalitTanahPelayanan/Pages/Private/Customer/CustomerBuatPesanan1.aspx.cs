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
    public partial class CustomerBuatPesanan : System.Web.UI.Page
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
            cmb2SubKomoditas.Text = LanguageHelper.GetTranslation("sub_commodity");
            cmb2JenisAnalisa.Text = LanguageHelper.GetTranslation("analysis_type");
            lblInputDataSample.Text = LanguageHelper.GetTranslation("input_sample_data");

            lbspta.Text = LanguageHelper.GetTranslation("choose_type_analysis");
            lbspsk.Text = LanguageHelper.GetTranslation("select_sub_comodity");
            lbspk.Text = LanguageHelper.GetTranslation("choose_a_comodity");
            lbtp.Text = LanguageHelper.GetTranslation("order_date");

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
        protected void Page_Load(object sender, EventArgs e)
        {
            GvData.RowDataBound += GvData_RowDataBound;
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
            GvParameter.RowDataBound += GvParameter_RowDataBound;
        }

        private void GvParameter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var hidMandatory = e.Row.FindControl("HidMandatory") as HiddenField;
                var chk = e.Row.FindControl("isChecked") as CheckBox;
                if (hidMandatory != null)
                {

                    chk.Checked = hidMandatory.Value == "1";

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
            if (GvParameter!=null && GvParameter.Rows.Count>0)
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
                CalculateTotal(null,null);
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
            GenerateKomoditas();
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

            LitTotalBiaya.Text = Formater.ToRupiah(totalBiaya);
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
            if (CmbJenisAnalisa.SelectedIndex != 0 && CmbSubKomoditas.SelectedIndex != 0)
            {
                var ret = pcc.GetParameterUji(CmbSubKomoditas.SelectedValue, CmbJenisAnalisa.SelectedValue);
                var datas = ret.Result;

                //foreach (var data in datas)
                //{
                //    checkedparam.Add(new GridParameter
                //    {
                //        ischecked = "1",

                //    });
                //}

                GvParameter.DataSource = datas;
                GvParameter.DataBind();
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
            if (DataSampel.Count <= 0)
            {
                CommonWeb.Alert(this, "Silakan masukan data sampel terlebih dahulu.");
                return;
            }
            if (Formater.ToNumber(LitTotalBiaya.Text)<=0)
            {
                CommonWeb.Alert(this, "Silakan minimal pilih 1 parameter untuk diuji.");
                return;
            }
            List<ordersampletbl> sampel = DataSampel;
            ordermastertbl order = new ordermastertbl();
            List<orderpricedetailtbl> parameter = new List<orderpricedetailtbl>();
            var LastNum = CounterGen.Increment("BALITTANAH");
            var NewOrderNo = GenerateNoOrder(LastNum);
            foreach(var item in sampel)
            {
                item.orderNo = NewOrderNo;
                item.noBalittanah = GenerateNoBalitTanah(CounterGen.Increment("SAMPEL"),LastNum);
            }
            order = new ordermastertbl
            {
                orderNo = NewOrderNo,
                customerNo = pcc.GetCustomerNo(currentUser),
                comodityNo = int.Parse(CmbSubKomoditas.SelectedValue),
                analysisType = CmbJenisAnalisa.SelectedValue,
                sampleTotal = sampel.Count,
                priceTotal = Formater.ReturnModCurency(LitTotalBiaya.Text),
                statusType = "Komersial",
                paymentStatus = "Belum dibayar",
                status = "Pesanan Baru",
                ppn = Formater.ToNumber(LitTotalBiaya.Text) * 10 / 100,
                receiptDate = Formater.ToDate(TxtTanggalDiterima.Text),
                isPaid = "0",
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow(),
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
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
                Response.Redirect("CustomerBeranda.aspx");
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
                    ,samplingDate = sampel.samplingDate,
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
                    DivPesananBaru.Visible = false;
                    DivInfoPelanggan.Visible = false;
                    DivInfoPesanan.Visible = false;
                    DivInfoSampel.Visible = false;
                    DivInfoParameterUji.Visible = false;
                    DivJumlah.Visible = false;
                    DivAgreement.Visible = false;
                    DivButton.Visible = false;
                    DivSOP.Visible = false;
                    DivBtnTutup.Visible = false;
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
                    DivPesananBaru.Visible = false;
                    DivInfoPelanggan.Visible = false;
                    DivInfoPesanan.Visible = false;
                    DivInfoSampel.Visible = false;
                    DivInfoParameterUji.Visible = false;
                    DivJumlah.Visible = false;
                    DivAgreement.Visible = false;
                    DivButton.Visible = false;
                    DivSOP.Visible = false;
                    DivBtnTutup.Visible = false;
                    break;

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
                    DivPesananBaru.Visible = true;
                    DivInfoPelanggan.Visible = true;
                    DivInfoPesanan.Visible = true;
                    DivInfoSampel.Visible = true;
                    DivInfoParameterUji.Visible = true;
                    DivJumlah.Visible = true;
                    DivAgreement.Visible = true;
                    DivButton.Visible = true;
                    DivSOP.Visible = false;
                    DivBtnTutup.Visible = false;
                    break;

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
                    DivPesananBaru.Visible = false;
                    DivInfoPelanggan.Visible = false;
                    DivInfoPesanan.Visible = false;
                    DivInfoSampel.Visible = false;
                    DivInfoParameterUji.Visible = false;
                    DivJumlah.Visible = false;
                    DivAgreement.Visible = false;
                    DivButton.Visible = false;
                    DivSOP.Visible = true;
                    DivBtnTutup.Visible = true;
                    break;

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
                    DivPesananBaru.Visible = true;
                    DivInfoPelanggan.Visible = true;
                    DivInfoPesanan.Visible = true;
                    DivInfoSampel.Visible = true;
                    DivInfoParameterUji.Visible = true;
                    DivJumlah.Visible = true;
                    DivAgreement.Visible = true;
                    DivButton.Visible = true;
                    DivSOP.Visible = false;
                    DivBtnTutup.Visible = false;
                    break;

                case 5:
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
                    DivPesananBaru.Visible = false;
                    DivInfoPelanggan.Visible = false;
                    DivInfoPesanan.Visible = false;
                    DivInfoSampel.Visible = false;
                    DivInfoParameterUji.Visible = false;
                    DivJumlah.Visible = false;
                    DivAgreement.Visible = false;
                    DivButton.Visible = false;
                    DivSOP.Visible = false;
                    DivBtnTutup.Visible = false;
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
                        ShowZone(0);
                        TxtNoSampel.Text = "";
                        TxtNoBalitTanah.Text = "";
                        break;

                    case "cancel":
                        Response.Redirect("CustomerBeranda.aspx");
                        break;

                    case "proses":
                        ShowZone(2);
                        break;

                    case "add-sampel":
                        if (string.IsNullOrEmpty(TxtNoBalitTanah.Text))
                            AddSampel();
                        else
                            AddSampel(true);
                        break;

                    case "cancel-sampel":
                        ShowZone(1);
                        break;

                    case "sop":
                        ShowZone(3);
                        break;

                    case "close":
                        ShowZone(4);
                        break;

                    case "back":
                        ShowZone(5);
                        break;

                }
            }
            catch (Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi Kesalahan");
            }
        }

        string GenerateNoBalitTanah(long SampelCounter,long OrderLastNumber=-1)
        {
            if (OrderLastNumber <= 0)
            {
                var curDate = DatetimeHelper.GetDatetimeNow();
                string FormatNo = $"{curDate.ToString("yy")}.{curDate.ToString("MM")}.{CounterGen.GetLastNumber("BALITTANAH") + 1} K.P. {CounterGen.GetLastNumber("SAMPEL") + SampelCounter}";
                //$"{CounterGen.GetLastNumber("SAMPEL") + SampelCounter}/PRM/POG/{curDate.ToString("MM")}/{curDate.ToString("yyyy")}";
                return FormatNo;
            }
            else
            {
                var curDate = DatetimeHelper.GetDatetimeNow();
                string FormatNo = $"{curDate.ToString("yy")}.{curDate.ToString("MM")}.{OrderLastNumber} K.P. {SampelCounter}";
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
    }

    //class GridParameter
    //{
    //    public string ischecked { get; set; }


    //}
}