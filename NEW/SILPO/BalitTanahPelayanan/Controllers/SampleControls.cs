using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BalitTanahPelayanan.Controllers
{
    public class SampleControls : ISampleMasterData
    {
        public async Task<bool> AddData(Ordersampletbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Ordersampletbl.Add(obj);
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

        public async Task<bool> UpdateData(string id, Ordersampletbl obj)
        {
            try
            {
                if (id != obj.NoBalittanah)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Ordersampletbl.Attach(obj);
                    context.Entry(obj).Property(x => x.OrderNo).IsModified = true;
                    context.Entry(obj).Property(x => x.SampleCode).IsModified = true;
                    context.Entry(obj).Property(x => x.CountNumber).IsModified = true;
                    context.Entry(obj).Property(x => x.SampleDescription).IsModified = true;
                    context.Entry(obj).Property(x => x.SamplingDate).IsModified = true;
                    context.Entry(obj).Property(x => x.Village).IsModified = true;
                    context.Entry(obj).Property(x => x.SubDistrict).IsModified = true;
                    context.Entry(obj).Property(x => x.District).IsModified = true;
                    context.Entry(obj).Property(x => x.Province).IsModified = true;
                    context.Entry(obj).Property(x => x.Longitude).IsModified = true;
                    context.Entry(obj).Property(x => x.Latitude).IsModified = true;
                    context.Entry(obj).Property(x => x.LandUse).IsModified = true;
                    context.Entry(obj).Property(x => x.IsReceived).IsModified = true;
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
                    var datas = from x in context.Ordersampletbl
                                where x.NoBalittanah == id
                                select x;
                    foreach (var item in datas)
                    {
                        context.Ordersampletbl.Remove(item);
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
        public async Task<IEnumerable<Ordersampletbl>> GetDataByOrderNo(string OrderNo)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Ordersampletbl.Where(x=>x.OrderNo == OrderNo).AsNoTracking().ToListAsync();
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
        public async Task<IEnumerable<Ordersampletbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Ordersampletbl.AsNoTracking().ToListAsync();
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

        public async Task<Ordersampletbl> DetailData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Ordersampletbl
                        .Where(x => x.NoBalittanah == id)
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

        public async Task<IEnumerable<Ordersampletbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Ordersampletbl
                                       where x.SampleCode.Contains(param)
                                       || x.SampleDescription.Contains(param)
                                       || x.Village.Contains(param)
                                       || x.SubDistrict.Contains(param)
                                       || x.District.Contains(param)
                                       || x.Province.Contains(param)
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