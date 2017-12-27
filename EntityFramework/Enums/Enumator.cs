using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityFramework.Enums
{
    public class Enumator<TEntity, TEnum, TContext> : IDisposable
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        private readonly IRepository<TEntity> repository;

        public Enumator()
        {
            repository = new GenericRepository<TEntity, TContext>(new TContext());
        }

        public Enumator<TEntity, TEnum, TContext> CreateNewIfAble<TName, TValue>(Action<TEntity, TName> setName, Action<TEntity, TValue> setValue,
            Func<TEnum, TName> getName, Func<TEnum, TValue> getValue,
            Func<TEntity, TEnum, bool> isTheSame)
        {
            var all = repository.GetAll();

            foreach (TEnum val in Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
            {
                if (all.Any(entity => isTheSame(entity, val)))
                    continue;

                var name = getName(val);
                var value = getValue(val);

                TEntity newEntity = new TEntity();
                setName(newEntity, name);
                setValue(newEntity, value);

                repository.Add(newEntity);
            }

            repository.SaveChanges();
            return this;
        }

        public Enumator<TEntity, TEnum, TContext> CreateNewIfAble()
        {
            var all = repository.GetAll();

            foreach (TEnum val in Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
            {
                if (all.Any(entity => ((dynamic)entity).ID == (int)((dynamic)val)))
                    continue;

                string name = val.ToString();
                int value = (int)((dynamic)val);

                TEntity newEntity = new TEntity();
                ((dynamic)newEntity).Name = name;
                ((dynamic)newEntity).ID = value;

                repository.Add(newEntity);
            }

            repository.SaveChanges();
            return this;
        }

        bool disposed = false;
        public void Dispose()
        {
            if (disposed == false)
                repository.Dispose();
            disposed = true;
        }
    }
}
