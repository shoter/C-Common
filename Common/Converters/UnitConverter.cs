using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Converters
{
    public static class UnitConverter
    {
        public static string Convert(int value)
        {
            if (value <= 999)
                return value.ToString();
            if (value <= 999_999)
                return $"{divide(value, 1000)}K";
            if (value <= 999_999_999)
                return $"{divide(value, 1000_000)}M";

            return value.ToString();
        }

        private static string divide(int value, int by)
        {
            return Math.Round((double)value / (double)by, 1).ToString();
        }

        public static string ConvertToBasicUnits(this int value)
        {
            return Convert(value);
        }
    }
}
