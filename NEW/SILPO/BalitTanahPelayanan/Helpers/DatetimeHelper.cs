using System;
using System.Collections.Generic;
using System.Text;

namespace BalitTanahPelayanan.Helpers
{
    public static class DatetimeHelper
    {
        public static DateTime GetDatetimeNow()
        {
            TimeZoneInfo timeZoneInfo;
            DateTime dateTime;

            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            return dateTime;
        }

        public static string GetMonthNow()
        {
            TimeZoneInfo timeZoneInfo;
            string month;

            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime now = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            month = now.ToString("MM");

            return month;
        }

        public static string GetYearNow()
        {
            TimeZoneInfo timeZoneInfo;
            string year;

            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime now = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            year = now.ToString("yy");

            return year;
        }
    }
}
