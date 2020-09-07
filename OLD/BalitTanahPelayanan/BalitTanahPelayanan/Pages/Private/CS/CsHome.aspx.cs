using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private.CS
{
    public partial class CsHome : System.Web.UI.Page
    {
        OrderMasterControls ordm = new OrderMasterControls();        
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshGridMasuk();            
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
                        RefreshGridMasuk(param);
                        break;

                    case "refresh":
                        TxtSearch.Text = "";
                        RefreshGridMasuk();
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert("Terjadi Kesalahan");
            }
        }

        public void RefreshGridMasuk(string param = "")
        {
            GvIn.DataBind();
            if (param == null || param == "")
            {
                var ret = ordm.GetData();
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
                foreach (var dat in datas)
                {
                    if (dat.isOnLab == "1")
                    {
                        dat.isOnLab = "Sudah Di lab";
                    }

                    else
                    {
                        dat.isOnLab = "Belum Di lab";
                    }
                }
                if (datas != null && datas.Count() > 0)
                {
                    GvIn.DataSource = datas.ToList().Where(x => x.status == Status.OrderStatus[0]).Select(x => x); /////coba tampilan master berdasar status di detail
                    GvIn.DataBind();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("data null");
                }
            }
        }
        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }        
    }
}