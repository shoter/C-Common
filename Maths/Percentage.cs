﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Maths
{
    public static class Percentage
    {
        public static double ConvertToPercent(double value, int decimalPlaces = 1) => Math.Round(value * 100.0, decimalPlaces);
    }
}
