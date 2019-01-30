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
            if (isPlural(days))
                return "days";
            return "day";
        }

        public static bool isPlural(int x)
        {
            if (x == 1)
                return false;
            return true;
        }

        public static string S(int x)
        {
            if (isPlural(x))
                return "s";
            return "";
        }

        public static string Else(int x, string singular, string plural)
        {
            return isPlural(x) ? plural : singular;
        }
    }
}
