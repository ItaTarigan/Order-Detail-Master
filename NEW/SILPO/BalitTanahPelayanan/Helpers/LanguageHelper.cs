using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;

namespace BalitTanahPelayanan.Helpers
{
    public class LanguageHelper
    {
        /*
        public static string CurrentLanguage
        {
            get
            {
                if (HttpContext.Current.Session["lang"] == null)
                {
                    HttpContext.Current.Session["lang"] = "id";
                }
                return HttpContext.Current.Session["lang"].ToString();
            }
            set
            {
                HttpContext.Current.Session["lang"] = value;
                
            }
        }
       
        public static string GetTranslation(string KeyName)
        {
            var tempCulture = CurrentLanguage;
            var culture = "";
            if (tempCulture.CompareTo("en") == 0 || string.IsNullOrEmpty(tempCulture))
            {
                culture = "en-US";
            }
            else
            if (tempCulture.ToLower().CompareTo("id") == 0)
            {
                culture = "id-ID";
            }
            if (Thread.CurrentThread.CurrentCulture.ToString() != culture)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            var ResVal = HttpContext.GetGlobalResourceObject($"app.language", KeyName);
            if (ResVal==null) return "";
            string resourceValue = ti.ToTitleCase(ResVal.ToString());
            return resourceValue;
        }*/
    }
}