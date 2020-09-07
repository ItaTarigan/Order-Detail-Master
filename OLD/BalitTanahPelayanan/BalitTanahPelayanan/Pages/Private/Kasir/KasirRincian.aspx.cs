using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private.Kasir
{
    public partial class KasirRincian : System.Web.UI.Page
    {
        OrderAnalysisControls orderanalysisControls = new OrderAnalysisControls();
        CustomerRincianControl rincianControls = new CustomerRincianControl();
        SampleControls sampelControls = new SampleControls();
        OrderMasterControls orderControls = new OrderMasterControls();

        void GetTranslation()
        {
            btnKembali.Text = LanguageHelper.GetTranslation("back");
            btnSimpan.Text = LanguageHelper.GetTranslation("save");
            GvSample.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            LitOrder.Text = LanguageHelper.GetTranslation("Lit_NoOrder");
            LitCustomer.Text = LanguageHelper.GetTranslation("Lit_Customer");
            LitKomoditas.Text = LanguageHelper.GetTranslation("Lit_Komoditas");
            LitAnalisis.Text = LanguageHelper.GetTranslation("Lit_Analisis");
            LitSampel.Text = LanguageHelper.GetTranslation("Lit_Sampel");
            LitHarga.Text = LanguageHelper.GetTranslation("Lit_Price");

            litTipePembayaran.Text = LanguageHelper.GetTranslation("payment_type");
            litStatusPembayaran.Text = LanguageHelper.GetTranslation("payment_status");
            litDaftarSampel.Text = LanguageHelper.GetTranslation("sample_list");

            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GvSample.RowDataBound += GvSample_RowDataBound;
            GvParameter.RowDataBound += GvParameter_RowDataBound;
            if (!IsPostBack)
            {
                StatusPembayaranCmb.Items.Clear();
                StatusPembayaranCmb.Items.Add(new ListItem(Status.PaymentStatus[0], Status.PaymentStatus[0]));
                StatusPembayaranCmb.Items.Add(new ListItem(Status.PaymentStatus[2], Status.PaymentStatus[2]));
                StatusPembayaranCmb.Items.Add(new ListItem("DP", "DP"));
                TipePembayaranCmb.Items.Clear();
                TipePembayaranCmb.Items.Add(new ListItem("Penelitian", "Penelitian"));
                TipePembayaranCmb.Items.Add(new ListItem("PNBP", "PNBP"));
                TipePembayaranCmb.Items.Add(new ListItem("Khusus", "Khusus"));


                var NoOrder = Request.QueryString["orderNo"];
                if (!string.IsNullOrEmpty(NoOrder))
                {
                    LoadDetail(NoOrder);
                    LoadGridSample(NoOrder);
                    LoadParameter(NoOrder);
                }

            }
            GetTranslation();


            btnSimpan.Click += btnSimpan_Click;
            this.GvSample.DataBound += (object o, EventArgs ev) =>
            {
                GvSample.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
            this.GvParameter.DataBound += (object o, EventArgs ev) =>
            {
                GvParameter.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (orderControls.UpdatePayment(txtNoOrder.Text, StatusPembayaranCmb.SelectedValue.ToString(), TipePembayaranCmb.SelectedValue.ToString()))
            {
                

                var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                context.Clients.All.PushNotification("All", "Pesanan no " + txtNoOrder.Text + " sudah membayar", "https://silpo.id");

                string[] rolesArray;
                RolePrincipal r = (RolePrincipal)User;
                rolesArray = r.GetRoles();
                if (StatusPembayaranCmb.SelectedValue.ToString() == Status.PaymentStatus[0])
                {
                    CommonWeb.Alert(this, "Pembayaran sudah terupdate");
                }
                else
                {
                    
                    Response.Redirect("KasirMasuk.aspx");
                    CommonWeb.Alert(this, "Pembayaran selesai, diteruskan ke bagian pelayanan untuk memberi label sampel.");
                }
            }
            else
            {
                CommonWeb.Alert(this, "Gagal update");
            }

        }
            void LoadParameter(string orderNo)
            {
                var ret3 = orderanalysisControls.GetData(orderNo);
                var filteredData = from x in ret3.Result
                                   select new { x.elementId, x.elementservicestbl.elementCode };
                var dataParameter = filteredData.Distinct();




                GvParameter.DataSource = dataParameter;
                GvParameter.DataBind();

                if (GvParameter.Rows.Count > 0)
                {
                    GvParameter.UseAccessibleHeader = true;
                    GvParameter.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                Response.Redirect("KasirMasuk.aspx");
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

            private void GvParameter_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[0].Text = LanguageHelper.GetTranslation("element_code");
                }
            }

        protected void BtnGenerateInvoice_Click(object sender, EventArgs e)
        {
            var NoOrder = Request.QueryString["orderNo"];
            Response.Redirect("CetakInvoice.aspx?orderNo=" + NoOrder);
        }
    }
}