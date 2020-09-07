using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class ApprovalEvaluasi : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        ManagerTeknisControls ManagerControls = new ManagerTeknisControls();
        string orderNo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                orderNo = Request.QueryString["orderNo"];
                LoadDetail();
                RefreshGridDetail();
            }

        }
        void LoadDetail()
        {

            var ret = orderControls.DetailData(orderNo);
            var data = ret.Result;
            //var rett2 = orderControls.GetDataDetail(fid);
            //var data2 = rett2.Result;
            if (data != null)
            {
                txtNoOreder.Text = data.orderNo;
                txtCustomer.Text = data.customertbl.customerName;
                txtKomoditas.Text = data.comoditytbl.comodityName;
                txtTipeAnalis.Text = data.analysisType;
                txtTotalSample.Text = data.sampleTotal.ToString();
                txtStatusPesanan.Text = data.status;

            }
        }

        void RefreshGridDetail(string param = "")
        {

            GvData3.DataBind();

            if (param == null || param == "")
            {
                var ret = orderControls.GetDataDetail(orderNo);
                var datas = ret.Result;

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


                if (datas != null && datas.Count() > 0)
                {
                    GvData3.DataSource = datas;
                    GvData3.DataBind();
                }
            }
            else
            {
                var ret = orderControls.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData3.DataSource = datas;
                    GvData3.DataBind();
                }
            }
        }

        protected void ActionButton(object sender, EventArgs e)
        {
            try
            {
                //orderNo = Request.QueryString["orderNo"];
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

                    case "Download":
                        DoDownload();
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }


        private void DoDownload()
        {
            orderNo = Request.QueryString["orderNo"];
            var ret = ManagerControls.GetDataFile(orderNo);
            var data = ret.Result;


            if (data.LHPAttachmentUrl == null)
            {
                Alert("Data file tidak ada");
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
            string id = txtNoOreder.Text;
            //int x = Int32.Parse(id);
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
                status = "Menunggu approval",
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



                //customerName = txtCustomer.Text,
                //sampleNo = txtNoSample.Text,                
                //priceTotal = datas
            };


        }

        private void DoHitungUlang()
        {
            string id = txtNoOreder.Text;
            //int x = Int32.Parse(id);
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

                //customerName = txtCustomer.Text,
                //sampleNo = txtNoSample.Text,                
                //priceTotal = datas
            };

            var ret = orderControls.UpdateData(id, data);

            if (ret.Result)
            {
                Alert("Status telah diubah ke Hitung Ulang");
                Response.Redirect("DaftarPesanan.aspx");
            }
            else
            {
                Alert("Gagal mengubah data");
            }
        }

        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }
    }
}