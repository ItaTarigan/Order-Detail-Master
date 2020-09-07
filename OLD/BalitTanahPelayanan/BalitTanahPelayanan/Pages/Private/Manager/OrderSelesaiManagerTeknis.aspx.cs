using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Controllers;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class OrderSelesaiManagerTeknis : System.Web.UI.Page
    {
        //CustomerRincianControl rincianControls = new CustomerRincianControl();
        //SampleControls sampelControls = new SampleControls();
        //ManagerTeknisControls ManagerControls = new ManagerTeknisControls();
        //string rCurrentUser = "";
        ListGridMaster listGridMaster = new ListGridMaster();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                RefreshGrid();

            }
            GvData.RowCommand += GvData_RowCommand;
            this.GvData.DataBound += (object o, EventArgs ev) =>
            {
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        //void LoadDetail2(string fid)
        //{
        //    var ret = ManagerControls.GetDataFile(fid);
        //    var data = ret.Result;

            
        //    if (data != null)
        //    {
        //        System.Diagnostics.Process.Start(data.LHPAttachmentUrl.ToString());
        //    }
        //}

        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "lihatdetail":
                    Response.Redirect("../Manager/SelesaiDetail.aspx?value=" + IDS);
                    break;
            }
        }

        //private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    var IDS = e.CommandArgument;
        //    switch (e.CommandName)
        //    {
        //        case "DownloadListManager":
        //            SetLayout(ModeForm.ViewData);
        //            LoadDetail2(IDS.ToString());
        //            break;

        //        case "lihatdetail":
        //            SetLayout(ModeForm.DetailData);
        //            LoadDetail(Convert.ToString(IDS));
        //            RefreshGridDetail();
        //            btnKembali.Visible = true;
        //            break;
        //    }
        //}

        void RefreshGrid(string param = "")
        {
            var myLab = CommonWeb.GetUserLab();
            var ret = listGridMaster.GetDataSelesai(myLab);
            var datas = ret.Result;
            foreach (var dat in datas)
            {
                if (dat.isPaid == "1")
                {
                    dat.isPaid = "Sudah Dibayar";
                }
                else
                {
                    dat.isPaid = "Belum Dibayar";
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

        //void LoadDetail(string fid)
        //{
        //    var ret = rincianControls.DetailDataCustomer(fid);
        //    var data = ret.Result;

        //    if (data != null)
        //    {
        //        txtNoOrder.Text = data.orderNo.ToString();
        //        txtCustomer.Text = data.customertbl.customerName.ToString();
        //        txtKomoditas.Text = data.comoditytbl.comodityName.ToString();
        //        txtTipeAnalisis.Text = data.analysisType;
        //        txtTotalSample.Text = data.sampleTotal.ToString();
        //        txtTotalHarga.Text = Formater.ToRupiah(data.priceTotal.Value);
        //    }
        //}

        //private void DoKembali()
        //{
        //    PanelSelesai.Visible = true;
        //    detailOrder.Visible = false;
        //}

        
    }
}