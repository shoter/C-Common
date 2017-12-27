using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityFramework.SingleChanges
{
    public class SingleChangeRepository<Context> : ISingleChangeRepository, IDisposable
        where Context : DbContext, new()
    {
        private Context _entities = new Context();

        public SingleChangeRepository()
        {
            _entities.Configuration.AutoDetectChangesEnabled = false;
        }


        public void CreateNew<TEntity>(params ISingleChangeExpression<TEntity>[] singleChanges) where TEntity : class, new()
        {
            var entity = new TEntity();

            _entities.Set<TEntity>().Attach(entity);

            foreach (var singleChange in singleChanges)
            {
                singleChange.Set(entity);
            }

            foreach (var singleChange in singleChanges)
                singleChange.NotifyAboutNew(_entities, entity);

            _entities.Entry(entity).State = EntityState.Added;
        }

        public void UpdateSingleField<TEntity>(Action<TEntity> setUnique, params ISingleChangeExpression<TEntity>[] singleChanges) where TEntity : class, new()
        {
            var entity = new TEntity();
            setUnique(entity);

            _entities.Set<TEntity>().Attach(entity);

            foreach (var singleChange in singleChanges)
            {
                singleChange.Set(entity);
            }

            foreach (var singleChange in singleChanges)
                singleChange.NotifyAboutChange(_entities, entity);
        }

        public void CreateSingeEntity<TEntity>(TEntity entity)
            where TEntity : class
        {
            _entities.Set<TEntity>().Attach(entity);
        }

        public void SaveChanges()
        {
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            if (_entities != null)
            {
                _entities.SaveChanges();
                _entities = null;
            }

        }

        async public Task AsyncDispose(Object threadContext)
        {
            if (_entities != null)
            {
                await _entities.SaveChangesAsync();
                _entities = null;
            }
        }


    }
}
