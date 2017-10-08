using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Language
{
    public class PluralHelper
    {
        public static string Days(int days)
        {
            if (days == 1)
                return "day";
            return "days";
        }

        public static string S(int x)
        {
            if (x == 1)
                return "";
            return "s";
        }
    }
}
