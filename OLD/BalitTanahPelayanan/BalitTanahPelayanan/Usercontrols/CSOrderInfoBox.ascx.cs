using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Usercontrols
{
    public partial class CSOrderInfoBox : System.Web.UI.UserControl
    {
        ListGridMaster listGridMaster = new ListGridMaster();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                GetTranslate();
            }
        }
        void GetTranslate()
        {
            litTotalPesanan.Text = LanguageHelper.GetTranslation("total_order");
            litPesananMasuk.Text = LanguageHelper.GetTranslation("total_order_entry");
            litPesananDiProses.Text = LanguageHelper.GetTranslation("total_order_processed");
            litPesananSelesai.Text = LanguageHelper.GetTranslation("total_order_complete");
        }
        void LoadData()
        {
            var ret = listGridMaster.GetData();
            var datas = ret.Result.Where(x => x.status != "Pesanan Baru").Count();
            lblTotal.Text = datas.ToString();

            var ret2 = listGridMaster.GetData();
            var datas2 = ret2.Result.Where(x => x.status == "Barcode Sampel").Count();
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