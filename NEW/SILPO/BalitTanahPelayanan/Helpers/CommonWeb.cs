using BalitTanahPelayanan.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI;
//using Microsoft.EntityFrameworkCore;
namespace BalitTanahPelayanan.Helpers
{
    public class CommonWeb
    {
        /*
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
        }*/
        public static int GetCurrentEmployeeNo(string username)
        {
            try
            {
                var empNo = -1;
                //var uname = GetCurrentUser();
                using (var db = new smlpobDB())
                {

                    var EmpNo = (from x in db.Employeetbl
                                 where x.EmployeeEmail == username
                                 select x.EmployeeNo).FirstOrDefault();
                    empNo = EmpNo;
                }
                return empNo;
            }
            catch
            {
                return -1;
            }
        }
        public static string GetCurrentUserName(string username)
        {
            try
            {
                var fName = "anonymous";
                //var uname = GetCurrentUser();
                using (var db = new smlpobDB())
                {
                    var UserFullName = (from x in db.Customertbl
                                        where x.CustomerEmail == username
                                        select x.CustomerName).FirstOrDefault();
                    if (UserFullName != null)
                    {
                        fName = UserFullName;
                    }
                    else
                    {
                        UserFullName = (from x in db.Employeetbl
                                        where x.EmployeeEmail == username
                                        select x.EmployeeName).FirstOrDefault();
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

        public static string GetUserLab(string username)
        {
            try
            {
                /*
                if (!IsForce)
                {
                    if (HttpContext.Current.Session["MyLab"] != null)
                        return HttpContext.Current.Session["MyLab"].ToString();
                }*/
                var LabName = "";
                //var uname = GetCurrentUser();
                using (var db = new smlpobDB())
                {

                    LabName = (from x in db.Employeetbl.Include(c => c.Laboratorium)
                               where x.EmployeeEmail == username
                               select x.Laboratorium.LaboratoriumName).FirstOrDefault();
                    //HttpContext.Current.Session["MyLab"] = LabName;


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