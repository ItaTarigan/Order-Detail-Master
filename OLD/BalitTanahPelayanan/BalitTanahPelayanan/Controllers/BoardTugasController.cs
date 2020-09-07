using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Security;

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
                    var _lab = (from x in _context.employeetbls
                                         where x.employeeEmail == _user
                                         select x.laboratoriumtbl.laboratoriumName).FirstOrDefault();

                    var _dataList = (from x in _context.ordermastertbls
                                     join y in _context.orderanalysisdetailtbls on
                                     x.orderNo equals y.orderNo
                                     join z in _context.employeetbls on x.pic equals z.employeeNo
                                     join a in _context.elementservicestbls on y.elementId equals a.elementid
                                     where x.analysisType == _lab && x.status == "Proses Lab" 
                                     orderby x.creaDate ascending
                                     select new Analysis
                                     {
                                         BatchNo = x.batchId,
                                         SampleNo = y.sampleNo,
                                         ParameterName = a.elementCode,
                                         SampleStatus = y.status,
                                         Pic = z.employeeName
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