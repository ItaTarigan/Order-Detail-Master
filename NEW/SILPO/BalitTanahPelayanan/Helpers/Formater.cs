using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BalitTanahPelayanan.Helpers
{
    public static class Formater
    {
        // Date Formater
        public static string ModDate(string date)
        {
            // Make string date to date format '01-Jan-1019' 
            DateTime dates = new DateTime();
            DateTime.TryParse(date, out dates);
            string modDate = dates.ToString("dd-MMM-yyyy");
            return modDate;
        }

        public static DateTime ToDate(string date)
        {
            DateTime dates = new DateTime();
            DateTime.TryParse(date, out dates);
            return dates;
        }

        // Currency Formater
        public static string ModCurrency(decimal currency)
        {
            // Make number to currency format '1000000.00'
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("id-ID");
            string prcMod;
            prcMod = currency.ToString("N2", cultureInfo);
            return prcMod;
        }

        public static decimal ReturnModCurency(string currency)
        {
            CultureInfo culureInfo = CultureInfo.CreateSpecificCulture("id-ID");
            decimal prc = 0;
            decimal.TryParse(currency, NumberStyles.Currency, culureInfo, out prc);
            return prc;
        }

        public static string ToRupiah(decimal currency)
        {
            return string.Format(CultureInfo.CreateSpecificCulture("id-ID"), "Rp{0:N}", currency);
            //return string.Format(CultureInfo.CreateSpecificCulture("id-ID"), "{0:C}", currency);
        }

        public static decimal ToNumber(string currency)
        {
            return decimal.Parse(Regex.Replace(currency, @",.*|\D", ""));
        }
    }
}