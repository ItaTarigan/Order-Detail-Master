using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Security;

namespace BalitTanahPelayanan.Controllers
{
    public class RegisterControls : IRegisterFormData
    {
        public async Task<bool> AddData(Accounttbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Accounttbl.Add(obj);
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

        public async Task<bool> AddData2(Customertbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Customertbl.Add(obj);
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
                    var data = (from x in context.Accounttbl
                                where x.Username == username
                                select x.RoleName).FirstOrDefault();
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

        public async Task<Accounttbl> MasterData(string x)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Accounttbl.Where(c => c.Username == x).FirstOrDefaultAsync();
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

        public async Task<bool> UpdateData(string id, Accounttbl obj)
        {
            try
            {
                if (id != obj.Username)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Accounttbl.Attach(obj);
                    context.Entry(obj).Property(x => x.AccountNo).IsModified = true;
                    context.Entry(obj).Property(x => x.Username).IsModified = true;
                    context.Entry(obj).Property(x => x.Password).IsModified = true;
                    context.Entry(obj).Property(x => x.RoleName).IsModified = true;
                    context.Entry(obj).Property(x => x.IsEmailVerified).IsModified = true;


                    await context.SaveChangesAsync();
                    /*
                    MembershipUser user = Membership.GetUser(obj.username);
                    if (user != null)
                    {
                        user.IsApproved = true;

                        user.UnlockUser();
                        Membership.UpdateUser(user);
                    }*/

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