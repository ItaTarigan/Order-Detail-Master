using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BalitTanahPelayanan.Data
{
    public class OrderMasterControls : IOrderMasterMasterData
    {
        public async Task<bool> AddData(Ordermastertbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Ordermastertbl.Add(obj);
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
        public bool UpdatePayment(string OrderNo, string StatusPembayaran, string TipePembayaran)
        {
            try
            {
                using (var db = new smlpobDB())
                {
                    var selMaster = (from x in db.Ordermastertbl
                                     where x.OrderNo == OrderNo
                                     select x).FirstOrDefault();
                    if (selMaster != null)
                    {
                        selMaster.PaymentStatus = StatusPembayaran;
                        selMaster.StatusType = TipePembayaran;
                       
                        if(StatusPembayaran!= "Belum dibayar")
                        {
                            selMaster.Status = "Barcode Sampel";
                            selMaster.IsPaid = "1";
                        }
                        else
                        {
                            selMaster.IsPaid = "0";
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
                    context.Entry(obj).Property(x => x.CustomerNo).IsModified = true;
                    context.Entry(obj).Property(x => x.ComodityNo).IsModified = true;
                    context.Entry(obj).Property(x => x.SampleTotal).IsModified = true;
                    context.Entry(obj).Property(x => x.PriceTotal).IsModified = true;
                    context.Entry(obj).Property(x => x.Status).IsModified = true;
                    context.Entry(obj).Property(x => x.IsPaid).IsModified = true;
                    context.Entry(obj).Property(x => x.ApprPenyelia).IsModified = true;
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
                    var datas = from x in context.Ordermastertbl
                                where x.OrderNo == id
                                select x;
                    foreach (var item in datas)
                    {
                        context.Ordermastertbl.Remove(item);
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
        
        public async Task<IEnumerable<Ordermastertbl>> GetDataKasir()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Ordermastertbl
                        .Include(c => c.CustomerNoNavigation)
                        .Include(c => c.ComodityNoNavigation)
                        .Where(x => x.PackageName == "Belum dibayar" && x.Status == "Pesanan Baru").AsNoTracking()
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
        public async Task<IEnumerable<Ordermastertbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Ordermastertbl
                        .Include(c => c.CustomerNoNavigation)
                        .Include(c => c.ComodityNoNavigation)
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

        public async Task<Ordermastertbl> DetailData(string id)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Ordermastertbl
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

        public async Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Ordermastertbl
                                       where x.OrderNo.Contains(param)
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
                    var isExist = await context.Ordermastertbl.FindAsync(id);

                    if (isExist == null)
                    {
                        return false;
                    }

                    var obj = isExist;
                    obj.Status = status;

                    context.Ordermastertbl.Attach(obj);
                    context.Entry(obj).Property(x => x.Status).IsModified = true;
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
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }

            return false;
        }
    }
}