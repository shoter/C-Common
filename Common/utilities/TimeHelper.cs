using Common.Time;
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

        public static ITimeProvider timeProvider => TimeProviders.Current;

        public static TimeSpan CalculateTimeLeft(int startDay, int currentDay, int eventInDayLength,  DateTime startTime)
        {
            return CalculateTimeLeft(startDay, currentDay, eventInDayLength,  startTime, DateTime.Now);
        }
        public static TimeSpan CalculateTimeLeft(int startDay, int currentDay, int eventInDayLength, DateTime startDateTime, DateTime currentDateTime )
        {
            return startDateTime - currentDateTime +  TimeSpan.FromDays(1 * eventInDayLength);

           /* startDate = MakeDateInSameDay(startDate, currentDateTime);

            var dateDiffrence = timeProvider.Now - startDate;
            var dayDiffrence = currentDay - startDay;


            return TimeSpan.FromSeconds(eventInDayLength * HoursInDay * SecondsInMinute * MinutesInHour -
                (dayDiffrence * 24 + dateDiffrence.Hours) * MinutesInHour * SecondsInMinute -
                dateDiffrence.Minutes * SecondsInMinute -
                dateDiffrence.Seconds
                );*/
                
        }

        public static TimeSpan CalculateDateDiffrence(int startDay, int currentDay, DateTime startDateTime, DateTime currentDateTime)
        {
            return currentDateTime - startDateTime;
           /* startTime = MakeDateInSameDay(startTime, currentTime);

            var dateDiffrence = timeProvider.Now - startTime;
            var dayDiffrence = currentDay - startDay;



            return TimeSpan.FromSeconds(
                (dayDiffrence * 24 + dateDiffrence.Hours) * MinutesInHour * SecondsInMinute +
                dateDiffrence.Minutes * SecondsInMinute +
                dateDiffrence.Seconds
                );*/
        }

        public static DateTime MakeDateInSameDay(DateTime toChange, DateTime preset)
        {
            return new DateTime(preset.Year, preset.Month, preset.Day, toChange.Hour, toChange.Minute, toChange.Second, toChange.Kind);
        }
    }
}
