using BalitTanahPelayanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Entity;
namespace BalitTanahPelayanan.Helpers
{
    public class CommonWeb
    {
        public static void Alert(Page thisPage, string message)
        {
            ScriptManager.RegisterClientScriptBlock(thisPage, thisPage.GetType(),
                "alertMessage", $"alert('{message}')", true);
        }

        public static string GetCurrentUser()
        {
            try
            {
                return string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) ? "anonymous" : HttpContext.Current.User.Identity.Name;
            }
            catch
            {
                return "anonymous";
            }
        }
        public static int GetCurrentEmployeeNo()
        {
            try
            {
                var empNo = -1;
                var uname = GetCurrentUser();
                using (var db = new smlpobDB())
                {

                    var EmpNo = (from x in db.employeetbls
                                 where x.employeeEmail == uname
                                 select x.employeeNo).FirstOrDefault();
                    empNo = EmpNo;
                }
                return empNo;
            }
            catch
            {
                return -1;
            }
        }
        public static string GetCurrentUserName()
        {
            try
            {
                var fName = "anonymous";
                var uname = GetCurrentUser();
                using (var db = new smlpobDB())
                {
                    var UserFullName = (from x in db.customertbls
                                        where x.customerEmail == uname
                                        select x.customerName).FirstOrDefault();
                    if (UserFullName != null)
                    {
                        fName = UserFullName;
                    }
                    else
                    {
                        UserFullName = (from x in db.employeetbls
                                        where x.employeeEmail == uname
                                        select x.employeeName).FirstOrDefault();
                        fName = UserFullName;
                    }
                }
                return fName;
            }
            catch
            {
                return "anonymous";
            }
        }

        public static string GetUserLab(bool IsForce = true)
        {
            try
            {
                if (!IsForce)
                {
                    if (HttpContext.Current.Session["MyLab"] != null)
                        return HttpContext.Current.Session["MyLab"].ToString();
                }
                var LabName = "";
                var uname = GetCurrentUser();
                using (var db = new smlpobDB())
                {

                    LabName = (from x in db.employeetbls.Include(c => c.laboratoriumtbl)
                               where x.employeeEmail == uname
                               select x.laboratoriumtbl.laboratoriumName).FirstOrDefault();
                    HttpContext.Current.Session["MyLab"] = LabName;


                }
                return LabName;
            }
            catch
            {
                return "";
            }
        }
    }
}