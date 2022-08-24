using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class ExtensionMethod
    {
        public static T GetPropertyValue<T>(this object obj, string propName)
        {
            return (T)obj.GetType().GetProperty(propName).GetValue(obj, null);
        }

        // ref: http://stackoverflow.com/questions/2609875/null-safe-way-to-get-values-from-an-idatareader
        public static T GetValueOrDefault<T>(this IDataRecord row, string fieldName)
        {
            int ordinal = row.GetOrdinal(fieldName);
            return row.GetValueOrDefault<T>(ordinal);
        }

        // ref: http://stackoverflow.com/questions/2609875/null-safe-way-to-get-values-from-an-idatareader
        public static T GetValueOrDefault<T>(this IDataRecord row, int ordinal)
        {
            return (T)(row.IsDBNull(ordinal) ? default(T) : row.GetValue(ordinal));
        }

       
    }

   
}

