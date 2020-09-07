using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using ZXing;
using ZXing.QrCode;

namespace BalitTanahPelayanan.Helpers
{
    public class QRcode
    {
        public static string GenerateQR(string str, string serverpath = @"C:\", int width = 80, int height = 80)
        {
            //var checkfolder = CheckFolderExists(serverpath);
            string barcodeString = str;
            string path = Path.GetTempFileName()+ ".jpg";

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                //Options = new ZXing.Common.EncodingOptions
                //{
                   
                //    Width = width,
                //    Height = height,
                //    Margin = 0
                //}
            };
            var options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = width,
                Height = height,
            };
            writer.Options = options;
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

            return barcodeResult.Text;
        }

        // Checking folder
        public static bool CheckFolderExists(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("Directory is exists");
                }
                else if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("Creating new directory");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process failed : {0}", ex.ToString());
                return false;
            }
        }
    }
}