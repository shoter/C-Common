using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityFramework
{
    public class RepositoryBaseEntityless<TContext> : IDisposable
        where TContext : DbContext, new()
    {
        protected TContext context;

        public RepositoryBaseEntityless(TContext context)
        {
            this.context = context;
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
            catch (Exception e)
            {
                throw e; //sometimes there are errors which have properties that are only seen by viewing 'e' variable. 
                //Weird way but only good way to deal with that.
            }
#endif
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
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
    }
}
