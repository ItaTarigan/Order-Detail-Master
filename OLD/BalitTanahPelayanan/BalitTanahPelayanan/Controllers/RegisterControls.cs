using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace BalitTanahPelayanan.Controllers
{
    public class RegisterControls : IRegisterFormData
    {
        public async Task<bool> AddData(accounttbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.accounttbls.Add(obj);
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

        public async Task<bool> AddData2(customertbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.customertbls.Add(obj);
                    await context.SaveChangesAsync();
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

        public string GetRole(string username)
        {

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = (from x in context.accounttbls
                                where x.username == username
                                select x.roleName).FirstOrDefault();
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

        public async Task<accounttbl> MasterData(string x)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.accounttbls.Where(c => c.username == x).FirstOrDefaultAsync();
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

        public async Task<bool> UpdateData(string id, accounttbl obj)
        {
            try
            {
                if (id != obj.username)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.accounttbls.Attach(obj);
                    context.Entry(obj).Property(x => x.accountNo).IsModified = true;
                    context.Entry(obj).Property(x => x.username).IsModified = true;
                    context.Entry(obj).Property(x => x.password).IsModified = true;
                    context.Entry(obj).Property(x => x.roleName).IsModified = true;
                    context.Entry(obj).Property(x => x.isEmailVerified).IsModified = true;


                    await context.SaveChangesAsync();

                    MembershipUser user = Membership.GetUser(obj.username);
                    if (user != null)
                    {
                        user.IsApproved = true;

                        user.UnlockUser();
                        Membership.UpdateUser(user);
                    }

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
    }
}