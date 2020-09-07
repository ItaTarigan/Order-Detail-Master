using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Security;

namespace BalitTanahPelayanan.Controllers
{
    public class RoleControls : IRoleMasterData
    {
        public async Task<bool> AddData(roletbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.roletbls.Add(obj);
                    await context.SaveChangesAsync();

                    Roles.CreateRole(obj.roleName);
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

        public async Task<bool> UpdateData(string id, roletbl obj)
        {
            try
            {
                if(id != obj.roleName)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.roletbls.Attach(obj);
                    context.Entry(obj).Property(x => x.description).IsModified = true;
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
                    var datas = from x in context.roletbls
                                where x.roleName == id
                                select x;
                    foreach (var item in datas)
                    {
                        context.roletbls.Remove(item);
                    }
                    await context.SaveChangesAsync();
                    Roles.DeleteRole(id);

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

        public async Task<IEnumerable<roletbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.roletbls.AsNoTracking().ToListAsync();
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

        public async Task<roletbl> DetailData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.roletbls
                        .Where(x => x.roleName == id)
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

        public async Task<IEnumerable<roletbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.roletbls
                                       where x.roleName.Contains(param)
                                       || x.description.Contains(param)
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