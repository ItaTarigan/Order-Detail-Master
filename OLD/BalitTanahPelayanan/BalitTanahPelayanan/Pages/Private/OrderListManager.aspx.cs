using BalitTanahPelayanan.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class OrderListManager : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        EmployeeControls employeecontrols = new EmployeeControls();

        enum ModeForm { ViewData, DetailData, UpdateData, ProsesData }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                RefreshGrid();
            }

            GvData.RowCommand += GvData_RowCommand;
            gv2.RowCommand += gv2_RowCommand;
        }

        void RefreshGrid(string param = "")
        {

            GvData.DataBind();
            DropDownList1.DataBind();
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

        void RefreshGridPIC(string param)
        {
            gvPIC.DataBind();
            DropDownList1.DataBind();
            int ids = Convert.ToInt32(param);
            if (!ids.Equals(null))
            {
                var ret = orderControls.GetData();
                var datas = ret.Result.Where(x => x.pic == ids);
                var ret2 = employeecontrols.GetData();
                var nameemp = ret2.Result.Where(x => x.employeeNo == ids).Select(x => x.employeeName).First();
                lblpic.Text = nameemp.ToString();
                if (datas != null && datas.Count() > 0)
                {
                    gvPIC.DataSource = datas;
                    gvPIC.DataBind();
                }
            }
            else
            {
                Alert("Gagal");
            }
        }

        //private void DoUpdate()
        //{
        //    string id = txtNoOreder.Text;
        //    //master
        //    var rett = orderControls.MasterData(id);
        //    var datas = rett.Result;
        //    //detail
        //    var detor = orderControls.GetDetailOrder(id);
        //    var datadet = detor.Result;
        //    int iddet = datadet.orderDetailNo;
        //    int _pic = Convert.ToInt32(DropDownList1.SelectedValue);

        //    var data = new ordermastertbl
        //    {
        //        orderNo = datas.orderNo,
        //        customerNo = datas.customerNo,
        //        comodityNo = datas.comodityNo,
        //        sampleTotal = datas.sampleTotal,
        //        priceTotal = datas.priceTotal,
        //        status = datas.status,
        //        isPaid = datas.isPaid,
        //        ApprPenyelia = datas.ApprPenyelia,
        //        pic = _pic
        //    };

        //    var data2 = new orderanalysisdetailtbl
        //    {
        //        orderDetailNo = iddet,
        //        orderNo = datadet.orderNo,
        //        sampleNo = datadet.sampleNo,
        //        elementCode = datadet.elementCode,
        //        parametersNo = datadet.parametersNo,
        //        elementValue = datadet.elementValue,
        //        status = datadet.status,
        //        pic = _pic
        //    };

        //    var ret = orderControls.UpdateData(id, data);
        //    var ret2 = orderControls.UpdateDataDetail(iddet, data2);

        //    if (ret.Result && ret2.Result)
        //    {
        //        ClearFields();
        //        SetLayout(ModeForm.ViewData);
        //        string msg = "Pic Untuk No Order " + id + " telah dipilih";
        //        Alert(msg);
        //    }
        //    else
        //    {
        //        Alert("Gagal mengubah data");
        //    }
        //}

        void ClearFields()
        {
            txtSample.Text = "";

        }

        void LoadDetail(int fid)
        {
            //var ret = orderControls.DetailData(fid);
            //var data = ret.Result;
            //var ret2 = employeecontrols.GetData();
            //var datas2 = ret2.Result.Where(x => x.position == "analis");

            //if (datas2 != null && datas2.Count() > 0)
            //{
            //    DropDownList1.DataSource = datas2;
            //    DropDownList1.DataTextField = "employeeName";
            //    DropDownList1.DataValueField = "employeeNo";
            //    DropDownList1.DataBind();
            //}

            //if (data != null)
            //{
            //    txtNoOreder.Text = data.orderNo;
            //    txtNoSample.Text = data.sampleNo;
            //    txtCustomer.Text = data.ordermastertbl.customertbl.customerName;
            //    txtSample.Text = data.ordersampletbl.sampleDescription;
            //    Jenis.Text = data.elementservicestbl.elementCode;
            //}
        }

        // Alert
        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }

        protected void ActionImageButton(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ImageButton;
                var command = btn.CommandName;

                switch (command)
                {
                    case "search":
                        var param = (TxtSearch.Text).Trim();
                        RefreshGrid(param);
                        break;

                    case "refresh":
                        TxtSearch.Text = "";
                        RefreshGrid();
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
            }
        }


        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "lihat":
                    SetLayout(ModeForm.DetailData);
                    LoadDetail(Convert.ToInt32(IDS));
                    break;
                case "lihatproses":
                    SetLayout(ModeForm.ProsesData);
                    RefreshGridPIC(IDS.ToString());
                    break;
            }
        }

        private void gv2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "lihatproses":
                    SetLayout(ModeForm.ProsesData);
                    RefreshGridPIC(IDS.ToString());
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

                case ModeForm.ProsesData:
                    PanelGrid.Visible = false;
                    DTOrder.Visible = false;
                    PanelOrderMasuk.Visible = false;
                    PanelPIC.Visible = true;
                    break;
            }
        }

        void RefreshGridProses(string param = "")
        {

            gv2.DataBind();
            //DropDownList1.DataBind();
            if (param == null || param == "")
            {
                var datas = orderControls.GetAllMasterOrder();
                //var picname = datas.
                //var getempname = employeecontrols.GetData();
                //var res = getempname.Result.Where(x => x.employeeNo == picname);

                //var datas = ret.res;
                if (datas != null)
                {
                    gv2.DataSource = datas;
                    gv2.DataBind();
                }
            }
            else
            {
                var ret = orderControls.GetDataByContaint(param);
                var datas = ret.Result;



                if (datas != null && datas.Count() > 0)
                {
                    gv2.DataSource = datas;
                    gv2.DataBind();
                }
            }
        }

        protected void BtnLanjut_Click(object sender, EventArgs e)
        {
            //DoUpdate();
            RefreshGrid();
            PanelGrid.Visible = true;
            DTOrder.Visible = false;
        }

        protected void BtnKembali_Click(object sender, EventArgs e)
        {
            RefreshGrid();
            PanelGrid.Visible = true;
            DTOrder.Visible = false;
        }

        protected void BtnOrderProses_Click(object sender, EventArgs e)
        {
            RefreshGridProses();
            PanelGrid.Visible = false;
            DTOrder.Visible = false;
            PanelOrderMasuk.Visible = true;
        }
    }
}