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
    public class StringUtilsTests
    {
        [TestMethod]
        public void GetNumberAtEnd_simple_test()
        {
            string str = "alamakota123";

            Assert.AreEqual(123, str.GetNumberAtEnd());
        }

        [TestMethod]
        public void GetNumberAtEnd_numberAtStartAndEnd_test()
        {
            string str = "321ala123";

            Assert.AreEqual(123, str.GetNumberAtEnd());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetNumberAtEnd_numberAtStart_test()
        {
            string str = "123ala";

            Assert.AreEqual(123, str.GetNumberAtEnd());
        }
    }
}
