using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Helpers
{
    public class LogHelpers
    {
        public static string source { get; set; }
        public static string message { get; set; }
        public static string user { get; set; }

        public static void WriteLog()
        {
            try
            {
                using (var context = new smlpobDB())
                {
                    var log = new Logtbl()
                    {
                        Source = source,
                        Description = message,
                        CreaBy = user,
                        CreaDate = DatetimeHelper.GetDatetimeNow()
                    };

                    context.Logtbl.Add(log);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}