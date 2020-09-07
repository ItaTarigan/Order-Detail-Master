using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class StandardDetailControls : IStandardDetailMasterData
    {
        public async Task<bool> AddData(Standarddetailtbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var isExsist = (from x in context.Standarddetailtbl
                                    where x.ElementId == obj.ElementId
                                    && x.StdId == obj.StdId
                                    select x).SingleOrDefault();

                    if (isExsist != null)
                    {
                        return false;
                    }

                    context.Standarddetailtbl.Add(obj);
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

        public async Task<bool> UpdateData(string id, Standarddetailtbl obj)
        {
            try
            {
                if(id != obj.StdId.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    var isExsist = (from x in context.Standarddetailtbl
                                    where x.ElementId == obj.ElementId
                                    && x.StdId == obj.StdId
                                    select x).SingleOrDefault();

                    if (isExsist != null)
                    {
                        return false;
                    }

                    context.Standarddetailtbl.Attach(obj);
                    context.Entry(obj).Property(x => x.StdId).IsModified = true;
                    context.Entry(obj).Property(x => x.ElementId).IsModified = true;
                    context.Entry(obj).Property(x => x.ModBy).IsModified = true;
                    context.Entry(obj).Property(x => x.ModDate).IsModified = true;
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
                    var datas = from x in context.Standarddetailtbl
                                where x.StdDetailId == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.Standarddetailtbl.Remove(item);
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

        public async Task<IEnumerable<Standarddetailtbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Standarddetailtbl.ToListAsync();
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

        public async Task<Standarddetailtbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Standarddetailtbl
                        .Where(x => x.StdId == no)
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

        public async Task<IEnumerable<Standarddetailtbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Standarddetailtbl
                                       where x.ElementId.ToString().Contains(param)
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


        public async Task<IEnumerable<Standardtbl>> GetStandardData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Standardtbl.Include("comoditytbl")
                                       where x.ComodityNo != null
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