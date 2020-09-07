using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class ReviewingControls : IReviewingMasterData
    {
        public async Task<bool> AddData(reviewingtbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.reviewingtbls.Add(obj);
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

        public async Task<bool> UpdateData(string id, reviewingtbl obj)
        {
            try
            {
                if(id != obj.reviewingNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.reviewingtbls.Attach(obj);
                    context.Entry(obj).Property(x => x.orderNo).IsModified = true;
                    context.Entry(obj).Property(x => x.elementCodeList).IsModified = true;
                    context.Entry(obj).Property(x => x.reviewingDate).IsModified = true;
                    context.Entry(obj).Property(x => x.isLabUtilitySurfficient).IsModified = true;
                    context.Entry(obj).Property(x => x.isHumanResourceSurfficient).IsModified = true;
                    context.Entry(obj).Property(x => x.isChemicalMaterialSurfficent).IsModified = true;
                    context.Entry(obj).Property(x => x.isVolumeCorrect).IsModified = true;
                    context.Entry(obj).Property(x => x.workdays).IsModified = true;
                    context.Entry(obj).Property(x => x.isMethode).IsModified = true;
                    context.Entry(obj).Property(x => x.isQualityStandard).IsModified = true;
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
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.reviewingtbls
                                where x.reviewingNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.reviewingtbls.Remove(item);
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

        public async Task<IEnumerable<reviewingtbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.reviewingtbls.ToListAsync();
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

        public async Task<reviewingtbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.reviewingtbls
                        .Where(x => x.reviewingNo == no)
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

        public async Task<IEnumerable<reviewingtbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.reviewingtbls
                                       where x.elementCodeList.Contains(param)
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

        public async Task<bool> RequestReviewing(string param, reviewingtbl data)
        {
            OrderMasterControls orderMasterControls = new OrderMasterControls();
            var ret = await AddData(data);

            if (ret)
            {
                var update = await orderMasterControls.UpdateStatus(data.orderNo,
                    status: "Kaji Ulang");

                if (update)
                    return true;
            }
            return false;
        }
    }
}