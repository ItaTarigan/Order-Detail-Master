using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Data
{
    public class OrderSampleControls : IOrderSampleMasterData
    {
        public async Task<IEnumerable<Ordersampletbl>> GetDataAsync(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Ordersampletbl
                                       where x.OrderNo.Contains(id)
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

        public static  IEnumerable<Ordersampletbl> GetDataByStatus(string Status,string Lab="")
        {
            try
            {
                using (var db = new smlpobDB())
                {
                    var datas = new List<Ordersampletbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = db.Ordersampletbl.Include(c => c.OrderNoNavigation).Where(x => x.OrderNoNavigation.Status == Status && x.OrderNoNavigation.AnalysisType==Lab)
                            .AsNoTracking()
                            .ToList();
                    }
                    else
                    {
                        datas = db.Ordersampletbl.Include(c => c.OrderNoNavigation).Where(x => x.OrderNoNavigation.Status == Status)
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