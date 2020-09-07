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
    public class OrderDetailControls : IOrderDetailMasterData
    {
        public async Task<bool> AddData(orderanalysisdetailtbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.orderanalysisdetailtbls.Add(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return false;
        }

        public async Task<bool> DeleteData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.orderanalysisdetailtbls
                                where x.orderNo == id
                                select x;
                    foreach (var item in datas)
                    {
                        context.orderanalysisdetailtbls.Remove(item);
                    }
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }
            return false;
        }

        public async Task<bool> UpdateData(string id, orderanalysisdetailtbl obj)
        {
            try
            {
                if (id != obj.orderDetailNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.orderanalysisdetailtbls.Attach(obj);
                    context.Entry(obj).Property(x => x.status).IsModified = true;
                    await context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return false;
        }

        public async Task<IEnumerable<orderanalysisdetailtbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.orderanalysisdetailtbls
                        .Include(c => c.employeetbl)
                        .Include(c => c.ordermastertbl)
                        .Include(c => c.elementservicestbl)
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

        public async Task<orderanalysisdetailtbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.orderanalysisdetailtbls
                        .Where(x => x.orderDetailNo == no)
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

        public async Task<IEnumerable<orderanalysisdetailtbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.orderanalysisdetailtbls
                                       where x.orderNo.ToString().Contains(param)
                                       || x.parametersNo.ToString().Contains(param)
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

        public async Task<List<string>> GetAllElementCode(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await (from x in context.orderanalysisdetailtbls
                                       where x.orderNo == id
                                       select x.sampleNo).SingleOrDefaultAsync();

                    var listdata = await (from x in context.orderanalysisdetailtbls
                                          where x.sampleNo == data
                                          select x.elementId.ToString()).ToListAsync();

                    return listdata;
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