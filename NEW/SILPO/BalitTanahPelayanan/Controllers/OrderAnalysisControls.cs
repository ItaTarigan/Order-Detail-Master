using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace BalitTanahPelayanan.Controllers
{
    public class OrderAnalysisControls : IOrderAnalysisMasterData
    {
        public async Task<IEnumerable<Orderanalysisdetailtbl>> GetData(string id)
        {
                try
                {
                    using (var context = new smlpobDB())
                    {
                        var datas = await context.Orderanalysisdetailtbl.Where(x => x.OrderNo == id).Include(c=>c.Element).ToListAsync();
                        return datas;
                    }
                }
                catch (Exception ex)
                {
                    LogHelpers.source = this.GetType().Name;
                    LogHelpers.message = ex.Message;
                    LogHelpers.user = "";
                    LogHelpers.WriteLog();
                }

                return null;
        }
    }
}