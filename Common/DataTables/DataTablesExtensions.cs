using DataTables.AspNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTables
{
    public static class DataTablesExtensions
    {
        public static IColumn Get(this IEnumerable<IColumn> collection, string columnName)
        {
            return collection.FirstOrDefault(c => c.Name == columnName);
        }

        public static IOrderedQueryable<T> OrderBy<T, TProp>(this IQueryable<T> query, Expression<Func<T, TProp>> expr, ISort sort)
        {
            if (sort.Direction == SortDirection.Ascending)
                return query.OrderBy(expr);
            else if (sort.Direction == SortDirection.Descending)
                return query.OrderByDescending(expr);

            throw new Exception();
        }

        public static IOrderedQueryable<T> ThenBy<T, TProp>(this IOrderedQueryable<T> query, Expression<Func<T, TProp>> expr, ISort sort)
        {
            if (sort.Direction == SortDirection.Ascending)
                return query.ThenBy(expr);
            else if (sort.Direction == SortDirection.Descending)
                return query.ThenByDescending(expr);

            throw new Exception();
        }
    }
}
