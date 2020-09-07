using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BalitTanahPelayanan.Data;

namespace BalitTanahPelayanan.Controllers
{
    public class ReviewingControls : IReviewingMasterData
    {
        public async Task<bool> AddData(Reviewingtbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Reviewingtbl.Add(obj);
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

        public async Task<bool> UpdateData(string id, Reviewingtbl obj)
        {
            try
            {
                if(id != obj.ReviewingNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Reviewingtbl.Attach(obj);
                    context.Entry(obj).Property(x => x.OrderNo).IsModified = true;
                    context.Entry(obj).Property(x => x.ElementCodeList).IsModified = true;
                    context.Entry(obj).Property(x => x.ReviewingDate).IsModified = true;
                    context.Entry(obj).Property(x => x.IsLabUtilitySurfficient).IsModified = true;
                    context.Entry(obj).Property(x => x.IsHumanResourceSurfficient).IsModified = true;
                    context.Entry(obj).Property(x => x.IsChemicalMaterialSurfficent).IsModified = true;
                    context.Entry(obj).Property(x => x.IsVolumeCorrect).IsModified = true;
                    context.Entry(obj).Property(x => x.Workdays).IsModified = true;
                    context.Entry(obj).Property(x => x.IsMethode).IsModified = true;
                    context.Entry(obj).Property(x => x.IsQualityStandard).IsModified = true;
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
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = from x in context.Reviewingtbl
                                where x.ReviewingNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.Reviewingtbl.Remove(item);
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

        public async Task<IEnumerable<Reviewingtbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Reviewingtbl.ToListAsync();
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

        public async Task<Reviewingtbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Reviewingtbl
                        .Where(x => x.ReviewingNo == no)
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

        public async Task<IEnumerable<Reviewingtbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Reviewingtbl
                                       where x.ElementCodeList.Contains(param)
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

        public async Task<bool> RequestReviewing(string param, Reviewingtbl data)
        {
            OrderMasterControls orderMasterControls = new OrderMasterControls();
            var ret = await AddData(data);

            if (ret)
            {
                var update = await orderMasterControls.UpdateStatus(data.OrderNo,
                    status: "Kaji Ulang");

                if (update)
                    return true;
            }
            return false;
        }
    }
}