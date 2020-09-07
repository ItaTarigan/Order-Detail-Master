using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class CustomerOrderProcessControls : ICustomerOrderProcessMasterData
    {
        public async Task<ordermastertbl> DetailData(int id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    //var IDS = id;
                    var data = await context.ordermastertbls
                                .Include(c => c.customertbl)
                                .Include(c => c.comoditytbl)
                                .Include(c => c.ordersampletbls)
                                .Where(x => x.orderNo == id.ToString())
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

        public async Task<IEnumerable<ordermastertbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.ordermastertbls
                                //.Include(c => c.sampletbl)
                                .Include(c => c.customertbl)
                                .Include(c => c.comoditytbl)

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

        public async Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.ordermastertbls
                                       where x.orderNo.Contains(param) ||
                                       x.status.Contains(param)
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