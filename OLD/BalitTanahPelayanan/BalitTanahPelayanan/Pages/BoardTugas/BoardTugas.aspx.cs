using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.BoardTugas
{
    public partial class BoardTugas : System.Web.UI.Page
    {
        OrderDetailControls ordtl = new OrderDetailControls();

        enum ModeForm { viewdata, updatedata }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUser.Value = Membership.GetUser().UserName.ToString();
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
                        //LoadDetail(IDS.ToString().Trim());
                        Setlayout(ModeForm.updatedata);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi Kesalahan");
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
                        //DoUpdate();
                        break;

                    case "cancel":
                        Setlayout(ModeForm.viewdata);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi Kesalahan");
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        //set layout
        private void Setlayout(ModeForm mode)
        {
            switch (mode)
            {
                case ModeForm.updatedata:
                    break;
                case ModeForm.viewdata:
                    break;
            }
        }
    }
}