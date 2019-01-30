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
        public readonly DateTime UtcDate;
        public DateTime Local => UtcDate.ToLocalTime();


        /// <param name="date">.NET date</param>
        public JavascriptDate(DateTime date)
        {
            if (date.Kind != DateTimeKind.Utc)
            {
                date = date.ToUniversalTime();
            }

            UtcDate = date;
            JavascriptMilliseconds = (long)date.
                Subtract(new DateTime(1970, 1, 1).ToUniversalTime())
                .Subtract(new TimeSpan(1, 0, 0))
                .TotalMilliseconds;
        }

        /// <param name="javascriptMilliseconds">milliseconds from date.GetTime()</param>
        public JavascriptDate(long javascriptMilliseconds)
        {
            JavascriptMilliseconds = javascriptMilliseconds;
            UtcDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddMilliseconds(javascriptMilliseconds);
            //Date = new DateTime(epochMiliseconds * ticksPerMillisecond + javascriptMilliseconds * ticksPerMillisecond, DateTimeKind.Utc);
        }
    }
}
