using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneService.App.AppData
{
    public static class ControllerHelperMethods
    {
        public static bool ArePropertiesNotNull<T>(this T obj) => typeof(T).GetProperties().Any(propertyInfo => propertyInfo.GetValue(obj) != null);
    }
}
