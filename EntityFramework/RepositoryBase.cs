using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityFramework
{
    public class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        protected TContext context;
        protected DbSet<TEntity> dbSet;

        public DbSet<TEntity> DbSet { get { return dbSet; } }

        public virtual IQueryable<TEntity> Query { get { return dbSet.AsQueryable(); } }

        public RepositoryBase(TContext context)
        {
            this.context = context;
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
            dbSet.Remove(entity);
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

        public void SaveChanges()
        {
#if DEBUG
            try
            {
#endif
                context.SaveChanges();
#if DEBUG
            }
            catch(Exception e)
            {
                throw e; //sometimes there are errors which have properties that are only seen by viewing 'e' variable. 
                //Weird way but only good way to deal with that.
            }
#endif
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public TEntity First()
        {
            return Query.First();
        }

        public virtual void Remove(TEntity  entity)
        {
            DbSet.Remove(entity);
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
    }
}
