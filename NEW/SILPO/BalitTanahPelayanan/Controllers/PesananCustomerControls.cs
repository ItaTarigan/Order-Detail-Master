using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Security;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class PesananCustomerControls
    {
        public PesananCustomerControls(string username)
        {
            currentUser = username;

        }
        string currentUser; //Membership.GetUser().UserName.ToString();
        public async Task<bool> AddData(Customertbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Customertbl.Add(obj);
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

        public async Task<bool> UpdateData(string id, Customertbl obj)
        {
            try
            {
                if(id != obj.CustomerNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Customertbl.Attach(obj);
                    context.Entry(obj).Property(x => x.CustomerName).IsModified = true;
                    context.Entry(obj).Property(x => x.CustomerEmail).IsModified = true;
                    context.Entry(obj).Property(x => x.CompanyName).IsModified = true;
                    context.Entry(obj).Property(x => x.CompanyAddress).IsModified = true;
                    context.Entry(obj).Property(x => x.CompanyPhone).IsModified = true;
                    context.Entry(obj).Property(x => x.CompanyEmail).IsModified = true;
                    context.Entry(obj).Property(x => x.AccountNo).IsModified = true;
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
                    var datas = from x in context.Customertbl
                                where x.CustomerNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.Customertbl.Remove(item);
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
        public Comoditytbl GetCommodityByNo(int ComodityNo)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = context.Comoditytbl.Where(x=>x.ComodityNo == ComodityNo).AsNoTracking().FirstOrDefault();
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
        public async Task<IEnumerable<Analysistypetbl>> GetAnalysis()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Analysistypetbl.AsNoTracking().ToListAsync();
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

        public async Task<IEnumerable<Comoditytbl>> GetKomodity()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Comoditytbl
                                       where x.DerivativeTo == -1
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

        public async Task<IEnumerable<Sampletypetbl>> GetSampleType()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Sampletypetbl.AsNoTracking().ToListAsync();
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
        public async Task<IEnumerable<Comoditytbl>> GetKomoditiChild(int id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Comoditytbl
                                       where x.DerivativeTo == id
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

        public async Task<Customertbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Customertbl
                        .Where(x => x.CustomerNo == no).AsNoTracking()
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

        public async Task<IEnumerable<Customertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Customertbl
                                       where x.CustomerName.Contains(param)
                                       || x.CustomerEmail.Contains(param)
                                       || x.CompanyName.Contains(param)
                                       || x.CompanyEmail.Contains(param)
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
                    var data = (from x in contex.Customertbl
                               where x.CustomerEmail == email
                               select x.CustomerName).AsNoTracking().SingleOrDefault();

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
        public IEnumerable<Elementservicestbl> GetParameterUjiByCommodityNo(int commodityNo, string tipeanalis, out Packagetbl package)
        {
            try
            {
               
                using (var context = new smlpobDB())
                {
                    var selComodity = (from x in context.Comoditytbl
                                       where x.ComodityNo == commodityNo
                                       select x).FirstOrDefault();
                    if (selComodity.IsPackage=="1")
                    {
                        package = context.Packagetbl.Where(x => x.ComodityNo == commodityNo).FirstOrDefault();
                        var datas = (from x in context.Elementservicestbl
                                     where x.ComodityNo == commodityNo &&
                                     x.AnalysisTypeName == tipeanalis &&
                                     x.ServiceStatus == "Tersedia"
                                     select x).AsNoTracking().ToList();
                        foreach(var item in datas)
                        {
                            item.ServiceRate = 0;
                            item.IsMandatory = "1";
                        }
                        return datas;
                    }
                    else
                    {
                        var datas = (from x in context.Elementservicestbl
                                           where x.ComodityNo == commodityNo &&
                                           x.ServiceStatus == "Tersedia" &&
                                           x.AnalysisTypeName == tipeanalis
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
        public async Task<IEnumerable<Standarddetailtbl>> GetParameterUji(string childkomoditas, string tipeanalis)
        {
            try
            {
                int no = 0;
                int.TryParse(childkomoditas, out no);
                using (var context = new smlpobDB())
                {

                    var datas = await (from x in context.Standarddetailtbl
                                      .Include("Standardtbl")
                                      .Include("Elementservicestbl")
                                      where x.Std.ComodityNo == no &&
                                      x.Element.ServiceStatus == "Tersedia" &&
                                      x.Element.AnalysisTypeName==tipeanalis
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
                    var data = (from x in contex.Customertbl.Include("Accounttbl")
                                where x.AccountNoNavigation.Username == username
                                select x.CustomerNo).SingleOrDefault();

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
                    var data = (from x in contex.Elementservicestbl
                                where x.ElementCode == elementservice && x.ComodityNo == comoditynum
                                select x.ExtractionId).FirstOrDefault();
                    if (data != null)
                    {
                        int exid = Int32.Parse(data);
                        var prep = (from x in contex.Elementservicestbl
                                    where x.Elementid == exid
                                    select x.ServiceRate).FirstOrDefault().ToString();
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
                    var data = (from x in contex.Elementservicestbl
                                where x.ElementCode == elementservice && x.ComodityNo == comoditynum
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
                    var data = (from x in context.Ordermastertbl
                                .OrderByDescending(x => x.OrderNo)
                                select x.OrderNo).FirstOrDefault();

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
                    var kmd = (from x in context.Comoditytbl
                               where x.ComodityNo == no
                               select x.ComodityName).AsNoTracking().SingleOrDefault();
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
                    var data = (from x in context.Ordersampletbl
                                .OrderByDescending(x => x.NoBalittanah)
                                where x.NoBalittanah.Contains(kodeKomoditas) &&
                                x.NoBalittanah.Contains(kodeAnalisis)
                                select x.NoBalittanah).AsNoTracking().SingleOrDefault();

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

                    var sample = new Ordersampletbl
                    {
                        NoBalittanah = id,
                        SampleCode = "",
                    };

                    context.Ordersampletbl.Add(sample);
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

        public async Task<bool> SaveOrder(Ordermastertbl order, List<Ordersampletbl> sample, List<Orderpricedetailtbl> element)
        {
            try
            {
                //string id = AutoGenerateOrder();
                //order.orderNo = id;
                List<Orderanalysisdetailtbl> detail = new List<Orderanalysisdetailtbl>();

                foreach (var data1 in sample)
                {
                    foreach (var data2 in element)
                    {
                        detail.Add(new Orderanalysisdetailtbl
                        {
                            OrderNo = order.OrderNo,
                            SampleNo = data1.NoBalittanah,
                            ElementId = Convert.ToInt32(data2.ElementId),
                            Status = "Menunggu",
                            Recalculate = "0",
                            CreaBy = order.CreaBy,
                            CreaDate = order.CreaDate
                        });
                    }
                }

                using (var context = new smlpobDB())
                {
                    context.Ordermastertbl.Add(order);

                    foreach (var data in sample)
                    {
                        //data.orderNo = id;
                        data.IsReceived = "0";
                        context.Ordersampletbl.Add(data);
                    }

                    foreach(var data in detail)
                    {
                        context.Orderanalysisdetailtbl.Add(data);
                    }

                    foreach(var data in element)
                    {
                        //data.orderNo = id;
                        context.Orderpricedetailtbl.Add(data);
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