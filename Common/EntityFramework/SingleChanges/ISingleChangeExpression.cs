using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityFramework.SingleChanges
{
    public interface ISingleChangeExpression<TEntity>
       where TEntity : class
    {
        void Set(TEntity entity);
        void NotifyAboutChange(DbContext context, TEntity entity);
        void NotifyAboutNew(DbContext context, TEntity entity);

    }
}
