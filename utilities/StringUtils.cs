using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.utilities
{
    public static class StringUtils
    {
        public static string FirstToUpper(this string str)
        {
            if(str.Length > 0)
            {
                return str.Substring(0, 1).ToUpper() + str.Substring(1);
            }

            return str;
        }

        public static string OnlyFirstUpper(this string str)
        {
            string changed = "";
            if(str.Length > 0)
            {
                changed += str.Substring(0, 1).ToUpper();
                changed += str.Substring(1).ToLower();
            }
            

            return changed;
        }
    }
}
