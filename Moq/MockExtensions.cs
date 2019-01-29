using Moq.Language.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Moq
{
    public static class MockExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReturnsResult<TMock> ReturnsTaskResult<TMock, TReturnType>(this ISetup<TMock, Task<TReturnType>> setup, TReturnType value)
            where TMock: class
        {
            return setup.Returns(Task.FromResult(value));
        }
    }
}
