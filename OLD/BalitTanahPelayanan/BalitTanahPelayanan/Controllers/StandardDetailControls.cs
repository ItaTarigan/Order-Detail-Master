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
    public class StandardDetailControls : IStandardDetailMasterData
    {
        public async Task<bool> AddData(standarddetailtbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var isExsist = (from x in context.standarddetailtbls
                                    where x.elementId == obj.elementId
                                    && x.stdId == obj.stdId
                                    select x).SingleOrDefault();

                    if (isExsist != null)
                    {
                        return false;
                    }

                    context.standarddetailtbls.Add(obj);
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

        public async Task<bool> UpdateData(string id, standarddetailtbl obj)
        {
            try
            {
                if(id != obj.stdId.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    var isExsist = (from x in context.standarddetailtbls
                                    where x.elementId == obj.elementId
                                    && x.stdId == obj.stdId
                                    select x).SingleOrDefault();

                    if (isExsist != null)
                    {
                        return false;
                    }

                    context.standarddetailtbls.Attach(obj);
                    context.Entry(obj).Property(x => x.stdId).IsModified = true;
                    context.Entry(obj).Property(x => x.elementId).IsModified = true;
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
            int no = 0;
            int.TryParse(id, out no);
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.standarddetailtbls
                                where x.stdDetailId == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.standarddetailtbls.Remove(item);
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

        public async Task<IEnumerable<standarddetailtbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.standarddetailtbls.ToListAsync();
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

        public async Task<standarddetailtbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.standarddetailtbls
                        .Where(x => x.stdId == no)
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

        public async Task<IEnumerable<standarddetailtbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.standarddetailtbls
                                       where x.elementId.ToString().Contains(param)
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


        public async Task<IEnumerable<standardtbl>> GetStandardData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.standardtbls.Include("comoditytbl")
                                       where x.comodityNo != null
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