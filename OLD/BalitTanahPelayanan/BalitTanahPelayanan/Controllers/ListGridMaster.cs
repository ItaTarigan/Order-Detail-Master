using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class customerBySample
    {
        
        public int customerNo { get; set; }
        public string customerName { get; set; }
        public string analysisType { get; set; }
        public int? sampleTotal { get; set; }
    }
    public class ListGridMaster : IOrderMasterData
    {
        public async Task<ordermastertbl> DetailData(int id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    //var IDS = id;
                    string di = id.ToString();
                    var data = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
                                .Where(x => x.orderNo == di)
                                //.Include(c => c.)
                                //.Include(c => c.)
                                //.Include(c => c.sampleNo)
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
        public async Task<IEnumerable<customerBySample>> GetDataGroupByCustomer(string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<customerBySample>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = await context.ordermastertbls
                                .Where(x=>x.analysisType == Lab)
                               .Include(c => c.comoditytbl)
                               .Include(c => c.customertbl)
                               .GroupBy(l => l.customertbl.customerName)
                               .Select(cl => new customerBySample
                               {
                                   customerNo = cl.FirstOrDefault().customerNo,
                                   customerName = cl.FirstOrDefault().customertbl.customerName,
                                   analysisType = cl.FirstOrDefault().analysisType,
                                   sampleTotal = cl.Sum(c => c.sampleTotal),
                               }).ToListAsync();
                    }
                    else
                    {
                        datas = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
                                .GroupBy(l => l.customertbl.customerName)
                                .Select(cl => new customerBySample
                                {
                                    customerNo = cl.FirstOrDefault().customerNo,
                                    customerName = cl.FirstOrDefault().customertbl.customerName,
                                    analysisType = cl.FirstOrDefault().analysisType,
                                    sampleTotal = cl.Sum(c => c.sampleTotal),
                                }).ToListAsync();
                    }
                        
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
        public async Task<IEnumerable<ordermastertbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
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
        public async Task<IEnumerable<ordermastertbl>> GetDataByOrderNoAndStatus(string OrderNo, params string[] States)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    HashSet<string> Statuses = new HashSet<string>();
                    States.ToList().ForEach(x => Statuses.Add(x));
                    var datas = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
                                .Where(x => Statuses.Contains(x.status) && x.orderNo.Contains(OrderNo))
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
        public async Task<IEnumerable<ordermastertbl>> GetDataByStatus(string[] States,string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<ordermastertbl>();
                    HashSet<string> Statuses = new HashSet<string>();
                    States.ToList().ForEach(x => Statuses.Add(x));
                    if (!string.IsNullOrEmpty(Lab)){
                        datas = await context.ordermastertbls
                               .Include(c => c.comoditytbl)
                               .Include(c => c.customertbl)
                               .Where(x => Statuses.Contains(x.status) && x.analysisType == Lab)
                               .AsNoTracking()
                               .ToListAsync();
                    }
                    else
                    {
                        datas = await context.ordermastertbls
                               .Include(c => c.comoditytbl)
                               .Include(c => c.customertbl)
                               .Where(x => Statuses.Contains(x.status))
                               .AsNoTracking()
                               .ToListAsync();
                    }
                   
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
        public async Task<IEnumerable<ordermastertbl>> GetDataBaru()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
                                .Where(x => x.status == "Pesanan Baru")
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

        public async Task<IEnumerable<ordermastertbl>> GetDataProses(string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<ordermastertbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
                                .Where(x => x.status == "Diproses" && x.analysisType == Lab)
                                .AsNoTracking()
                                .ToListAsync();
                    }
                    else
                    {
                         datas = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
                                .Where(x => x.status == "Diproses")
                                .AsNoTracking()
                                .ToListAsync();
                    }
                    
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

        public async Task<IEnumerable<ordermastertbl>> GetDataSelesai(string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<ordermastertbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = await context.ordermastertbls
                               .Include(c => c.comoditytbl)
                               .Include(c => c.customertbl)
                               .Where(x => x.status == "Selesai" && x.analysisType == Lab)
                               .AsNoTracking()
                               .ToListAsync();
                    }
                    else
                    {
                        datas = await context.ordermastertbls
                               .Include(c => c.comoditytbl)
                               .Include(c => c.customertbl)
                               .Where(x => x.status == "Selesai")
                               .AsNoTracking()
                               .ToListAsync();
                    }
                 
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
        public async Task<IEnumerable<ordermastertbl>> GetDataByCustNo(int customerNo,string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<ordermastertbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = await (from x in context.ordermastertbls
                                       where x.customerNo == customerNo && x.analysisType == Lab
                                       select x).AsNoTracking().ToListAsync();
                    }
                    else
                    {
                        datas = await (from x in context.ordermastertbls
                                       where x.customerNo == customerNo
                                       select x).AsNoTracking().ToListAsync();
                    }
                   
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
        public async Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.ordermastertbls
                                       where x.orderNo.Contains(param) ||
                                       x.status.Contains(param)
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
    }
}