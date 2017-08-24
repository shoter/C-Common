using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class IEnumerableExtensions
    {
        static Random rand = new Random();

        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> collection, int count)
        {
            return collection
                .OrderBy(item => rand.Next())
                .Take(count);
        }
    }
}
