using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Services
{
    public class CustomersServices
    {
        public async Task<bool> AddData(Customertbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Customertbl.Add(obj);
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

        public async Task<bool> UpdateData(string id, Customertbl obj)
        {
            try
            {
                if (id != obj.CustomerNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Customertbl.Attach(obj);
                    context.Entry(obj).Property(x => x.CustomerName).IsModified = true;
                    context.Entry(obj).Property(x => x.CustomerEmail).IsModified = true;
                    context.Entry(obj).Property(x => x.CompanyName).IsModified = true;
                    context.Entry(obj).Property(x => x.CompanyAddress).IsModified = true;
                    context.Entry(obj).Property(x => x.CompanyPhone).IsModified = true;
                    context.Entry(obj).Property(x => x.CompanyEmail).IsModified = true;
                    context.Entry(obj).Property(x => x.AccountNo).IsModified = true;
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
                    var emails = new HashSet<string>();
                    var datas = from x in context.Customertbl
                                where x.CustomerNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.Customertbl.Remove(item);
                        emails.Add(item.CustomerEmail);
                        //Membership.DeleteUser(item.customerEmail);
                    }
                    var dataAcc = (from x in context.Accounttbl
                                   where emails.Contains(x.Username)
                                   select x).ToList();
                    foreach (var item in dataAcc)
                    {
                        context.Accounttbl.Remove(item);
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

        public async Task<IEnumerable<Customertbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Customertbl.AsNoTracking().ToListAsync();
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

        public async Task<Customertbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Customertbl
                        .Where(x => x.CustomerNo == no)
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

        public async Task<IEnumerable<Customertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Customertbl
                                       where x.CustomerName.Contains(param)
                                       || x.CustomerEmail.Contains(param)
                                       || x.CompanyName.Contains(param)
                                       || x.CompanyEmail.Contains(param)
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
                    var data = (from x in contex.Customertbl
                                where x.CustomerEmail == email
                                select x.CustomerName).AsNoTracking().SingleOrDefault();

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
