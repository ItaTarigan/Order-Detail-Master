using BalitTanahPelayanan.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class DaftarTugasLaboran : System.Web.UI.Page
    {
        OrderDetailControls ordt = new OrderDetailControls();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {                        
            var ret = ordt.GetData();
            var datas = ret.Result;
            int diproses = ret.Result.Where(c => c.status == "Dalam Proses").Select(c => c.status).Count();
            int selesai = ret.Result.Where(c => c.status == "Selesai").Select(c => c.status).Count();
            lblProcessed.Text = diproses.ToString();
            lblDone.Text = selesai.ToString();
            btntes.Text = "tet";
        }
    }
}