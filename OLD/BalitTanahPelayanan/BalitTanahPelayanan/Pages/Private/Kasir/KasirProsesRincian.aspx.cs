using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private.Kasir
{
    public partial class KasirProsesRincian : System.Web.UI.Page
    {
        SampleControls sampelControls = new SampleControls();
        CustomerRincianControl rincianControls = new CustomerRincianControl();
        OrderMasterControls orderControls = new OrderMasterControls();
        string orderNo { get; set; }

        void GetTranslation()
        {
            BtnTutup.Text = LanguageHelper.GetTranslation("close");
            btnKembali.Text = LanguageHelper.GetTranslation("back");
            btnPrint.Text = LanguageHelper.GetTranslation("print");
            GvSample.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            GvParameter.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            LitOrder.Text = LanguageHelper.GetTranslation("Lit_NoOrder");
            LitCustomer.Text = LanguageHelper.GetTranslation("Lit_Customer");
            LitKomoditas.Text = LanguageHelper.GetTranslation("Lit_Komoditas");
            LitAnalisis.Text = LanguageHelper.GetTranslation("Lit_Analisis");
            LitSampel.Text = LanguageHelper.GetTranslation("Lit_Sampel");
            LitHarga.Text = LanguageHelper.GetTranslation("Lit_Price");
            LitDaftarSampel.Text = LanguageHelper.GetTranslation("daftar_sampel");
            LitNoSampel.Text = LanguageHelper.GetTranslation("Lit_NoSampel");
            LitNoBalittanah.Text = LanguageHelper.GetTranslation("Lit_NoBalittanah");
            LitDesa.Text = LanguageHelper.GetTranslation("Lit_Desa");
            LitKecamatan.Text = LanguageHelper.GetTranslation("Lit_Kecamatan");
            LitKabupaten.Text = LanguageHelper.GetTranslation("Lit_Kabupaten");
            LitPropinsi.Text = LanguageHelper.GetTranslation("Lit_Propinsi");
            LitGPS.Text = LanguageHelper.GetTranslation("Lit_GPS");
            LitTanah.Text = LanguageHelper.GetTranslation("Lit_Tanah");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GvSample.RowDataBound += GvSample_RowDataBound;
            GvParameter.RowDataBound += GvParameter_RowDataBound;
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
            BtnTutup.Click += BtnTutup_Click;
            GvSample.RowCommand += GvSample_RowCommand;
           
            this.GvSample.DataBound += (object o, EventArgs ev) =>
            {
                GvSample.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
            this.GvParameter.DataBound += (object o, EventArgs ev) =>
            {
                GvParameter.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        private void DoPrint()
        {
            var NoOrder = Request.QueryString["orderNo"];
            if (!string.IsNullOrEmpty(NoOrder))
            {
                Response.Redirect("CetakTandaTerima.aspx?orderNo=" + NoOrder);
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

        private void BtnTutup_Click(object sender, EventArgs e)
        {
            DivRow6.Visible = false;
            DivRow7.Visible = false;
            DivRow8.Visible = false;

            DivRow2.Visible = true;
            DivRow3.Visible = true;
            DivRow4.Visible = true;
            DivRow5.Visible = true;
        }

        private void GvSample_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    DivRow8.Visible = true;

                    DivRow2.Visible = false;
                    DivRow3.Visible = false;
                    DivRow4.Visible = false;
                    DivRow5.Visible = false;

                    using (var db = new smlpobDB())
                    {
                        orderNo = Request.QueryString["orderNo"];
                        var headerInfo = (from x in db.ordersampletbls
                                          where x.orderNo == orderNo
                                          select x).FirstOrDefault();

                        if (headerInfo != null)
                        {
                            TxtNoSample.Text = headerInfo.sampleCode;
                            TxtNoBalitTanah.Text = headerInfo.noBalittanah;
                            TxtDesa.Text = headerInfo.village;
                            TxtKecamatan.Text = headerInfo.subDistrict;
                            TxtKabupaten.Text = headerInfo.district;
                            TxtPropinsi.Text = headerInfo.province;
                            TxtGps.Text = headerInfo.latitude + "," + headerInfo.longitude;
                            TxtTipeTanah.Text = headerInfo.landUse;
                        }
                    }
                    GvParameter.DataSource = data.ToList();
                    GvParameter.DataBind();

                    if (GvParameter.Rows.Count > 0)
                    {
                        GvParameter.UseAccessibleHeader = true;
                        GvParameter.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    break;
            }
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

        private void DoKembali()
        {
            Response.Redirect("KasirProses.aspx");
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

        protected void btnPrint_Click(object sender, EventArgs e)
        {

            Response.Write("<script>alert('Siap Di Cetak');</script>");
        }

        //-------------------Param Uji---------------------//
        //protected void BtnTutup_Click(object sender, EventArgs e)
        //{
        //    DivRowParam.Visible = false;
        //    DivRowClose.Visible = false;

        //    DivRowJudSample.Visible = true;
        //    DivRowSideBox.Visible = true;
        //    DivRowSample.Visible = true;
        //    DivRowBtn.Visible = true;
        //}

        private void GvParameter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("parameter_test");
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
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("Lihat") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("element_code");
            }
        }
    }
}