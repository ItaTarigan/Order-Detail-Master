using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Pages.Private.Customer
{
    public partial class CustomerPesananBaru : System.Web.UI.Page
    {
        string currentUser = Membership.GetUser().UserName.ToString();
        PesananCustomerControls pcc = new PesananCustomerControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPage();
            }
        }
        private void LoadPage()
        {
            GenerateAnalisis();
            GenerateKomoditas();
            GenerateSampleType();
            LoadDataGrid();
            txtTanggalTerima.Text = DatetimeHelper.GetDatetimeNow().ToString("yyyy-MM-dd");
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
            table.Columns.Add("gpsCoordinat", typeof(string));

            GvData.DataSource = table;
            GvData.DataBind();
        }

        private void GenerateKomoditas()
        {
            txtKomoditas.Items.Clear();
            txtKomoditas.Items.Insert(0, new ListItem("Pilih", "-1"));

            var ret = pcc.GetKomodity();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                txtKomoditas.DataSource = datas;
                txtKomoditas.DataTextField = "comodityName";
                txtKomoditas.DataValueField = "comodityNo";
                txtKomoditas.DataBind();
            }
            txtKomoditas.SelectedIndex = 0;
        }

        private void GenerateSampleType()
        {
            txtInputTipeSampel.Items.Clear();

            var ret = pcc.GetSampleType();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                txtInputTipeSampel.DataSource = datas;
                txtInputTipeSampel.DataTextField = "typeName";
                txtInputTipeSampel.DataValueField = "typeName";
                txtKomoditas.DataBind();
            }
            txtInputTipeSampel.SelectedIndex = 0;
        }

        protected void GenerateChildKomoditas(object sender, EventArgs e)
        {
            if (txtKomoditas.SelectedIndex != 0)
            {
                txtKomoditasChild.Items.Clear();
                txtKomoditasChild.Items.Insert(0, new ListItem("Pilih", "-1"));

                int id = int.Parse(txtKomoditas.SelectedValue);
                var ret = pcc.GetKomoditiChild(id);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    txtKomoditasChild.DataSource = datas;
                    txtKomoditasChild.DataTextField = "comodityName";
                    txtKomoditasChild.DataValueField = "comodityNo";
                    txtKomoditasChild.DataBind();
                }
                txtKomoditasChild.SelectedIndex = 0;
            }
        }

        protected void CalculateTotal(object sender, EventArgs e)
        {
            decimal totalBiaya = 0;
            foreach (GridViewRow gvrow in GvParameter.Rows)
            {
                var tarif = gvrow.FindControl("txtTarif") as Label;
                var jumlah = gvrow.FindControl("txtJumlahContoh") as TextBox;
                var biaya = gvrow.FindControl("txtBiaya") as Label;

                decimal hasil = Formater.ToNumber(tarif.Text) * int.Parse(jumlah.Text);
                biaya.Text = Formater.ToRupiah(hasil);
                totalBiaya += hasil;
            }

            txtJumlahHarga.Text = Formater.ToRupiah(totalBiaya);
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
            txtTotalParameter.Text = totalParameterUji.ToString();
        }

        private void GenerateAnalisis()
        {
            txtJenisAnalisis.Items.Clear();
            txtJenisAnalisis.Items.Insert(0, new ListItem("Pilih", "-1"));

            var ret = pcc.GetAnalysis();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                txtJenisAnalisis.DataSource = datas;
                txtJenisAnalisis.DataTextField = "analysisTypeName";
                txtJenisAnalisis.DataValueField = "analysisTypeName";
                txtJenisAnalisis.DataBind();
            }
            txtJenisAnalisis.SelectedIndex = 0;
        }

        protected void GenerateParameterUji(object sender, EventArgs e)
        {
            if (txtJenisAnalisis.SelectedIndex != 0 && txtKomoditasChild.SelectedIndex != 0)
            {
                var ret = pcc.GetParameterUji(txtKomoditasChild.SelectedValue, txtJenisAnalisis.SelectedValue);
                var datas = ret.Result;

                GvParameter.DataSource = datas;
                GvParameter.DataBind();
            }
        }

        private void AddRowGv()
        {
            List<ordersampletbl> sampel = new List<ordersampletbl>();
            DataTable table = new DataTable();
            table.Columns.Add("countNumber", typeof(int));
            table.Columns.Add("sampleCode", typeof(string));
            table.Columns.Add("noBalittanah", typeof(string));
            table.Columns.Add("village", typeof(string));
            table.Columns.Add("subDistrict", typeof(string));
            table.Columns.Add("district", typeof(string));
            table.Columns.Add("province", typeof(string));
            table.Columns.Add("landUse", typeof(string));
            table.Columns.Add("gpsCoordinat", typeof(string));

            if (GvData.Rows.Count > 0)
            {
                for (int i = 0; i < GvData.Rows.Count; i++)
                {
                    string[] longlat1 = (GvData.Rows[i].Cells[8].Text).Split(',');
                    sampel.Add(new ordersampletbl
                    {
                        countNumber = i+1,
                        sampleCode = GvData.Rows[i].Cells[1].Text,
                        noBalittanah = GvData.Rows[i].Cells[2].Text,
                        village = GvData.Rows[i].Cells[3].Text,
                        subDistrict = GvData.Rows[i].Cells[4].Text,
                        district = GvData.Rows[i].Cells[5].Text,
                        province = GvData.Rows[i].Cells[6].Text,
                        landUse = GvData.Rows[i].Cells[7].Text,
                        longitude = longlat1[0],
                        latitude = longlat1[1]
                    });
                }

                string[] longlat2 = (txtGps.Text).Split(',');
                sampel.Add(new ordersampletbl
                {
                    countNumber = sampel.Count + 1,
                    sampleCode = txtInputNoSample.Text,
                    noBalittanah = pcc.AutoGenerateSample(txtKomoditas.SelectedValue, txtJenisAnalisis.SelectedValue),
                    village = txtInputDesa.Text,
                    subDistrict = txtInputKecamatan.Text,
                    district = txtInputKabupaten.Text,
                    province = txtInputPropinsi.Text,
                    landUse = txtInputTipeSampel.Text,
                    longitude = longlat2[0],
                    latitude = longlat2[1]
                });
            }
            else
            {

                string[] longlat2 = (txtGps.Text).Split(',');
                sampel.Add(new ordersampletbl
                {

                    countNumber = sampel.Count + 1,
                    sampleCode = txtInputNoSample.Text,
                    noBalittanah = pcc.AutoGenerateSample(txtKomoditas.Text, txtJenisAnalisis.Text),
                    village = txtInputDesa.Text,
                    subDistrict = txtInputKecamatan.Text,
                    district = txtInputKabupaten.Text,
                    province = txtInputPropinsi.Text,
                    landUse = txtInputTipeSampel.Text,
                    longitude = longlat2[0],
                    latitude = longlat2[1]
                });
            }

            if (sampel.Count > 0)
            {
                var sort = sampel.OrderBy(o => o.countNumber);
                sampel = sort.ToList();

                foreach (var data in sampel)
                {
                    table.Rows.Add(data.countNumber, data.sampleCode, data.noBalittanah, data.village,
                        data.subDistrict, data.district, data.province, data.landUse,
                        (data.longitude + "," + data.latitude).ToString());
                }
            }

            txtJumlahSampel.Text = sampel.Count.ToString();

            GvData.DataSource = table;
            GvData.DataBind();
        }

        private void DelRowGv(string param)
        {
            List<ordersampletbl> sampel = new List<ordersampletbl>();
            DataTable table = new DataTable();
            table.Columns.Add("countNumber", typeof(int));
            table.Columns.Add("sampleCode", typeof(string));
            table.Columns.Add("noBalittanah", typeof(string));
            table.Columns.Add("village", typeof(string));
            table.Columns.Add("subDistrict", typeof(string));
            table.Columns.Add("district", typeof(string));
            table.Columns.Add("province", typeof(string));
            table.Columns.Add("landUse", typeof(string));
            table.Columns.Add("gpsCoordinat", typeof(string));

            if (GvData.Rows.Count > 0)
            {
                for (int i = 0; i < GvData.Rows.Count; i++)
                {
                    if (GvData.Rows[i].Cells[2].Text != param)
                    {
                        string[] longlat1 = (GvData.Rows[i].Cells[8].Text).Split(',');
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
                            longitude = longlat1[0],
                            latitude = longlat1[1]
                        });
                    }
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
                        (data.longitude + "," + data.latitude).ToString());
                }
            }

            txtJumlahSampel.Text = sampel.Count.ToString();

            GvData.DataSource = table;
            GvData.DataBind();
        }

        private void DoSave()
        {
            List<ordersampletbl> sampel = new List<ordersampletbl>();
            ordermastertbl order = new ordermastertbl();
            List<orderpricedetailtbl> parameter = new List<orderpricedetailtbl>();

            if (GvData.Rows.Count > 0)
            {
                for (int i = 0; i < GvData.Rows.Count; i++)
                {
                    string[] longlat1 = (GvData.Rows[i].Cells[8].Text).Split(',');
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
                        longitude = longlat1[0],
                        latitude = longlat1[1]
                    });
                }
            }

            order = new ordermastertbl
            {
                customerNo = pcc.GetCustomerNo(currentUser),
                receiptDate = Formater.ToDate(txtTanggalTerima.Text),
                comodityNo = int.Parse(txtKomoditasChild.SelectedValue),
                analysisType = txtJenisAnalisis.SelectedValue,
                sampleTotal = sampel.Count,
                priceTotal = Formater.ToNumber(txtJumlahHarga.Text),
                statusType = "Komersial",
                paymentStatus = Status.PaymentStatus[0],
                status = Status.OrderStatus[0],
                ppn = Formater.ToNumber(txtJumlahHarga.Text) * 10/100,
                isPaid = "0",
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            foreach (GridViewRow gvrow in GvParameter.Rows)
            {
                var chkbx = gvrow.FindControl("isChecked") as CheckBox;
                if (chkbx.Checked)
                {
                    var element = gvrow.FindControl("txtParameterUji") as Label;
                    var price = gvrow.FindControl("txtTarif") as Label;
                    var qty = gvrow.FindControl("txtJumlahContoh") as TextBox;
                    var total = gvrow.FindControl("txtBiaya") as Label;
                    parameter.Add(new orderpricedetailtbl
                    {
                        elementId = Convert.ToInt32(element),
                        price = Formater.ToNumber(price.Text),
                        quantity = int.Parse(qty.Text),
                        TotalPrice = Formater.ToNumber(total.Text)
                    });
                }
            }

            var ret = pcc.SaveOrder(order, sampel, parameter);

            if (ret.Result)
            {
                Alert("Terima kasih pesanan anda telah tersimpan");
            }
            else
            {
                Alert("Gagal menyimpan data");
            }
        }


        protected void CheckedAll(object sender, EventArgs e)
        {
            var masterchk = sender as CheckBox;

            if (masterchk.Checked)
            {
                txtTotalParameter.Text = "0";
                int totalparam = 0;
                foreach (GridViewRow gvrow in GvParameter.Rows)
                {
                    var chkbx = gvrow.FindControl("isChecked") as CheckBox;
                    chkbx.Checked = true;
                    totalparam =+ 1;
                }
                txtTotalParameter.Text = totalparam.ToString();
            }
            else if (!masterchk.Checked)
            {
                txtTotalParameter.Text = "0";
                int totalparam = 0;
                foreach (GridViewRow gvrow in GvParameter.Rows)
                {
                    var chkbx = gvrow.FindControl("isChecked") as CheckBox;
                    chkbx.Checked = false;
                    totalparam = +1;
                }
                txtTotalParameter.Text = totalparam.ToString();
            }
        }

        private void DoDuplicate(int id)
        {
            txtInputNoSample.Text = "";
            //txtInputNoBalittanah.Text = pcc.AutoGenerateSample(txtKomoditas.Text, txtJenisAnalisis.Text);
            txtInputDesa.Text = GvData.Rows[id -1].Cells[3].Text;
            txtInputKecamatan.Text = GvData.Rows[id - 1].Cells[4].Text;
            txtInputKabupaten.Text = GvData.Rows[id - 1].Cells[5].Text;
            txtInputPropinsi.Text = GvData.Rows[id - 1].Cells[6].Text;
            txtInputTipeSampel.SelectedIndex = txtInputTipeSampel.Items.IndexOf(
                txtInputTipeSampel.Items.FindByValue(GvData.Rows[id - 1].Cells[7].Text));
            txtGps.Text = GvData.Rows[id - 1].Cells[8].Text;
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
                        if (txtJenisAnalisis.SelectedIndex > 0 || txtKomoditasChild.SelectedIndex > 0)
                        {
                            AddRowGv();
                        }
                        else
                        {
                            Alert("Silahkan pilih jenis analisi dan komoditas");
                        }
                        break;

                    case "cancel":
                        Response.Redirect("~/Pages/Private/Customer/CustomerPesanan.aspx");
                        break;

                    case "save":

                        if (GvData.Rows.Count > 0)
                        {
                            DoSave();
                        }
                        else
                        {
                            Alert("Silahkan Masukan sampel");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
            }
        }

        // Alert
        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }

        protected void ActionImageButton(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ImageButton;
                var command = btn.CommandName;

                switch (command)
                {
                    case "hapus":
                        DelRowGv(btn.CommandArgument);
                        break;

                    case "duplikat":
                        DoDuplicate(int.Parse(btn.CommandArgument));
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
            }
        }
    }
}