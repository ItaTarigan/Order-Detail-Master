using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace BalitTanahPelayanan.Pages.Private.Analis
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        string BatchID { set; get; }
        string orderNo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BatchID = Request.QueryString["batchId"];
            GvData.RowDataBound += GridData_RowDataBound;
            GvParameter.RowDataBound += GvParameter_RowDataBound;
            if (!IsPostBack)
            {

                orderNo = Request.QueryString["orderNo"];
                LoadHeaderInfo(orderNo);
                LoadGridSample(orderNo);
                GetTranslation();

            }
            BtnTutup.Click += BtnTutup_Click;
            GvData.RowCommand += GvData3_RowCommand;
            GvParameter.RowCommand += GvParameter_RowCommand;
          
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        private void GvParameter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var lht = e.Row.FindControl("Lihat") as LinkButton;
                if (lht != null)
                {
                    lht.Text = LanguageHelper.GetTranslation("downl");
                    if (e.Row.Cells[1].Text == "Menunggu")
                    {
                        lht.Enabled = false;
                        lht.Text = "-";
                    }
                }

            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("parameter_test");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("testing_status");
                
            }
        }

        void GetTranslation()
        {

            txtRincian.Text = LanguageHelper.GetTranslation("order_no");
            txtnamapelanggan.Text = LanguageHelper.GetTranslation("customer_name");
            txtkomoditas1.Text = LanguageHelper.GetTranslation("commodity");
            txttipeanalis1.Text = LanguageHelper.GetTranslation("type_analyst");
            txttotalsampel.Text = LanguageHelper.GetTranslation("total_sample");
            txttotalprice.Text = LanguageHelper.GetTranslation("total_price");
            txtDaftarSampel.Text = LanguageHelper.GetTranslation("sample_list");
            BtnKembali.Text = LanguageHelper.GetTranslation("btn_kembali");
            
            //txtketerangan1.Text = LanguageHelper.GetTranslation("remark");

            txtnosampel.Text = LanguageHelper.GetTranslation("sample_no");
            txtnobalit.Text = LanguageHelper.GetTranslation("no_balittanah");
            txtdesa1.Text = LanguageHelper.GetTranslation("village");
            txtkecamatan1.Text = LanguageHelper.GetTranslation("sub_district");
            txtkabupaten1.Text = LanguageHelper.GetTranslation("district");
            txtpropinsi1.Text = LanguageHelper.GetTranslation("province");
            txtgsp.Text = LanguageHelper.GetTranslation("gps");
            txttipetanah1.Text = LanguageHelper.GetTranslation("soil_type");
            BtnTutup.Text = LanguageHelper.GetTranslation("close");

            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }

        private void GridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("serial_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_no");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("no_balittanah");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("gps_coordinates");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("soil_type");
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("actions");

            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("Lihat") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("detail");
            }
        }
        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("test_parameter");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("testing_status");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("result");
            }
        }


        private void BtnDownload_Click(object sender, EventArgs e)
        {
            if (ViewState["DownloadUrl"] != null)
            {
                Response.Redirect(ViewState["DownloadUrl"].ToString());
            }
        }

        private void GvParameter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var FileUrl = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "DownloadParameter":
                    Response.Redirect(FileUrl);
                    break;
            }
        }

        private void BtnTutup_Click(object sender, EventArgs e)
        {
            DivRow9.Visible = false;
            DivRow8.Visible = false;
            DivRow7.Visible = false;


            DivRow1.Visible = true;
            DivRow2.Visible = true;
            DivRow3.Visible = true;
            DivRow4.Visible = true;
            //DivRow5.Visible = true;
            DivRow6.Visible = true;

        }

        private void GvData3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var NoBalitTanah = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "DetailorderList":
                    OrderListControls orderControls = new OrderListControls();
                    var ret = orderControls.GetParameter(NoBalitTanah);
                    var data = ret.Result;

                    DivRow9.Visible = true;
                    DivRow8.Visible = true;
                    DivRow7.Visible = true;


                    DivRow1.Visible = false;
                    DivRow2.Visible = false;
                    DivRow3.Visible = false;
                    DivRow4.Visible = false;
                    //DivRow5.Visible = false;
                    DivRow6.Visible = false;



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
                    //Response.Redirect("DaftarService.aspx?orderNo=" + IDS);
                    break;
            }
        }


        void LoadHeaderInfo(string orderNo)
        {

            var ret = orderControls.DetailData(orderNo);
            var data = ret.Result;

            if (data != null)
            {
                //FileNameTxt.Text = data.orderanaly;
                txtNoOrder.Text = data.orderNo;
                txtCustomer.Text = data.customertbl.customerName;
                txtKomoditas.Text = data.comoditytbl.comodityName;
                txtTipeAnalis.Text = data.analysisType;
                txtTotalSample.Text = data.sampleTotal.ToString();
                txtTotalHarga.Text = Formater.ToRupiah(data.priceTotal.Value);

            }
        }

        void LoadGridSample(string orderNo)
        {
            try
            {
                var ret = orderControls.GetDataDetail(orderNo);
                var datas = ret.Result;

                using (var db = new smlpobDB())
                {
                    var UrlToFile = (from x in db.ordermastertbls
                                     where x.orderNo == orderNo
                                     select x.LHPAttachmentUrl).FirstOrDefault();

                    if (!string.IsNullOrEmpty(UrlToFile))
                    {
                        //BtnDownload.PostBackUrl = UrlToFile;
                        ViewState["DownloadUrl"] = UrlToFile;
                    }
                    else
                    {
                        
                    }

                }

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
            catch { }
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
                LogHelpers.source = this.GetType().ToString();
                LogHelpers.message = "Terjadi kesalahan:" + ex.Message;
                LogHelpers.user = CommonWeb.GetCurrentUser();
                LogHelpers.WriteLog();

            }
        }





        private void DoKembali()
        {
            Response.Redirect($"DaftarOrder.aspx?batchId={BatchID}");
        }


        private void DoContinue()
        {
            string id = txtNoOrder.Text;

            var rett = orderControls.MasterData(id);
            var datas = rett.Result;

            var data = new ordermastertbl
            {


                orderNo = datas.orderNo,
                customerNo = datas.customerNo,
                comodityNo = datas.comodityNo,
                analysisType = datas.analysisType,
                sampleTotal = datas.sampleTotal,
                priceTotal = datas.priceTotal,
                statusType = datas.statusType,
                status = Status.OrderStatus[6],
                paymentStatus = datas.paymentStatus,
                ppn = datas.ppn,
                receiptDate = datas.receiptDate,
                isPaid = datas.isPaid,
                paymentDate = datas.paymentDate,
                pic = datas.pic,
                isOnLab = datas.isOnLab,
                ApprPenyelia = datas.ApprPenyelia,
                ApprEvaluator = datas.ApprEvaluator,
                ApprManagerTeknis = datas.ApprManagerTeknis,
                LHPAttachmentUrl = datas.LHPAttachmentUrl,
                LHPFileName = datas.LHPFileName,
                EvaluationFileUrl = datas.EvaluationFileUrl,
                EvaluationFileName = datas.EvaluationFileName

            };

            var ret = orderControls.UpdateData(id, data);

            if (ret.Result)
            {
                orderNo = Request.QueryString["orderNo"];
                LoadHeaderInfo(orderNo);
                LoadGridSample(orderNo);
                //can't upload and re-calculate after change status
                

                CommonWeb.Alert(this, "Menunggu approval manager teknis");
                Response.Redirect("EvaluasiHasil.aspx");
            }
            else
            {
                CommonWeb.Alert(this, "Gagal mengubah data");
            }
        }



    }
}