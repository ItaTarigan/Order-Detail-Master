using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace BalitTanahPelayanan.Services
{
    public class OrderDetailService
    {
        public async Task<bool> AddData(Orderanalysisdetailtbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Orderanalysisdetailtbl.Add(obj);
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
                    var datas = from x in context.Orderanalysisdetailtbl
                                where x.OrderNo == id
                                select x;
                    foreach (var item in datas)
                    {
                        context.Orderanalysisdetailtbl.Remove(item);
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

        public async Task<bool> UpdateData(string id, Orderanalysisdetailtbl obj)
        {
            try
            {
                if (id != obj.OrderDetailNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Orderanalysisdetailtbl.Attach(obj);
                    context.Entry(obj).Property(x => x.Status).IsModified = true;
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

        public async Task<IEnumerable<Orderanalysisdetailtbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Orderanalysisdetailtbl
                        .Include(c => c.PicNavigation)
                        .Include(c => c.OrderNoNavigation)
                        .Include(c => c.Element)
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

        public async Task<Orderanalysisdetailtbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Orderanalysisdetailtbl
                        .Where(x => x.OrderDetailNo == no)
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

        public async Task<IEnumerable<Orderanalysisdetailtbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Orderanalysisdetailtbl
                                       where x.OrderNo.ToString().Contains(param)
                                       || x.ParametersNo.ToString().Contains(param)
                                       select x).AsNoTracking().ToListAsync();
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

        public async Task<List<string>> GetAllElementCode(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await (from x in context.Orderanalysisdetailtbl
                                      where x.OrderNo == id
                                      select x.SampleNo).SingleOrDefaultAsync();

                    var listdata = await (from x in context.Orderanalysisdetailtbl
                                          where x.SampleNo == data
                                          select x.ElementId.ToString()).ToListAsync();

                    return listdata;
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