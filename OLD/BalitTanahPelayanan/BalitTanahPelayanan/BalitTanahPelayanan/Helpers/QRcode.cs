using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using ZXing;

namespace BalitTanahPelayanan.Helpers
{
    public class QRcode
    {
        public static string GenerateQR(string str, int width = 100, int height = 100)
        {
            string barcodeString = str;
            string path = @"C:\qr.jpg";

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = width,
                    Height = height,
                    Margin = 0
                }
            };

            var output = writer.Write(barcodeString);
            Bitmap qrCode = new Bitmap(output);

            qrCode.Save(path, ImageFormat.Jpeg);

            return path;
        }

        public static string ReadQR(Bitmap qr)
        {
            var barcodeReader = new BarcodeReader();
            var barcodeBitmap = qr;
            var barcodeResult = barcodeReader.Decode(barcodeBitmap);

            return barcodeResult.Text; ;
        }
    }
}