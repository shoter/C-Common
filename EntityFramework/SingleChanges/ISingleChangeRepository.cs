using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityFramework.SingleChanges
{
    public interface ISingleChangeRepository : IDisposable
    {
        void UpdateSingleField<TEntity>(Action<TEntity> setUnique, params ISingleChangeExpression<TEntity>[] singleChanges)
            where TEntity : class, new();

        void SaveChanges();
    }
}
