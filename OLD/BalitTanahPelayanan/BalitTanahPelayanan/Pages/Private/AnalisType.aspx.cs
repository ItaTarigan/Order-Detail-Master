using BalitTanahPelayanan.Models;
using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using System.Web.Security;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class AnalisType : System.Web.UI.Page
    {
        smlpobDB context = new smlpobDB();
        string userId = Membership.GetUser().UserName.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnSave.Click += BtnSave_Click;
        }

        protected async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var UploadFolder = HttpContext.Current.Server.MapPath("/Uploads");
                string nameFile = userId +"_"+ DateTime.Now.ToString("ddMMMyyyy") + Path.GetExtension(FileUpload1.FileName);
                //var fileName = Guid.NewGuid().ToString().Replace("-", "_") + Path.GetExtension(FileUpload1.FileName);
                var fullName = UploadFolder + "\\" + nameFile;
                
                if (FileUpload1.HasFile)
                {
                    await CloudStorage.BlobPostAsync(FileUpload1.FileBytes, nameFile);
                    var newDetail = new orderanalysisdetailtbl() { };
                    newDetail.fileName = nameFile;
                    newDetail.fileAttachmentUrl = ConfigurationManager.AppSettings["DefaultBlobRootUrl"]+nameFile;
                    newDetail.modDate = DateTime.Now;                    
                    newDetail.modBy = CommonWeb.GetCurrentUser();
                    newDetail.orderDetailNo = Convert.ToInt32(txtOrderDetailNo.Text);

                    var NewItem = new parameterstbl() { };
                    NewItem.string0 = txtBerat.Text;
                    NewItem.string1 = txtFP.Text;                    
                    NewItem.modDate = DateTime.Now;

                    context.parameterstbls.Add(NewItem);

                    using (var context = new smlpobDB())
                    {
                        context.orderanalysisdetailtbls.Attach(newDetail);
                        context.Entry(newDetail).Property(x => x.fileAttachmentUrl).IsModified = true;
                        context.Entry(newDetail).Property(x => x.fileName).IsModified = true;
                        await context.SaveChangesAsync();
                    }
                        
                    context.SaveChanges();
                    await CloudStorage.BlobPostAsync(FileUpload1.FileBytes, nameFile);
                    TxtStatus.Text = "Berhasil";

                    //FileUpload1.SaveAs(fullName);                                                            
                }
            }
            
            catch (Exception ex)
            {
                TxtStatus.Text = "gagal save --> " + ex.Message;
            }
        }

    //    void SaveExcelToDB(string filename)
    //    {
    //        SpreadsheetInfo.SetLicense("E43Y-5TC3-221R-AA4K");
    //        List<ExcelData> Data = new List<ExcelData>();
    //        smlpobDB Context = new smlpobDB();
    //        var workbook = ExcelFile.Load(filename);            

    //        // Iterate through all worksheets in an Excel workbook.
    //        foreach (var worksheet in workbook.Worksheets)
    //        {
    //            int RowCount = 0;
    //            // Iterate through all rows in an Excel worksheet.
    //            foreach (var row in worksheet.Rows)
    //            {
    //                if (row.Cells[0].Value == null || row.Cells[0].StringValue == string.Empty) break;
    //                // Iterate through all allocated cells in an Excel row.                                        
    //                    var item = new ExcelData();
    //                    item.NeedleNumber = int.Parse(row.Cells[0].StringValue);
    //                    item.ResultID = int.Parse(row.Cells[1].StringValue);
    //                    item.Position = (row.Cells[2].StringValue);
    //                    item.SampleType = (row.Cells[3].StringValue);
    //                    item.SampleIdentity = (row.Cells[4].StringValue);
    //                    item.Ammonia = float.Parse(row.Cells[5].StringValue);
    //                    Data.Add(item);
    //                    RowCount++;
    //            }
    //        }            
    //    }
    //}

    //public class ExcelData
    //{
    //    public int NeedleNumber { get; set; }
    //    public int ResultID { get; set; }
    //    public string Position { get; set; }
    //    public string SampleType { get; set; }
    //    public string SampleIdentity { get; set; }
    //    public float Ammonia{ get; set; }

    }
}