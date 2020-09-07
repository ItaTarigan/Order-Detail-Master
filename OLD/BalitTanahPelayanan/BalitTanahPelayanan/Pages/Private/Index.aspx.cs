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
	public partial class Index : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //redirector
                using (var db = new smlpobDB())
                {
                    var currentUser = CommonWeb.GetCurrentUser();
                    var role = (from x in db.accounttbls
                                where x.username == currentUser
                                select x.roleName).FirstOrDefault();
                    if (!string.IsNullOrEmpty(role))
                    {
                        switch (role.ToLower())
                        {
                            case "pelanggan":
                                if(Session["touch"]!=null && Convert.ToBoolean(Session["touch"]))
                                {
                                    Response.Redirect("/Pages/Private/Customer/CustomerBuatPesananTouch.aspx",false);
                                }
                                else
                                Response.Redirect("/Pages/Private/Customer/CustomerBuatPesanan.aspx", false);
                                break;
                            case "penyelia":
                                Response.Redirect("/Pages/Private/Penyelia/DaftarPesanan.aspx");
                                break;
                            case "manajer teknis":
                                Response.Redirect("/Pages/Private/Manager/Dash_ManagerTeknis.aspx");
                                break;
                            case "evaluator":
                                Response.Redirect("/Pages/Private/Evaluator/EvaluasiHasil.aspx");
                                break;
                            case "analis":
                                if (CommonWeb.GetUserLab() == "Kimia") 
                                    Response.Redirect("/Pages/Private/Analis/AnalisBeranda.aspx");
                                else
                                    Response.Redirect("/Pages/Private/Analis/AnalisBerandaNonBatch.aspx");

                                break;
                            case "cs":
                                Response.Redirect("/Pages/Private/CS/CustomerServiceBeranda.aspx");
                                break;
                            case "kasir":
                                Response.Redirect("/Pages/Private/Kasir/KasirMasuk.aspx");
                                break;
                            case "admin":
                                Response.Redirect("/Pages/Private/MasterData/AccountsMaster.aspx");
                                break;
                            case "pimpinan":
                                Response.Redirect("/Pages/Private/Pimpinan/PimpinanBeranda.aspx");
                                break;
                            case "boardtugas":
                                Response.Redirect("/Pages/BoardTugas/BoardTugas.aspx");
                                break;
                        }
                    }
                }
            }
        }
	}
}