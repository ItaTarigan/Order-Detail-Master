using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
namespace BalitTanahPelayanan.Pages.Private.Penyelia
{
    public partial class Rincian : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        ManagerTeknisControls ManagerControls = new ManagerTeknisControls();
        string orderNo { get; set; }
        public object GridvData { get; private set; }
        public object DetailorderList { get; private set; }

        void GetTranslation()
        {
            txtnamapelanggan.Text = LanguageHelper.GetTranslation("customer_name");
            txtkomoditass.Text = LanguageHelper.GetTranslation("commodity");
            txttipeanaliss.Text = LanguageHelper.GetTranslation("analisystype");
            txttotalsamplee.Text = LanguageHelper.GetTranslation("total_sample");
            txtstatuspesanann.Text = LanguageHelper.GetTranslation("order_status");
            txtdaftarsampel.Text = LanguageHelper.GetTranslation("sample_list");
            BtnDownload.Text = LanguageHelper.GetTranslation("downl");
            BtnUpload.Text = LanguageHelper.GetTranslation("upload");
            BtnKembali.Text = LanguageHelper.GetTranslation("back");
            BtnLanjut.Text = LanguageHelper.GetTranslation("continue");
            BtnHitungUlang.Text = LanguageHelper.GetTranslation("recalculate");
            txtnosample1.Text = LanguageHelper.GetTranslation("sample_no");
            txtnobalittanah1.Text = LanguageHelper.GetTranslation("balittanah_no");
            txtdesa1.Text = LanguageHelper.GetTranslation("village");
            txtkecamatan1.Text = LanguageHelper.GetTranslation("sub_district");
            txtkabupaten1.Text = LanguageHelper.GetTranslation("district");
            txtprovinsi1.Text = LanguageHelper.GetTranslation("province");
            txtgps1.Text = LanguageHelper.GetTranslation("gps");
            txttipetanah1.Text = LanguageHelper.GetTranslation("soil_type");
            BtnTutup.Text = LanguageHelper.GetTranslation("close");
            litUploadLHP.Text = LanguageHelper.GetTranslation("upload_lhp");
            litNoPesanan.Text = LanguageHelper.GetTranslation("detail_order_no");
            litDownloadLhp.Text = LanguageHelper.GetTranslation("download_lhp");
            litDownloadBatch.Text = LanguageHelper.GetTranslation("download_batch");
            // DownloadParameter.Text = LanguageHelper.GetTranslation("Download_Parameter");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }

        private void GridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("serial_number");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_no");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("balittanah_no");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("village");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("sub_district");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("district");
                e.Row.Cells[6].Text = LanguageHelper.GetTranslation("province");
                e.Row.Cells[7].Text = LanguageHelper.GetTranslation("gps");
                e.Row.Cells[8].Text = LanguageHelper.GetTranslation("soil_type");
                e.Row.Cells[9].Text = LanguageHelper.GetTranslation("sample_is_accepted");
                e.Row.Cells[10].Text = LanguageHelper.GetTranslation("actions");
                

            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var DetailorderList = e.Row.FindControl("Lihat") as LinkButton;
                if (DetailorderList != null)
                    DetailorderList.Text = LanguageHelper.GetTranslation("detail");

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GvData.RowDataBound += GridData_RowDataBound;
            if (!IsPostBack)
            {
                GetTranslation();
                var Filter = Request.QueryString["Filter"];
                if (Filter == "Filter1")
                {
                    BtnLanjut.Visible = true;
                    BtnQR.Visible = true;
                    BtnHitungUlang.Visible = true;
                    BtnDownloadZip.Visible = true;
                    BtnDownloadZip2.Visible = true;
                    BtnUploadZip.Visible = true;
                }
                else
                {
                    BtnLanjut.Visible = false;
                    BtnQR.Visible = false;
                    BtnHitungUlang.Visible = false;
                    BtnUploadZip.Visible = false;
                }

                orderNo = Request.QueryString["orderNo"];
                LoadHeaderInfo(orderNo);
                LoadGridSample(orderNo);

            }
            BtnDownload.Click += BtnDownload_Click;
            BtnTutup.Click += BtnTutup_Click;
            GvData.RowCommand += GvData3_RowCommand;
            GvParameter.RowCommand += GvParameter_RowCommand;
            GvParameter.RowDataBound += GvParameter_RowDataBound;
            BtnUpload.Click += (a, b) => { DoUpload(); };
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
                
               
                
            }else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("parameter_test");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("testing_status");
                //e.Row.Cells[2].Text = LanguageHelper.GetTranslation("result");

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
            DivRow6.Visible = false;
            DivRow7.Visible = false;
            DivRow8.Visible = false;

            DivRow2.Visible = true;
            DivRow3.Visible = true;
            DivRow4.Visible = true;
            DivRow5.Visible = true;

        }

        private void GvData3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var NoBalitTanah = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "DetailorderList":
                    OrderListControls orderControls = new OrderListControls();
                    var ret = orderControls.GetParameter(NoBalitTanah);
                    var dataAnalysisDetail = ret.Result;

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



                    GvParameter.DataSource = dataAnalysisDetail.ToList();
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
                txtStatusPesanan.Text = data.status;
                // "Hitung ulang" "Verifikasi Penyelia"  "Kaji Ulang" "Evaluasi Hasil" "Proses Lab"
                switch (data.status)
                {
                    case "Evaluasi Hasil":
                    case "Proses Lab":
                        BtnLanjut.Visible = false;
                        BtnQR.Visible = false;
                        BtnHitungUlang.Visible = false;
                        BtnUploadZip.Visible = false;
                        break;
                }

            }
        }

        void LoadGridSample(string orderNo)
        {
            try
            {
                var ret = orderControls.GetDataDetail(orderNo);
                var dataSample = ret.Result;

                using (var db = new smlpobDB())
                {
                    var UrlToFile = (from x in db.ordermastertbls
                                     where x.orderNo == orderNo
                                     select x.LHPAttachmentUrl).FirstOrDefault();

                    if (!string.IsNullOrEmpty(UrlToFile))
                    {
                        ViewState["DownloadUrl"] = UrlToFile;
                        //BtnDownload.PostBackUrl = UrlToFile;
                    }
                    else
                    {
                        BtnDownloadZip.Visible = false;
                        BtnDownloadZip2.Visible = true;
                    }

                }

                foreach (var data in dataSample)
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



                GvData.DataSource = dataSample;
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

                    case "Lanjut":
                        DoContinue();
                        break;

                    case "HitungUlang":
                        DoHitungUlang();
                        break;
                    case "GenerateQR":
                        {
                            var noOrder = txtNoOrder.Text;
                            Session["SourceUrl"] = Request.Url.PathAndQuery;
                            Response.Redirect($"/pages/private/shared/generateqr.aspx?OrderNo={noOrder}");
                        }
                        break;
                    /*
                case "Upload":
                    DoUpload();

                    break;*/

                    case "Download":
                        DoDownload();
                        break;
                    case "DownloadBatch":
                        {
                            using(var db = new smlpobDB())
                            {
                                var item = db.ordermastertbls.Include(c=>c.batchtbl).Where(x => x.orderNo == txtNoOrder.Text).FirstOrDefault();
                                if (item != null)
                                {
                                    if (item.batchId == null)
                                    {
                                        CommonWeb.Alert(this, "File batch tidak ditemukan. Ini data dengan proses bisnis versi lama");

                                    }

                                    var fileUrl = item.batchtbl.fileurl;
                                    if (!string.IsNullOrEmpty(fileUrl))
                                    {
                                        Response.Redirect(fileUrl);
                                    }
                                    else
                                    {
                                        CommonWeb.Alert(this, "Url batch file tidak valid");

                                    }
                                }
                            }
                        }
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

        private async void DoUpload()
        {
            if (FileUpload1.HasFile)
            {
                /*
                var FilePath = Server.MapPath("~/Uploads");
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                var ItemName = Guid.NewGuid().ToString().Replace("-", "_") + Path.GetExtension(FileUpload1.FileName);
                var FileName = FilePath + "\\" + ItemName;
                FileUpload1.SaveAs(FileName);
                */
                string nameFile = "LHP_" + CommonWeb.GetCurrentUser() + "_" + DateTime.Now.ToString("ddMMMyyyy") + "_" + shortid.ShortId.Generate(true, false) + Path.GetExtension(FileUpload1.FileName);
                await CloudStorage.BlobPostAsync(FileUpload1.FileBytes, nameFile);
                var FileUrl = ConfigurationManager.AppSettings["DefaultBlobRootUrl"] + nameFile;

                string orderNo = txtNoOrder.Text;
                var rett = orderControls.MasterData(orderNo);
                var dataOrder = rett.Result;
                var data = new ordermastertbl
                {


                    orderNo = dataOrder.orderNo,
                    customerNo = dataOrder.customerNo,
                    comodityNo = dataOrder.comodityNo,
                    analysisType = dataOrder.analysisType,
                    sampleTotal = dataOrder.sampleTotal,
                    priceTotal = dataOrder.priceTotal,
                    statusType = dataOrder.statusType,
                    status = dataOrder.status,
                    paymentStatus = dataOrder.paymentStatus,
                    ppn = dataOrder.ppn,
                    receiptDate = dataOrder.receiptDate,
                    isPaid = dataOrder.isPaid,
                    paymentDate = dataOrder.paymentDate,
                    pic = dataOrder.pic,
                    isOnLab = dataOrder.isOnLab,
                    ApprPenyelia = dataOrder.ApprPenyelia,
                    ApprEvaluator = dataOrder.ApprEvaluator,
                    ApprManagerTeknis = dataOrder.ApprManagerTeknis,
                    LHPAttachmentUrl = FileUrl,
                    LHPFileName = nameFile,
                    EvaluationFileUrl = dataOrder.EvaluationFileUrl,
                    EvaluationFileName = dataOrder.EvaluationFileName

                };
                var ret = orderControls.UpdateData(orderNo, data);

                if (ret.Result)
                {
                    this.orderNo = Request.QueryString["orderNo"];
                    LoadHeaderInfo(this.orderNo);
                    LoadGridSample(this.orderNo);
                    CommonWeb.Alert(this, "File berhasil diupload");
                    Response.Redirect("DaftarPesanan.aspx");
                }
                else
                {
                    CommonWeb.Alert(this, "Gagal upload file");

                }



            }
        }


        private void DoDownload()
        {
            orderNo = Request.QueryString["orderNo"];
            var ret = ManagerControls.GetDataFile(orderNo);
            var data = ret.Result;


            if (data.LHPAttachmentUrl == null)
            {
                CommonWeb.Alert(this, "Data file tidak ada");
            }
            else
            {
                var Link = data.LHPAttachmentUrl;
                Response.Redirect(Link);
            }
        }

        private void DoKembali()
        {
            Response.Redirect("DaftarPesanan.aspx");
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
                BtnLanjut.Visible = false;
                BtnQR.Visible = false;
                BtnHitungUlang.Visible = false;
                BtnUploadZip.Visible = false;
                CommonWeb.Alert(this, "Menunggu approval evaluator");

            }
            else
            {
                CommonWeb.Alert(this, "Gagal mengubah data");
            }
        }

        private void DoHitungUlang()
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
                status = Status.OrderStatus[3],
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
            using (var db = new smlpobDB())
            {
                var updatedOrderAnalysis = (from x in db.orderanalysisdetailtbls
                                            where x.orderNo == data.orderNo
                                            select x).ToList();
                if (updatedOrderAnalysis != null)
                {
                    foreach (var item in updatedOrderAnalysis)
                    {
                        item.status = "Menunggu";
                    }
                }
                db.SaveChanges();
            }

            if (ret.Result)
            {
                orderNo = Request.QueryString["orderNo"];
                LoadHeaderInfo(orderNo);
                LoadGridSample(orderNo);
                CommonWeb.Alert(this, "Status telah diubah ke Hitung Ulang");

                //Response.Redirect("DaftarPesanan.aspx");
            }
            else
            {
                CommonWeb.Alert(this, "Gagal mengubah data");
            }
        }



    }
}