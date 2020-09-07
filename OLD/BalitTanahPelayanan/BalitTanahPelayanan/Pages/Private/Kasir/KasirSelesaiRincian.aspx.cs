using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private.Kasir
{
    public partial class KasirSelesaiRincian : System.Web.UI.Page
    {
        SampleControls sampelControls = new SampleControls();
        CustomerRincianControl rincianControls = new CustomerRincianControl();
        OrderMasterControls orderControls = new OrderMasterControls();

        void GetTranslation()
        {
            btnKembali.Text = LanguageHelper.GetTranslation("back");
            btnPrint.Text = LanguageHelper.GetTranslation("printQR");
            GvSample.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            LitOrder.Text = LanguageHelper.GetTranslation("Lit_NoOrder");
            LitCustomer.Text = LanguageHelper.GetTranslation("Lit_Customer");
            LitKomoditas.Text = LanguageHelper.GetTranslation("Lit_Komoditas");
            LitAnalisis.Text = LanguageHelper.GetTranslation("Lit_Analisis");
            LitSampel.Text = LanguageHelper.GetTranslation("Lit_Sampel");
            LitHarga.Text = LanguageHelper.GetTranslation("Lit_Price");
            LitDaftarSampel.Text = LanguageHelper.GetTranslation("daftar_sampel");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GvSample.RowDataBound += GvSample_RowDataBound;
            if (!IsPostBack)
            {
                var NoOrder = Request.QueryString["orderNo"];
                if (!string.IsNullOrEmpty(NoOrder))
                {
                    
                    LoadDetail(NoOrder);
                    LoadGridSample(NoOrder);
                }

            }
            GetTranslation();

            
            this.GvSample.DataBound += (object o, EventArgs ev) =>
            {
                GvSample.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        void LoadGridSample(string orderNo)
        {


            var ret = sampelControls.GetDataByOrderNo(orderNo);
            var datas = ret.Result;


            GvSample.DataSource = datas;
            GvSample.DataBind();

            if (GvSample.Rows.Count > 0)
            {
                GvSample.UseAccessibleHeader = true;
                GvSample.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        void LoadDetail(string fid)
        {
            var ret = rincianControls.DetailDataCustomer(fid);
            var data = ret.Result;

            if (data != null)
            {
                txtNoOrder.Text = data.orderNo.ToString();
                txtCustomer.Text = data.customertbl.customerName.ToString();
                txtKomoditas.Text = data.comoditytbl.comodityName.ToString();
                txtTipeAnalisis.Text = data.analysisType;
                txtTotalSample.Text = data.sampleTotal.ToString();
                txtTotalHarga.Text = Formater.ToRupiah(data.priceTotal.Value);
            }
        }

        private void DoPrint()
        {
            var NoOrder = Request.QueryString["orderNo"];
            if (!string.IsNullOrEmpty(NoOrder))
            {
                Response.Redirect("CetakQR.aspx?orderNo=" + NoOrder);
            }
            /*
            PdfPTable pdfTable = new PdfPTable(GvSample.Columns.Count);
            foreach (GridViewRow gridViewRow in GvSample.Rows)
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

        private void DoKembali()
        {
            Response.Redirect("KasirSelesai.aspx");
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
                        DoKembali();
                        break;
                    case "Cetak":
                        DoPrint();
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi Kesalahan");

            }
        }

        private void GvSample_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("count_number");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_number");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("balittanah_number");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("gps");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("landuse");
            }
        }
    }
}