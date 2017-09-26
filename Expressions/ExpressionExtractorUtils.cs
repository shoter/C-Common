using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Expressions
{
    public class ExpressionExtractor
    {
        public static MethodInfo ExtractMethodInfo(LambdaExpression expression)
        {
            var methodCallExpression = (MethodCallExpression)expression.Body;
            return methodCallExpression.Method;
        }

        public static string ExtractMethodName(LambdaExpression expression)
        {
            return ExtractMethodInfo(expression).Name;
        }
    }
}
