using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Enums
    {
        public static Random random = new Random();

        public static TEnum GetRandomValue<TEnum>()
        {
            TEnum[] values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
            return values[random.Next(0, values.Length)];
        }
    }
}
