using BalitTanahPelayanan.Models;
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
using ZXing.QrCode;
using System.Data.Entity;
using BalitTanahPelayanan.Helpers;

namespace BalitTanahPelayanan.Pages.Private.Kasir
{
    public partial class CetakQR : System.Web.UI.Page
    {
        static string prevPage;

        void GetTranslation()
        {
            BtnKembali.Text = LanguageHelper.GetTranslation("back");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var orderNo = Request.QueryString["orderNo"];
                if (!string.IsNullOrEmpty(orderNo))
                {
                    GetTranslation();
                    LoadData(orderNo);
                }
                prevPage = Request.UrlReferrer.ToString();
            }
            BtnKembali.Click += BtnKembali_Click;
        }

        private void BtnKembali_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(prevPage))
            {
                Response.Redirect("KasirSelesaiRincian.aspx");
            }
            else
                Response.Redirect(prevPage);
        }

        void LoadData(string orderNo)
        {
            try
            {

                var qr = new ZXing.BarcodeWriter();
                var options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = 100,
                    Height = 100,
                };
                qr.Options = options;
                qr.Format = ZXing.BarcodeFormat.QR_CODE;

                var fName = Path.GetTempPath() + "/" + Guid.NewGuid().ToString().Replace("-", "_") + ".jpg";
                string FilePath = @"file:\" + fName;
                var result = new Bitmap(qr.Write(orderNo));
                result.Save(fName, ImageFormat.Jpeg);

                //setup report
                reportViewer.LocalReport.EnableExternalImages = true;

                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports") + "/QRcode.rdlc";

                using (var db = new smlpobDB())
                {
                    var orderData = (from x in db.ordermastertbls
                                     where x.orderNo == orderNo
                                     select x).FirstOrDefault();

                    if (orderData != null)
                    {
                        ReportParameter ImageQRParam = new ReportParameter();
                        ImageQRParam.Name = "ImageQR";
                        ImageQRParam.Values.Add(FilePath);

                        reportViewer.LocalReport.SetParameters(new ReportParameter[] { ImageQRParam});
                    }
                }
            }
            catch (Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi kesalahan, silahkan coba kembali.");
                LogHelpers.source = this.GetType().ToString();
                LogHelpers.message = "Failed to print QR code with the following error:" + ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();
            }


        }
    }
}