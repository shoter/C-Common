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
    public class StringConverterTests
    {
        [TestMethod]
        public void ConvertStringToIntTest()
        {
            string input = "123";

            var output = StringConverter.ConvertString<int>(input);

            Assert.AreEqual(123, output);
        }

        [TestMethod]
        public void ConvertStringToDoubleTest()
        {
            string input = "123.343";

            var output = StringConverter.ConvertString<double>(input);

            Assert.AreEqual(123.343, output);
        }
    }
}
