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

namespace BalitTanahPelayanan.Pages.Private.CS
{
    public partial class CetakBarcodeSampel : System.Web.UI.Page
    {
        void GetTranslation()
        {
            BtnKembali.Text = LanguageHelper.GetTranslation("back");
            BtnCetak.Text = LanguageHelper.GetTranslation("print_view");
            BtnCetak2.Text = LanguageHelper.GetTranslation("print");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GvData.RowDataBound += GvData_RowDataBound;
            if (!IsPostBack)
            {
                //CmbPrinter.DataSource = new List<string> { "All", "Printer1", "Printer2" };
                //CmbPrinter.DataBind();
                //CmbPrinter.SelectedIndex = 0;
                var orderNo = Request.QueryString["value"];
                if (!string.IsNullOrEmpty(orderNo))
                {
                    LoadData(orderNo);
                    
                }
                GetTranslation();
            }
            BtnKembali.Click += (x, y) =>
            {
                Response.Redirect("CustomerServiceBeranda.aspx");
            };
            BtnCetak.Click += (x, y) =>
            {
                Preview();
            };
            BtnCetak2.Click += (a, b) =>
            {
                Cetak();
            };
        }

        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("count_number");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_code");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("balittanah_no");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("gps");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("landuse");
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("is_received");
                e.Row.Cells[10].Text = LanguageHelper.GetTranslation("print_total");
            }
        }

        void Cetak()
        {
            try
            {
                var orderNo = Request.QueryString["value"];
                if (!string.IsNullOrEmpty(orderNo))
                {
                    List<BarcodeItem> Barcode = new List<BarcodeItem>();
                    int RowNum = 0;
                    foreach (GridViewRow dr in GvData.Rows)
                    {
                        var txtJml = dr.FindControl("TxtJml") as TextBox;
                        var RepeatCount = int.Parse(txtJml.Text);
                        for (int i = 0; i < RepeatCount; i++)
                        {
                            DropDownList cmb = dr.FindControl("CmbPrinter") as DropDownList;
                            var printName = "All";
                            if (cmb != null)
                                printName = cmb.SelectedValue;
                            RowNum++;
                            Barcode.Add(new BarcodeItem() { Barcode = dr.Cells[2].Text, PrinterName = printName } );

                        }
                    }
                    if (Barcode.Count > 0)
                    {
                        //DefaultHubManager hd = new DefaultHubManager(GlobalHost.DependencyResolver);
                        //var hub = hd.ResolveHub("BarcodeHub") as BarcodeHub;
                        var context = GlobalHost.ConnectionManager.GetHubContext<BarcodeHub>();
                        var Printers = Barcode.Select(x => x.PrinterName).Distinct().ToList();
                        foreach (var printer in Printers)
                        {
                            var datas = (from x in Barcode
                                        where x.PrinterName == printer
                                        select new string(x.Barcode.ToCharArray())).ToList();
                            context.Clients.All.PrintBarcode(printer, datas);
                        }
                        //var hub = GlobalHost.ConnectionManager.GetHubContext<BarcodeHub>() as BarcodeHub;
                        //hub.PrintBarcode("All", Barcode);
                        CommonWeb.Alert(this, "Data barcode di Cetak");
                    }
                }
            }
            catch(Exception ex)
            {
                CommonWeb.Alert(this, "Gagal cetak barcode:"+ex.Message + " - "+ex.StackTrace);
            }
        }
        void Preview()
        {
            var orderNo = Request.QueryString["value"];
            if (!string.IsNullOrEmpty(orderNo))
            {
                /*
                // Create the required label
                var label = new SharpPDFLabel.Labels.A4Labels.Avery.LabelBarcodeCustom();

                // Create a LabelCreator, passing the required label
                var labelCreator = new SharpPDFLabel.LabelCreator(label);

                //Add content to the labels

                // instantiate a writer object
                var barcodeWriter = new BarcodeWriter();

                // set the barcode format
                barcodeWriter.Format = BarcodeFormat.QR_CODE;
                */
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
              
                DataTable dt = new DataTable("data");
                dt.Columns.Add("No",typeof(int));
                dt.Columns.Add("OrderNo");
                dt.Columns.Add("NoBalitTanah");
                dt.Columns.Add("Barcode");
                int RowNum = 0;
                foreach(GridViewRow dr in GvData.Rows)
                {
                    var txtJml = dr.FindControl("TxtJml") as TextBox;
                    var RepeatCount = int.Parse(txtJml.Text);
                    for(int i = 0; i < RepeatCount; i++)
                    {
                        RowNum++;
                        var NewRow = dt.NewRow();
                        var fName = Path.GetTempPath() + "/" + Guid.NewGuid().ToString().Replace("-","_") +".jpg";
                        string FilePath = @"file:\" + fName;
                        var result = new Bitmap(qr.Write(dr.Cells[2].Text));
                        result.Save(fName, ImageFormat.Jpeg);
                        NewRow["No"] = RowNum;
                        NewRow["OrderNo"] = orderNo;
                        NewRow["NoBalitTanah"] = dr.Cells[2].Text;
                        NewRow["Barcode"] = FilePath;//dr.Cells[2].Text
                        dt.Rows.Add(NewRow);

                    }
                }
                dt.AcceptChanges();
                reportViewer.LocalReport.EnableExternalImages = true;
                
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports") + "/BarcodeSample.rdlc";

                ReportDataSource datasource = new ReportDataSource("BarcodeDS", dt);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(datasource);



                // Create the sales order number report parameter  
                //ReportParameter salesOrderNumber = new ReportParameter();
                //salesOrderNumber.Name = "SalesOrderNumber";
                //salesOrderNumber.Values.Add("SO43661");

                // Set the report parameters for the report  
                //reportViewer.ServerReport.SetParameters(
                //new ReportParameter[] { salesOrderNumber });
            }
        }
        void LoadData(string orderNo)
        {
            using(var db = new smlpobDB())
            {
                var dataSample = (from x in db.ordersampletbls
                                 where x.orderNo == orderNo
                                 select x).ToList();
                GvData.DataSource = dataSample;
                GvData.DataBind();
            }
            
        }
        public class BarcodeItem
        {
            public string PrinterName { get; set; }
            public string Barcode { get; set; }
        }
    }
}