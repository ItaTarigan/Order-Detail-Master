using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Silpo.Tools
{
    public static class ObjectExtension
    {
        public static void CopyTo<T>(this object from, T to)
        {
            var fromProperties = from.GetType().GetProperties();
            var toProperties = to.GetType().GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                var pt = fromProperty.PropertyType;
                if (pt.IsClass && pt.Namespace != "System")
                    continue;

                var toProperty = toProperties.Where(t => t.Name == fromProperty.Name && t.PropertyType == pt).FirstOrDefault();
                if (toProperty != null)
                    toProperty.SetValue(to, fromProperty.GetValue(from));
            }
        }
    }
}
