using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Enums
    {
        public static Random random = new Random();

        public static TEnum GetRandomValue<TEnum>()
        {
            TEnum[] values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
            return values[random.Next(0, values.Length)];
        }

        public static bool HasEnumAttribute<TAttribute>(this object value)
            where TAttribute : Attribute
        {
            var type = value.GetType(); ;
            var memberInfo = type.GetMember(value.ToString()).First();

            return memberInfo.GetCustomAttributes(typeof(TAttribute), true).Count() > 0;
        }

        public static TAttribute GetEnumAttribute<TAttribute>(this object value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString()).First();

            return (TAttribute)memberInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() ;
        }
    }
}
