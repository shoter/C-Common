using Common.Time;
using Common.utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTests.Utilities
{
    [TestClass]
    public class TimeHelperTests
    {
        [TestMethod]
        public void CalculateTimeLeft_simple_test()
        {
            int day = 234;
            var start = DateTime.MinValue;
            var end = start.AddHours(3);

            TimeProviders.Current = new FixedTimeProvider(end);

            Assert.AreEqual(21.0, TimeHelper.CalculateTimeLeft(day,
                day, eventInDayLength: 1, startDateTime: start, currentDateTime: end).TotalHours, 0.01);
        }

        [TestMethod]
        public void CalculateTimeLeft_hourLeftTest_test()
        {
            int day = 234;
            var start = DateTime.Now;
            var end = start.AddDays(1).AddHours(-1);

            TimeProviders.Current = new FixedTimeProvider(end);

            Assert.AreEqual(1, TimeHelper.CalculateTimeLeft(day,
                day + 1, eventInDayLength: 1, startDateTime: start, currentDateTime: end).TotalHours, 0.01);
        }

        [TestMethod]
        public void CalculateTimeLeft_24hourTest_test()
        {


            for (int i = 0; i < 60 * 60 * 24 - 1; ++i)
            {
                int day = 1;
                var start = DateTime.Now.AddHours(6);
                var current = start.AddSeconds(i);

                if (start.Day != current.Day)
                    day = 2;

                TimeProviders.Current = new FixedTimeProvider(current);


                Assert.AreEqual(60 * 60 * 24 - i, TimeHelper.CalculateTimeLeft(1,
                    day , eventInDayLength: 1, startDateTime: start, currentDateTime: current).TotalSeconds, 3);
            }
        }

        [TestMethod]
        public void CalculateDateDiffrence_24hourTest_test()
        {


            for (int i = 0; i < 60 * 60 * 24 - 1; ++i)
            {
                int day = 1;
                var start = DateTime.Now.AddHours(6);
                var current = start.AddSeconds(i);

                if (start.Day != current.Day)
                    day = 2;

                TimeProviders.Current = new FixedTimeProvider(current);


                Assert.AreEqual(i, TimeHelper.CalculateDateDiffrence(1,
                    day, startDateTime: start, currentDateTime: current).TotalSeconds, 3);
            }
        }

        [TestMethod]
        public void CalculateTimeLeft_hourLeftTestFor2Days_test()
        {
            int day = 234;
            var start = DateTime.Now;
            var end = start.AddDays(1).AddHours(-1);

            TimeProviders.Current = new FixedTimeProvider(end);

            Assert.AreEqual(25, TimeHelper.CalculateTimeLeft(day,
                day + 1, eventInDayLength: 2, startDateTime: start, currentDateTime: end).TotalHours, 0.01);
        }
    }
}
