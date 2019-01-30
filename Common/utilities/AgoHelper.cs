using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.utilities
{
    public class AgoHelper
    {
        public static string Ago(DateTime now, DateTime ago)
        {
            TimeSpan span = now - ago;
            if (span.TotalMinutes < 1)
            {
                return "Just now";
            }
            else if (span.TotalMinutes < 60)
            {
                return string.Format("{0} minutes ago", span.Minutes);
            }
            else if (span.TotalHours < 24)
            {
                return string.Format("{0} hours ago", span.Hours);
            }
            else if (span.TotalDays < 365)
            {
                return string.Format("{0} days ago", span.Days);
            }
            else
            {
                return string.Format("{0} months ago", DateUtils.MonthDifference(now, ago));
            }
        }

        public static string DayAgo(int today, int pastDay)
        {
            int totalDays = today - pastDay;

            if (totalDays == 0)
                return "Today";

            return string.Format("{0} days ago", totalDays);
        }

        public static string Ago(int today, DateTime todayTime, int pastDay, DateTime pastTime)
        {
            int dayDiffrence = today - pastDay;

            DateTime dummyNow = DateTime.Now;
            DateTime dummyPast = DateTime.Now.AddDays(-dayDiffrence);

            dummyNow = dummyNow
                .AddHours(todayTime.Hour)
                .AddMinutes(todayTime.Minute);

            dummyPast = dummyPast
                .AddHours(pastTime.Hour)
                .AddMinutes(pastTime.Minute);

            return Ago(dummyNow, dummyPast);
        }
    }
}
