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
    public class ElementServicesControls : IElementServicesMasterData
    {
        public async Task<bool> AddData(elementservicestbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.elementservicestbls.Add(obj);
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

        public async Task<bool> UpdateData(string id, elementservicestbl obj)
        {
            try
            {
                if(id != obj.elementCode)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.elementservicestbls.Attach(obj);
                    context.Entry(obj).Property(x => x.analysisTypeName).IsModified = true;
                    context.Entry(obj).Property(x => x.serviceGroup).IsModified = true;
                    context.Entry(obj).Property(x => x.serviceRate).IsModified = true;
                    context.Entry(obj).Property(x => x.serviceStatus).IsModified = true;
                    context.Entry(obj).Property(x => x.modBy).IsModified = true;
                    context.Entry(obj).Property(x => x.modDate).IsModified = true;
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
                    var datas = from x in context.elementservicestbls
                                where x.elementCode == id
                                select x;
                    foreach (var item in datas)
                    {
                        context.elementservicestbls.Remove(item);
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

        public async Task<IEnumerable<elementservicestbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.elementservicestbls.ToListAsync();
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

        public async Task<elementservicestbl> DetailData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.elementservicestbls
                        .Where(x => x.elementCode == id)
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

        public async Task<IEnumerable<elementservicestbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.elementservicestbls
                                       where x.elementCode.Contains(param)
                                       || x.serviceGroup.Contains(param)
                                       || x.serviceStatus.Contains(param)
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
    }
}