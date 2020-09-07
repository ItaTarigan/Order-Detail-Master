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
    public class OrderSampleControls : IOrderSampleMasterData
    {
        public async Task<IEnumerable<ordersampletbl>> GetDataAsync(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.ordersampletbls
                                       where x.orderNo.Contains(id)
                                       select x).ToListAsync();
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

        public static  IEnumerable<ordersampletbl> GetDataByStatus(string Status,string Lab="")
        {
            try
            {
                using (var db = new smlpobDB())
                {
                    var datas = new List<ordersampletbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = db.ordersampletbls.Include(c => c.ordermastertbl).Where(x => x.ordermastertbl.status == Status && x.ordermastertbl.analysisType==Lab)
                            .AsNoTracking()
                            .ToList();
                    }
                    else
                    {
                        datas = db.ordersampletbls.Include(c => c.ordermastertbl).Where(x => x.ordermastertbl.status == Status)
                            .AsNoTracking()
                            .ToList();
                    }
                    
                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = typeof(OrderSampleControls).Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return null;
        }
    }
}