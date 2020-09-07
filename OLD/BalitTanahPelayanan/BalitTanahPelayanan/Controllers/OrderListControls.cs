using BalitTanahPelayanan.Helpers;
using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class OrderListControls : IOrderListMasterData
    {
        public async Task<IEnumerable<ordermastertbl>> GetDataByStatus(params string[] States)
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
                                .Where(x => Statuses.Contains(x.status))
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
        public async Task<ordermastertbl> DetailData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    //var IDS = id;
                    var data = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)   
                                .Where(x => x.orderNo == id)
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

        public async Task<IEnumerable<comoditytbl>> GetKomoditasName()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    
                    var datas = await context.comoditytbls
                                .OrderBy(x=>x.comodityName)
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
        public async Task<IEnumerable<ordermastertbl>> GetDataByCreatedByAndComodity(string UserName,int commodityNo)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var uname = UserName;
                    var datas = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
                                .Include(c => c.customertbl.accounttbl)
                                .Include(c => c.orderanalysisdetailtbls)
                                .Where(c => c.creaBy == uname && c.comodityNo == commodityNo)
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
        public async Task<IEnumerable<ordermastertbl>> GetDataByCreatedBy(string UserName)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var uname = UserName;
                    var datas = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
                                .Include(c => c.customertbl.accounttbl)
                                .Include(c => c.orderanalysisdetailtbls)
                                .Where(c => c.creaBy == uname)
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
        public async Task<IEnumerable<ordermastertbl>> GetDataByPenyelia()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
                                .Include(c => c.orderanalysisdetailtbls)
                                .Where(c => c.status == "Hitung ulang" || c.status == "Verifikasi Penyelia" || c.status == "Kaji Ulang" || c.status == "Evaluasi Hasil" || c.status == "Proses Lab")

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
        public async Task<IEnumerable<ordermastertbl>> GetData(string Lab="")
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
                               .Include(c => c.orderanalysisdetailtbls)
                               .Where(c => (c.status == "Hitung ulang" || c.status == "Verifikasi Penyelia" || c.status == "Kaji Ulang" || c.status == "Evaluasi Hasil" || c.status == "Proses Lab") && c.analysisType == Lab)
                               //.Include(c => c.)
                               //.Include(c => c.)
                               //.Include(c => c.sampleNo)
                               .ToListAsync();
                    }
                    else
                    {
                        datas = await context.ordermastertbls
                               .Include(c => c.comoditytbl)
                               .Include(c => c.customertbl)
                               .Include(c => c.orderanalysisdetailtbls)
                               .Where(c => c.status == "Hitung ulang" || c.status == "Verifikasi Penyelia" || c.status == "Kaji Ulang" || c.status == "Evaluasi Hasil" || c.status == "Proses Lab")
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
        public async Task<IEnumerable<ordermastertbl>> GetDataPenyelia(string Lab = "")
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
                               .Include(c => c.orderanalysisdetailtbls)
                               .Where(c => (c.status == "Hitung ulang" || c.status == "Verifikasi Penyelia" || c.status == "Kaji Ulang" || c.status == "Proses Lab") && c.analysisType == Lab)
                               //.Include(c => c.)
                               //.Include(c => c.)
                               //.Include(c => c.sampleNo)
                               .ToListAsync();
                    }
                    else
                    {
                        datas = await context.ordermastertbls
                               .Include(c => c.comoditytbl)
                               .Include(c => c.customertbl)
                               .Include(c => c.orderanalysisdetailtbls)
                               .Where(c => c.status == "Hitung ulang" || c.status == "Verifikasi Penyelia" || c.status == "Kaji Ulang" || c.status == "Proses Lab")
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
        public async Task<IEnumerable<batchtbl>> GetBatchDataByPIC(int AnalisEmpNo,string Status = "Proses")
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.batchtbls.Include(c => c.employeetbl).Where(x=>x.pic_analis == AnalisEmpNo && x.status==Status)
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
        public async Task<IEnumerable<batchtbl>> GetBatchData()
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var datas = await context.batchtbls.Include(c=>c.employeetbl)
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
                               .Include(c => c.orderanalysisdetailtbls)
                               .Where(x => (x.status == "LHP Keluar" || x.status == "LHP Sudah Diambil") && x.analysisType == Lab)
                               .ToListAsync();
                    }
                    else
                    {
                        datas = await context.ordermastertbls
                               .Include(c => c.comoditytbl)
                               .Include(c => c.customertbl)
                               .Include(c => c.orderanalysisdetailtbls)
                               .Where(x => x.status == "LHP Keluar" || x.status == "LHP Sudah Diambil")
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

        public async Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.ordermastertbls
                                       where x.orderNo.Contains(param)
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

        public async Task<ordermastertbl> MasterData(string orderNo)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.ordermastertbls
                                .Include(c => c.comoditytbl)
                                .Include(c => c.customertbl)
                                .Include(c => c.orderanalysisdetailtbls)
                                .Where(c => c.orderNo == orderNo).FirstOrDefaultAsync();
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

        //public async Task<ordermastertbl> DetailNoOrder(string param)
        //{
        //    try
        //    {
        //        using (var context = new smlpobDB())
        //        {

        //            var data = await (from x in context.ordermastertbls where x.orderNo == param select x)
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

        public async Task<IEnumerable<orderanalysisdetailtbl>> GetDetailOrder(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.orderanalysisdetailtbls
                        .Where(x => x.orderNo == id)
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

        public async Task<bool> UpdateData(string id, ordermastertbl obj)
        {
            try
            {
                if (id != obj.orderNo)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.ordermastertbls.Attach(obj);
                    context.Entry(obj).Property(x => x.orderNo).IsModified = true;
                    context.Entry(obj).Property(x => x.customerNo).IsModified = true;
                    context.Entry(obj).Property(x => x.comodityNo).IsModified = true;
                    context.Entry(obj).Property(x => x.analysisType).IsModified = true;
                    context.Entry(obj).Property(x => x.sampleTotal).IsModified = true;
                    context.Entry(obj).Property(x => x.priceTotal).IsModified = true;
                    context.Entry(obj).Property(x => x.statusType).IsModified = true;
                    context.Entry(obj).Property(x => x.status).IsModified = true;
                    context.Entry(obj).Property(x => x.paymentStatus).IsModified = true;
                    context.Entry(obj).Property(x => x.ppn).IsModified = true;
                    //context.Entry(obj).Property(x => x.payment).IsModified = true;
                    context.Entry(obj).Property(x => x.receiptDate).IsModified = true;
                    context.Entry(obj).Property(x => x.isPaid).IsModified = true;
                    context.Entry(obj).Property(x => x.paymentDate).IsModified = true;
                    context.Entry(obj).Property(x => x.pic).IsModified = true;
                    context.Entry(obj).Property(x => x.isOnLab).IsModified = true;
                    context.Entry(obj).Property(x => x.ApprPenyelia).IsModified = true;
                    context.Entry(obj).Property(x => x.ApprEvaluator).IsModified = true;
                    context.Entry(obj).Property(x => x.ApprManagerTeknis).IsModified = true;
                    context.Entry(obj).Property(x => x.LHPAttachmentUrl).IsModified = true;
                    context.Entry(obj).Property(x => x.LHPFileName).IsModified = true;
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

        public bool SimpanDataBatch(batchtbl newData, IEnumerable<string> OrderNos)
        {
            try
            {
                HashSet<string> Orders = new HashSet<string>();
                OrderNos.ToList().ForEach(x => Orders.Add(x));
                using (var context = new smlpobDB())
                {
                    context.batchtbls.Add(newData);
                    var datas = from x in context.ordermastertbls
                                where Orders.Contains(x.orderNo)
                                select x;
                    foreach(var item in datas)
                    {
                        item.batchId = newData.batchId;
                        item.status = "Proses Lab";
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
        public List<employeetbl> GetPICAnalyst(string Lab="")
        {
            try
            {
              
                using (var context = new smlpobDB())
                {
                    var datas = new List<employeetbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = (from x in context.employeetbls.Include(c=>c.laboratoriumtbl)
                                where x.position == "analis" && x.laboratoriumtbl.laboratoriumName == Lab
                                select x).ToList();
                    }
                    else
                    {
                        datas = (from x in context.employeetbls
                                where x.position == "analis"
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
        public async Task<bool> UpdateDataDetail(int id, orderanalysisdetailtbl obj)
        {
            try
            {
                if (id != obj.orderDetailNo)
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.orderanalysisdetailtbls.Attach(obj);
                    context.Entry(obj).Property(x => x.orderDetailNo).IsModified = true;
                    context.Entry(obj).Property(x => x.orderNo).IsModified = true;
                    context.Entry(obj).Property(x => x.sampleNo).IsModified = true;
                    context.Entry(obj).Property(x => x.elementId).IsModified = true;
                    context.Entry(obj).Property(x => x.parametersNo).IsModified = true;
                    context.Entry(obj).Property(x => x.elementValue).IsModified = true;
                    context.Entry(obj).Property(x => x.status).IsModified = true;
                    context.Entry(obj).Property(x => x.pic).IsModified = true;
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
        public batchtbl GetBatchFromId(string BatchId)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.batchtbls.Include(c => c.ordermastertbls)
                                where x.batchId == BatchId
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
        public IEnumerable<ordermastertbl> GetOrdersFromBatchId(string BatchId)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.ordermastertbls.Include(c => c.customertbl).Include(c => c.comoditytbl)
                                where x.batchId == BatchId
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
        public IEnumerable<ordermastertbl> GetOrdersForBatch(int PICPenyelia)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.ordermastertbls.Include(c=>c.customertbl).Include(c=>c.comoditytbl)
                                where x.pic == PICPenyelia
                                && string.IsNullOrEmpty(x.batchId) && x.status== "Batch Management"
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

        public async Task<IEnumerable<ordersampletbl>> GetDataDetail(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var data = await context.ordersampletbls
                                .Include(c => c.ordermastertbl)
                                .Where(x => x.orderNo == id)
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

        public async Task<IEnumerable<orderanalysisdetailtbl>> GetParameter(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var data = await context.orderanalysisdetailtbls
                        .Include(c => c.elementservicestbl)
                        .Where(x => x.sampleNo == id)
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

        public async Task<ordermastertbl> GetDataForPrint(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {

                    var data = await (from x in context.ordermastertbls
                                      .Include(c => c.orderpricedetailtbls.Select(a => a.elementservicestbl))
                                      .Include(c => c.ordersampletbls)
                                      .Include(c => c.customertbl)
                                      .Include(c=>c.comoditytbl)
                                      where x.orderNo == id
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