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
    public partial class CetakTandaTerima : System.Web.UI.Page
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
            //BtnKembali.Attributes.Add("onclick", "window.history.go(-1);");
        }

        private void BtnKembali_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(prevPage))
            {
                Response.Redirect("KasirProses.aspx");
            }
            else
            Response.Redirect(prevPage);
        }

        void LoadData(string orderNo)
        {
            try
            {
                DataTable dt = new DataTable("data");
                dt.Columns.Add("No", typeof(int));
                dt.Columns.Add("JenisAnalisis");
                dt.Columns.Add("Tarif", typeof(Int64));
                dt.Columns.Add("JumlahContoh", typeof(int));
                dt.Columns.Add("Biaya", typeof(Int64));
                int RowNum = 0;

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
                bool isPackage = false;

                using (var db = new smlpobDB())
                {
                    var orderData = (from x in db.ordermastertbls.Include(c => c.comoditytbl).Include(c => c.customertbl)
                                     where x.orderNo == orderNo
                                     select x).FirstOrDefault();
                    if (orderData != null)
                    {
                        if (orderData.comoditytbl.isPackage == "1")
                        {
                            reportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports") + "/TandaTerimaKasirPaket.rdlc";
                            isPackage = true;
                        }
                        else
                        {
                            reportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports") + "/TandaTerimaKasir.rdlc";
                        }


                        var datas = (from x in db.orderpricedetailtbls
                                     .Include(c => c.elementservicestbl)
                                     where x.orderNo == orderNo
                                     select x).ToList();
                        //set DS
                        foreach (var item in datas)
                        {
                            RowNum++;
                            var NewRow = dt.NewRow();

                            NewRow["No"] = RowNum;
                            NewRow["JenisAnalisis"] = item.elementservicestbl.elementCode;
                            NewRow["Tarif"] = item.price;
                            NewRow["JumlahContoh"] = item.quantity;
                            NewRow["Biaya"] = item.TotalPrice;
                            dt.Rows.Add(NewRow);


                        }

                        ReportParameter NoOrderParam = new ReportParameter();
                        NoOrderParam.Name = "NoOrder";
                        NoOrderParam.Values.Add(orderNo);

                        ReportParameter TanggalTerimaParam = new ReportParameter();
                        TanggalTerimaParam.Name = "TanggalTerima";
                        TanggalTerimaParam.Values.Add(orderData.receiptDate?.ToString());

                        ReportParameter JumlahContohParam = new ReportParameter();
                        JumlahContohParam.Name = "JumlahContoh";
                        JumlahContohParam.Values.Add(datas.Count.ToString());

                        ReportParameter KomoditasParam = new ReportParameter();
                        KomoditasParam.Name = "Komoditas";
                        KomoditasParam.Values.Add(orderData.comoditytbl.comodityName);

                        ReportParameter JenisAnalisaParam = new ReportParameter();
                        JenisAnalisaParam.Name = "JenisAnalisa";
                        JenisAnalisaParam.Values.Add(orderData.analysisType);

                        ReportParameter NamaPengirimParam = new ReportParameter();
                        NamaPengirimParam.Name = "NamaPengirim";
                        NamaPengirimParam.Values.Add(orderData.customertbl.customerName);

                        ReportParameter InstansiParam = new ReportParameter();
                        InstansiParam.Name = "Instansi";
                        InstansiParam.Values.Add(orderData.customertbl.companyName);

                        ReportParameter AlamatParam = new ReportParameter();
                        AlamatParam.Name = "Alamat";
                        AlamatParam.Values.Add(orderData.customertbl.companyAddress);

                        ReportParameter TeleponParam = new ReportParameter();
                        TeleponParam.Name = "Telepon";
                        TeleponParam.Values.Add(orderData.customertbl.companyPhone);

                        ReportParameter NamaPetugasParam = new ReportParameter();
                        NamaPetugasParam.Name = "NamaPetugas";
                        NamaPetugasParam.Values.Add(CommonWeb.GetCurrentUserName());

                        ReportParameter TanggalCetakParam = new ReportParameter();
                        TanggalCetakParam.Name = "TanggalCetak";
                        TanggalCetakParam.Values.Add(DateTime.Now.ToString());

                        ReportParameter ImageQRParam = new ReportParameter();
                        ImageQRParam.Name = "ImageQR";
                        ImageQRParam.Values.Add(FilePath);

                        var reportParams = new List<ReportParameter>() { NoOrderParam, TanggalTerimaParam,
                    JumlahContohParam,KomoditasParam,JenisAnalisaParam,NamaPengirimParam,InstansiParam,AlamatParam,
                    TeleponParam,NamaPetugasParam,TanggalCetakParam, ImageQRParam};

                        if (isPackage)
                        {
                            ReportParameter TotalBiayaParam = new ReportParameter();
                            TotalBiayaParam.Name = "TotalBiaya";
                            TotalBiayaParam.Values.Add(orderData.priceTotal?.ToString());
                            reportParams.Add(TotalBiayaParam);

                            ReportParameter TambahanBiayaParam = new ReportParameter();
                            TambahanBiayaParam.Name = "TambahanBiaya";
                            TambahanBiayaParam.Values.Add(orderData.additionalPriceRemark);
                            reportParams.Add(TambahanBiayaParam);
                        }

                        

                        reportViewer.LocalReport.SetParameters(reportParams);



                    }
                }

                dt.AcceptChanges();
                ReportDataSource datasource = new ReportDataSource("ReportDS", dt);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(datasource);

            }catch(Exception ex)
            {
                CommonWeb.Alert(this, "terjadi kesalahan, silakan coba kembali.");
                LogHelpers.source = this.GetType().ToString();
                LogHelpers.message = "failed to print tanda terima kasir with the following error:" + ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();
            }

            
        }
    }
}