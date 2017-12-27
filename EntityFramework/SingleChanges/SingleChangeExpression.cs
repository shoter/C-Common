using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityFramework.SingleChanges
{
    public class SingleChangeExpression<TEntity, TProp> : ISingleChangeExpression<TEntity>
       where TEntity : class
    {

        private Expression<Func<TEntity, TProp>> expression;
        private TProp value;

        public SingleChangeExpression(Expression<Func<TEntity, TProp>> expression, TProp value)
        {
            this.expression = expression;
            this.value = value;
        }


        public void Set(TEntity entity)
        {

            var memberSelectorExpression = expression.Body as MemberExpression;
            var property = memberSelectorExpression.Member as PropertyInfo;
            property.SetValue(entity, value, null);

        }

        public void NotifyAboutChange(DbContext context, TEntity entity)
        {
            context.Entry(entity).Property(expression).IsModified = true;
        }

        public void NotifyAboutNew(DbContext context, TEntity entity)
        {
            NotifyAboutChange(context, entity);
        }
    }
}
