using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityFramework
{
    public interface IGenericRepository : IRepository
    {
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, new();
    }
}
