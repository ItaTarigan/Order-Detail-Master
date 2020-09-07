using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Controllers;
using System.IO;
using System.Configuration;

namespace BalitTanahPelayanan.Pages.Private.Analis
{
    public partial class DaftarOrder : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        string BatchID { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BatchID = Request.QueryString["batchId"];
            GvData.RowDataBound += GvData_RowDataBound;
            GvData.RowCommand += GvData_RowCommand;
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(BatchID))
                {
                    GetTranslation();
                    LoadBatchData();
                }
            }
            BtnDownload.Click += BtnDownload_Click;
            BtnBack.Click += (a, b) => { Response.Redirect("AnalisBeranda.aspx"); };
            BtnSimpan.Click += (a, b) => { Simpan(); };
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                if (GvData.HeaderRow != null)
                    GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }
        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                var orderNo = e.CommandArgument.ToString();
                Response.Redirect($"OrderDetail.aspx?orderNo={orderNo}&batchId={BatchID}");
            }
        }
        private void BtnDownload_Click(object sender, EventArgs e)
        {
            var templateFile = Server.MapPath("~/Document/Template/") + "/template_batch.xlsx";
            if(File.Exists(templateFile))
             Response.Redirect("/Document/Template/template_batch.xlsx");

        }
        async void Simpan()
        {
            if (!FileUpload1.HasFile)
            {
                CommonWeb.Alert(this,"Silakan pilih file yang mau di upload terlebih dahulu");
            }
            else
            {
                using(var db = new smlpobDB())
                {
                    var batchData = (from x in db.batchtbls
                                     where x.batchId == BatchID
                                     select x).FirstOrDefault();
                    if (batchData != null)
                    {
                        string nameFile = "batch_" + CommonWeb.GetCurrentUser()
                         + "_" + DateTime.Now.ToString("ddMMMyyyy")
                         + "_" + shortid.ShortId.Generate(true, false)
                         + Path.GetExtension(FileUpload1.FileName);
                        await CloudStorage.BlobPostAsync(FileUpload1.FileBytes, nameFile);

                        batchData.filename = nameFile;
                        batchData.fileurl = ConfigurationManager.AppSettings["DefaultBlobRootUrl"] + nameFile;
                        batchData.status = "Selesai";
                    }

                    var orderNos = (from x in db.ordermastertbls
                                   where x.batchId == BatchID
                                   select x).ToList();
                    foreach(var item in orderNos)
                    {
                        item.status = Status.OrderStatus[4];
                        var analysis = from x in db.orderanalysisdetailtbls
                                       where x.orderNo == item.orderNo
                                       select x;
                        foreach(var item2 in analysis)
                        {
                            item2.status = "Diproses";
                        }
                    }

                    

                    db.SaveChanges();
                    Response.Redirect("AnalisBeranda.aspx");
                }
            }
        }
        void LoadBatchData(string NoBalitTanah = "")
        {
            var data = orderControls.GetBatchFromId(BatchID);
            if (data != null)
            {
                GvData.DataSource = orderControls.GetOrdersFromBatchId(BatchID);
                GvData.DataBind();
            }

            if (GvData.Rows.Count > 0)
            {
                GvData.UseAccessibleHeader = true;
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("customer_name");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("commodity");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("analisystype");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("total_sample");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("order_status");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("BtnRincian") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("parameter_test");
            }
        }

        void GetTranslation()
        {
            txtdaftarsample.Text = LanguageHelper.GetTranslation("sample_list");
            GvData.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            litDownload.Text = LanguageHelper.GetTranslation("download_template");
            litUpload.Text = LanguageHelper.GetTranslation("upload");
            BtnSimpan.Text = LanguageHelper.GetTranslation("btn_simpan");
            BtnBack.Text = LanguageHelper.GetTranslation("btn_kembali");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }


    }
}