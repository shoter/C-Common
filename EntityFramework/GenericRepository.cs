using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityFramework
{
    public class GenericRepository<TContext> : IGenericRepository
        where TContext : DbContext, new()
    {
        private readonly TContext context;

        public GenericRepository(TContext context)
        {
            this.context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() 
            where TEntity : class, new()
        {
            return new GenericRepository<TEntity, TContext>(context);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }

    public class GenericRepository<TEntity, TContext> : RepositoryBase<TEntity, TContext>, IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public GenericRepository(TContext context) : base(context)
        {
        }
    }
}
