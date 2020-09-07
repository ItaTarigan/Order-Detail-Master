using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class DaftarSPControl : IDaftarSPMasterData
    {
        public async Task<bool> AddData(ordermastertbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.ordermastertbls.Add(obj);
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

        public async Task<bool> UpdateData(string id, ordermastertbl obj)
        {
            try
            {
                if (id != obj.orderNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    //context.Entry(obj).State = EntityState.Modified;
                    context.ordermastertbls.Attach(obj);
                    context.Entry(obj).Property(x => x.orderNo).IsModified = true;
                    context.Entry(obj).Property(x => x.customerNo).IsModified = true;
                    context.Entry(obj).Property(x => x.comodityNo).IsModified = true;
                    context.Entry(obj).Property(x => x.sampleTotal).IsModified = true;
                    context.Entry(obj).Property(x => x.priceTotal).IsModified = true;
                    context.Entry(obj).Property(x => x.status).IsModified = true;
                    context.Entry(obj).Property(x => x.paymentType).IsModified = true;
                    context.Entry(obj).Property(x => x.isPayed).IsModified = true;
                    context.Entry(obj).Property(x => x.isPayedDate).IsModified = true;
                    context.Entry(obj).Property(x => x.isAppr).IsModified = true;
                    context.Entry(obj).Property(x => x.pic).IsModified = true;
                    context.Entry(obj).Property(x => x.modBy).IsModified = true;
                    context.Entry(obj).Property(x => x.modDate).IsModified = true;
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

        public async Task<bool> DeleteData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.ordermastertbls
                                where x.orderNo == id
                                select x;
                    foreach (var item in datas)
                    {
                        context.ordermastertbls.Remove(item);
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

        public async Task<IEnumerable<ordermastertbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.ordermastertbls.ToListAsync();
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

        public async Task<ordermastertbl> DetailData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.ordermastertbls
                        .Where(x => x.orderNo == id)
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
        public async Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.ordermastertbls
                                       where x.orderNo.ToString().Contains(param)
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