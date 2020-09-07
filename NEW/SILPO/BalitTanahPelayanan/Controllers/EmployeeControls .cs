using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Controllers
{
    public class EmployeeControls : IEmployeeMasterData
    {
        public async Task<bool> AddData(Employeetbl obj)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    context.Employeetbl.Add(obj);
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

        public async Task<bool> UpdateData(string id, Employeetbl obj)
        {
            try
            {
                if(id != obj.EmployeeNo.ToString())
                {
                    return false;
                }

                using (var context = new smlpobDB())
                {
                    context.Employeetbl.Attach(obj);
                    context.Entry(obj).Property(x => x.EmployeeName).IsModified = true;
                    context.Entry(obj).Property(x => x.Position).IsModified = true;
                    context.Entry(obj).Property(x => x.EmployeeEmail).IsModified = true;
                    context.Entry(obj).Property(x => x.DerivativeToEmployee).IsModified = true;
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
                    var datas = from x in context.Employeetbl
                                where x.EmployeeNo == no
                                select x;
                    foreach (var item in datas)
                    {
                        context.Employeetbl.Remove(item);
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

        public async Task<IEnumerable<Employeetbl>> GetData()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await context.Employeetbl.AsNoTracking().ToListAsync();
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

        public async Task<IEnumerable<Employeetbl>> GetDataAnalis(string Lab="")
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = new List<Employeetbl>();
                    if (!string.IsNullOrEmpty(Lab))
                    {
                        datas = await context.Employeetbl.Include(c=>c.Laboratorium).Where(x => x.Position == "penyelia" && x.Laboratorium.LaboratoriumName == Lab).AsNoTracking().ToListAsync();
                    }
                    else
                    {
                        datas = await context.Employeetbl.Where(x => x.Position == "penyelia").AsNoTracking().ToListAsync();
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

        public async Task<Employeetbl> DetailData(string id)
        {
            int no = 0;
            int.TryParse(id, out no);

            try
            {
                using (var context = new smlpobDB())
                {
                    var data = await context.Employeetbl
                        .Where(x => x.EmployeeNo == no)
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

        public async Task<IEnumerable<Employeetbl>> GetDataByContaint(string param)
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var datas = await (from x in context.Employeetbl
                                       where x.EmployeeName.Contains(param)
                                       || x.Position.Contains(param)
                                       || x.EmployeeEmail.Contains(param)
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