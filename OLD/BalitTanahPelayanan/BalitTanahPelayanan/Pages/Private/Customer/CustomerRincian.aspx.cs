using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GemBox.Spreadsheet;
using System.Configuration;
using System.IO;
using PdfSharp.Pdf.IO;

namespace BalitTanahPelayanan.Pages.Private.Customer
{
    public partial class CustomerRincian : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();

        void GetTranslation()
        {
            BtnDownload.Text = LanguageHelper.GetTranslation("downl");
            BtnDownloadLampiran.Text = LanguageHelper.GetTranslation("downl");
            BtnKembali.Text = LanguageHelper.GetTranslation("back");
            BtnKajiUlang.Text = LanguageHelper.GetTranslation("reviewing");
            BtnCetakPermohonan.Text = LanguageHelper.GetTranslation("print_request");
            BtnTutup.Text = LanguageHelper.GetTranslation("close");
            rincian.Text = LanguageHelper.GetTranslation("Lit_NoOrder");
            komoditas.Text = LanguageHelper.GetTranslation("Lit_Komoditas");
            tipeanalisis.Text = LanguageHelper.GetTranslation("Lit_Analisis");
            totalsample.Text = LanguageHelper.GetTranslation("Lit_Sampel");
            totalharga.Text = LanguageHelper.GetTranslation("Lit_Price");
            status.Text = LanguageHelper.GetTranslation("Lit_status"); 
            //txtStatusPesanan.Text = LanguageHelper.GetTranslation("order_status");
            LitTitle.Text = LanguageHelper.GetTranslation("sample_list");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
            lhpresult.Text = LanguageHelper.GetTranslation("lhpresult");
        }
        string orderNo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BtnDownloadLampiran.Click += BtnDownloadLampiran_Click;
            BtnDownload.Click += BtnDownload_Click;
            GvData.RowDataBound += GvData_RowDataBound;
            GvParameter.RowDataBound += GvParameter_RowDataBound;
            if (!IsPostBack)
            {
                
                orderNo = Request.QueryString["orderNo"];
                LoadHeaderInfo(orderNo);
                LoadGridSample(orderNo);
            }
            BtnTutup.Click += BtnTutup_Click;
            GvData.RowCommand += GvData_RowCommand;
            GetTranslation();

            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        private void BtnDownloadLampiran_Click(object sender, EventArgs e)
        {
            if (ViewState["DownloadLampiranUrl"] != null)
            {
                Response.Redirect(ViewState["DownloadLampiranUrl"].ToString());
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            if (ViewState["LHPUrl"] != null)
            {
                Response.Redirect(ViewState["LHPUrl"].ToString());
            }
        }

        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("serial_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_no");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("balittanah_no");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("gps");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("soil_type");                
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("sample_is_accepted");
                e.Row.Cells[10].Text = LanguageHelper.GetTranslation("actions");                                
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("Lihat") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("test_parameter");
            }
        }
        private void GvParameter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {                
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("test_parameter");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("testing_status");
            }            
        }




        private void BtnTutup_Click(object sender, EventArgs e)
        {
            DivRow6.Visible = false;
            DivRow7.Visible = false;

            DivRow1.Visible = true;
            DivRow2.Visible = true;
            DivRow3.Visible = true;
            DivRow4.Visible = true;
            DivRow5.Visible = true;

        }

        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var NoBalitTanah = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "DetailorderList":
                    OrderListControls orderControls = new OrderListControls();
                    var ret = orderControls.GetParameter(NoBalitTanah);
                    var data = ret.Result;

                    DivRow6.Visible = true;
                    DivRow7.Visible = true;

                    DivRow1.Visible = false;
                    DivRow2.Visible = false;
                    DivRow3.Visible = false;
                    DivRow4.Visible = false;
                    DivRow5.Visible = false;
                    
                    GvParameter.DataSource = data.ToList();
                    GvParameter.DataBind();
                    break;
            }
        }


        void LoadHeaderInfo(string orderNo)
        {

            var ret = orderControls.DetailData(orderNo);
            var data = ret.Result;

            if (data != null)
            {
           
                txtNoOrder.Text = data.orderNo;
                TxtTotalHarga.Text = "Rp "+data.priceTotal?.ToString("n2");
                txtKomoditas.Text = data.comoditytbl.comodityName;
                txtTipeAnalis.Text = data.analysisType;
                txtTotalSample.Text = data.sampleTotal.ToString();
                txtStatusPesanan.Text = data.status;
                if(data.paymentStatus== Status.PaymentStatus[0])
                {
                    BtnCetakPermohonan.Visible = true;
                }
                else
                {
                    BtnCetakPermohonan.Visible = false;
                }
                if (data.status == Status.OrderStatus[7] || data.status == Status.OrderStatus[8])
                {
                    BtnKajiUlang.Visible = true;
                }
                else
                {
                    BtnKajiUlang.Visible = false;
                }

                if (!string.IsNullOrEmpty(data.LHPAttachmentUrl))
                {
                    ViewState["LHPUrl"] = data.LHPAttachmentUrl;
                    DivDownload.Visible = true;
                    //BtnDownload.PostBackUrl = UrlToFile;
                }
                else
                {
                    DivDownload.Visible = false;
                }
                if (!string.IsNullOrEmpty(data.CalculationFileUrl))
                {
                    ViewState["DownloadLampiranUrl"] = data.CalculationFileUrl;
                    DivDownloadLampiran.Visible = true;
                    //BtnDownload.PostBackUrl = UrlToFile;
                }
                else
                {
                    DivDownloadLampiran.Visible = false;
                }
            }
        }

        void LoadGridSample(string orderNo)
        {

            var ret = orderControls.GetDataDetail(orderNo);
            var datas = ret.Result;
            
            foreach (var data in datas)
            {
                if (data.isReceived == "1")
                {
                    data.isReceived = "Sudah";
                }

                else
                {
                    data.isReceived = "Belum";
                }
            }

            GvData.DataSource = datas;
            GvData.DataBind();


            if (GvData.Rows.Count > 0)
            {
                GvData.UseAccessibleHeader = true;
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void ActionButton(object sender, EventArgs e)
        {
            try
            {

                var btn = sender as Button;
                var command = btn.CommandName;

                switch (command)
                {
                    case "Kembali":
                        Response.Redirect("CustomerBeranda.aspx");
                        break;

                    case "Cetak":
                        string filepath = GenerateLP();
                        //cetak lembar permohonan
                        Response.Redirect("CustomerCetakPermohonan.aspx?path=" + filepath);
                        break;
                    case "KajiUlang":
                        
                        Response.Redirect("FormKajiUlang.aspx?orderNo=" + txtNoOrder.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi Kesalahan");
              
            }
        }

        private string GenerateLP()
        {
            List<string> fileFragment = new List<string>();
            string savePath = "";
            string filePath = Server.MapPath("~/Document/Generate/");
            string qrpath = Server.MapPath("~/Document/QR/");
            string qr = QRcode.GenerateQR(txtNoOrder.Text.Replace(" ", ""), qrpath); //.Replace("/", "")
            string fileName = "";
            string replaceName = null;

            try
            {
                var ret = orderControls.GetDataForPrint(txtNoOrder.Text);
                var order = ret.Result;
                replaceName = order.orderNo.Replace("/","");
                var ordersample = order.ordersampletbls.ToList();
                var orderprice = order.orderpricedetailtbls;

                SpreadsheetInfo.SetLicense(ConfigurationManager.AppSettings["GemboxLicense"]);
                bool isPackage = false;
                if (order.comoditytbl.isPackage == "1")
                {
                    isPackage = true;
                }
                // Load Excel file.
                var templateName = isPackage ? "/TemplateLP_Paket.xlsx" : "/TemplateLP.xlsx";
                var workbook =   ExcelFile.Load(Server.MapPath("~/Document/Template") + templateName);

                // Select active worksheet.
                var worksheet = workbook.Worksheets[0];

                worksheet.Cells["G9"].Value = order.orderNo;
                worksheet.Cells["D12"].Value = order.sampleTotal;
                worksheet.Cells["D11"].Value = order.receiptDate;
                worksheet.Cells["F13"].Value = ordersample[0].village;
                worksheet.Cells["L13"].Value = ordersample[0].subDistrict;
                worksheet.Cells["F14"].Value = ordersample[0].district;
                worksheet.Cells["L14"].Value = ordersample[0].province;
                worksheet.Cells["F15"].Value = ordersample[0].longitude +"," +ordersample[0].latitude;
                worksheet.Cells["D16"].Value = order.customertbl.customerName;
                worksheet.Cells["D17"].Value = order.customertbl.companyName;
                worksheet.Cells["D18"].Value = order.customertbl.companyAddress;
                worksheet.Cells["M17"].Value = order.customertbl.companyPhone;
                // Insert Image
                worksheet.Pictures.Add(qr, "A49");
                //worksheet.Pictures.Add(qr, "N8", "N12");

                int pages = 1;
                int startRow = 22;
                int row = 0;
                int rowLimit = 21;
                int totalPage = decimal.ToInt32(Math.Ceiling(orderprice.Count() / (decimal)21));
                decimal pagetotalprice = 0;

                foreach (var item in orderprice)
                {
                    worksheet.Cells[row + startRow, 0].Value = row + 1;
                    worksheet.Cells[row + startRow, 1].Value = item.elementservicestbl.elementCode;
                    worksheet.Cells[row + startRow, 10].Value = item.price.Value <=0 ? "-" : item.price.Value.ToString("N0");
                    worksheet.Cells[row + startRow, 12].Value = item.quantity;
                    worksheet.Cells[row + startRow, 13].Value = item.TotalPrice.Value <= 0 ? "-" : item.TotalPrice.Value.ToString("N0");

                    pagetotalprice = pagetotalprice + item.TotalPrice.Value;

                    row++;

                    if (row == rowLimit)
                    {
                        worksheet.Cells["N45"].Value = isPackage ? order.priceTotal?.ToString("N0") : pagetotalprice.ToString("N0");
                        worksheet.Cells["N46"].Value = "page" + pages + "/" + totalPage;
                        if (isPackage)
                        {
                            worksheet.Cells["B48"].Value = order.additionalPriceRemark;
                        }
                        // Save the file in PDF format.
                        CheckFolderExists(filePath);
                        fileName = replaceName + "_page" + pages + ".pdf";
                        savePath = filePath + fileName;
                        workbook.Save(savePath);
                        fileFragment.Add(savePath);

                        pages++;

                        for (int x = 1; x < 21; x++)
                        {
                            worksheet.Cells[row + startRow, 0].Value = "";
                            worksheet.Cells[row + startRow, 1].Value = "";
                            worksheet.Cells[row + startRow, 10].Value = "";
                            worksheet.Cells[row + startRow, 12].Value = "";
                            worksheet.Cells[row + startRow, 13].Value = "";
                        }
                        row = 0;
                        pagetotalprice = 0;
                    }
                }

                if (pages > 1)
                {
                    worksheet.Cells["N45"].Value = isPackage ? order.priceTotal?.ToString("N0") : pagetotalprice.ToString("N0");
                    worksheet.Cells["N46"].Value = "page" + pages + "/" + totalPage;
                    if (isPackage)
                    {
                        worksheet.Cells["B48"].Value = order.additionalPriceRemark;
                    }
                    // Save the file in PDF format.
                    CheckFolderExists(filePath);
                    fileName = replaceName + "_page" + pages + ".pdf";
                    savePath = filePath + fileName;
                    fileFragment.Add(savePath);
                    workbook.Save(savePath);

                    #region Combine multiple pdf
                    // Open the output document
                    PdfSharp.Pdf.PdfDocument outputDocument = new PdfSharp.Pdf.PdfDocument();

                    // Iterate files
                    foreach (string file in fileFragment)
                    {
                        // Open the document to import pages from it.
                        PdfSharp.Pdf.PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                        // Iterate pages
                        int count = inputDocument.PageCount;
                        for (int idx = 0; idx < count; idx++)
                        {
                            // Get the page from the external document...
                            PdfSharp.Pdf.PdfPage page = inputDocument.Pages[idx];
                            // ...and add it to the output document.
                            outputDocument.AddPage(page);
                        }
                    }

                    // Save the document...
                    CheckFolderExists(filePath);
                    fileName = replaceName + ".pdf";
                    savePath = filePath + fileName;
                    outputDocument.Save(savePath);
                    #endregion
                }
                else
                {
                    worksheet.Cells["N45"].Value = isPackage ? order.priceTotal?.ToString("N0") : pagetotalprice.ToString("N0");
                    worksheet.Cells["N46"].Value = "page" + pages + "/" + totalPage;
                    if (isPackage)
                    {
                        worksheet.Cells["B48"].Value = order.additionalPriceRemark;
                    }
                    // Save the file in PDF format.
                    CheckFolderExists(filePath);
                    fileName = replaceName + ".pdf";
                    savePath = filePath + fileName;
                    workbook.Save(savePath);
                }

                return savePath;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        private bool CheckFolderExists(string path)
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