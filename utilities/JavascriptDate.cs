using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.utilities
{
    public class JavascriptDate
    {
        const long epochMiliseconds = 62135596800000;
        const long ticksPerMillisecond = 10_000;

        public readonly long JavascriptMilliseconds;
        public readonly DateTime Date;


        /// <param name="date">.NET date</param>
        public JavascriptDate(DateTime date)
        {
            Date = date;
            JavascriptMilliseconds = date.ToUniversalTime().Millisecond;
        }

        /// <param name="javascriptMilliseconds">milliseconds from date.GetTime()</param>
        public JavascriptDate(long javascriptMilliseconds)
        {
            JavascriptMilliseconds = javascriptMilliseconds;
            Date = new DateTime(epochMiliseconds * ticksPerMillisecond, DateTimeKind.Utc);
        }
    }
}
