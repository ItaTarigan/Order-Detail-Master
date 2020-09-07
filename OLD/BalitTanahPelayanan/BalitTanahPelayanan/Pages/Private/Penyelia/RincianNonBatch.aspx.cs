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
namespace BalitTanahPelayanan.Pages.Private.Penyelia
{
    public partial class RincianNonBatch : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        ManagerTeknisControls ManagerControls = new ManagerTeknisControls();
        string orderNo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Filter = Request.QueryString["Filter"];
                if (Filter == "Filter1")
                {
                    BtnLanjut.Visible = true;
                    BtnHitungUlang.Visible = true;
                    BtnDownloadZip.Visible = true;
                    BtnUploadZip.Visible = true;
                    DivUploadLampiran.Visible = true;
                    DivDownloadLampiran.Visible = true;
                    BtnQR.Visible = true;
                    
                }
                else
                {
                    BtnLanjut.Visible = false;
                    BtnHitungUlang.Visible = false;
                    BtnUploadZip.Visible = false;
                    DivUploadLampiran.Visible = false;
                    BtnQR.Visible = false;
                }

                orderNo = Request.QueryString["orderNo"];
                LoadHeaderInfo(orderNo);
                LoadGridSample(orderNo);

            }
            BtnDownload.Click += BtnDownload_Click;
            BtnDownloadKalkulasi.Click += BtnDownloadKalkulasi_Click;
            BtnTutup.Click += BtnTutup_Click;
            GvData.RowCommand += GvData3_RowCommand;
            GvParameter.RowCommand += GvParameter_RowCommand;
            BtnUpload.Click += (a, b) => { DoUpload(); };
            BtnUploadKalkulasi.Click += async(a, b) => {
                if (FileUploadKalkulasi.HasFile)
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
                    string nameFile = "LampiranLHP_" + CommonWeb.GetCurrentUser() + "_" + DateTime.Now.ToString("ddMMMyyyy") + "_" + shortid.ShortId.Generate(true, false) + Path.GetExtension(FileUploadKalkulasi.FileName);
                    await CloudStorage.BlobPostAsync(FileUploadKalkulasi.FileBytes, nameFile);
                    var FileUrl = ConfigurationManager.AppSettings["DefaultBlobRootUrl"] + nameFile;

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
                        status = datas.status,
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
                        EvaluationFileName = datas.EvaluationFileName,
                        CalculationFileUrl = FileUrl,
                        CalculationFilename = nameFile

                    };
                    var ret = orderControls.UpdateData(id, data);

                    if (ret.Result)
                    {
                        orderNo = Request.QueryString["orderNo"];
                        LoadHeaderInfo(orderNo);
                        LoadGridSample(orderNo);
                       
                        CommonWeb.Alert(this, "File lampiran berhasil diupload");
                        //Response.Redirect("DaftarPesanan.aspx");
                    }
                    else
                    {
                        CommonWeb.Alert(this, "Gagal upload file");

                    }
                }
                };
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        private void BtnDownloadKalkulasi_Click(object sender, EventArgs e)
        {
            if (ViewState["DownloadLampiranUrl"] != null)
            {
                Response.Redirect(ViewState["DownloadLampiranUrl"].ToString());
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
                if (data.status == Status.OrderStatus[3] || data.status == Status.OrderStatus[4])
                {
                    //hide beberapa button
                    BtnLanjut.Visible = false;
                    BtnHitungUlang.Visible = false;
                    BtnUploadZip.Visible = false;
                    BtnQR.Visible = false;
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
                    var Lampiran = (from x in db.ordermastertbls
                                     where x.orderNo == orderNo
                                     select new { LHPUrl = x.LHPAttachmentUrl, CalculationUrl = x.CalculationFileUrl }).FirstOrDefault();

                    if (!string.IsNullOrEmpty(Lampiran.LHPUrl))
                    {
                        ViewState["DownloadUrl"] = Lampiran.LHPUrl;
                        //BtnDownload.PostBackUrl = UrlToFile;
                    }
                    else
                    {
                        BtnDownloadZip.Visible = false;
                    }
                    if (!string.IsNullOrEmpty(Lampiran.CalculationUrl))
                    {
                        ViewState["DownloadLampiranUrl"] = Lampiran.CalculationUrl;
                        DivDownloadLampiran.Visible = true;
                        //BtnDownload.PostBackUrl = UrlToFile;
                    }
                    else
                    {
                        DivDownloadLampiran.Visible = false;
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
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
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
                    status = datas.status,
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
                    LHPAttachmentUrl = FileUrl,
                    LHPFileName = nameFile,
                    EvaluationFileUrl = datas.EvaluationFileUrl,
                    EvaluationFileName = datas.EvaluationFileName,
                    CalculationFileUrl = datas.CalculationFileUrl,
                    CalculationFilename = datas.CalculationFilename

                };
                var ret = orderControls.UpdateData(id, data);

                if (ret.Result)
                {
                    orderNo = Request.QueryString["orderNo"];
                    //LoadHeaderInfo(orderNo);
                    //LoadGridSample(orderNo);
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
                status = Status.OrderStatus[4],
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
                EvaluationFileName = datas.EvaluationFileName,
                CalculationFilename = datas.CalculationFilename,
                CalculationFileUrl = datas.CalculationFileUrl

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
                status = "Hitung ulang",
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