using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GemBox.Spreadsheet;

namespace BalitTanahPelayanan.Pages.Private.Analis
{
    public partial class InputParameter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var NoBalitTanah = Request.QueryString["NoBalitTanah"];
                if (!string.IsNullOrEmpty(NoBalitTanah))
                {
                    GetTranslation();
                    LoadData(NoBalitTanah);
                }
            }
            BtnDownloadAlat.Click += BtnDownloadAlat_Click;
            BtnDownloadManual.Click += BtnDownloadManual_Click;
            BtnKembali.Click += BtnKembali_Click;
            BtnUbah.Click += BtnUbah_Click;
            BtnSimpan.Click += BtnSimpan_Click;
            CmbParameter.SelectedIndexChanged += CmbParameter_SelectedIndexChanged;
        }

        private void BtnDownloadManual_Click(object sender, EventArgs e)
        {
            if (ViewState["fileAttachmentUrl"] != null)
            {
                Response.Redirect(ViewState["fileAttachmentUrl"].ToString());
            }
        }
        
        //void uploadalatN()
        //{
        //    try
        //    {
        //        var db = new smlpobDB();
        //        string uploadN = FileUploadAlat.FileContent.ToString();
        //        //Console.Write("Insert file path : ");

        //        var newN = db.parameterstbls.Where(x => x.string1 == FileUploadAlat.FileContent.ToString()).FirstOrDefault();
        //        //string filepath = Console.ReadLine();

        //        if ((FileUploadAlat.HasFile && newN != null))
        //        {
        //            CommonWeb.Alert(this, "File Tidak Ada");
        //        }
        //        else
        //        {
        //            // If using Professional version, put your serial key below
        //            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
        //            var workbook = ExcelFile.Load(newN);

        //            // Select active worksheet.
        //            var worksheet = workbook.Worksheets.ActiveWorksheet;

        //            // Display the value of first cell in MessageBox.
        //            int rowTotal = worksheet.Rows.Count();
        //            for (int x = 0; x < rowTotal; x++)
        //            {
        //                var readData = worksheet.Cells[x, 4].GetFormattedValue();
        //                if (readData == "blk")
        //                {
        //                    string usedData = worksheet.Cells[x + 1, 5].GetFormattedValue();
        //                    Console.Write(usedData);
        //                    break;
        //                }
        //            }
        //        }
        //        //if (!File.Exists(filepath))
        //        //{
        //        //    Console.WriteLine("Ga ada filenya bodoh");
        //        //}
        //        //else
        //        //{
        //        //    // If using Professional version, put your serial key below.
        //        //    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

        //        //    var workbook = ExcelFile.Load(filepath);

        //        //    // Select active worksheet.
        //        //    var worksheet = workbook.Worksheets.ActiveWorksheet;

        //        //    // Display the value of first cell in MessageBox.
        //        //    int rowTotal = worksheet.Rows.Count();

        //        //for (int x = 0; x < rowTotal; x++)
        //        //{
        //        //    var readData = worksheet.Cells[x, 4].GetFormattedValue();
        //        //    if (readData == "blk")
        //        //    {
        //        //        string usedData = worksheet.Cells[x + 1, 5].GetFormattedValue();
        //        //        Console.Write(usedData);
        //        //        break;
        //        //    }
        //        //}
        //        //}

        //        Console.ReadLine();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("The process failed: {0}", ex.ToString());
        //    }
        //}
        //void uploadalatC()
        //{
        //    try
        //    {
        //        var db = new smlpobDB();
        //        string uploadC = FileUploadAlat.FileContent.ToString();
        //        //Console.Write("Insert file path : ");

        //        var newC = db.parameterstbls.Where(x => x.string1 == FileUploadAlat.FileContent.ToString()).FirstOrDefault();
        //        //string filepath = Console.ReadLine();

        //        if (FileUploadAlat.HasFile && newC != null)
        //        {
        //            CommonWeb.Alert(this, "File Tidak Ada");
        //        }
        //        else
        //        {
        //            using (var sr = new StreamReader(newC))
        //            {
        //                while (sr.Peek() >= 0)
        //                {
        //                    if (sr.ReadLine().Contains("	Sample ID	Abs	CONC(mg/L)"))
        //                    {
        //                        string[] splt = sr.ReadLine().Split('\t');
        //                        newC.string2 = ConfigurationManager.ConnectionStrings["xls"].ConnectionString;
        //                    }
        //                }
        //            }
        //            Console.ReadLine();
        //        }
        //        //if (!File.Exists(filepath))
        //        //{
        //        //    Console.WriteLine("Ga ada filenya bodoh");
        //        //}
        //        //else
        //        //{
        //        //    using (var sr = new StreamReader(filepath))
        //        //    {
        //        //        while (sr.Peek() >= 0)
        //        //        {
        //        //            if (sr.ReadLine().Contains(" 	Sample ID	Abs	CONC(mg/L)"))
        //        //            {
        //        //                string[] splt = sr.ReadLine().Split('\t');
        //        //                Console.WriteLine(splt[3]);
        //        //            }
        //        //        }
        //        //    }

        //        //    Console.ReadLine();
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        CommonWeb.Alert(this, "The Process Failed");
        //        //Console.WriteLine("The process failed: {0}", ex.ToString());
        //    }
        //}

        private void BtnDownloadAlat_Click(object sender, EventArgs e)
        {
            if (ViewState["LabToolAttachmentUrl"] != null)
            {
                Response.Redirect(ViewState["LabToolAttachmentUrl"].ToString());
            }
            
        }

        private void BtnKembali_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnalisBerandaNonBatch.aspx");
        }

        private async void BtnSimpan_Click(object sender, EventArgs e)
        {
            try
            {

                var db = new smlpobDB();
                var newDetail = db.orderanalysisdetailtbls.Where(x => x.sampleNo == txtNoBalitTanah.Text && x.elementId.ToString() == CmbParameter.SelectedValue).FirstOrDefault();

                if (FileUploadManual.HasFile && newDetail!=null)
                {
                    string nameFile = "manual_" + CommonWeb.GetCurrentUser() 
                        + "_" + DateTime.Now.ToString("ddMMMyyyy")
                        +"_"+shortid.ShortId.Generate(true,false) 
                        + Path.GetExtension(FileUploadManual.FileName);
                    await CloudStorage.BlobPostAsync(FileUploadManual.FileBytes, nameFile);

                    newDetail.fileName = nameFile;
                    newDetail.fileAttachmentUrl = ConfigurationManager.AppSettings["DefaultBlobRootUrl"] + nameFile;

                }
                else
                {
                    CommonWeb.Alert(this, "Silakan lampirkan file perhitungan terlebih dahulu.");
                    return;
                }
                if (FileUploadAlat.HasFile && newDetail != null)
                {
                    string nameFile = "alat_" + CommonWeb.GetCurrentUser() 
                        + "_" + DateTime.Now.ToString("ddMMMyyyy") 
                        + "_" + shortid.ShortId.Generate(true, false) 
                        + Path.GetExtension(FileUploadAlat.FileName);
                    await CloudStorage.BlobPostAsync(FileUploadAlat.FileBytes, nameFile);

                    newDetail.LabToolFileName = nameFile;
                    newDetail.LabToolAttachmentUrl = ConfigurationManager.AppSettings["DefaultBlobRootUrl"] + nameFile;
                   
                }
                if (newDetail != null)
                {
                    newDetail.modDate = DateTime.Now;
                    newDetail.modBy = CommonWeb.GetCurrentUser();
                    newDetail.status = "Diproses";
                    await db.SaveChangesAsync();
                    ChangeOrderMasterStatus();
                    LoadData(txtNoBalitTanah.Text);
                    CommonWeb.Alert(this,"Data telah tersimpan");
                }
                else
                {
                    CommonWeb.Alert(this, "Gagal menyimpan, terjadi kesalahan.");
                 
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().ToString();
                LogHelpers.message = "failed to post input parameter:" + ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();
            }
        }

        void ChangeOrderMasterStatus()
        {
            using(var db = new smlpobDB()) {
                var isNotCompleted = db.orderanalysisdetailtbls.Any(x => x.orderNo == txtOrderNo.Text && x.status != "Diproses");
                if (!isNotCompleted)
                {
                    var master = db.ordermastertbls.Where(x => x.orderNo == txtOrderNo.Text).FirstOrDefault();
                    if (master != null)
                    {
                        master.status = Status.OrderStatus[5];
                        db.SaveChanges();
                    }
                }
            }
          
        }

        private void BtnUbah_Click(object sender, EventArgs e)
        {
            BtnUbah.Visible = false;
            BtnSimpan.Visible = true;
            UploadDiv.Visible = true;
            DownloadDiv.Visible = false;
        }

        private void CmbParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderByStatus(Convert.ToInt32(CmbParameter.SelectedValue));
        }
        void RenderByStatus(int elementId)
        {
            if (!string.IsNullOrEmpty(elementId.ToString()))
            {
                using (var db = new smlpobDB())
                {
                    var parameterUji = (from x in db.orderanalysisdetailtbls
                                        where x.sampleNo == txtNoBalitTanah.Text && x.elementId == elementId
                                        select x).FirstOrDefault();
                    if (parameterUji != null)
                    {
                        if (parameterUji.status == "Menunggu")
                        {
                            BtnUbah.Visible = false;
                            BtnSimpan.Visible = true;
                            UploadDiv.Visible = true;
                            DownloadDiv.Visible = false;
                        }
                        else
                        {
                            BtnUbah.Visible = true;
                            BtnSimpan.Visible = false;
                            UploadDiv.Visible = false;
                            DownloadDiv.Visible = true;
                            ViewState["LabToolAttachmentUrl"] = parameterUji.LabToolAttachmentUrl;
                            ViewState["fileAttachmentUrl"] = parameterUji.fileAttachmentUrl;
                            //BtnDownloadAlat.PostBackUrl = parameterUji.LabToolAttachmentUrl;
                            //BtnDownloadManual.PostBackUrl = parameterUji.fileAttachmentUrl;
                        }
                    }
                }
            }
        }
        void LoadData(string NoBalitTanah)
        {
            using(var db = new smlpobDB())
            {
                var sample = db.ordersampletbls.Where(x => x.noBalittanah == NoBalitTanah).FirstOrDefault();
                var data = (from x in db.ordersampletbls.Include(c=>c.ordermastertbl).Include(d=>d.ordermastertbl.comoditytbl)
                            where x.noBalittanah == NoBalitTanah 
                            select x).FirstOrDefault();
                if (data != null)
                {
                    txtKomoditas.Text = data.ordermastertbl.comoditytbl.comodityName;
                    txtNamaSampel.Text = sample.sampleDescription;
                    txtNoBalitTanah.Text = NoBalitTanah;
                    txtNoSample.Text = sample.sampleCode;
                    txtTipeAnalis.Text = data.ordermastertbl.analysisType;
                    txtOrderNo.Text = sample.orderNo;
                }

                var parameterUji = (from x in db.orderanalysisdetailtbls.Include(c=>c.elementservicestbl)
                                   where x.sampleNo == NoBalitTanah
                                   select new { x.elementId, x.elementservicestbl.elementCode }).ToList();
                if (parameterUji != null)
                {
                    CmbParameter.DataSource = parameterUji;
                    CmbParameter.DataTextField = "elementCode";
                    CmbParameter.DataValueField = "elementId";
                    CmbParameter.DataBind();
                    CmbParameter.SelectedIndex = 0;
                    RenderByStatus(Convert.ToInt32(CmbParameter.SelectedValue));
                }
            }
        }

        void GetTranslation()
        {
            no_balittanah.Text = LanguageHelper.GetTranslation("no_balittanah");
            no_pesanan.Text = LanguageHelper.GetTranslation("order_no");
            no_sample.Text = LanguageHelper.GetTranslation("sample_no");
            nama_sample.Text = LanguageHelper.GetTranslation("sample_name");
            tipe_analis.Text = LanguageHelper.GetTranslation("analysis_type");
            komoditas.Text = LanguageHelper.GetTranslation("commodity");
            pilihparameteruji.Text = LanguageHelper.GetTranslation("pilihparameteruji");
            uploadexcel.Text = LanguageHelper.GetTranslation("uploadexcel");
            uploadfiledarialat.Text = LanguageHelper.GetTranslation("uploadfiledarialat");
            dwnloadexcelpengukuran.Text = LanguageHelper.GetTranslation("dwnloadexcelpengukuran");
            dwnloadfilecsv.Text = LanguageHelper.GetTranslation("dwnloadfilecsv");
            BtnKembali.Text = LanguageHelper.GetTranslation("btn_kembali");
            BtnSimpan.Text = LanguageHelper.GetTranslation("btn_simpan");
            BtnUbah.Text = LanguageHelper.GetTranslation("btn_ubah");
            
        }
    }
}