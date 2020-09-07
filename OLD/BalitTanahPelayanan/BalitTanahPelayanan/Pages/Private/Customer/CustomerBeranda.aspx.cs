using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private.Customer
{
    public partial class CustomerBeranda : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
      
        void GetTranslation()
        {
            GridData.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            BtnOrder.Text = LanguageHelper.GetTranslation("order_new");
            BtnSOP.Text = LanguageHelper.GetTranslation("sop");
            LitTitle.Text = LanguageHelper.GetTranslation("order_list");
            BtnTutup.Text = LanguageHelper.GetTranslation("close");
            cmb2Komoditas.Text = LanguageHelper.GetTranslation("choice_comodity");
            CmbKomoditas.SelectedValue = LanguageHelper.GetTranslation("Show_all");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            GridData.RowDataBound += GridData_RowDataBound;
            BtnValidasiQR.Click += (a, b) =>
            {
                Session["SourceUrl"] = Request.Url.PathAndQuery;
                Response.Redirect($"/Pages/Private/Shared/ValidasiQR.aspx");
            };
            if (!IsPostBack)
            {
                if(Session["touch"]!=null && Convert.ToBoolean(Session["touch"]))
                {
                    Response.Redirect("CustomerBerandaTouch.aspx");
                }
                LoadKomoditas();
                GetTranslation();
                RefreshGrid();
                RefreshGridAll();


                this.GridData.DataBound += (object o, EventArgs ev) =>
                {
                    GridData.HeaderRow.TableSection = TableRowSection.TableHeader;
                };
            }

            BtnOrder.Click += BtnOrder_Click;          
            BtnTutup.Click += BtnTutup_Click;
            BtnSOP.Click += BtnSOP_Click;
         
        }


        private void GridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("commodity");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("analysis_type");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("total_sample");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("order_status");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("payment_status");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("actions");
            }else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("BtnLihat") as LinkButton;
                if(linkBtn!=null)
                    linkBtn.Text = LanguageHelper.GetTranslation("detail");
               
                linkBtn = e.Row.FindControl("BtnBayar") as LinkButton;
                if (linkBtn != null)
                {
                    linkBtn.Text = LanguageHelper.GetTranslation("pay_transfer");
                    if (e.Row.Cells[5].Text == Status.PaymentStatus[0])
                    {
                        linkBtn.Visible = true;
                    }
                    else
                    {
                        linkBtn.Visible = false;
                    }
                }
                var statusChange = e.Row.Cells[4].Text;
                switch (e.Row.Cells[4].Text)
                {
                    case "Pesanan Baru":
                        statusChange = "Pesanan Baru";
                        break;
              
                    case "Pilih Penyelia":
                    case "Proses Lab":
                    case "Barcode Sampel":
                    case "Verifikasi Penyelia":
                    case "Evaluasi Hasil":
                    case "Hitung ulang":
                    case "Menunggu Approval":
                        statusChange = "Diproses";
                        break;
                    case "LHP keluar":
                    case "LHP Sudah Diambil":
                        statusChange = "LHP Keluar";
                        break;
                }
                e.Row.Cells[4].Text = statusChange;
            }
        }

        private void BtnTutup_Click(object sender, EventArgs e)
        {
            DivRow1.Visible = true;
            DivRow2.Visible = true;
            DivRow3.Visible = true;
            DivRow4.Visible = true;
            DivRowComodity.Visible = true;

            DivRow5.Visible = false;
            DivRow6.Visible = false;
        }

        private void BtnSOP_Click(object sender, EventArgs e)
        {
            DivRow1.Visible = false;
            DivRow2.Visible = false;
            DivRow3.Visible = false;
            DivRow4.Visible = false;
            DivRowComodity.Visible = false;

            DivRow5.Visible = true;
            DivRow6.Visible = true;
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerBuatPesanan.aspx");
        }

        private void RefreshGrid()
        {
            var ret = orderControls.GetDataByCreatedByAndComodity(CommonWeb.GetCurrentUser(), int.Parse(CmbKomoditas.SelectedValue));
            var datas = ret.Result;
            GridData.DataSource = datas;
            GridData.DataBind();

            if (GridData.Rows.Count > 0)
            {
                GridData.UseAccessibleHeader = true;
                GridData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


        private void RefreshGridAll()
        {
            var ret = orderControls.GetDataByCreatedBy(CommonWeb.GetCurrentUser());
            var datas = ret.Result;
            GridData.DataSource = datas;
            GridData.DataBind();

            if (GridData.Rows.Count > 0)
            {
                GridData.UseAccessibleHeader = true;
                GridData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void ChangeValueKomoditas(object sender, EventArgs e)
        {

            if(CmbKomoditas.SelectedValue == "001")
            {
                if (CmbKomoditas.SelectedIndex != -1)
                {
                    RefreshGridAll();
                } 
            }
            else
            {
                if (CmbKomoditas.SelectedIndex != -1)
                {
                    RefreshGrid();
                }
            }   
        }

        private void LoadKomoditas()
        {
            var datas = orderControls.GetKomoditasName();
            var ret = datas.Result;

            CmbKomoditas.DataSource = ret;
            CmbKomoditas.DataValueField = "comodityNo";
            CmbKomoditas.DataTextField = "comodityName";
            CmbKomoditas.DataBind();
        }
    }
}