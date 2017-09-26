using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTests.Expressions
{
    public class NamedTestMethods
    {
        public static void SimpleMethod() { }
        public static int MethodReturningInt() { return 0; }
        public static int MethodReturningIntTakingInt(int a) { return a + 1; }
        public static int Method2ArgumentsReturnsInt(int a, int b) { return a + b; }
    }
}
