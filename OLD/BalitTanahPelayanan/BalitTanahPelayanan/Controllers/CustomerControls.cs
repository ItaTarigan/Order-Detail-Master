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
    public class CustomerControls : ICustomerMasterData
    {
        public async Task<bool> AddData(customertbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.customertbls.Add(obj);
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

        public async Task<bool> UpdateData(string id, customertbl obj)
        {
            try
            {
                if(id != obj.customerNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.customertbls.Attach(obj);
                    context.Entry(obj).Property(x => x.customerName).IsModified = true;
                    context.Entry(obj).Property(x => x.customerEmail).IsModified = true;
                    context.Entry(obj).Property(x => x.companyName).IsModified = true;
                    context.Entry(obj).Property(x => x.companyAddress).IsModified = true;
                    context.Entry(obj).Property(x => x.companyPhone).IsModified = true;
                    context.Entry(obj).Property(x => x.companyEmail).IsModified = true;
                    context.Entry(obj).Property(x => x.accountNo).IsModified = true;
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
                    var emails = new HashSet<string>();
                    var datas = from x in context.customertbls
                                where x.customerNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.customertbls.Remove(item);
                        emails.Add(item.customerEmail);
                        Membership.DeleteUser(item.customerEmail);
                    }
                    var dataAcc = (from x in context.accounttbls
                                   where emails.Contains(x.username)
                                   select x).ToList();
                    foreach (var item in dataAcc)
                    {
                        context.accounttbls.Remove(item);
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

        public async Task<IEnumerable<customertbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.customertbls.AsNoTracking().ToListAsync();
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

        public async Task<customertbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.customertbls
                        .Where(x => x.customerNo == no)
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

        public async Task<IEnumerable<customertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.customertbls
                                       where x.customerName.Contains(param)
                                       || x.customerEmail.Contains(param)
                                       || x.companyName.Contains(param)
                                       || x.companyEmail.Contains(param)
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

        public string GetCurrentUser(string email)
        {
            try
            {
                using (var contex = new smlpobDB())
                {
                    var data = (from x in contex.customertbls
                               where x.customerEmail == email
                               select x.customerName).AsNoTracking().SingleOrDefault();

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
    }
}