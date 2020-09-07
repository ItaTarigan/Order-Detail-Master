using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BalitTanahPelayanan.Controllers
{
    public class ParameterControls : IParameterMasterData
    {
        public async Task<bool> AddData(Parameterstbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Parameterstbl.Add(obj);
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

        public async Task<bool> UpdateData(string id, Parameterstbl obj)
        {
            try
            {
                if (id != obj.ParametersNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Parameterstbl.Attach(obj);
                    context.Entry(obj).Property(x => x.String0).IsModified = true;
                    context.Entry(obj).Property(x => x.String1).IsModified = true;
                    context.Entry(obj).Property(x => x.String2).IsModified = true;
                    context.Entry(obj).Property(x => x.String3).IsModified = true;
                    context.Entry(obj).Property(x => x.String4).IsModified = true;
                    context.Entry(obj).Property(x => x.String5).IsModified = true;
                    context.Entry(obj).Property(x => x.String6).IsModified = true;
                    context.Entry(obj).Property(x => x.String7).IsModified = true;
                    context.Entry(obj).Property(x => x.String8).IsModified = true;
                    context.Entry(obj).Property(x => x.String9).IsModified = true;
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
                    var datas = from x in context.Parameterstbl
                                where x.ParametersNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.Parameterstbl.Remove(item);
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

        public async Task<IEnumerable<Parameterstbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Parameterstbl.AsNoTracking().ToListAsync();
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

        public async Task<Parameterstbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Parameterstbl
                        .Where(x => x.ParametersNo == no)
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

        public async Task<IEnumerable<Parameterstbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Parameterstbl
                                       where x.String0.Contains(param)
                                       || x.String1.Contains(param)
                                       || x.String2.Contains(param)
                                       || x.String3.Contains(param)
                                       || x.String4.Contains(param)
                                       || x.String5.Contains(param)
                                       || x.String6.Contains(param)
                                       || x.String7.Contains(param)
                                       || x.String8.Contains(param)
                                       || x.String9.Contains(param)
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