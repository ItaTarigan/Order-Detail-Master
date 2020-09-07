using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class CustomerRincianControl : ICustomerRincianMasterData
    {
        public async Task<ordermastertbl> DetailDataCustomer(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    //var IDS = id;
                    var data = await context.ordermastertbls
                                .Where(x => x.orderNo == id)
                                .Include(c => c.customertbl)
                                .Include(c => c.comoditytbl)
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
        //Data for DGV
        public async Task<ordersampletbl> DetailData(int id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    //var IDS = id;
                    var data = await context.ordersampletbls
                                .Where(x => x.noBalittanah == id.ToString())
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

        public async Task<IEnumerable<ordersampletbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.ordersampletbls
                                .Include(c => c.noBalittanah.ToString())
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

        public async Task<IEnumerable<ordersampletbl>> GetDataSelesai()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    
                    var datas = await context.ordersampletbls
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

        public async Task<IEnumerable<ordersampletbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.ordersampletbls
                                       where x.orderNo.Contains(param) ||
                                       x.isReceived.Contains(param)
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

        public async Task<ordersampletbl> MasterData(string x)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.ordersampletbls                                
                    .Include(c => c)
                    
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

        public async Task<orderanalysisdetailtbl> GetDetailOrder(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.orderanalysisdetailtbls
                        .Where(x => x.orderNo == id)
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

        public List<getallorder> GetAllMasterOrder()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    List<getallorder> op = new List<getallorder>();
                    string empname = "";
                    foreach (var line in context.ordermastertbls.GroupBy(info => info.pic)
                        .Select(group => new { pics = group.Key, counts = group.Count() }).OrderBy(x => x.pics))
                    {
                        int idpic = Convert.ToInt32(line.pics.ToString());
                        using (var ctx = new smlpobDB())
                        {
                            var datas = (from x in ctx.employeetbls
                                         where x.employeeNo == idpic
                                         select x.employeeName).First();
                            empname = datas.ToString();
                        };
                        op.Add(new getallorder() { _pics = line.pics.ToString(), _empname = empname.ToString(), _count = line.counts.ToString() });
                    };
                    return op;
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

        public class getallorder
        {
            public string _pics { get; set; }
            public string _empname { get; set; }
            public string _count { get; set; }
        }
    }
}