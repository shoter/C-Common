using Common.Extensions;
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
            StringBuilder changed = new StringBuilder();
            if(str.Length > 0)
            {
                changed.Append(str.Substring(0, 1).ToUpper());
                changed.Append(str.Substring(1).ToLower());
            }
            

            return changed.ToString();
        }

        /// <summary>
        /// Change camel case word to words.
        /// For example BeAble will be changed to "be able"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CamelCaseToWord(this string str)
        {
            StringBuilder changed = new StringBuilder();
            
            if(str.Length > 0)
            {
                changed.Append(str[0].ToLower());
                for(int i = 1; i < str.Length;++i)
                {
                    char character = str[i];

                    if (character.IsUpper())
                        changed.Append(" ");
                    changed.Append(character.ToLower());
                }
            }

            return changed.ToString();
        }

    }
}
