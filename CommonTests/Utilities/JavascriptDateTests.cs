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

            Assert.AreEqual(1, date.Date.Day);
            Assert.AreEqual(1, date.Date.Month);
            Assert.AreEqual(1970, date.Date.Year);
            Assert.AreEqual(0, date.JavascriptMilliseconds);
        }

        [TestMethod]
        public void JavascriptTimeStartFromNetTest()
        {
            var date = new JavascriptDate(new DateTime(1970, 1, 1));

            Assert.AreEqual(1, date.Date.Day);
            Assert.AreEqual(1, date.Date.Month);
            Assert.AreEqual(1970, date.Date.Year);
            Assert.AreEqual(0, date.JavascriptMilliseconds);
        }

        [TestMethod]
        public void JavascriptTimeStartFromJavascriptToNet()
        {
            var date = new JavascriptDate(new JavascriptDate(javascriptMilliseconds: 0).Date);

            Assert.AreEqual(1, date.Date.Day);
            Assert.AreEqual(1, date.Date.Month);
            Assert.AreEqual(1970, date.Date.Year);
            Assert.AreEqual(0, date.JavascriptMilliseconds);
        }
    }
}
