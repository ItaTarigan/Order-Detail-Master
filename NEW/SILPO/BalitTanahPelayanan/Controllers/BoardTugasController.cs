using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
//using System.Web.Security;

using Newtonsoft.Json;

namespace BalitTanahPelayanan.Controllers
{
    public class BoardTugasController
    {
        public List<Analysis> RequestData(string _user)
        {
            try
            {
                using (var _context = new smlpobDB())
                {
                    var _lab = (from x in _context.Employeetbl
                                         where x.EmployeeEmail == _user
                                         select x.Laboratorium.LaboratoriumName).FirstOrDefault();

                    var _dataList = (from x in _context.Ordermastertbl
                                     join y in _context.Orderanalysisdetailtbl on
                                     x.OrderNo equals y.OrderNo
                                     join z in _context.Employeetbl on x.Pic equals z.EmployeeNo
                                     join a in _context.Elementservicestbl on y.ElementId equals a.Elementid
                                     where x.AnalysisType == _lab && x.Status == "Proses Lab" 
                                     orderby x.CreaDate ascending
                                     select new Analysis
                                     {
                                         BatchNo = x.BatchId,
                                         SampleNo = y.SampleNo,
                                         ParameterName = a.ElementCode,
                                         SampleStatus = y.Status,
                                         Pic = z.EmployeeName
                                     }).AsNoTracking().ToList();
                                    
                    if (_dataList != null)
                    {
                        return _dataList;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelpers.source = this.GetType().Name;
                LogHelpers.message = ex.InnerException.ToString();
                LogHelpers.user = "";
                LogHelpers.WriteLog();
            }
            return null;
        }
    }

    public class Analysis
    {
        public string BatchNo { get; set; }
        public string SampleNo { get; set; }
        public string ParameterName { get; set; }
        public string SampleStatus { get; set; }
        public string Pic { get; set; }
    }
}