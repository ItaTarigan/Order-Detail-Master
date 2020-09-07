using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalitTanahPelayanan.Controllers;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Pages.Private.MasterData
{
    public partial class ResultsMaster : System.Web.UI.Page
    {
        ResultControls resultControl = new ResultControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();
            }
        }

        // Reload datagrid
        void RefreshGrid()
        {
            var ret = resultControl.GetData();
            var datas = ret.Result;

            if (datas != null && datas.Count() > 0)
            {
                GvData.DataSource = datas;
                GvData.DataBind();
            }

            if (GvData.Rows.Count > 0)
            {
                //Allow Paging
                GvData.AllowCustomPaging = true;
                //This replaces <td> with <th>    
                GvData.UseAccessibleHeader = true;
                //This will add the <thead> and <tbody> elements    
                GvData.HeaderRow.TableSection = TableRowSection.TableHeader;
                //This adds the <tfoot> element. Remove if you don't have a footer row    
                GvData.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}