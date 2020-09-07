using BalitTanahPelayanan.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BalitTanahPelayanan.Helpers;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Usercontrols
{
    public partial class ManagerInfoOrderBox : System.Web.UI.UserControl
    {
        ListGridMaster listGridMaster = new ListGridMaster();

        void GetTranslation()
        {
            litTotalPesanan.Text = LanguageHelper.GetTranslation("total_order");
            litPesananMasuk.Text = LanguageHelper.GetTranslation("total_order_entry");
            litPesananDiProses.Text = LanguageHelper.GetTranslation("total_order_processed");
            litPesananSelesai.Text = LanguageHelper.GetTranslation("total_order_complete");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetTranslation();
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
          

            
            var myLab = CommonWeb.GetUserLab();
            if (!string.IsNullOrEmpty(myLab))
            {
                var ret = listGridMaster.GetData();
                var datas = ret.Result.Where(x=>x.analysisType==myLab).Count();
                lblTotal.Text = datas.ToString();

                var ret2 = listGridMaster.GetData();
                var datas2 = ret2.Result.Where(x => (x.status == "Pesanan Baru" || x.status == "Barcode Sampel") && x.analysisType == myLab).Count();
                lblNewOrder.Text = datas2.ToString();
                var ret3 = listGridMaster.GetData();
                var datas3 = ret3.Result.Where(x => (x.status == "Pilih Penyelia" || x.status == "Proses Lab" 
                    || x.status == "Verifikasi Penyelia" || x.status == "Evaluasi Hasil" || x.status == "Hitung ulang" || x.status == "Menunggu Approval" ) && x.analysisType == myLab).Count();
                lblOrderProses.Text = datas3.ToString();

                var ret4 = listGridMaster.GetData();
                var datas4 = ret4.Result.Where(x => (x.status == "LHP Keluar" || x.status == "LHP Sudah Diambil") && x.analysisType == myLab).Count();
                lblOrderDone.Text = datas4.ToString();
            }
            else
            {
                var ret = listGridMaster.GetData();
                var datas = ret.Result.Count();
                lblTotal.Text = datas.ToString();

                var ret2 = listGridMaster.GetData();
                var datas2 = ret2.Result.Where(x => x.status == "Pesanan Baru" || x.status == "Barcode Sampel").Count();
                lblNewOrder.Text = datas2.ToString();
                var ret3 = listGridMaster.GetData();
                var datas3 = ret3.Result.Where(x => x.status == "Pilih Penyelia" || x.status == "Proses Lab" 
                    || x.status == "Verifikasi Penyelia" || x.status == "Evaluasi Hasil" || x.status == "Hitung ulang" || x.status == "Menunggu Approval").Count();
                lblOrderProses.Text = datas3.ToString();

                var ret4 = listGridMaster.GetData();
                var datas4 = ret4.Result.Where(x => x.status == "LHP Keluar" || x.status == "LHP Sudah Diambil").Count();
                lblOrderDone.Text = datas4.ToString();
            }
            
        }
    }
}