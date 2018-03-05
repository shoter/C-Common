using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class IListExtension
    {
        /// <summary>
        /// Searches for element inside list and returns it. It removes found element from the list
        public static T TakeFirst<T>(this IList<T> list, Func<T, bool> predicate)
        {
            var element = list.First(predicate);
            list.Remove(element);
            return element;
        }

        public static T TakeFirst<T>(this IList<T> list)
        {
            var element = list.First();
            list.Remove(element);
            return element;
        }

        public static bool Remove<T>(this IList<T> enumerable, Func<T, bool> predicate)
        {
            var elements = enumerable.Where(predicate).ToList();
            foreach (var element in elements)
                enumerable.Remove(element);

            return elements.Count() > 0;
        }
    }
}
