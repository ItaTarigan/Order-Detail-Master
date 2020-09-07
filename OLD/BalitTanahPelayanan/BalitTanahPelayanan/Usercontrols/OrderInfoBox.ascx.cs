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
    public partial class OrderInfoBox : System.Web.UI.UserControl
    {
        public string FilterType { get; set; }
        void GetTranslation()
        {
            Labelr.Text = LanguageHelper.GetTranslation("total_order");
            Label3.Text = LanguageHelper.GetTranslation("title_pesanan_diproses");
            Label3a.Text = LanguageHelper.GetTranslation("title_pesanan_selesai");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                LoadData();
                GetTranslation();

            }
        }
        

        void LoadData()
        {

            ListGridMaster listGridMaster = new ListGridMaster();

            if (FilterType == "ByUser")
            {
                var ret = listGridMaster.GetData();
                var datas = ret.Result.Where(x => x.creaBy == CommonWeb.GetCurrentUser()).Count();
                lblTotal.Text = datas.ToString();

                var ret3 = listGridMaster.GetData();

                var datas3 = ret3.Result.Where(x => x.creaBy == CommonWeb.GetCurrentUser() && (x.status == "Pilih Penyelia" || x.status == "Proses Lab"
                || x.status == "Verifikasi Penyelia" || x.status == "Evaluasi Hasil" || x.status == "Hitung ulang" || x.status == "Menunggu Approval")).Count();
                lblOrderProses.Text = datas3.ToString();

                var ret4 = listGridMaster.GetData();
                var datas4 = ret4.Result.Where(x => x.creaBy == CommonWeb.GetCurrentUser() && (x.status == "LHP Keluar" || x.status == "LHP Sudah Diambil")).Count();

                lblOrderDone.Text = datas4.ToString();

            }
            else
            {
                var myLab = CommonWeb.GetUserLab();
                if (!string.IsNullOrEmpty(myLab))
                {
                    var ret = listGridMaster.GetData();
                    var datas = ret.Result.Where(x=>x.analysisType == myLab).Count();
                    lblTotal.Text = datas.ToString();

                    var ret3 = listGridMaster.GetData();
                    var datas3 = ret3.Result.Where(x => (x.status == "Pilih Penyelia" || x.status == "Proses Lab" || x.status == "Barcode Sampel"
                    || x.status == "Verifikasi Penyelia" || x.status == "Evaluasi Hasil" || x.status == "Hitung ulang" || x.status == "Menunggu Approval") && x.analysisType == myLab).Count();
                    lblOrderProses.Text = datas3.ToString();

                    var ret4 = listGridMaster.GetData();
                    var datas4 = ret4.Result.Where(x => (x.status == "LHP Keluar" || x.status == "LHP Sudah Diambil") && x.analysisType==myLab).Count();
                    lblOrderDone.Text = datas4.ToString();
                }
                else
                {
                    var ret = listGridMaster.GetData();
                    var datas = ret.Result.Count();
                    lblTotal.Text = datas.ToString();

                    var ret3 = listGridMaster.GetData();

                    var datas3 = ret3.Result.Where(x => x.status == "Pilih Penyelia" || x.status == "Proses Lab" || x.status == "Barcode Sampel"
                    || x.status == "Verifikasi Penyelia" || x.status == "Evaluasi Hasil" || x.status == "Hitung ulang" || x.status == "Menunggu Approval").Count();
                    lblOrderProses.Text = datas3.ToString();

                    var ret4 = listGridMaster.GetData();
                    var datas4 = ret4.Result.Where(x => x.status == "LHP Keluar" || x.status == "LHP Sudah Diambil").Count();
                    lblOrderDone.Text = datas4.ToString();
                }
            }
        }
    }
}