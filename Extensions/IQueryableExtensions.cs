using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public static List<TResult> ToList<T, TResult>(this IQueryable<T> query, Func<T, TResult> selector)
        {
            return query.ToList()
                .Select(selector)
                .ToList();
        }

        

        public static IQueryable<T> TakeRandom<T>(this IQueryable<T> collection, int count)
        {
            return collection
                .OrderBy(item => Guid.NewGuid())
                .Take(count);
        }


    }
}
