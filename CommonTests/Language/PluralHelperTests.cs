using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Language;

namespace CommonTests.Language
{
    [TestClass]
    public class PluralHelperTests
    {
        [TestMethod]
        public void isPlural_Singular_Test()
        {
            Assert.IsFalse(PluralHelper.isPlural(1));
        }

        [TestMethod]
        public void isPlural_Plural_Test()
        {
            Assert.IsTrue(PluralHelper.isPlural(5));
        }

        [TestMethod]
        public void isPlural_Plural2_Test()
        {
            Assert.IsTrue(PluralHelper.isPlural(24));
        }

        [TestMethod]
        public void Else_Singular_Test()
        {
            Assert.AreEqual("S", PluralHelper.Else(1, "S", "P"));
        }

        [TestMethod]
        public void Else_Plural_Test()
        {
            Assert.AreEqual("P", PluralHelper.Else(123, "S", "P"));
        }

        [TestMethod]
        public void Else_Plural2_Test()
        {
            Assert.AreEqual("P", PluralHelper.Else(321, "S", "P"));
        }
    }
}
