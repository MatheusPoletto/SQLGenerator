using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static TValue GetAttributValue<TAttribute, TValue>(this PropertyInfo prop, Func<TAttribute, TValue> value) where TAttribute : Attribute
        {
            var att = prop.GetCustomAttributes(
                typeof(TAttribute), true
                ).FirstOrDefault() as TAttribute;
            if (att != null)
            {
                return value(att);
            }
            return default(TValue);
        }
    }
}
