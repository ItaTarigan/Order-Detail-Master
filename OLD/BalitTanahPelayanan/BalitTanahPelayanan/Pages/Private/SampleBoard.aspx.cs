using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Controllers;

namespace BalitTanahPelayanan.Pages.Private
{
    public partial class SampleBoard : System.Web.UI.Page
    {
        //OrderDetailControls orderdetailcontrols = new OrderDetailControls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
            //GvData.RowCommand += GvData_RowCommand;
        }

        //private void GvData_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //        var IDS = e.CommandArgument;

        //        switch (e.CommandName)
        //        {
        //            case "Menunggu":
        //                {
        //                    DoUpdate(IDS.ToString().Trim());
        //                    CommonWeb.Alert(this, IDS.ToString());

        //                    break;
        //                }
        //        }
         
        //}

        //private void DoUpdate(string id)
        //{
        //    //var ret =  orderdetailcontrols.UpdateData(id)            
        //    var data = new orderanalysisdetailtbl
        //    {   
        //        status = "Diproses"
        //    };
           

        //    var ret = orderdetailcontrols.UpdateData(id.ToString(), data);

        //    if (ret.Result)
        //    {
        //        LoadData();

        //        CommonWeb.Alert(this, "Data Berhasil diubah");
        //    }
        //    else
        //    {
        //        CommonWeb.Alert(this, "Data gagal diubah");
        //    }
        //}

        void LoadData()
            {
                DataTable dt = new DataTable("data");
                using (var db = new smlpobDB())
                {
                    var dataSamples = (from x in db.ordersampletbls
                                       select new { noBalittanah = x.noBalittanah }).Distinct().ToList();
                    var dataParameters = (from x in db.orderanalysisdetailtbls
                                          select new { code = x.elementId.ToString() }).Distinct().ToList();
                    dt.Columns.Add("OrderNo");
                    dt.Columns.Add("NoSample");
                    dt.Columns.Add("AnalisisType");
                    dt.Columns.Add("PIC");
                    foreach (var par in dataParameters)
                    {
                        dt.Columns.Add(par.code);
                    }
                    var orderNos = (from x in db.ordermastertbls
                                    select new { orderNo = x.orderNo, AnalisType = x.analysisType, pic = x.pic }).Distinct().ToList();
                    foreach (var item in orderNos)
                    {
                        foreach (var sample in dataSamples)
                        {
                            var dr = dt.NewRow();
                            dr["OrderNo"] = item.orderNo;
                            dr["NoSample"] = sample.noBalittanah;
                            dr["AnalisisType"] = item.AnalisType;
                            dr["PIC"] = item.pic;

                            foreach (var par in dataParameters)
                            {
                                var status = (from x in db.orderanalysisdetailtbls
                                              where x.orderNo == item.orderNo && x.elementId.ToString() == par.code && x.sampleNo == sample.noBalittanah
                                              select new { status = x.status }).FirstOrDefault();

                                if (status == null)
                                    dr[par.code] = "-";
                                else
                                    dr[par.code] = status.status;
                            }
                            dt.Rows.Add(dr);
                        }

                    }
                    var htmlStr = "<table class='table table-hover table-bordered'>";    
                    htmlStr += "<tr>";

                  foreach (DataColumn col in dt.Columns)
                    {
                        htmlStr +=$"<td><span class='badge badge - primary'>{col.ColumnName}</span></td>" ;
                    }
                    htmlStr += "</tr>";

                  foreach (DataRow row in dt.Rows)
                  {
                    htmlStr += "<tr>";
                    int colCounter = 0;
                    foreach(DataColumn col in dt.Columns)
                    {
                        colCounter++;
                        
                        htmlStr += colCounter>2 ? $"<td><span class='badge badge - primary'>{row[col.ColumnName].ToString()}</span></td>" : $"<td>{row[col.ColumnName].ToString()}</td>";
                    }
                    htmlStr += "</tr>";

                  }
                    htmlStr += "</table>";
                    Literal1.Text = htmlStr;
                    //GvData.DataSource = dt;
                    //GvData.DataBind();

                }
            }
        }
    }