using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.StringDecorators
{
    public static class StringDecoratorsArrayExtensions
    {
        public static string Process(this IStringDecorator[] decorators, string input)
        {
            foreach (var decorator in decorators)
                input = decorator.Process(input);
            return input;
        }
    }
}
