using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.EntityFramework
{

    public interface IRepository
    {
        void SaveChanges();
        /// <summary>
        /// 
        /// </summary>
        /// <example>await context.SaveChangesAsync()</example>
        Task SaveChangesAsync();
    }

    public interface IRepository<TEntity> : IRepository
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Query { get; }
        /// <summary>
        /// Returns null if entity is not found
        /// </summary>
        TEntity GetById(int? id);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        void AddRange(IEnumerable<TEntity> entities);
        void Add(TEntity t);
        void Remove(int id);
        void Remove(TEntity t);
        void RemoveRange(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity t);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        TEntity First();
        IQueryable<TSelect> Apply<TSelect>(IDomSelector<TEntity, TSelect> selector);



        IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> predicate);
        IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector);

        IOrderedQueryable<TEntity> OrderByDescending<TValue>(Expression<Func<TEntity, TValue>> keySelector);

        IOrderedQueryable<TEntity> OrderBy<TValue>(Expression<Func<TEntity, TValue>> keySelector);

        void ReloadEntity<TAnyEntity>(TAnyEntity entity)
            where TAnyEntity : class;

        void ReloadNavigationProperty<TElement>(TEntity entity, Expression<Func<TEntity, ICollection<TElement>>> navigationProperty)
            where TElement : class;

        /// <summary>
        /// Update single column of single(!) row in database
        /// </summary>
        /// <param name="expression">Expression which will point on the column</param>
        /// <param name="setUnique">Expression which determine SINGLE row in table</param>
        /// <param name="value">value to which set the column</param>
        /// <example>UpdateSingleField(x => x.LastActionDateTime, x => x.ID = userID, DateTime.Now)</example>
        void UpdateSingleField<TProp>(Expression<Func<TEntity, TProp>> expression, Action<TEntity> setUnique, TProp value);
    }
}
