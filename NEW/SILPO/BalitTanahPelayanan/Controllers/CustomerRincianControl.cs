using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class CustomerRincianControl : ICustomerRincianMasterData
    {
        public async Task<Ordermastertbl> DetailDataCustomer(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    //var IDS = id;
                    var data = await context.Ordermastertbl
                                .Where(x => x.OrderNo == id)
                                .Include(c => c.CustomerNoNavigation)
                                .Include(c => c.ComodityNoNavigation)
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
        public async Task<Ordersampletbl> DetailData(int id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    //var IDS = id;
                    var data = await context.Ordersampletbl
                                .Where(x => x.NoBalittanah == id.ToString())
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

        public async Task<IEnumerable<Ordersampletbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.Ordersampletbl
                                .Include(c => c.NoBalittanah.ToString())
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

        public async Task<IEnumerable<Ordersampletbl>> GetDataSelesai()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    
                    var datas = await context.Ordersampletbl
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

        public async Task<IEnumerable<Ordersampletbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Ordersampletbl
                                       where x.OrderNo.Contains(param) ||
                                       x.IsReceived.Contains(param)
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

        public async Task<Ordersampletbl> MasterData(string x)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Ordersampletbl                                
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

        public async Task<Orderanalysisdetailtbl> GetDetailOrder(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Orderanalysisdetailtbl
                        .Where(x => x.OrderNo == id)
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
                    foreach (var line in context.Ordermastertbl.GroupBy(info => info.Pic)
                        .Select(group => new { pics = group.Key, counts = group.Count() }).OrderBy(x => x.pics))
                    {
                        int idpic = Convert.ToInt32(line.pics.ToString());
                        using (var ctx = new smlpobDB())
                        {
                            var datas = (from x in ctx.Employeetbl
                                         where x.EmployeeNo == idpic
                                         select x.EmployeeName).First();
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