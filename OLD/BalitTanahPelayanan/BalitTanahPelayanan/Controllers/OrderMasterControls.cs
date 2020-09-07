using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using System.Data.Entity;

namespace BalitTanahPelayanan.Controllers
{
    public class OrderMasterControls : IOrderMasterMasterData
    {
        public async Task<bool> AddData(ordermastertbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.ordermastertbls.Add(obj);
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
        public bool UpdatePayment(string orderNo, string StatusPembayaran, string TipePembayaran)
        {
            try
            {
                using (var db = new smlpobDB())
                {
                    var selMaster = (from x in db.ordermastertbls
                                     where x.orderNo == orderNo
                                     select x).FirstOrDefault();
                    if (selMaster != null)
                    {
                        selMaster.paymentStatus = StatusPembayaran;
                        selMaster.statusType = TipePembayaran;
                       
                        if(StatusPembayaran!= "Belum dibayar")
                        {
                            selMaster.status = "Barcode Sampel";
                            selMaster.isPaid = "1";
                        }
                        else
                        {
                            selMaster.isPaid = "0";
                        }
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
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
                    context.Entry(obj).Property(x => x.customerNo).IsModified = true;
                    context.Entry(obj).Property(x => x.comodityNo).IsModified = true;
                    context.Entry(obj).Property(x => x.sampleTotal).IsModified = true;
                    context.Entry(obj).Property(x => x.priceTotal).IsModified = true;
                    context.Entry(obj).Property(x => x.status).IsModified = true;
                    context.Entry(obj).Property(x => x.isPaid).IsModified = true;
                    context.Entry(obj).Property(x => x.ApprPenyelia).IsModified = true;
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
                    var datas = from x in context.ordermastertbls
                                where x.orderNo == id
                                select x;
                    foreach (var item in datas)
                    {
                        context.ordermastertbls.Remove(item);
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
        
        public async Task<IEnumerable<ordermastertbl>> GetDataKasir()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.ordermastertbls
                        .Include(c => c.customertbl)
                        .Include(c => c.comoditytbl)
                        .Where(x => x.paymentStatus == "Belum dibayar" && x.status == "Pesanan Baru").AsNoTracking()
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
        public async Task<IEnumerable<ordermastertbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.ordermastertbls
                        .Include(c => c.customertbl)
                        .Include(c => c.comoditytbl)
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

        public async Task<ordermastertbl> DetailData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.ordermastertbls
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

        public async Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.ordermastertbls
                                       where x.orderNo.Contains(param)
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

        public async Task<bool> UpdateStatus(string id, string status)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var isExist = await context.ordermastertbls.FindAsync(id);

                    if (isExist == null)
                    {
                        return false;
                    }

                    var obj = isExist;
                    obj.status = status;

                    context.ordermastertbls.Attach(obj);
                    context.Entry(obj).Property(x => x.status).IsModified = true;
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
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return false;
        }
    }
}