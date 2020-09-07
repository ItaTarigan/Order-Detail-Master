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

    public partial class OrderList : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        string id { get; set; }
        enum ModeForm { ViewData, DetailData, UpdateData }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                RefreshGrid();
                RefreshGridSelesai();
                

            }
               

            GvData.RowCommand += GvData_RowCommand;
            GvData2.RowCommand += GvData2_RowCommand;
            GvData3.RowCommand += GvData3_RowCommand;
        }

        void ClearFields()
        {
            txtNoOreder.Text = "";
            txtKomoditas.Text = "";
            txtTipeAnalis.Text = "";
            txtTotalSample.Text = "";
            txtStatusPesanan.Text = "";

        }

        void RefreshGridDetail(string param = "")
        {
            
            GvData3.DataBind();

            if (param == null || param == "")
            {
                var ret = orderControls.GetDataDetail();
                var datas = ret.Result.Where(x => x.orderNo == id);

                foreach (var data in datas)
                {
                    if (data.ordersampletbl.isReceived == "1")
                    {
                        data.ordersampletbl.isReceived = "Sudah";
                    }

                    else
                    {
                        data.ordersampletbl.isReceived = "Belum";
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
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
        }

        void RefreshGrid(string param = "")
        {

            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = orderControls.GetData();
                var datas = ret.Result;


                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = orderControls.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
        }

        void RefreshGridSelesai(string param = "")
        {

            GvData2.DataBind();

            if (param == null || param == "")
            {
                var ret = orderControls.GetDataSelesai();
                var datas = ret.Result;


                if (datas != null && datas.Count() > 0)
                {
                    GvData2.DataSource = datas;
                    GvData2.DataBind();
                }
            }
            else
            {
                var ret = orderControls.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData2.DataSource = datas;
                    GvData2.DataBind();
                }
            }
        }



        //void RefreshGrid2(string param = "")
        //{

        //    GvData2.DataBind();

        //    if (param == null || param == "")
        //    {
        //        var ret = orderControls.GetData();
        //        var datas = ret.Result;


        //        if (datas != null && datas.Count() > 0)
        //        {
        //            GvData2.DataSource = datas;
        //            GvData.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        var ret = orderControls.GetDataByContaint(param);
        //        var datas = ret.Result;

        //        if (datas != null && datas.Count() > 0)
        //        {
        //            GvData2.DataSource = datas;
        //            GvData2.DataBind();
        //        }
        //    }
        //}


        void LoadDetail(int fid)
        {
            var ret = orderControls.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                txtNoOreder.Text = data.ordermastertbl.orderNo;
                txtCustomer.Text = data.ordermastertbl.customertbl.customerName;
                txtKomoditas.Text = data.ordermastertbl.comoditytbl.comodityName;
                txtTipeAnalis.Text = data.ordermastertbl.analysisType;
                txtTotalSample.Text = data.ordermastertbl.sampleTotal.ToString();
                txtStatusPesanan.Text = data.status;
                id = data.ordermastertbl.orderNo;


                //TxtAnalysisTypeName.Text = data.analysisTypeName;
                //TxtDescription.Text = data.description;
            }
        }

        private void DoKembali()
        {
            PanelGrid.Visible = true;
            OrderSelesai.Visible = false;
            DTOrder.Visible = false;
        }

        private void DoKembaliSelesai()
        {
            PanelGrid.Visible = false;
            OrderSelesai.Visible = true;
            DTOrder.Visible = false;
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
                sampleTotal = datas.sampleTotal,
                priceTotal = datas.priceTotal,
                status = "Menunggu Approval",
                paymentStatus = datas.paymentStatus,
                isPaid = datas.isPaid,
                paymentDate = datas.paymentDate,
                ApprPenyelia = datas.ApprPenyelia,
                pic = datas.pic
                
                
                //customerName = txtCustomer.Text,
                //sampleNo = txtNoSample.Text,                
                //priceTotal = datas
            };

            var ret = orderControls.UpdateData(id, data);

            if (ret.Result)
            {
                ClearFields();
                SetLayout(ModeForm.ViewData);
                Alert("Menunggu approval evaluator");
            }
            else
            {
                Alert("Gagal mengubah data");
            }
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
                sampleTotal = datas.sampleTotal,
                priceTotal = datas.priceTotal,
                status = "Hitung ulang",
                paymentStatus = datas.paymentStatus,
                isPaid = datas.isPaid,
                paymentDate = datas.paymentDate,
                ApprPenyelia = datas.ApprPenyelia,
                pic = datas.pic
                //customerName = txtCustomer.Text,
                //sampleNo = txtNoSample.Text,                
                //priceTotal = datas
            };

            var ret = orderControls.UpdateData(id, data);

            if (ret.Result)
            {
                ClearFields();
                SetLayout(ModeForm.ViewData);
                Alert("Status telah diubah ke Hitung Ulang");
            }
            else
            {
                Alert("Gagal mengubah data");
            }
        }

        // Alert
        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }
                              
        protected void ActionImageButton(object sender, EventArgs e)
        {
            var btn = sender as ImageButton;
            var command = btn.CommandName;
            try
            {
                switch (command)
                {
                    case "search":
                        var param = (TxtSearch.Text).Trim();
                        RefreshGrid(param);
                        break;

                    case "refresh":
                        //TxtSearch.Text = "";
                        RefreshGrid();
                        break;
                }

            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
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

                    case "KembaliSelesai":
                        DoKembaliSelesai();
                        break;

                    case "Lanjut":
                        DoContinue();
                        break;

                    case "HitungUlang":
                        DoHitungUlang();
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }


        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "lihatOrderList":
                    SetLayout(ModeForm.DetailData);
                    LoadDetail(Convert.ToInt32(IDS));
                    RefreshGridDetail();
                    BtnKembaliSelesai.Visible = false;
                    BtnKembali.Visible = true;
                    BtnLanjut.Visible = true;
                    BtnHitungUlang.Visible = true;
                    BtnGenerate.Visible = true;
                    BtnUpload.Visible = true;
                    BtnDownload.Visible = false;
                    break;
            }
        }

        private void GvData2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "LihatOrderSelesai":
                    SetLayout(ModeForm.DetailData);
                    LoadDetail(Convert.ToInt32(IDS));
                    RefreshGridDetail();
                    BtnKembaliSelesai.Visible = true;
                    BtnKembali.Visible = false;
                    BtnLanjut.Visible = false;
                    BtnHitungUlang.Visible = false;
                    BtnGenerate.Visible = false;
                    BtnUpload.Visible = false;
                    BtnDownload.Visible = true;
                    OrderSelesai.Visible = false;
                    break;
            }
        }

        private void GvData3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "DetailorderList":
                    
                    PanelParameterUji.Visible = true;
                    BtnKembaliSelesai.Visible = false;
                    BtnKembali.Visible = false;
                    BtnLanjut.Visible = false;
                    BtnHitungUlang.Visible = false;
                    BtnGenerate.Visible = false;
                    BtnUpload.Visible = false;
                    BtnDownload.Visible = false;
                    OrderSelesai.Visible = false;

                    break;
            }
        }

        private void SetLayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.DetailData:
                    RefreshGrid();
                    PanelGrid.Visible = false;
                    DTOrder.Visible = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();

                    PanelGrid.Visible = true;
                    DTOrder.Visible = false;
                    break;
            }
        }

        protected void BtnOrderList_Click(object sender, EventArgs e)
        {

            PanelGrid.Visible = true;          
            OrderSelesai.Visible = false;
            DTOrder.Visible = false;
        }

        protected void BtnOrderSelesai_Click(object sender, EventArgs e)
        {
            RefreshGridSelesai();
            PanelGrid.Visible = false;
            DTOrder.Visible = false;
            OrderSelesai.Visible = true;
        }
    }
}