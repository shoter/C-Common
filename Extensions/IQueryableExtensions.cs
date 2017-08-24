using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TSelect> Apply<T, TSelect>(this IQueryable<T> query, IDomSelector<T, TSelect> selector)
            where T : class
        {
            return selector.Select(query);
        }
    }
}
