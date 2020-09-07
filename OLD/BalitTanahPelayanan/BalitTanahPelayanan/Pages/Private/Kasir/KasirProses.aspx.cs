using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Controllers;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BalitTanahPelayanan.Pages.Private.Kasir
{
    public partial class KasirProses : System.Web.UI.Page
    {
        OrderMasterControls orderControls = new OrderMasterControls();

        void GetTranslation()
        {
            LitProses.Text = LanguageHelper.GetTranslation("title_pesanan_diproses");
            GvData.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
            btnMasuk.Text = LanguageHelper.GetTranslation("order_entry");
            btnProses.Text = LanguageHelper.GetTranslation("order_processed");
            btnSelesai.Text = LanguageHelper.GetTranslation("order_complete");
            btnVerifikasi.Text = LanguageHelper.GetTranslation("title_payment_verification");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GvData.RowDataBound += GvData_RowDataBound;
            if (!IsPostBack)
            {
                
                RefreshGrid();
            }
            GetTranslation();

            GvData.RowCommand += GvData_RowCommand;
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName){
                case "print":
                    var NoOrder = e.CommandArgument.ToString();
                    if (!string.IsNullOrEmpty(NoOrder))
                    {
                        Response.Redirect("CetakTandaTerima.aspx?orderNo=" + NoOrder);
                    }
                    break;
            }
            /*
            PdfPTable pdfTable = new PdfPTable(GvData.Columns.Count);
            foreach (GridViewRow gridViewRow in GvData.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfTable.AddCell(pdfCell);
                }
            }
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=PrintTandaTerima.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();*/
        }

        void RefreshGrid(string param = "")
        {
            var ret = orderControls.GetData();
            var datas = ret.Result.Where(x => x.paymentStatus != Status.PaymentStatus[0] && x.status != Status.OrderStatus[7] && x.status != Status.OrderStatus[8]);

            GvData.DataSource = datas;
            GvData.DataBind();

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
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("analysis_type");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("order_status");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("payment_status");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("status_type");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("actions");

            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("btnRincian") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("detail");

                var linkBtn2 = e.Row.FindControl("btnPrint") as LinkButton;
                if (linkBtn2 != null)
                    linkBtn2.Text = LanguageHelper.GetTranslation("print");
            }
            
        }
    }
}