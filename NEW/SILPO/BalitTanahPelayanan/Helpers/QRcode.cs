using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using ZXing;
using ZXing.Presentation;
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
            
            var writer = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                
            };
            var options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = width,
                Height = height,
            };
            writer.Options = options;
            var pixelData = writer.Write(barcodeString);
            using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            using (var ms = new MemoryStream())
            {
                var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image   
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }
                // save to stream as PNG   
                //bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                bitmap.Save(path, ImageFormat.Jpeg);
            }
            return path;
        }

        public static string ReadQR(Bitmap qr)
        {
            ImageConverter converter = new ImageConverter();
            var bytes =  (byte[])converter.ConvertTo(qr, typeof(byte[]));
            var barcodeReader = new ZXing.BarcodeReader();
            var barcodeBitmap = qr;
            var barcodeResult = barcodeReader.Decode(bytes);

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