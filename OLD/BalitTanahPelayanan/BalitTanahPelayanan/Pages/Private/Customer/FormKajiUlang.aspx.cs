using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System.Data.Entity;
namespace BalitTanahPelayanan.Pages.Private.Customer
{
    public partial class FormKajiUlang : System.Web.UI.Page
    {

        string currentUser = "";
        string orderNo = "";

        ReviewingControls reviewingControls = new ReviewingControls();
        OrderDetailControls orderDetailControls = new OrderDetailControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GvParam.RowCommand += GvParam_RowCommand;
                GetTranslate();
                if (!string.IsNullOrEmpty(Request.QueryString["orderno"]))
                {
                    var orderstr = Request.QueryString["orderno"];
                    smlpobDB db = new smlpobDB();

                    var data = (from x in db.orderpricedetailtbls.Include(c=>c.elementservicestbl)
                                where x.orderNo == orderstr
                                select x).ToList();
                    GvParam.DataSource = data;
                    GvParam.DataBind();
                    if (GvParam.Rows.Count > 0)
                    {
                        GvParam.UseAccessibleHeader = true;
                        GvParam.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    var master = (from x in db.ordermastertbls
                                  where x.orderNo == orderstr
                                  select new { x.receiptDate, x.customerNo, x.comodityNo }).FirstOrDefault();
                    TxtReceiptDate.Text = master.receiptDate?.ToString("yyyy-MM-dd");

                    var como = (from x in db.comoditytbls
                                where x.comodityNo == master.comodityNo
                                select x).FirstOrDefault();
                    TxtComodityType.Text = como.comodityName;

                    var cust = (from x in db.customertbls
                                where x.customerNo == master.customerNo
                                select x).FirstOrDefault();
                    TxtCustomerName.Text = cust.customerName;
                    TxtCompanyName.Text = cust.companyName;
                    TxtCompanyAddress.Text = cust.companyAddress;
                }
            }
            this.GvParam.DataBound += (object o, EventArgs ev) =>
            {
                GvParam.HeaderRow.TableSection = TableRowSection.TableHeader;
            };

        }
        private void GetTranslate()
        {
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
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

                    case "cancel":

                        if (!string.IsNullOrEmpty(Request.QueryString["orderno"]))
                        {
                            var orderstr = Request.QueryString["orderno"];
                            Response.Redirect("CustomerRincian.aspx?orderNo=" + orderstr);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonWeb.Alert(this, "Terjadi Kesalahan");
            }
        }
        private void DoSave()
        {
            reviewingtbl review = new reviewingtbl();
            List<reviewingtbl> parameter = new List<reviewingtbl>();

            var data = new reviewingtbl
            {
                orderNo = TxtNoOrder.Text,
                reviewingDate = Convert.ToDateTime(TxtReceiptDate.Text),
                workdays = Convert.ToInt32(TxtWorkDay.Text),
                creaBy = currentUser,
                creaDate = DatetimeHelper.GetDatetimeNow()
            };

            foreach (GridViewRow gvrow in GvParam.Rows)
            {
                var chkbx = gvrow.FindControl("isChecked") as CheckBox;
                if (chkbx.Checked)
                {
                    var element = gvrow.FindControl("txtParameterUji") as Label;
                    parameter.Add(new reviewingtbl
                    {
                        elementCodeList = element.Text,
                    });
                }
            }

            if (TxtLabUtility1.Checked)
            {
                data.isLabUtilitySurfficient = "1";
            }
            else
            {
                data.isLabUtilitySurfficient = "0";
            }

            if (TxtLabHumanResource1.Checked)
            {
                data.isHumanResourceSurfficient = "1";
            }
            else
            {
                data.isHumanResourceSurfficient = "0";
            }

            if (TxtLabChemicalMat1.Checked)
            {
                data.isChemicalMaterialSurfficent = "1";
            }
            else
            {
                data.isChemicalMaterialSurfficent = "0";
            }

            if (TxtVolume1.Checked)
            {
                data.isVolumeCorrect = "1";
            }
            else
            {
                data.isVolumeCorrect = "0";
            }

            if (TxtMethode1.Checked)
            {
                data.isMethode = "1";
            }
            else
            {
                data.isMethode = "0";
            }

            if (TxtQualityStandard1.Checked)
            {
                data.isQualityStandard = "1";
            }
            else
            {
                data.isQualityStandard = "0";
            }

            var ret = reviewingControls.AddData(data);

            if (ret.Result)
            {
                CommonWeb.Alert(this, "data berhasil disimpan");
                Response.Redirect("CustomerBeranda.aspx");
            }
            else
            {
                CommonWeb.Alert(this, "Gagal menyimpan data");
            }
        }

        private void DoChecked(object sender, EventArgs e)
        {
            int totalParameterUji = 0;
            foreach (GridViewRow gvrow in GvParam.Rows)
            {
                var chkbx = gvrow.FindControl("isChecked") as CheckBox;
                if (chkbx.Checked)
                {
                    totalParameterUji++;
                }
            }
        }

        protected void GvParam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (sender is CheckBox)
            {
                var chk = sender as CheckBox;
                Response.Write(chk.ID + "test");
            }
        }
    }
}
