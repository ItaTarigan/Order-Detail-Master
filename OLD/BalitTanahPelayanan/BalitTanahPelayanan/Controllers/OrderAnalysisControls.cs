using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using System.Data.Entity;
using System.Threading.Tasks;


namespace BalitTanahPelayanan.Controllers
{
    public class OrderAnalysisControls : IOrderAnalysisMasterData
    {
        public async Task<IEnumerable<orderanalysisdetailtbl>> GetData(string id)
        {
                try
                {
                    using (var context = new smlpobDB())
                    {
                        var datas = await context.orderanalysisdetailtbls.Where(x => x.orderNo == id).Include(c=>c.elementservicestbl).ToListAsync();
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