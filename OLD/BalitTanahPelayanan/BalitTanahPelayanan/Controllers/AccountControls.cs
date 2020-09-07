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
    public class AccountControls : IAccountMasterData
    {
        public async Task<bool> AddData(accounttbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var isExist = (from x in context.accounttbls
                                  where x.username == obj.username
                                  select x).SingleOrDefault();

                    if (isExist != null)
                    {
                        return false;
                    }

                    context.accounttbls.Add(obj);
                    await context.SaveChangesAsync();

                    Membership.CreateUser(obj.username, Crypto.Decrypt(obj.password), obj.username);
                    Roles.AddUserToRole(obj.username, obj.roleName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.InnerException.ToString();
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return false;
        }

        public async Task<bool> UpdateData(string id, accounttbl obj)
        {
            try
            {
                if(id != obj.accountNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.accounttbls.Attach(obj);
                    context.Entry(obj).Property(x => x.username).IsModified = true;
                    context.Entry(obj).Property(x => x.password).IsModified = true;
                    context.Entry(obj).Property(x => x.roleName).IsModified = true;
                    context.Entry(obj).Property(x => x.modBy).IsModified = true;
                    context.Entry(obj).Property(x => x.modDate).IsModified = true;
                    await context.SaveChangesAsync();

                    MembershipUser ms = Membership.GetUser(obj.username);
                    ms.ChangePassword(ms.ResetPassword(), Crypto.Decrypt(obj.password));

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.InnerException.ToString();
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
                    var name = (from x in context.accounttbls
                               where x.accountNo == no
                               select x.username).SingleOrDefault();

                    var datas = from x in context.accounttbls
                                where x.accountNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.accounttbls.Remove(item);
                    }
                    await context.SaveChangesAsync();

                    Membership.DeleteUser(name);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.InnerException.ToString();
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }
            return false;
        }

        public async Task<IEnumerable<accounttbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.accounttbls.AsNoTracking().ToListAsync();
                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.InnerException.ToString();
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return null;
        }

        public async Task<accounttbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.accounttbls
                        .Where(x => x.accountNo == no)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.InnerException.ToString();
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return null;
        }

        public async Task<IEnumerable<accounttbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.accounttbls
                                       where x.username.Contains(param)
                                       select x).AsNoTracking().ToListAsync();
                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.InnerException.ToString();
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return null;
        }

        public async Task<IEnumerable<accounttbl>> GetDataEmployee()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.accounttbls
                                       where x.roleName != "Pelanggan"
                                       select x).AsNoTracking().ToListAsync();
                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.InnerException.ToString();
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return null;
        }

        public async Task<IEnumerable<accounttbl>> GetDataCustomer()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.accounttbls
                                       where x.roleName == "Pelanggan"
                                       select x).AsNoTracking().ToListAsync();
                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.InnerException.ToString();
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return null;
        }
    }
}