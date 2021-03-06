﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static string FirstUpper(this string str)
        {
            if (str?.Length > 1)
            {
                return ReplaceAt(str, 0, str[0].ToUpper());
            }
            return str;
        }

        public static string ReplaceAt(this string input, int index, char newChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }

        public static string MultipleSpaceRemove(this string input)
        {
            return Regex.Replace(input, @"\s+", " ");
        }



        public static string ReverseAsString(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string FormatString(this string s, params object[] arguments)
        {
            return string.Format(s, arguments);
        }


    }
}
