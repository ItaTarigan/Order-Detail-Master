using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Controllers;

namespace BalitTanahPelayanan.Pages.Private.MasterData
{
    public partial class OrderMaster : System.Web.UI.Page
    {
        string currentUser = "";
        OrderMasterControls orderControl = new OrderMasterControls();
        CustomerControls customerControl = new CustomerControls();
        ComodityControls comodityControl = new ComodityControls();
        EmployeeControls employeeControl = new EmployeeControls();

        enum ModeForm { ViewData, UpdateData, DetailData, AddData }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();
            }

            GvData.RowCommand += GvData_RowCommand;
        }

        #region Custom function
        // Clear input fields
        void ClearFields()
        {
            TxtOrderNo.Text = "Otomatis";
            TxtComodityNo.SelectedIndex = 0;
            TxtCustomerNo.SelectedIndex = 0;
            TxtSampleTotal.Text = "0";
            TxtPriceTotal.Text = "0";
            TxtStatus.SelectedIndex = 0;
            TxtIsApprove.SelectedIndex = 0;
            TxtIsPayed.SelectedIndex = 0;
            TxtPic.SelectedIndex = 0;
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = orderControl.GetData();
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }
            else
            {
                var ret = orderControl.GetDataByContaint(param);
                var datas = ret.Result;

                if (datas != null && datas.Count() > 0)
                {
                    GvData.DataSource = datas;
                    GvData.DataBind();
                }
            }

            //if (GvData.Rows.Count > 0)
            //{
            //    //Allow Paging
            //    GvData.AllowCustomPaging = true;
            //    //This replaces <td> with <th>    
            //    GvData.UseAccessibleHeader = true;
            //    //This will add the <thead> and <tbody> elements    
            //    GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            //    //This adds the <tfoot> element. Remove if you don't have a footer row    
            //    GvData.FooterRow.TableSection = TableRowSection.TableFooter;
            //}
        }

        void LoadDetail(string fid)
        {
            var ret = orderControl.DetailData(fid);
            var data = ret.Result;

            if (data != null)
            {
                TxtOrderNo.Text = data.orderNo;
                TxtCustomerNo.SelectedIndex = TxtCustomerNo.Items.IndexOf(
                        TxtCustomerNo.Items.FindByValue(data.customerNo.ToString()));
                TxtComodityNo.SelectedIndex = TxtComodityNo.Items.IndexOf(
                        TxtComodityNo.Items.FindByValue(data.comodityNo.ToString()));
                TxtSampleTotal.Text = data.sampleTotal.ToString();
                TxtPriceTotal.Text = Formater.ToRupiah(data.priceTotal.Value);
                TxtStatus.SelectedIndex = TxtStatus.Items.IndexOf(
                    TxtStatus.Items.FindByValue(data.status));
                TxtIsPayed.SelectedIndex = TxtIsPayed.Items.IndexOf(
                        TxtIsPayed.Items.FindByValue(data.isPaid));
                TxtIsApprove.SelectedIndex = TxtIsApprove.Items.IndexOf(
                        TxtIsApprove.Items.FindByValue(data.ApprEvaluator));

                if (data.pic != null)
                {
                    TxtPic.SelectedIndex = TxtPic.Items.IndexOf(
                        TxtPic.Items.FindByValue(data.pic.ToString()));
                }
                else
                {
                    TxtPic.SelectedIndex = 0;
                }
            }
        }

        private void DoUpdate()
        {
            string id = TxtOrderNo.Text;
            var data = new ordermastertbl
            {
                orderNo = id,
                customerNo = ParseInt(TxtCustomerNo.SelectedValue),
                comodityNo = ParseInt(TxtComodityNo.SelectedValue),
                sampleTotal = ParseInt(TxtSampleTotal.Text),
                priceTotal = Formater.ToNumber(TxtPriceTotal.Text),
                status = TxtStatus.Text,
                isPaid = TxtIsPayed.SelectedValue,
                ApprEvaluator = TxtIsApprove.SelectedValue,
                modBy = currentUser,
                modDate = DatetimeHelper.GetDatetimeNow()
            };

            if (TxtPic.SelectedValue != "-1")
            {
                data.pic = ParseInt(TxtPic.SelectedValue);
            }

            var ret = orderControl.UpdateData(id.ToString(), data);

            if (ret.Result)
            {
                ClearFields();
                SetLayout(ModeForm.ViewData);
                Alert("Data berhasil diubah");
            }
            else
            {
                Alert("Gagal mengubah data");
            }
        }

        private void DoSave()
        {
            string id = TxtOrderNo.Text;
            var data = new ordermastertbl
            {
                orderNo = id,
                customerNo = ParseInt(TxtCustomerNo.SelectedValue),
                comodityNo = ParseInt(TxtComodityNo.SelectedValue),
                sampleTotal = ParseInt(TxtSampleTotal.Text),
                priceTotal = Formater.ToNumber(TxtPriceTotal.Text),
                status = TxtStatus.Text,
                isPaid = TxtIsPayed.SelectedValue,
                ApprEvaluator = TxtIsApprove.SelectedValue,
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            if (TxtPic.SelectedValue != "-1")
            {
                data.pic = ParseInt(TxtPic.SelectedValue);
            }

            var ret = orderControl.AddData(data);

            if (ret.Result)
            {
                ClearFields();
                SetLayout(ModeForm.ViewData);
                Alert("data berhasil disimpan");
            }
            else
            {
                Alert("Gagal menyimpan data");
            }
        }

        private void DoDelete(string id)
        {
            var ret = orderControl.DeleteData(id);

            if (ret.Result)
            {
                RefreshGrid();
                Alert("Data berhasil dihapus");
            }
            else
            {
                Alert("Gagal menghapus data");
            }
        }

        // DropDown Generator

        private void GeneratePic()
        {
            TxtPic.Items.Clear();
            TxtPic.Items.Insert(0, new ListItem("Belum ada PIC", "-1"));

            var ret = employeeControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtPic.DataSource = datas;
                TxtPic.DataTextField = "employeeName";
                TxtPic.DataValueField = "employeeNo";
                TxtPic.DataBind();
            }

            TxtPic.SelectedIndex = 0;
        }

        private void GenerateCus()
        {
            TxtCustomerNo.Items.Clear();

            var ret = customerControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtCustomerNo.DataSource = datas;
                TxtCustomerNo.DataTextField = "customerName";
                TxtCustomerNo.DataValueField = "customerNo";
                TxtCustomerNo.DataBind();
            }

            TxtCustomerNo.SelectedIndex = 0;
        }

        private void GenerateCom()
        {
            TxtComodityNo.Items.Clear();

            var ret = comodityControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                TxtComodityNo.DataSource = datas;
                TxtComodityNo.DataTextField = "comodityName";
                TxtComodityNo.DataValueField = "comodityNo";
                TxtComodityNo.DataBind();
            }

            TxtComodityNo.SelectedIndex = 0;
        }

        // Helper function
        private int ParseInt(string param)
        {
            int ret = 0;
            int.TryParse(param, out ret);

            return ret;
        }

        // Alert
        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }
        #endregion

        #region Action function
        // Action on datagrid table
        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "ubah":
                    SetLayout(ModeForm.UpdateData);
                    LoadDetail(IDS.ToString().Trim());
                    break;

                case "hapus":
                    DoDelete(IDS.ToString().Trim());
                    break;

                case "lihat":
                    SetLayout(ModeForm.DetailData);
                    LoadDetail(IDS.ToString().Trim());
                    break;
            }
        }
        // Action Field
        protected void ActionButton(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var command = btn.CommandName;

                switch (command)
                {
                    case "save":
                        DoSave();
                        break;

                    case "add":
                        SetLayout(ModeForm.AddData);
                        break;

                    case "update":
                        DoUpdate();
                        break;

                    case "cancel":
                        SetLayout(ModeForm.ViewData);
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
            }
        }
        //protected void ActionImageButton(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var btn = sender as ImageButton;
        //        var command = btn.CommandName;

        //        switch (command)
        //        {
        //            case "search":
        //                var param = (TxtSearch.Text).Trim();
        //                RefreshGrid(param);
        //                break;

        //            case "refresh":
        //                TxtSearch.Text = "";
        //                RefreshGrid();
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Alert("Terjadi Kesalahan");
        //    }
        //}

        // Change layout
        private void SetLayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.AddData:
                    GeneratePic();
                    GenerateCom();
                    GenerateCus();
                    ClearFields();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    BtnUpdate.Visible = false;
                    BtnSave.Visible = true;
                    TxtOrderNo.Text = "Otomatis";
                    TxtCustomerNo.Enabled = true;
                    TxtComodityNo.Enabled = true;
                    TxtSampleTotal.Enabled = true;
                    TxtPriceTotal.Enabled = true;
                    TxtStatus.Enabled = true;
                    TxtIsApprove.Enabled = true;
                    TxtIsPayed.Enabled = true;
                    break;

                case ModeForm.UpdateData:
                    GeneratePic();
                    GenerateCom();
                    GenerateCus();
                    PanelGrid.Visible = false;
                    PanelInput.Visible = true;
                    TxtCustomerNo.Enabled = true;
                    TxtComodityNo.Enabled = true;
                    TxtSampleTotal.Enabled = true;
                    TxtPriceTotal.Enabled = true;
                    TxtStatus.Enabled = true;
                    TxtIsApprove.Enabled = true;
                    TxtIsPayed.Enabled = true;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;
                    break;

                case ModeForm.ViewData:
                    RefreshGrid();
                    PanelGrid.Visible = true;
                    PanelInput.Visible = false;
                    break;

                case ModeForm.DetailData:
                    GeneratePic();
                    GenerateCom();
                    GenerateCus();
                    PanelInput.Visible = true;
                    PanelGrid.Visible = false;
                    TxtCustomerNo.Enabled = false;
                    TxtComodityNo.Enabled = false;
                    TxtSampleTotal.Enabled = false;
                    TxtPriceTotal.Enabled = false;
                    TxtStatus.Enabled = false;
                    TxtIsApprove.Enabled = false;
                    TxtIsPayed.Enabled = false;
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = false;
                    break;
            }
        }
        #endregion
    }
}