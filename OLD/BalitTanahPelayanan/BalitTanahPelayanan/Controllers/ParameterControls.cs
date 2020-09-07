using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using System.Data.Entity;

namespace BalitTanahPelayanan.Controllers
{
    public class ParameterControls : IParameterMasterData
    {
        public async Task<bool> AddData(parameterstbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.parameterstbls.Add(obj);
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

        public async Task<bool> UpdateData(string id, parameterstbl obj)
        {
            try
            {
                if (id != obj.parametersNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.parameterstbls.Attach(obj);
                    context.Entry(obj).Property(x => x.string0).IsModified = true;
                    context.Entry(obj).Property(x => x.string1).IsModified = true;
                    context.Entry(obj).Property(x => x.string2).IsModified = true;
                    context.Entry(obj).Property(x => x.string3).IsModified = true;
                    context.Entry(obj).Property(x => x.string4).IsModified = true;
                    context.Entry(obj).Property(x => x.string5).IsModified = true;
                    context.Entry(obj).Property(x => x.string6).IsModified = true;
                    context.Entry(obj).Property(x => x.string7).IsModified = true;
                    context.Entry(obj).Property(x => x.string8).IsModified = true;
                    context.Entry(obj).Property(x => x.string9).IsModified = true;
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
                    var datas = from x in context.parameterstbls
                                where x.parametersNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.parameterstbls.Remove(item);
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

        public async Task<IEnumerable<parameterstbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.parameterstbls.AsNoTracking().ToListAsync();
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

        public async Task<parameterstbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.parameterstbls
                        .Where(x => x.parametersNo == no)
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

        public async Task<IEnumerable<parameterstbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.parameterstbls
                                       where x.string0.Contains(param)
                                       || x.string1.Contains(param)
                                       || x.string2.Contains(param)
                                       || x.string3.Contains(param)
                                       || x.string4.Contains(param)
                                       || x.string5.Contains(param)
                                       || x.string6.Contains(param)
                                       || x.string7.Contains(param)
                                       || x.string8.Contains(param)
                                       || x.string9.Contains(param)
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