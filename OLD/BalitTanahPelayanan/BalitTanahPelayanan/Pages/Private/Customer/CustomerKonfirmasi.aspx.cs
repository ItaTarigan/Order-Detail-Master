using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;
using ZXing.QrCode;

namespace BalitTanahPelayanan.Pages.Private.Customer
{
    public partial class CustomerKonfirmasi : System.Web.UI.Page
    {

        void GetTranslation()
        {
            lblKonfirmasiPesananBaru.Text = LanguageHelper.GetTranslation("ConfirmNewOrder");
            lblInfoPelanggan.Text = LanguageHelper.GetTranslation("customer_info");
            name.Text = LanguageHelper.GetTranslation("name");
            instansi.Text = LanguageHelper.GetTranslation("agency");
            lblInfoPesanan.Text = LanguageHelper.GetTranslation("order_info");
            tanggal.Text = LanguageHelper.GetTranslation("date");
            noPesanan.Text = LanguageHelper.GetTranslation("ord_no");
            komoditas.Text = LanguageHelper.GetTranslation("Lit_Komoditas");
            subKomoditas.Text = LanguageHelper.GetTranslation("sub_commodity1");
            jenisAnalisis.Text = LanguageHelper.GetTranslation("analysistype");
            infoSampel.Text = LanguageHelper.GetTranslation("sample_info");
            parameterUji.Text = LanguageHelper.GetTranslation("test_parameter");
            lblJumlahParameterUji.Text = LanguageHelper.GetTranslation("total_parameter_uji");
            lblJumlahSample.Text = LanguageHelper.GetTranslation("sampletot");
            lblTotalBiaya.Text = LanguageHelper.GetTranslation("total_biaya");
            SayaSetuju.Text = LanguageHelper.GetTranslation("iagree");
            BtnSOP.Text = LanguageHelper.GetTranslation("SOP");
            BtnKembali.Text = LanguageHelper.GetTranslation("back");
            BtnSetuju.Text = LanguageHelper.GetTranslation("agree");
            BtnTutup.Text = LanguageHelper.GetTranslation("close");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetTranslation();
            BtnTutup.Click += BtnTutup_Click;
            BtnSOP.Click += BtnSOP_Click;
        }

        private void BtnTutup_Click(object sender, EventArgs e)
        {
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
        }

        private void BtnSOP_Click(object sender, EventArgs e)
        {
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
        }

        protected void ActionButton(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var command = btn.CommandName;

                switch (command)
                {
                    case "back":
                        Response.Redirect("CustomerBuatPesanan.aspx");
                        break;
                    
                }
            }
            catch (Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi Kesalahan");
            }
        }
    }
}