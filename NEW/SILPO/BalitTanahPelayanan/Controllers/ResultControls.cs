using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using Microsoft.EntityFrameworkCore;

namespace BalitTanahPelayanan.Controllers
{
    public class ResultControls : IResultMasterData
    {
        public async Task<IEnumerable<Resulttbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Resulttbl.ToListAsync();
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