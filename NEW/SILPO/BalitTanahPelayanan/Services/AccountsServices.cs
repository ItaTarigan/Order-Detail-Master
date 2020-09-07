using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Services
{
    public class AccountsServices
    {
        public async Task<bool> AddData(Accounttbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var isExist = (from x in context.Accounttbl
                                   where x.Username == obj.Username
                                   select x).SingleOrDefault();

                    if (isExist != null)
                    {
                        return false;
                    }

                    context.Accounttbl.Add(obj);
                    await context.SaveChangesAsync();


                    /*Membership.CreateUser(obj.Username, Crypto.Decrypt(obj.Password), obj.Username);
                    Roles.AddUserToRole(obj.Username, obj.RoleName);*/

                    /*Crypto.Decrypt(obj.Password);*/

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

        public async Task<bool> UpdateData(string id, Accounttbl obj)
        {
            try
            {
                if (id != obj.AccountNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Accounttbl.Attach(obj);
                    context.Entry(obj).Property(x => x.Username).IsModified = true;
                    context.Entry(obj).Property(x => x.Password).IsModified = true;
                    context.Entry(obj).Property(x => x.RoleName).IsModified = true;
                    context.Entry(obj).Property(x => x.ModBy).IsModified = true;
                    context.Entry(obj).Property(x => x.ModDate).IsModified = true;
                    await context.SaveChangesAsync();

                    /*MembershipUser ms = Membership.GetUser(obj.Username);
                    ms.ChangePassword(ms.ResetPassword(), Crypto.Decrypt(obj.Password));*/
                   /* Crypto.Decrypt(obj.Password);*/

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
                    var name = (from x in context.Accounttbl
                                where x.AccountNo == no
                                select x.Username).SingleOrDefault();

                    var datas = from x in context.Accounttbl
                                where x.AccountNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.Accounttbl.Remove(item);
                    }
                    await context.SaveChangesAsync();

                    /*Membership.DeleteUser(name);*/
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

        public async Task<IEnumerable<Accounttbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Accounttbl.AsNoTracking().ToListAsync();
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

        public async Task<Accounttbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Accounttbl
                        .Where(x => x.AccountNo == no)
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

        public async Task<IEnumerable<Accounttbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Accounttbl
                                       where x.Username.Contains(param)
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

        public async Task<IEnumerable<Accounttbl>> GetDataEmployee()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Accounttbl
                                       where x.RoleName != "Pelanggan"
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

        public async Task<IEnumerable<Accounttbl>> GetDataCustomer()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Accounttbl
                                       where x.RoleName == "Pelanggan"
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
