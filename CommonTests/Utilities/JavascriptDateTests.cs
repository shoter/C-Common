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
    public class JavascriptDateTests
    {
        [TestMethod]
        public void JavascriptTimeStartTest()
        {
            var date = new JavascriptDate(javascriptMilliseconds: 0);

            Assert.AreEqual(1, date.UtcDate.Day);
            Assert.AreEqual(1, date.UtcDate.Month);
            Assert.AreEqual(1970, date.UtcDate.Year);
            Assert.AreEqual(0, date.JavascriptMilliseconds);
        }

        [TestMethod]
        public void JavascriptTimeStartFromNetTest()
        {
            var date = new JavascriptDate(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));

            var local = date.Local;

            Assert.AreEqual(1, local.Day);
            Assert.AreEqual(1, local.Month);
            Assert.AreEqual(1970, local.Year);
            Assert.AreEqual(0, date.JavascriptMilliseconds);
        }

        //[TestMethod]
        //public void JavascriptTimeStartFromJavascriptToNet()
        //{
        //    var date = new JavascriptDate(new JavascriptDate(javascriptMilliseconds: 0).Date);

        //    var local = date.Date.ToLocalTime();

        //    Assert.AreEqual(1, local.Day);
        //    Assert.AreEqual(1, local.Month);
        //    Assert.AreEqual(1970, local.Year);
        //    Assert.AreEqual(0, date.JavascriptMilliseconds);
        //}

        [TestMethod]
        public void JavascriptSpecificDateTest()
        {
            var tick = 980985600000;

            var date = new JavascriptDate(tick);

            Assert.AreEqual(0, date.UtcDate.Second);
            Assert.AreEqual(0,date.UtcDate.Minute);
            Assert.AreEqual(0,date.UtcDate.Hour);
            Assert.AreEqual(1, date.UtcDate.Day);
            Assert.AreEqual(2, date.UtcDate.Month);
            Assert.AreEqual(2001, date.UtcDate.Year);
        }

        [TestMethod]
        public void JavascriptSpecificDateTest2()
        {
            var tick = 1112670330000;

            var date = new JavascriptDate(tick);

            Assert.AreEqual(30, date.UtcDate.Second);
            Assert.AreEqual(5, date.UtcDate.Minute);
            Assert.AreEqual(3, date.UtcDate.Hour);
            Assert.AreEqual(5, date.UtcDate.Day);
            Assert.AreEqual(4, date.UtcDate.Month);
            Assert.AreEqual(2005, date.UtcDate.Year);
        }

        [TestMethod]
        public void JavascriptSpecificTick2Test()
        {
            var tick = 1112670330000;

            var date = new JavascriptDate(new DateTime(2005, 3, 5, 3, 5, 30));

            Assert.AreEqual(tick, date.JavascriptMilliseconds);
        }

        [TestMethod]
        public void JavascriptSpecificTickTest()
        {
            var tick = 980985600000;

            var date = new JavascriptDate(new DateTime(2001, 2, 1, 0, 0, 0));

            Assert.AreEqual(tick, date.JavascriptMilliseconds);
        }

        [TestMethod]
        public void JavascriptCurrentDateTest()
        {
            var tick = 1509089730938;

            var date = new JavascriptDate(tick);

            var local = date.Local;

            Assert.AreEqual(35, local.Minute);
            Assert.AreEqual(9, local.Hour);
            Assert.AreEqual(27, local.Day);
            Assert.AreEqual(10, local.Month);
            Assert.AreEqual(2017, local.Year);
        }
    }
}
