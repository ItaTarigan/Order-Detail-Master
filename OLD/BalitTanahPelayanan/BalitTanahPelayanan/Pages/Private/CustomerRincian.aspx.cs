using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
	public partial class CustomerRincian : System.Web.UI.Page
	{
        string currentUser = "";
        CustomerRincianControl rincianControl = new CustomerRincianControl();
        SampleControls samplecontrol = new SampleControls();
        OrderMasterControls ordermastercontrol = new OrderMasterControls();

        enum ModeForm { ViewData, DetailData, UpdateData }
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {

                RefreshGrid();
                var NoOrder = Request.QueryString["orderNo"];
                if (!string.IsNullOrEmpty(NoOrder))
                {
                    LoadDetail(NoOrder);
                    //LoadGridSample(NoOrder);
                    //LoadParameter(NoOrder);
                }
            }

            GvData.RowCommand += GvData_RowCommand;
        }

        /*void ClearFields()
        {
            txtNoPesanan.Text = "";
            txtKomoditas.Text = "";
            txtTipeAnalisis.Text = "";
            txtTotalHarga.Text = "";
            txtTotalSampel.Text = "";
            txtStatus.Text = "";
        }*/

        /*void LoadDetail(string fid)
        {
            var ret = rincianControl.DetailDataCustomer(fid);
            var data = ret.Result;

            if (data != null)
            {
                txtNoPesanan.Text = data.orderNo.ToString();
                txtKomoditas.Text = data.comodityNo.ToString();
                txtTipeAnalisis.Text = data.analysisType;
                txtTotalHarga.Text = Formater.ToRupiah(data.priceTotal.Value);
                txtTotalSampel.Text = data.sampleTotal.ToString();
                if (data.status == "1")
                {
                    txtStatus.Text = "SUDAH";
                } else
                {
                    txtStatus.Text = "BELUM";
                }

               
            }
        }*/

        

        void LoadDetail(string fid)
        {
            var ret = rincianControl.DetailDataCustomer(fid);
            var data = ret.Result;

            if (data != null)
            {
                txtNoPesanan.Text = data.orderNo.ToString();
                txtKomoditas.Text = data.comoditytbl.comodityName.ToString();
                txtTipeAnalisis.Text = data.analysisType;
                txtTotalSample.Text = data.sampleTotal.ToString();
                txtTotalHarga.Text = Formater.ToRupiah(data.priceTotal.Value);
                txtStatus.Text = data.status;

            }
        }
        void RefreshGrid(string param = "")
        {

            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = samplecontrol.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = samplecontrol.GetDataByContaint(param);
                var datas = ret.Result;
                

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
        }


        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}