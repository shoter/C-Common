using Common.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonTests.Expressions
{
    [TestClass]
    public class ExpressionExtractorTests
    {
        [TestMethod]
        public void ExtractMethodNameBasicTest()
        {
            Expression<Action> expression = () => NamedTestMethods.SimpleMethod();
            Assert.AreEqual("SimpleMethod", ExpressionExtractor.ExtractMethodName(expression));
        }

        [TestMethod]
        public void ExtractMethodNamesArgumentsTests()
        {
            {
                Expression<Func<int>> expression = () => NamedTestMethods.MethodReturningInt();
                Assert.AreEqual("MethodReturningInt", ExpressionExtractor.ExtractMethodName(expression));
            }

            {
                Expression<Func<int, int>> expression = (a) => NamedTestMethods.MethodReturningIntTakingInt(a);
                Assert.AreEqual("MethodReturningIntTakingInt", ExpressionExtractor.ExtractMethodName(expression));
            }

            {
                Expression<Func<int, int, int>> expression = (a, b) => NamedTestMethods.Method2ArgumentsReturnsInt(a, b);
                Assert.AreEqual("Method2ArgumentsReturnsInt", ExpressionExtractor.ExtractMethodName(expression));
            }
        }
    }
}
