using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Ordermastertbl> DetailData(int id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    //var IDS = id;
                    string di = id.ToString();
                    var data = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)
                                .Where(x => x.OrderNo == di)
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
                        datas = await context.Ordermastertbl
                                .Where(x=>x.AnalysisType == Lab)
                               .Include(c => c.ComodityNoNavigation)
                               .Include(c => c.CustomerNoNavigation)
                               .GroupBy(l => l.CustomerNoNavigation.CustomerName)
                               .Select(cl => new customerBySample
                               {
                                   customerNo = cl.FirstOrDefault().CustomerNo,
                                   customerName = cl.FirstOrDefault().CustomerNoNavigation.CustomerName,
                                   analysisType = cl.FirstOrDefault().AnalysisType,
                                   sampleTotal = cl.Sum(c => c.SampleTotal),
                               }).ToListAsync();
                    }
                    else
                    {
                        datas = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)
                                .GroupBy(l => l.CustomerNoNavigation.CustomerName)
                                .Select(cl => new customerBySample
                                {
                                    customerNo = cl.FirstOrDefault().CustomerNo,
                                    customerName = cl.FirstOrDefault().CustomerNoNavigation.CustomerName,
                                    analysisType = cl.FirstOrDefault().AnalysisType,
                                    sampleTotal = cl.Sum(c => c.SampleTotal),
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
        public async Task<IEnumerable<Ordermastertbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)
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
        public async Task<IEnumerable<Ordermastertbl>> GetDataByOrderNoAndStatus(string OrderNo, params string[] States)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    HashSet<string> Statuses = new HashSet<string>();
                    States.ToList().ForEach(x => Statuses.Add(x));
                    var datas = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)
                                .Where(x => Statuses.Contains(x.Status) && x.OrderNo.Contains(OrderNo))
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
        public async Task<IEnumerable<Ordermastertbl>> GetDataByStatus(string[] States,string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<Ordermastertbl>();
                    HashSet<string> Statuses = new HashSet<string>();
                    States.ToList().ForEach(x => Statuses.Add(x));
                    if (!string.IsNullOrEmpty(Lab)){
                        datas = await context.Ordermastertbl
                               .Include(c => c.ComodityNoNavigation)
                               .Include(c => c.CustomerNoNavigation)
                               .Where(x => Statuses.Contains(x.Status) && x.AnalysisType == Lab)
                               .AsNoTracking()
                               .ToListAsync();
                    }
                    else
                    {
                        datas = await context.Ordermastertbl
                               .Include(c => c.ComodityNoNavigation)
                               .Include(c => c.CustomerNoNavigation)
                               .Where(x => Statuses.Contains(x.Status))
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
        public async Task<IEnumerable<Ordermastertbl>> GetDataBaru()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)
                                .Where(x => x.Status == "Pesanan Baru")
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

        public async Task<IEnumerable<Ordermastertbl>> GetDataProses(string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<Ordermastertbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)
                                .Where(x => x.Status == "Diproses" && x.AnalysisType == Lab)
                                .AsNoTracking()
                                .ToListAsync();
                    }
                    else
                    {
                         datas = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)
                                .Where(x => x.Status == "Diproses")
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

        public async Task<IEnumerable<Ordermastertbl>> GetDataSelesai(string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<Ordermastertbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = await context.Ordermastertbl
                               .Include(c => c.ComodityNoNavigation)
                               .Include(c => c.CustomerNoNavigation)
                               .Where(x => x.Status == "Selesai" && x.AnalysisType == Lab)
                               .AsNoTracking()
                               .ToListAsync();
                    }
                    else
                    {
                        datas = await context.Ordermastertbl
                               .Include(c => c.ComodityNoNavigation)
                               .Include(c => c.CustomerNoNavigation)
                               .Where(x => x.Status == "Selesai")
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
        public async Task<IEnumerable<Ordermastertbl>> GetDataByCustNo(int customerNo,string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<Ordermastertbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = await (from x in context.Ordermastertbl
                                       where x.CustomerNo == customerNo && x.AnalysisType == Lab
                                       select x).AsNoTracking().ToListAsync();
                    }
                    else
                    {
                        datas = await (from x in context.Ordermastertbl
                                       where x.CustomerNo == customerNo
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
        public async Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Ordermastertbl
                                       where x.OrderNo.Contains(param) ||
                                       x.Status.Contains(param)
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