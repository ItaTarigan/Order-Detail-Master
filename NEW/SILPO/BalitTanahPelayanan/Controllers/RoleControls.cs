using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
//using System.Web.Security;

namespace BalitTanahPelayanan.Controllers
{
    public class RoleControls : IRoleMasterData
    {
        public async Task<bool> AddData(Roletbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Roletbl.Add(obj);
                    await context.SaveChangesAsync();

                    //Roles.CreateRole(obj.roleName);
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

        public async Task<bool> UpdateData(string id, Roletbl obj)
        {
            try
            {
                if(id != obj.RoleName)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Roletbl.Attach(obj);
                    context.Entry(obj).Property(x => x.Description).IsModified = true;
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
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.Roletbl
                                where x.RoleName == id
                                select x;
                    foreach (var item in datas)
                    {
                        context.Roletbl.Remove(item);
                    }
                    await context.SaveChangesAsync();
                    //Roles.DeleteRole(id);

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

        public async Task<IEnumerable<Roletbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Roletbl.AsNoTracking().ToListAsync();
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

        public async Task<Roletbl> DetailData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Roletbl
                        .Where(x => x.RoleName == id)
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

        public async Task<IEnumerable<Roletbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Roletbl
                                       where x.RoleName.Contains(param)
                                       || x.Description.Contains(param)
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