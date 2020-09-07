using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class OrderListControls : IOrderListMasterData
    {
        public async Task<IEnumerable<Ordermastertbl>> GetDataByStatus(params string[] States)
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
                                .Where(x => Statuses.Contains(x.Status))
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
        public async Task<Ordermastertbl> DetailData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    //var IDS = id;
                    var data = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)   
                                .Where(x => x.OrderNo == id)
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

        public async Task<IEnumerable<Comoditytbl>> GetKomoditasName()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    
                    var datas = await context.Comoditytbl
                                .OrderBy(x=>x.ComodityName)
                                .ToListAsync();
                    //datas.Insert(0,new comoditytbl() { comodityNo= -1, comodityName="-- All --" });
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
        //
        public async Task<IEnumerable<Ordermastertbl>> GetDataByCreatedByAndComodity(string UserName,int commodityNo)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var uname = UserName;
                    var datas = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)
                                .Include(c => c.CustomerNoNavigation.AccountNoNavigation)
                                .Include(c => c.Orderanalysisdetailtbl)
                                .Where(c => c.CreaBy == uname && c.ComodityNo == commodityNo)
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
        public async Task<IEnumerable<Ordermastertbl>> GetDataByCreatedBy(string UserName)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var uname = UserName;
                    var datas = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)
                                .Include(c => c.CustomerNoNavigation.AccountNoNavigation)
                                .Include(c => c.Orderanalysisdetailtbl)
                                .Where(c => c.CreaBy == uname)
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
        public async Task<IEnumerable<Ordermastertbl>> GetDataByPenyelia()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.Ordermastertbl
                                .Include(c => c.ComodityNoNavigation)
                                .Include(c => c.CustomerNoNavigation)
                                .Include(c => c.Orderanalysisdetailtbl)
                                .Where(c => c.Status == "Hitung ulang" || c.Status == "Verifikasi Penyelia" || c.Status == "Kaji Ulang" || c.Status == "Evaluasi Hasil" || c.Status == "Proses Lab")

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
        public async Task<IEnumerable<Ordermastertbl>> GetData(string Lab="")
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
                               .Include(c => c.Orderanalysisdetailtbl)
                               .Where(c => (c.Status == "Hitung ulang" || c.Status == "Verifikasi Penyelia" || c.Status == "Kaji Ulang" || c.Status == "Evaluasi Hasil" || c.Status == "Proses Lab") && c.AnalysisType == Lab)
                               //.Include(c => c.)
                               //.Include(c => c.)
                               //.Include(c => c.sampleNo)
                               .ToListAsync();
                    }
                    else
                    {
                        datas = await context.Ordermastertbl
                               .Include(c => c.ComodityNoNavigation)
                               .Include(c => c.CustomerNoNavigation)
                               .Include(c => c.Orderanalysisdetailtbl)
                               .Where(c => c.Status == "Hitung ulang" || c.Status == "Verifikasi Penyelia" || c.Status == "Kaji Ulang" || c.Status == "Evaluasi Hasil" || c.Status == "Proses Lab")
                               //.Include(c => c.)
                               //.Include(c => c.)
                               //.Include(c => c.sampleNo)
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
        public async Task<IEnumerable<Ordermastertbl>> GetDataPenyelia(string Lab = "")
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
                               .Include(c => c.Orderanalysisdetailtbl)
                               .Where(c => (c.Status == "Hitung ulang" || c.Status == "Verifikasi Penyelia" || c.Status == "Kaji Ulang" || c.Status == "Proses Lab") && c.AnalysisType == Lab)
                               //.Include(c => c.)
                               //.Include(c => c.)
                               //.Include(c => c.sampleNo)
                               .ToListAsync();
                    }
                    else
                    {
                        datas = await context.Ordermastertbl
                               .Include(c => c.ComodityNoNavigation)
                               .Include(c => c.CustomerNoNavigation)
                               .Include(c => c.Orderanalysisdetailtbl)
                               .Where(c => c.Status == "Hitung ulang" || c.Status == "Verifikasi Penyelia" || c.Status == "Kaji Ulang" || c.Status == "Proses Lab")
                               //.Include(c => c.)
                               //.Include(c => c.)
                               //.Include(c => c.sampleNo)
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
        public async Task<IEnumerable<Batchtbl>> GetBatchDataByPIC(int AnalisEmpNo,string Status = "Proses")
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.Batchtbl.Include(c => c.PicAnalisNavigation).Where(x=>x.PicAnalis == AnalisEmpNo && x.Status==Status)
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
        public async Task<IEnumerable<Batchtbl>> GetBatchData()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.Batchtbl.Include(c=>c.PicAnalisNavigation)
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
                               .Include(c => c.ComodityNo)
                               .Include(c => c.CustomerNoNavigation)
                               .Include(c => c.Orderanalysisdetailtbl)
                               .Where(x => (x.Status == "LHP Keluar" || x.Status == "LHP Sudah Diambil") && x.AnalysisType == Lab)
                               .ToListAsync();
                    }
                    else
                    {
                        datas = await context.Ordermastertbl
                               .Include(c => c.ComodityNo)
                               .Include(c => c.CustomerNoNavigation)
                               .Include(c => c.Orderanalysisdetailtbl)
                               .Where(x => x.Status == "LHP Keluar" || x.Status == "LHP Sudah Diambil")
                               //.Include(c => c.)
                               //.Include(c => c.)
                               //.Include(c => c.sampleNo)
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

        public async Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Ordermastertbl
                                       where x.OrderNo.Contains(param)
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

        public async Task<Ordermastertbl> MasterData(string orderNo)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Ordermastertbl
                                .Include(c => c.ComodityNo)
                                .Include(c => c.CustomerNoNavigation)
                                .Include(c => c.Orderanalysisdetailtbl)
                                .Where(c => c.OrderNo == orderNo).FirstOrDefaultAsync();
                    //.Include(c => c)
                    //.Where(x => x.)
                    //.Include(c => c.)
                    //.Include(c => c.)
                    //.Include(c => c.sampleNo)
                    //.FirstOrDefaultAsync();
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

        //public async Task<Ordermastertbl> DetailNoOrder(string param)
        //{
        //    try
        //    {
        //        using (var context = new smlpobDB())
        //        {

        //            var data = await (from x in context.Ordermastertbl where x.orderNo == param select x)
        //                        .Include(a => a.customertbl)
        //                        .Include(b => b.sampletbls)
        //                        .Include(c => c.)
        //                        .Include(b => b.orderanalysisdetailtbls).FirstOrDefaultAsync();
        //            return data;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelpers.source = this.GetType().Name;
        //        LogHelpers.message = ex.Message;
        //        LogHelpers.user = "";
        //        LogHelpers.WriteLog();
        //    }

        //    return null;
        //}

        public async Task<IEnumerable<Orderanalysisdetailtbl>> GetDetailOrder(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Orderanalysisdetailtbl
                        .Where(x => x.OrderNo == id)
                        .ToListAsync();
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

        public async Task<bool> UpdateData(string id, Ordermastertbl obj)
        {
            try
            {
                if (id != obj.OrderNo)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Ordermastertbl.Attach(obj);
                    context.Entry(obj).Property(x => x.OrderNo).IsModified = true;
                    context.Entry(obj).Property(x => x.CustomerNo).IsModified = true;
                    context.Entry(obj).Property(x => x.ComodityNo).IsModified = true;
                    context.Entry(obj).Property(x => x.AnalysisType).IsModified = true;
                    context.Entry(obj).Property(x => x.SampleTotal).IsModified = true;
                    context.Entry(obj).Property(x => x.PriceTotal).IsModified = true;
                    context.Entry(obj).Property(x => x.StatusType).IsModified = true;
                    context.Entry(obj).Property(x => x.Status).IsModified = true;
                    context.Entry(obj).Property(x => x.PaymentStatus).IsModified = true;
                    context.Entry(obj).Property(x => x.Ppn).IsModified = true;
                    //context.Entry(obj).Property(x => x.payment).IsModified = true;
                    context.Entry(obj).Property(x => x.ReceiptDate).IsModified = true;
                    context.Entry(obj).Property(x => x.IsPaid).IsModified = true;
                    context.Entry(obj).Property(x => x.PaymentDate).IsModified = true;
                    context.Entry(obj).Property(x => x.Pic).IsModified = true;
                    context.Entry(obj).Property(x => x.IsOnLab).IsModified = true;
                    context.Entry(obj).Property(x => x.ApprPenyelia).IsModified = true;
                    context.Entry(obj).Property(x => x.ApprEvaluator).IsModified = true;
                    context.Entry(obj).Property(x => x.ApprManagerTeknis).IsModified = true;
                    context.Entry(obj).Property(x => x.LhpattachmentUrl).IsModified = true;
                    context.Entry(obj).Property(x => x.LhpfileName).IsModified = true;
                    context.Entry(obj).Property(x => x.EvaluationFileName).IsModified = true;
                    context.Entry(obj).Property(x => x.EvaluationFileUrl).IsModified = true;
                    context.Entry(obj).Property(x => x.CalculationFilename).IsModified = true;
                    context.Entry(obj).Property(x => x.CalculationFileUrl).IsModified = true;
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

        public bool SimpanDataBatch(Batchtbl newData, IEnumerable<string> OrderNos)
        {
            try
            {
                HashSet<string> Orders = new HashSet<string>();
                OrderNos.ToList().ForEach(x => Orders.Add(x));
                using (var context = new smlpobDB())
                {
                    context.Batchtbl.Add(newData);
                    var datas = from x in context.Ordermastertbl
                                where Orders.Contains(x.OrderNo)
                                select x;
                    foreach(var item in datas)
                    {
                        item.BatchId = newData.BatchId;
                        item.Status = "Proses Lab";
                    }

                    context.SaveChanges();

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
        public List<Employeetbl> GetPICAnalyst(string Lab="")
        {
            try
            {
              
                using (var context = new smlpobDB())
                {
                    var datas = new List<Employeetbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = (from x in context.Employeetbl.Include(c=>c.Laboratorium)
                                where x.Position == "analis" && x.Laboratorium.LaboratoriumName == Lab
                                select x).ToList();
                    }
                    else
                    {
                        datas = (from x in context.Employeetbl
                                where x.Position == "analis"
                                select x).ToList();
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
        public async Task<bool> UpdateDataDetail(int id, Orderanalysisdetailtbl obj)
        {
            try
            {
                if (id != obj.OrderDetailNo)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Orderanalysisdetailtbl.Attach(obj);
                    context.Entry(obj).Property(x => x.OrderDetailNo).IsModified = true;
                    context.Entry(obj).Property(x => x.OrderNo).IsModified = true;
                    context.Entry(obj).Property(x => x.SampleNo).IsModified = true;
                    context.Entry(obj).Property(x => x.ElementId).IsModified = true;
                    context.Entry(obj).Property(x => x.ParametersNo).IsModified = true;
                    context.Entry(obj).Property(x => x.ElementValue).IsModified = true;
                    context.Entry(obj).Property(x => x.Status).IsModified = true;
                    context.Entry(obj).Property(x => x.Pic).IsModified = true;
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
        public Batchtbl GetBatchFromId(string BatchId)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.Batchtbl.Include(c => c.Ordermastertbl)
                                where x.BatchId == BatchId
                                select x;
                    return datas.FirstOrDefault();
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
        public IEnumerable<Ordermastertbl> GetOrdersFromBatchId(string BatchId)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.Ordermastertbl.Include(c => c.CustomerNoNavigation).Include(c => c.ComodityNoNavigation)
                                where x.BatchId == BatchId
                                select x;
                    return datas.ToList();
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
        public IEnumerable<Ordermastertbl> GetOrdersForBatch(int PICPenyelia)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.Ordermastertbl.Include(c=>c.CustomerNoNavigation).Include(c=>c.ComodityNoNavigation)
                                where x.Pic == PICPenyelia
                                && string.IsNullOrEmpty(x.BatchId) && x.Status== "Batch Management"
                                select x;
                    return datas.ToList();
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

        public async Task<IEnumerable<Ordersampletbl>> GetDataDetail(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var data = await context.Ordersampletbl
                                .Include(c => c.OrderNoNavigation)
                                .Where(x => x.OrderNo == id)
                                .ToListAsync();
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

        public async Task<IEnumerable<Orderanalysisdetailtbl>> GetParameter(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var data = await context.Orderanalysisdetailtbl
                        .Include(c => c.Element)
                        .Where(x => x.SampleNo == id)
                        .ToListAsync();
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

        public async Task<Ordermastertbl> GetDataForPrint(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var data = await (from x in context.Ordermastertbl
                                      .Include(c => c.Orderpricedetailtbl.Select(a => a.Element))
                                      .Include(c => c.Ordersampletbl)
                                      .Include(c => c.CustomerNoNavigation)
                                      .Include(c=>c.ComodityNoNavigation)
                                      where x.OrderNo == id
                                      select x).FirstOrDefaultAsync();
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