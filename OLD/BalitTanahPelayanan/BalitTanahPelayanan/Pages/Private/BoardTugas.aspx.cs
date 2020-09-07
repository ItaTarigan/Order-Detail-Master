using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class BoardTugas : System.Web.UI.Page
    {
        OrderDetailControls ordtl = new OrderDetailControls();
        void GetTranslation()
        {
            lblPapanTugas.Text = LanguageHelper.GetTranslation("Board");
            lblAnalisisTipe.Text = LanguageHelper.GetTranslation("analysis_type");
            lblNoOrder.Text = LanguageHelper.GetTranslation("order_no");
            lblNoOrderDetail.Text = LanguageHelper.GetTranslation("detail_order_no");
            BtnCancel.Text = LanguageHelper.GetTranslation("back");
        }
        enum ModeForm { viewdata, updatedata }
        protected void Page_Load(object sender, EventArgs e)
        {
            GvTask.RowDataBound += GvTask_RowDataBound;
            if (!IsPostBack)
            {
                GetTranslation();
                RefreshGridTask();
            }
            GvTask.RowCommand += GvTask_command;
        }

        private void GvTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("sample_no");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("element_code");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("status");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("pic");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var linkBtn = e.Row.FindControl("btnLihat") as LinkButton;
                if (linkBtn != null)
                    linkBtn.Text = LanguageHelper.GetTranslation("view");
            }
        }
        void RefreshGridTask(string param = "")
        {
            GvTask.DataBind();
            if (param == null || param == "")
            {
                var ret = ordtl.GetData();
                var datas = ret.Result;
                if (datas != null && datas.Count() > 0)
                {
                    GvTask.DataSource = datas.ToList();
                    GvTask.DataBind();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("data null");
                }
            }
            else
            {
                var ret = ordtl.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvTask.DataSource = datas;
                    GvTask.DataBind();
                }
                else
                {

                }
            }
        }
        public string GetStatus(string fid)
        {
            string sts = "";
            var ret = ordtl.DetailData(fid);
            var data = ret.Result;
            if (data.status == Status.OrderStatus[0])
            {
                sts = Status.OrderStatus[1];
            }
            else if (data.status == Status.OrderStatus[1])
            {
                sts = Status.OrderStatus[2];
            }
            return sts;
        }
        private void DoUpdate()
        {
            try
            {
                string idd = TxtDetailNo.Text.ToString();
                int id = ParseInt(TxtorderNo.Text);

                var det = ordtl.DetailData(idd);
                var wholedata = det.Result;

                var updatests = GetStatus(idd.ToString());
                var data = new orderanalysisdetailtbl
                {
                    orderDetailNo = wholedata.orderDetailNo,
                    orderNo = wholedata.orderNo,
                    sampleNo = wholedata.sampleNo,
                    elementId = wholedata.elementId,
                    parametersNo = wholedata.parametersNo,
                    elementValue = wholedata.elementValue,
                    status = updatests,
                    pic = wholedata.pic,
                    creaBy = wholedata.creaBy,
                    creaDate = wholedata.creaDate,
                    modBy = wholedata.modBy,
                    modDate = DatetimeHelper.GetDatetimeNow()
                };

                var ret = ordtl.UpdateData(idd.ToString(), data);
                if (ret.Result)
                {
                    Alert("Tugas Telah Diambil");
                }
                else
                {
                    Alert("Terjadi Kesalahan, Gagal mengambil tugas");
                }
            }
            catch (Exception er)
            {
                System.Diagnostics.Debug.WriteLine(er);
            }
        }

        void LoadDetail(string fid)
        {
            var ret = ordtl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtorderNo.Text = data.orderNo.ToString();
                TxtParameter.Text = data.parametersNo.ToString();
                TxtStatus.Text = data.status;
                TxtDetailNo.Text = data.orderDetailNo.ToString();
            }
        }

        protected void GvTask_command(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var IDS = e.CommandArgument;
                switch (e.CommandName)
                {
                    case "lihat":
                        LoadDetail(IDS.ToString().Trim());
                        Setlayout(ModeForm.updatedata);
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
                    case "update":
                        DoUpdate();
                        break;

                    case "cancel":
                        Setlayout(ModeForm.viewdata);
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        //alert
        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }

        //set layout
        private void Setlayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.updatedata:
                    PanelGrid.Visible = false;
                    PanelUpdate.Visible = true;
                    if (TxtStatus.Text == Status.OrderStatus[0].ToString())
                    {
                        BtnUpdate.Visible = true;
                    }
                    else if (TxtStatus.Text == Status.OrderStatus[1].ToString())
                    {
                        BtnUpdate.Visible = true;
                    }
                    else { BtnUpdate.Visible = false; }
                    break;
                case ModeForm.viewdata:
                    PanelGrid.Visible = true;
                    PanelUpdate.Visible = false;
                    break;
            }
        }
        private int ParseInt(string param)
        {
            int ret = 0;
            int.TryParse(param, out ret);

            return ret;
        }
    }
}