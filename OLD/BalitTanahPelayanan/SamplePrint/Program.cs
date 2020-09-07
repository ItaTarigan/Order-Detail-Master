using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace SamplePrint
{
    class Program
    {
        static string PrinterName;
        static string QRCodeStr = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Printing Service is ready..");
            PrinterName= ConfigurationManager.AppSettings["PrinterName"];
            SetupSignalR();
            Console.WriteLine("Connected to server...");
            //Cetak(new string[] { "qweasdzxc", "abcde123" });
            Console.ReadLine();
            Console.WriteLine("Printing Service is shutting down..");
        }
        static string PrinterID;
        static IHubProxy _hub;
        static void SetupSignalR()
        {
            PrinterID = ConfigurationManager.AppSettings["PrinterID"];
            string url = ConfigurationManager.AppSettings["HubUrl"];//@"http://localhost:8080/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("BarcodeHub");
            connection.Start().Wait();

            _hub.On<string, List<string>>("PrintBarcode", (x, barcodes) =>
            {
                if(x=="All" || x==PrinterID)
                    Cetak(barcodes);
            });

        }
        static void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            // instantiate a writer object
            var barcodeWriter = new BarcodeWriter();

            // set the barcode format
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options.Height = 100;
            barcodeWriter.Options.Width = 100;
            var fName = Path.GetTempFileName() + ".jpg";
            // write text and generate a 2-D barcode as a bitmap
            barcodeWriter
                .Write(QRCodeStr)
                .Save(fName);
            //Font printFont = new Font("3 of 9 Barcode", 17);
            Font printFont1 = new Font("Verdana", 9, FontStyle.Regular);

            SolidBrush br = new SolidBrush(Color.Black);

            //ev.Graphics.DrawString("*AAAAAAFFF*", printFont, br, 10, 65);
            
            Image img = Bitmap.FromFile(fName);
            ev.Graphics.DrawImage(img, 10, 10);
            ev.Graphics.DrawString(QRCodeStr, printFont1, br, 25, 10);
        }
        static void Cetak(IEnumerable<string> Barcodes)
        {
            try
            {

                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                // Set the printer name. 
                //pd.PrinterSettings.PrinterName = "\\NS5\hpoffice
                pd.PrinterSettings.PrinterName = PrinterName; //"Gprinter  GP-2120T";
                foreach(var item in Barcodes)
                {
                    QRCodeStr = item;
                    Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - Print barcode dari server => {item}");
                    pd.Print();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
        }
    }
}
