using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.utilities
{
    public static class TimeHelper
    {
        const int SecondsInMinute = 60;
        const int MinutesInHour = 60;
        const int HoursInDay = 24;

        public static TimeSpan CalculateTimeLeft(int startDay, int currentDay, int eventInDayLength,  DateTime startTime)
        {
            return CalculateTimeLeft(startDay, currentDay, eventInDayLength,  startTime, DateTime.Now);
        }
        public static TimeSpan CalculateTimeLeft(int startDay, int currentDay, int eventInDayLength, DateTime startTime, DateTime currentTime )
        {
            var dateDiffrence = DateTime.Now - startTime;
            var dayDiffrence = currentDay - startDay;

            

            if (currentTime.Hour < startTime.Hour)
                dayDiffrence += 1;

            return TimeSpan.FromSeconds(eventInDayLength * HoursInDay * SecondsInMinute * MinutesInHour -
                (dayDiffrence * 24 + dateDiffrence.Hours) * MinutesInHour * SecondsInMinute -
                dateDiffrence.Minutes * SecondsInMinute -
                dateDiffrence.Seconds
                );
        }

        public static TimeSpan CalculateDateDiffrence(int startDay, int currentDay, DateTime startTime, DateTime currentTime)
        {
            var dateDiffrence = DateTime.Now - startTime;
            var dayDiffrence = currentDay - startDay;



            if (currentTime.Hour < startTime.Hour)
                dayDiffrence += 1;

            return TimeSpan.FromSeconds(
                (dayDiffrence * 24 + dateDiffrence.Hours) * MinutesInHour * SecondsInMinute +
                dateDiffrence.Minutes * SecondsInMinute +
                dateDiffrence.Seconds
                );
        }
    }
}
