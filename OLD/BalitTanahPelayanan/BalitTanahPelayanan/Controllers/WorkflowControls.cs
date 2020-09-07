using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System.Data.Entity;

namespace BalitTanahPelayanan.Controllers
{
    public class WorkflowControls : IWorkflowMasterData
    {
        public async Task<IEnumerable<workflowlogtbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.workflowlogtbls.ToListAsync();
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