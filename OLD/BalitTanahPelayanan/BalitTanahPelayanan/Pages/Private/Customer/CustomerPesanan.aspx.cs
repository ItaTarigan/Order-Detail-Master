using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Controllers;

namespace BalitTanahPelayanan.Pages.Private.Customer
{
    public partial class CustomerPesanan : System.Web.UI.Page
    {
        CustomerControls customerControls = new CustomerControls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();
                DisplayUser();
            }

            GvData.RowCommand += GvData_RowCommand;
        }

        protected void DisplayUser()
        {
            string id = Membership.GetUser().UserName.ToString();
            string currentUser = customerControls.GetCurrentUser(id);
            lbCurrentUser.Text = currentUser;
        }

        // Action on datagrid table
        private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var IDS = e.CommandArgument;
            switch (e.CommandName)
            {
                case "lihat":
                    //SetLayout(ModeForm.DetailData);
                    //LoadDetail(IDS.ToString().Trim());
                    break;
            }
        }

        // Reload datagrid
        void RefreshGrid(string param = "")
        {
            GvData.DataBind();

            //if (param == null || param == "")
            //{
            //    var ret = accountControl.GetData();
            //    var datas = ret.Result;

            //    if (datas != null && datas.Count() > 0)
            //    {
            //        GvData.DataSource = datas;
            //        GvData.DataBind();
            //    }
            //}
            //else
            //{
            //    var ret = accountControl.GetDataByContaint(param);
            //    var datas = ret.Result;

            //    if (datas != null && datas.Count() > 0)
            //    {
            //        GvData.DataSource = datas;
            //        GvData.DataBind();
            //    }
            //}

            //if (GvData.Rows.Count > 0)
            //{
            //    //This replaces <td> with <th>    
            //    GvData.UseAccessibleHeader = true;
            //    //This will add the <thead> and <tbody> elements    
            //    GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
            //    //This adds the <tfoot> element. Remove if you don't have a footer row    
            //    GvData.FooterRow.TableSection = TableRowSection.TableFooter;
            //}
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
                       // DoSave();
                        break;

                    case "add":
                        Response.Redirect("CustomerBuatPesanan.aspx");
                        break;

                    case "update":
                        //DoUpdate();
                        break;

                    case "cancel":
                        //SetLayout(ModeForm.ViewData);
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
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
            try
            {
                var btn = sender as ImageButton;
                var command = btn.CommandName;

                switch (command)
                {
                    case "search":
                        var param = (TxtSearch.Text).Trim();
                        //RefreshGrid(param);
                        break;

                    case "refresh":
                        TxtSearch.Text = "";
                        //RefreshGrid();
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
            }
        }
    }
}