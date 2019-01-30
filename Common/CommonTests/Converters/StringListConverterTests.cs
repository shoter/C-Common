using Common.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTests.Converters
{
    [TestClass]
    public class StringListConverterTests
    {
        [TestMethod]
        public void StringListToIntConvertTest()
        {
            string input = "12;34;45";

            List<int> output = new StringListConverter(input)
                .SetDelimeter(';')
                .Get<int>();

            Assert.AreEqual(12, output[0]);
            Assert.AreEqual(34, output[1]);
            Assert.AreEqual(45, output[2]);
        }

        [TestMethod]
        public void StringListToStringonvertTest()
        {
            string input = "ala;ma;kota";

            List<string> output = new StringListConverter(input)
                .SetDelimeter(';')
                .Get<string>();

            Assert.AreEqual("ala", output[0]);
            Assert.AreEqual("ma", output[1]);
            Assert.AreEqual("kota", output[2]);
        }
    }
}
