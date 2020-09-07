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
    public class EmployeeControls : IEmployeeMasterData
    {
        public async Task<bool> AddData(employeetbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.employeetbls.Add(obj);
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

        public async Task<bool> UpdateData(string id, employeetbl obj)
        {
            try
            {
                if(id != obj.employeeNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.employeetbls.Attach(obj);
                    context.Entry(obj).Property(x => x.employeeName).IsModified = true;
                    context.Entry(obj).Property(x => x.position).IsModified = true;
                    context.Entry(obj).Property(x => x.employeeEmail).IsModified = true;
                    context.Entry(obj).Property(x => x.derivativeToEmployee).IsModified = true;
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
                    var datas = from x in context.employeetbls
                                where x.employeeNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.employeetbls.Remove(item);
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

        public async Task<IEnumerable<employeetbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.employeetbls.AsNoTracking().ToListAsync();
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

        public async Task<IEnumerable<employeetbl>> GetDataAnalis(string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<employeetbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = await context.employeetbls.Include(c=>c.laboratoriumtbl).Where(x => x.position == "penyelia" && x.laboratoriumtbl.laboratoriumName == Lab).AsNoTracking().ToListAsync();
                    }
                    else
                    {
                        datas = await context.employeetbls.Where(x => x.position == "penyelia").AsNoTracking().ToListAsync();
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

        //public async Task<employeetbl> GetEmp()
        //{
        //    try
        //    {
        //        using (var context = new smlpobDB())
        //        {
        //            var datas = await context.employeetbls.ToListAsync();
        //            return datas;
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

        public async Task<employeetbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.employeetbls
                        .Where(x => x.employeeNo == no)
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

        public async Task<IEnumerable<employeetbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.employeetbls
                                       where x.employeeName.Contains(param)
                                       || x.position.Contains(param)
                                       || x.employeeEmail.Contains(param)
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
    }
}