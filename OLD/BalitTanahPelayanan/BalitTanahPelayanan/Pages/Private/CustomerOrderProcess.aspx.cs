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
    public partial class CustomerOrderProcess : System.Web.UI.Page
    {
        string currentUser = "";
        CustomerOrderProcessControls orderControl = new CustomerOrderProcessControls();
        CustomerControls customerControl = new CustomerControls();
        ComodityControls comodityControl = new ComodityControls();

        GridView grid1 = new GridView();

        enum ModeForm { ViewData, DetailData }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();
            }

            GvData.RowCommand += GvData_RowCommand;
        }

        #region Custom function
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            if (param == null || param == "")
            {
                var ret = orderControl.GetData();
                var datas = ret.Result;

                foreach (var data in datas)
                {
                    if (data.isPaid == "1")
                    {
                        data.isPaid = "Sudah";

                    }
                    else
                    {
                        data.isPaid = "Belum";
                    }
                }

                foreach (var data in datas)
                {
                    if (data.isPaid == "1")
                    {
                        data.isPaid = "Sudah";
                    }
                    else
                    {
                        data.isPaid = "Belum";
                    }
                }


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
        }

        // Alert
        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }

        #endregion

        #region Action Function
        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //var IDS = e.CommandArgument;

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
                        var param = (txtSearch.Text).Trim();
                        RefreshGrid(param);
                        break;

                    case "refresh":
                        txtSearch.Text = "";
                        RefreshGrid();
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
            }
        }
        #endregion   
    }
}