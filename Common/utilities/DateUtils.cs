using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.utilities
{
    public class DateUtils
    {
        public static int MonthDifference(DateTime now, DateTime ago)
        {
            return Math.Abs((now.Month - ago.Month) + 12 * (now.Year - ago.Year));
        }

    }
}
