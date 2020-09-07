using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{

    public class ManagerTeknisControls : IManagerTeknisSelesaiMasterData
    {
        public async Task<IEnumerable<Ordermastertbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                //.Include(c => c.)
                                //.Include(c => c.)
                                //.Include(c => c.sampleNo)
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

        public async Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Ordermastertbl
                                       where x.OrderNo.Contains(param)
                                       select x).AsNoTracking().ToListAsync();
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

        public async Task<Ordermastertbl> GetDataFile(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await (from x in context.Ordermastertbl
                                      where x.OrderNo == id
                                      select x).SingleOrDefaultAsync();
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
    }
    
}