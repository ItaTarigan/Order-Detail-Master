using BalitTanahPelayanan.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing.QrCode;

namespace BalitTanahPelayanan.Pages.Private.Shared
{
    public partial class GenerateQR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnBack.Click += (a, b) =>
            {
                var sourceUrl = Session["SourceUrl"]==null ? "" : Session["SourceUrl"].ToString();
                if (string.IsNullOrEmpty(sourceUrl))
                {
                    CommonWeb.Alert(this, "Tidak dapat kembali ke halaman sebelumnya.");
                }
                else
                {
                    Response.Redirect(sourceUrl);
                }
            };
            if (!IsPostBack)
            {
                var OrderNo = Request.QueryString["OrderNo"];
                if (string.IsNullOrEmpty(OrderNo))
                {
                    CommonWeb.Alert(this, "Order tidak ditemukan. QR tidak dapat ditampilkan.");
                }
                else
                {
                    txtNoOrder.Text = OrderNo;
                    var QREncrypted = Crypto.Encrypt(OrderNo);
                    var qr = new ZXing.BarcodeWriter();
                    var options = new QrCodeEncodingOptions
                    {
                        DisableECI = true,
                        CharacterSet = "UTF-8",
                        Width = 200,
                        Height = 200,
                    };
                    qr.Options = options;
                    qr.Format = ZXing.BarcodeFormat.QR_CODE;

                    var FilePath = Path.GetTempPath() + "/" + Guid.NewGuid().ToString().Replace("-", "_") + ".jpg";
                  
                    var result = new Bitmap(qr.Write(QREncrypted));
                    result.Save(FilePath, ImageFormat.Jpeg);

                    ImageQR.ImageUrl = "/handlers/imageloader.ashx?ImgPath=" + FilePath;

                }
            }
        }
    }
}