using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class PesananCustomerControls
    {
        string currentUser = Membership.GetUser().UserName.ToString();
        public async Task<bool> AddData(customertbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.customertbls.Add(obj);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return false;
        }

        public async Task<bool> UpdateData(string id, customertbl obj)
        {
            try
            {
                if(id != obj.customerNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.customertbls.Attach(obj);
                    context.Entry(obj).Property(x => x.customerName).IsModified = true;
                    context.Entry(obj).Property(x => x.customerEmail).IsModified = true;
                    context.Entry(obj).Property(x => x.companyName).IsModified = true;
                    context.Entry(obj).Property(x => x.companyAddress).IsModified = true;
                    context.Entry(obj).Property(x => x.companyPhone).IsModified = true;
                    context.Entry(obj).Property(x => x.companyEmail).IsModified = true;
                    context.Entry(obj).Property(x => x.accountNo).IsModified = true;
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
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return false;
        }

        public async Task<bool> DeleteData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.customertbls
                                where x.customerNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.customertbls.Remove(item);
                    }
                     await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }
            return false;
        }
        public comoditytbl GetCommodityByNo(int ComodityNo)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = context.comoditytbls.Where(x=>x.comodityNo == ComodityNo).AsNoTracking().FirstOrDefault();
                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }
        public async Task<IEnumerable<analysistypetbl>> GetAnalysis()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.analysistypetbls.AsNoTracking().ToListAsync();
                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }

        public async Task<IEnumerable<comoditytbl>> GetKomodity()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.comoditytbls
                                       where x.derivativeTo == -1
                                       select x).AsNoTracking().ToListAsync();
                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }

        public async Task<IEnumerable<sampletypetbl>> GetSampleType()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.sampletypetbls.AsNoTracking().ToListAsync();
                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }
        public async Task<IEnumerable<comoditytbl>> GetKomoditiChild(int id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.comoditytbls
                                       where x.derivativeTo == id
                                       select x).ToListAsync();
                    return datas;
                }
            }
            catch (Exception ex)
            {

                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }

        public async Task<customertbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.customertbls
                        .Where(x => x.customerNo == no).AsNoTracking()
                        .FirstOrDefaultAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }

        public async Task<IEnumerable<customertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.customertbls
                                       where x.customerName.Contains(param)
                                       || x.customerEmail.Contains(param)
                                       || x.companyName.Contains(param)
                                       || x.companyEmail.Contains(param)
                                       select x).ToListAsync();
                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }

        public string GetCurrentUser(string email)
        {
            try
            {
                using (var contex = new smlpobDB())
                {
                    var data = (from x in contex.customertbls
                               where x.customerEmail == email
                               select x.customerName).AsNoTracking().SingleOrDefault();

                    return data;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }
        public IEnumerable<elementservicestbl> GetParameterUjiByCommodityNo(int commodityNo, string tipeanalis, out packagetbl package)
        {
            try
            {
               
                using (var context = new smlpobDB())
                {
                    var selComodity = (from x in context.comoditytbls
                                       where x.comodityNo == commodityNo
                                       select x).FirstOrDefault();
                    if (selComodity.isPackage=="1")
                    {
                        package = context.packagetbls.Where(x => x.comodityNo == commodityNo).FirstOrDefault();
                        var datas = (from x in context.elementservicestbls
                                     where x.comodityNo == commodityNo &&
                                     x.analysisTypeName == tipeanalis &&
                                     x.serviceStatus == "Tersedia"
                                     select x).AsNoTracking().ToList();
                        foreach(var item in datas)
                        {
                            item.serviceRate = 0;
                            item.isMandatory = "1";
                        }
                        return datas;
                    }
                    else
                    {
                        var datas = (from x in context.elementservicestbls
                                           where x.comodityNo == commodityNo &&
                                           x.serviceStatus == "Tersedia" &&
                                           x.analysisTypeName == tipeanalis
                                           select x).AsNoTracking().ToList();
                        package = null;
                        return datas;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }
            package = null;
            return null;
        }
        public async Task<IEnumerable<standarddetailtbl>> GetParameterUji(string childkomoditas, string tipeanalis)
        {
            try
            {
                int no = 0;
                int.TryParse(childkomoditas, out no);
                using (var context = new smlpobDB())
                {

                    var datas = await (from x in context.standarddetailtbls
                                      .Include("standardtbl")
                                      .Include("elementservicestbl")
                                      where x.standardtbl.comodityNo == no &&
                                      x.elementservicestbl.serviceStatus == "Tersedia" &&
                                      x.elementservicestbl.analysisTypeName==tipeanalis
                                      select x).AsNoTracking().ToListAsync();

                    return datas;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }

        public int GetCustomerNo(string username)
        {
            try
            {
                using (var contex = new smlpobDB())
                {
                    var data = (from x in contex.customertbls.Include("accounttbl")
                                where x.accounttbl.username == username
                                select x.customerNo).SingleOrDefault();

                    return data;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return 0;
        }

        public string GetExteRate(string elementservice, int comoditynum)
        {
            try
            {
                using (var contex = new smlpobDB())
                {
                    var data = (from x in contex.elementservicestbls
                                where x.elementCode == elementservice && x.comodityNo == comoditynum
                                select x.ExtractionId).FirstOrDefault();
                    if (data != null)
                    {
                        int exid = Int32.Parse(data);
                        var prep = (from x in contex.elementservicestbls
                                    where x.elementid == exid
                                    select x.serviceRate).FirstOrDefault().ToString();
                        return prep;
                    }
                    return data;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }

        public string GetExtrID(string elementservice, int comoditynum)
        {
            try
            {
                using (var contex = new smlpobDB())
                {
                    var data = (from x in contex.elementservicestbls
                                where x.elementCode == elementservice && x.comodityNo == comoditynum
                                select x.ExtractionId).FirstOrDefault();                    
                    return data;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }

        public string AutoGenerateOrder()
        {
            string id = "";
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = (from x in context.ordermastertbls
                                .OrderByDescending(x => x.orderNo)
                                select x.orderNo).FirstOrDefault();

                    if (data != null)
                    {
                        string[] strSplit = data.Split('/');
                        int noUrut = int.Parse(strSplit[0]);
                        string instansi = strSplit[1];
                        int thn = int.Parse(strSplit[3]);
                        int thnNow = int.Parse(DatetimeHelper.GetYearNow());

                        if (thnNow > thn)
                        {
                            id = "0001/LPBalittanah/" + DatetimeHelper.GetMonthNow() + "/" +
                            DatetimeHelper.GetYearNow();
                        }
                        else
                        {
                            string newNoUrut = (noUrut + 1).ToString("0000");
                            id = newNoUrut + "/" + instansi + "/" + DatetimeHelper.GetMonthNow() + "/" +
                                DatetimeHelper.GetYearNow();
                        }
                    }
                    else
                    {
                        id = "0001/LPBalittanah/" + DatetimeHelper.GetMonthNow() + "/"+
                            DatetimeHelper.GetYearNow();
                    }

                    return id;
                } 
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }
            return null;
        }

        public string AutoGenerateSample(string komoditas, string analisis)
        {
            try
            {
                int no = int.Parse(komoditas);
                string cmdt = "";
                using (var context = new smlpobDB())
                {
                    var kmd = (from x in context.comoditytbls
                               where x.comodityNo == no
                               select x.comodityName).AsNoTracking().SingleOrDefault();
                    cmdt = kmd;
                }

                string id = "";
                string kodeKomoditas = "";
                string kodeAnalisis = "";

                // kode komoditas
                if (cmdt.Contains("Pupuk Organik"))
                {
                    kodeKomoditas = "Po.";
                }
                else if (cmdt.Contains("Pupuk Anorganik"))
                {
                    kodeKomoditas = "Pa.";
                }
                else if (cmdt.Contains("Tanah"))
                {
                    kodeKomoditas = "Th.";
                }
                else if (cmdt.Contains("Air"))
                {
                    kodeKomoditas = "A.";
                }
                else if (cmdt.Contains("Tanaman"))
                {
                    kodeKomoditas = "Tn.";
                }

                // kode analisis
                if (analisis.Contains("Kimia"))
                {
                    kodeAnalisis = "K.";
                }
                else if (analisis.Contains("Biologi"))
                {
                    kodeAnalisis = "B.";
                }
                else if (analisis.Contains("Fisika"))
                {
                    kodeAnalisis = "F.";
                }

                using (var context = new smlpobDB())
                {
                    var data = (from x in context.ordersampletbls
                                .OrderByDescending(x => x.noBalittanah)
                                where x.noBalittanah.Contains(kodeKomoditas) &&
                                x.noBalittanah.Contains(kodeAnalisis)
                                select x.noBalittanah).AsNoTracking().SingleOrDefault();

                    if (data != null)
                    {
                        string[] strSplit = data.Split('.');
                        int noUrut1 = int.Parse(strSplit[2]);
                        int noUrut2 = int.Parse(strSplit[5]);
                        string newNoUrut1 = (noUrut1 + 1).ToString();
                        string newNoUrut2 = (noUrut2 + 1).ToString();

                        id = DatetimeHelper.GetYearNow() + "." + DatetimeHelper.GetMonthNow() + "." + newNoUrut1 +
                            "." + kodeAnalisis + kodeKomoditas + newNoUrut2;
                    }
                    else
                    {
                        id = DatetimeHelper.GetYearNow() + "." + DatetimeHelper.GetMonthNow() + "." + "1" +
                            "." + kodeAnalisis + kodeKomoditas + "1";
                    }

                    var sample = new ordersampletbl
                    {
                        noBalittanah = id,
                        sampleCode = "",
                    };

                    context.ordersampletbls.Add(sample);
                    context.SaveChangesAsync();

                    return id;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }

            return null;
        }

        public async Task<bool> SaveOrder(ordermastertbl order, List<ordersampletbl> sample, List<orderpricedetailtbl> element)
        {
            try
            {
                //string id = AutoGenerateOrder();
                //order.orderNo = id;
                List<orderanalysisdetailtbl> detail = new List<orderanalysisdetailtbl>();

                foreach (var data1 in sample)
                {
                    foreach (var data2 in element)
                    {
                        detail.Add(new orderanalysisdetailtbl
                        {
                            orderNo = order.orderNo,
                            sampleNo = data1.noBalittanah,
                            elementId = Convert.ToInt32(data2.elementId),
                            status = "Menunggu",
                            recalculate = "0",
                            creaBy = order.creaBy,
                            creaDate = order.creaDate
                        });
                    }
                }

                using (var context = new smlpobDB())
                {
                    context.ordermastertbls.Add(order);

                    foreach (var data in sample)
                    {
                        //data.orderNo = id;
                        data.isReceived = "0";
                        context.ordersampletbls.Add(data);
                    }

                    foreach(var data in detail)
                    {
                        context.orderanalysisdetailtbls.Add(data);
                    }

                    foreach(var data in element)
                    {
                        //data.orderNo = id;
                        context.orderpricedetailtbls.Add(data);
                    }

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = currentUser;
                LogHelpers.WriteLog();
            }
            return false;
        }
    }
}