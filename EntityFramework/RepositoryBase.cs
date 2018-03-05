using Common.EntityFramework.SingleChanges;
using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityFramework
{
    public class RepositoryBase<TEntity, TContext> : RepositoryBaseEntityless<TContext>, IRepository<TEntity>, IDisposable
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
       
        protected DbSet<TEntity> dbSet;

        public DbSet<TEntity> DbSet { get { return dbSet; } }

        public virtual IQueryable<TEntity> Query { get { return dbSet.AsQueryable(); } }

        public RepositoryBase(TContext context) : base(context)
        {
            dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TSelect> Apply<TSelect>(IDomSelector<TEntity, TSelect> selector)
        {
            return Query.Apply(selector);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Query.ToList();
        }

        public virtual TEntity GetById(int? id)
        {
            if (id == null)
                return null;

            return dbSet.Find(id);
        }

        public virtual TEntity GetById(long? id)
        {
            if (id == null)
                return null;

            return dbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual void Remove(int id)
        {
            var entity = GetById(id);
            Remove(entity);
        }

        public virtual void Remove(long id)
        {
            var entity = GetById(id);
            Remove(entity);
        }

        public virtual IQueryable<IGrouping<TKey, TEntity>> GroupBy<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return dbSet.GroupBy(keySelector);
        }

        public virtual bool TryRemove(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                Remove(entity);
                return true;
            }
            return false;
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return dbSet.Select(selector);
        }

        public void RemoveRange(Expression<Func<TEntity, bool>> predicate)
        {
            dbSet.RemoveRange(dbSet.Where(predicate));
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.Where(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.FirstOrDefault(predicate);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.First(predicate);
        }

        public IOrderedQueryable<TEntity> OrderBy<TValue>(Expression<Func<TEntity, TValue>> keySelector)
        {
            return Query.OrderBy(keySelector);
        }

        public IOrderedQueryable<TEntity> OrderByDescending<TValue>(Expression<Func<TEntity, TValue>> keySelector)
        {
            return Query.OrderByDescending(keySelector);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }




        

        public TEntity First()
        {
            return Query.First();
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveSpecific<TSpecific>(TSpecific entity)
            where TSpecific : class, new()
        {
            var dbSet = context.Set<TSpecific>();
            dbSet.Remove(entity);
        }

        public void ReloadEntity<TAnyEntity>(TAnyEntity entity)
            where TAnyEntity : class
        {
            context.Entry(entity).Reload();
        }

        public void ReloadNavigationProperty<TElement>(TEntity entity, Expression<Func<TEntity, ICollection<TElement>>> navigationProperty)
            where TElement : class
        {
            context.Entry(entity).Collection(navigationProperty).Query();
        }

        public IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> predicate)
        {
            return Query.Include(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Any(predicate);
        }

        /// <summary>
        /// Updates one field on one particular record. Also it saved data after operation completion
        /// </summary>
        /// <param name="expression">pointer to the field which need to be updated</param>
        /// <param name="setUnique">actions that will led to setting primary keys</param>
        /// <param name="value">value that will be placed in place pointer by expression</param>
        public void UpdateSingleField<TProp>(Expression<Func<TEntity, TProp>> expression, Action<TEntity> setUnique, TProp value)
        {
            var entity = new TEntity();
            setUnique(entity);

            var memberSelectorExpression = expression.Body as MemberExpression;
            if (memberSelectorExpression != null)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(entity, value, null);
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            else
            {
                throw new NullReferenceException();
            }

            using (var db = new TContext())
            {
                db.Set<TEntity>().Attach(entity);
                db.Entry(entity).Property(expression).IsModified = true;
                db.SaveChanges();
            }
        }


        public void UpdateMany<TOther>(
            IEnumerable<TOther> collection,
            Action<TOther, TEntity> SetUnique,
            params Func<TOther, ISingleChangeExpression<TEntity>>[] expressions)
        {
            using (var db = new TContext())
            {
                foreach (var item in collection)
                {
                    TEntity entity = new TEntity();
                    SetUnique(item, entity);
                    foreach (var expression in expressions)
                        expression(item).Set(entity);

                    db.Set<TEntity>().Attach(entity);
                    foreach (var expression in expressions)
                        expression(item).NotifyAboutChange(db, entity);
                }
                db.SaveChanges();
            }
        }

        public void CreateMany<TOther>(
            IEnumerable<TOther> collection,
            Action<TOther, TEntity> SetUnique,
            params ISingleChangeExpression<TEntity>[] expressions)
        {
            using (var db = new TContext())
            {
                foreach (var item in collection)
                {
                    TEntity entity = new TEntity();
                    SetUnique(item, entity);
                    foreach (var expression in expressions)
                        expression.Set(entity);

                    db.Set<TEntity>().Attach(entity);
                    foreach (var expression in expressions)
                        expression.NotifyAboutNew(db, entity);
                }
                db.SaveChanges();
            }
        }


        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Single(predicate);
        }

        public TEntity SingleOrDefault()
        {
            return DbSet.SingleOrDefault();
        }

        public TEntity Single()
        {
            return DbSet.Single();
        }

        public void SetTimeout(int seconds)
        {
            ((IObjectContextAdapter)context).ObjectContext.CommandTimeout = seconds;
        }

        public TEntity FirstOrDefault()
        {
            return dbSet.FirstOrDefault();
        }

        public void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Where(predicate).ToList();
            foreach (var entity in entities)
                Remove(entity);
        }
    }
}
