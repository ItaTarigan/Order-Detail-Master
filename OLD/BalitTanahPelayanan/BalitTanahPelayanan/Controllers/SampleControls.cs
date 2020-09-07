using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using System.Data.Entity;

namespace BalitTanahPelayanan.Controllers
{
    public class SampleControls : ISampleMasterData
    {
        public async Task<bool> AddData(ordersampletbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.ordersampletbls.Add(obj);
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

        public async Task<bool> UpdateData(string id, ordersampletbl obj)
        {
            try
            {
                if (id != obj.noBalittanah)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.ordersampletbls.Attach(obj);
                    context.Entry(obj).Property(x => x.orderNo).IsModified = true;
                    context.Entry(obj).Property(x => x.sampleCode).IsModified = true;
                    context.Entry(obj).Property(x => x.countNumber).IsModified = true;
                    context.Entry(obj).Property(x => x.sampleDescription).IsModified = true;
                    context.Entry(obj).Property(x => x.samplingDate).IsModified = true;
                    context.Entry(obj).Property(x => x.village).IsModified = true;
                    context.Entry(obj).Property(x => x.subDistrict).IsModified = true;
                    context.Entry(obj).Property(x => x.district).IsModified = true;
                    context.Entry(obj).Property(x => x.province).IsModified = true;
                    context.Entry(obj).Property(x => x.longitude).IsModified = true;
                    context.Entry(obj).Property(x => x.latitude).IsModified = true;
                    context.Entry(obj).Property(x => x.landUse).IsModified = true;
                    context.Entry(obj).Property(x => x.isReceived).IsModified = true;
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
                    var datas = from x in context.ordersampletbls
                                where x.noBalittanah == id
                                select x;
                    foreach (var item in datas)
                    {
                        context.ordersampletbls.Remove(item);
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
        public async Task<IEnumerable<ordersampletbl>> GetDataByOrderNo(string OrderNo)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.ordersampletbls.Where(x=>x.orderNo == OrderNo).AsNoTracking().ToListAsync();
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
        public async Task<IEnumerable<ordersampletbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.ordersampletbls.AsNoTracking().ToListAsync();
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

        public async Task<ordersampletbl> DetailData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.ordersampletbls
                        .Where(x => x.noBalittanah == id)
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

        public async Task<IEnumerable<ordersampletbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.ordersampletbls
                                       where x.sampleCode.Contains(param)
                                       || x.sampleDescription.Contains(param)
                                       || x.village.Contains(param)
                                       || x.subDistrict.Contains(param)
                                       || x.district.Contains(param)
                                       || x.province.Contains(param)
                                       select x)
                                       .AsNoTracking()
                                       .ToListAsync();
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