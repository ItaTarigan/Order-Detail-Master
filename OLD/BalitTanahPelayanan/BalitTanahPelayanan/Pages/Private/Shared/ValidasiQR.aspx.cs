using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing.Common;
using ZXing.QrCode;

namespace BalitTanahPelayanan.Pages.Private.Shared
{
    public partial class ValidasiQR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnBack.Click += (a, b) =>
            {
                var sourceUrl = Session["SourceUrl"] == null ? "" : Session["SourceUrl"].ToString();
                if (string.IsNullOrEmpty(sourceUrl))
                {
                    CommonWeb.Alert(this, "Tidak dapat kembali ke halaman sebelumnya.");
                }
                else
                {
                    Response.Redirect(sourceUrl);
                }
            };

            BtnUpload.Click += BtnUpload_Click;
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                DivInfo.Visible = false;
                DivWarning.Visible = false;
                var ext = Path.GetExtension(FileUpload1.FileName).ToLower();
                var tempPath = Path.GetTempFileName() + ext;
                FileUpload1.SaveAs(tempPath);
                HashSet<String> exts = new HashSet<string> { ".bmp", ".png", ".jpg", ".gif", ".png" };
                if(exts.Contains(ext))
                {
                    ImageQR.ImageUrl = "/handlers/imageloader.ashx?ImgPath=" + tempPath;
                    var qr = new ZXing.BarcodeReader();
                    var options = new DecodingOptions
                    {
                      
                        CharacterSet = "UTF-8",
                      
                    };
                    qr.Options = options;
                    Bitmap bmp = (Bitmap)Bitmap.FromFile(tempPath);
                    var res = qr.Decode(bmp);
                    if(res!=null && !string.IsNullOrEmpty(res.Text))
                    {
                        try
                        {
                            var decrypt = Crypto.Decrypt(res.Text);
                            LoadHeaderInfo(decrypt.Trim());
                        }
                        catch
                        {
                            CommonWeb.Alert(this, "Qr dapat dibaca tapi tidak valid.");
                        }
                    }
                    else
                    {
                        CommonWeb.Alert(this, "Qr tidak dapat dibaca, atau gambar tidak valid.");
                    }

                }
                else
                {
                    CommonWeb.Alert(this, "Silakan upload file dengan tipe gambar");
                }
            }
            else
            {
                CommonWeb.Alert(this, "Silakan pilih foto QR LHP terlebih dahulu.");
            }
        }

        void LoadHeaderInfo(string orderNo)
        {
            OrderListControls orderControls = new OrderListControls();
            var ret = orderControls.DetailData(orderNo);
            var data = ret.Result;

            if (data != null)
            {
                DivInfo.Visible = true;
                //FileNameTxt.Text = data.orderanaly;
                txtOrderNo.Text = data.orderNo;
                txtCustomer.Text = data.customertbl.customerName;
                txtKomoditas.Text = data.comoditytbl.comodityName;
                txtTipeAnalis.Text = data.analysisType;
                txtTotalSample.Text = data.sampleTotal.ToString();
                txtStatusPesanan.Text = data.status;

            }
            else
            {
                DivWarning.Visible = true;
                LitWarning.Text = "Data LHP tidak ditemukan, QR ini tidak valid.";
            }
        }
    }
}