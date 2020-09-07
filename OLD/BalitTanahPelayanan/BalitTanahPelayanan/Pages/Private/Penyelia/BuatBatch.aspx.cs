using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private.Penyelia
{
    public partial class BuatBatch : System.Web.UI.Page
    {
        OrderListControls orderControls = new OrderListControls();
        static NumberCounter CounterGen;
        protected void Page_Load(object sender, EventArgs e)
        {
            GvData.RowDataBound += GvData_RowDataBound;
            if (!IsPostBack)
            {
                GetTranslation();
                CounterGen = new NumberCounter();
                CmbPIC.DataTextField = "employeeName";
                CmbPIC.DataValueField = "employeeNo";
                var myLab = CommonWeb.GetUserLab();
                var picData = orderControls.GetPICAnalyst(myLab);
                CmbPIC.DataSource = picData;
                CmbPIC.DataBind();
                var batchIdStr = Request.QueryString["batchId"];
                if (!string.IsNullOrEmpty(batchIdStr))
                {
                    LitTitleBatch.Text = "Lihat Batch";
                    LitTitleBatch.Text = LanguageHelper.GetTranslation("detailbatch");
                    TxtNoBatch.Text = batchIdStr;
                    var data = orderControls.GetBatchFromId(batchIdStr);
                    if (data != null)
                    {
                        GvData.DataSource = orderControls.GetOrdersFromBatchId(batchIdStr);
                        GvData.DataBind();
                    }
                    
                    BtnSimpan.Visible = false;
                    GvData.Columns[0].Visible = false;
                 
                    int counter = 0;
                    foreach(var x in picData)
                    {
                        if(x.employeeNo == data.pic_analis.Value)
                        {
                            CmbPIC.SelectedIndex = counter;
                        }
                        counter++;
                    }
                   
                        
                    
                    CmbPIC.Enabled = false;

                }
                else
                {
                    LitTitleBatch.Text = "Buat Batch";
                    LitTitleBatch.Text = LanguageHelper.GetTranslation("createbatch");
                    TxtNoBatch.Text = GenerateNoBatch();
                    BindData();
                }
               
                
                
            }
            BtnBack.Click += (a, b) => { Response.Redirect("DaftarPesanan.aspx"); };
            BtnSimpan.Click += (a, b) => { SimpanData(); };

        }
       
        void BindData()
        {
            var empNo = CommonWeb.GetCurrentEmployeeNo();
            var datas = orderControls.GetOrdersForBatch(empNo);
            GvData.DataSource = datas;
            GvData.DataBind();
        }
        void SimpanData()
        {
            var LastNum = CounterGen.Increment("BATCHNO");
            var NewBatchNo = GenerateNoBatch(LastNum);
            var curDate = DateTime.Now;
            var newBatch = new batchtbl() { status="Proses", batchId = NewBatchNo, creaBy = CommonWeb.GetCurrentUser(), creaDate=curDate, modBy = CommonWeb.GetCurrentUser(), modDate = curDate, pic_analis = Convert.ToInt32(CmbPIC.SelectedValue), pic_penyelia = CommonWeb.GetCurrentEmployeeNo() };
            var listOrderNo = new List<string>();
            foreach (GridViewRow row in GvData.Rows)
            {
                var chk = row.FindControl("ChkPilih") as CheckBox;
                if(chk!=null && chk.Checked)
                {
                    var orderNo = row.Cells[1].Text;
                    listOrderNo.Add(orderNo);

                }
            }
            if (listOrderNo.Count > 0)
            {
               var res = orderControls.SimpanDataBatch(newBatch, listOrderNo);
                if (res)
                {
                    Response.Redirect("DaftarPesanan.aspx");
                }
            }
            else
            {
               
                CommonWeb.Alert(this,"Silakan pilih order terlebih dahulu");
               
            }
           
        }
        string GenerateNoBatch(long LastNumber = -1)
        {
            if (LastNumber <= 0)
            {
                var curDate = DatetimeHelper.GetDatetimeNow();
                string FormatNo = $"B-{(CounterGen.GetLastNumber("BATCHNO") + 1).ToString("00000")}/{curDate.ToString("MM")}/{curDate.ToString("yyyy")}";
                return FormatNo;
            }
            else
            {
                var curDate = DatetimeHelper.GetDatetimeNow();
                string FormatNo = $"B-{LastNumber.ToString("00000")}/{curDate.ToString("MM")}/{curDate.ToString("yyyy")}";
                return FormatNo;
            }

        }

        private void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = LanguageHelper.GetTranslation("order_no");
                e.Row.Cells[1].Text = LanguageHelper.GetTranslation("customer_name");
                e.Row.Cells[2].Text = LanguageHelper.GetTranslation("commodity");
                e.Row.Cells[3].Text = LanguageHelper.GetTranslation("analisystype");
                e.Row.Cells[4].Text = LanguageHelper.GetTranslation("total_sample");
                e.Row.Cells[5].Text = LanguageHelper.GetTranslation("order_status");
            }
        }

        void GetTranslation()
        {
            //LitTitleBatch.Text = LanguageHelper.GetTranslation("createbatch");
            GvData.EmptyDataText = LanguageHelper.GetTranslation("empty_data");
            LblNoBatch.Text = LanguageHelper.GetTranslation("batch_ID");
            desc0.Text = LanguageHelper.GetTranslation("batchauto");
            LblPilihPIC.Text = LanguageHelper.GetTranslation("selectPIC");
            LblPesananBatch.Text = LanguageHelper.GetTranslation("batchorder");
            BtnSimpan.Text = LanguageHelper.GetTranslation("btn_simpan");
            BtnBack.Text = LanguageHelper.GetTranslation("btn_kembali");
            LblFontSize.Text = LanguageHelper.GetTranslation("zoom");
        }
    }
}