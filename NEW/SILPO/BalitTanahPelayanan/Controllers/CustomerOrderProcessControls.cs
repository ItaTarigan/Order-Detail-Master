using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class CustomerOrderProcessControls : ICustomerOrderProcessMasterData
    {
        public async Task<Ordermastertbl> DetailData(int id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    //var IDS = id;
                    var data = await context.Ordermastertbl
                                .Include(c => c.CustomerNoNavigation)
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.Ordersampletbl)
                                .Where(x => x.OrderNo == id.ToString())
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
                    return data;
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

        public async Task<IEnumerable<Ordermastertbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.Ordermastertbl
                                //.Include(c => c.sampletbl)
                                .Include(c => c.CustomerNoNavigation)
                                .Include(c => c.ComodityNoNavigation)

                                .ToListAsync();

                    //var datas = await context.sampletbls
                    //            //.Include(c => c.sampletbl.orderanalysisdetailtbls)
                    //            .Include(c => c.customertbl)
                    //            .Include(c => c.comoditytbl)
                    //            .Include(c => c.ordermastertbl)

                    //            .ToListAsync();

                    //var datas = await (from x in ordermastertbl
                    //                   join y in sampletbl
                    //                   on new {t1 })

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

        public async Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Ordermastertbl
                                       where x.OrderNo.Contains(param) ||
                                       x.Status.Contains(param)
                                       select x)
                                       .AsNoTracking()
                                       .ToListAsync();
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