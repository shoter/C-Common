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
    public class ForeignEntityChangeExpression<TEntity, TProp> : ISingleChangeExpression<TEntity>
       where TEntity : class
       where TProp : class
    {

        private Expression<Func<TEntity, TProp>> expression;
        private TProp value;
        private Expression<Func<TProp, ICollection<TEntity>>> collectionExpression;
        private Expression<Func<TEntity, int?>> idExpression;
        public ForeignEntityChangeExpression(Expression<Func<TEntity, TProp>> expression, Expression<Func<TEntity, int?>> idExpression, TProp value, Expression<Func<TProp, ICollection<TEntity>>> collectionExpression)
        {
            this.expression = expression;
            this.value = value;
            this.collectionExpression = collectionExpression;
            this.idExpression = idExpression;
        }


        public void Set(TEntity entity)
        {

            var memberSelectorExpression = expression.Body as MemberExpression;
            var property = memberSelectorExpression.Member as PropertyInfo;
            property.SetValue(entity, value, null);

            memberSelectorExpression = idExpression.Body as MemberExpression;
            property = memberSelectorExpression.Member as PropertyInfo;
            property.SetValue(entity, 0, null);


            memberSelectorExpression = collectionExpression.Body as MemberExpression;
            property = memberSelectorExpression.Member as PropertyInfo;

            ICollection<TEntity> collection = property.GetValue(value) as ICollection<TEntity>;
            collection.Add(entity);
        }

        public void NotifyAboutChange(DbContext context, TEntity entity)
        {
            context.Entry(entity).Property(idExpression).IsModified = true;


            context.Set<TProp>().Attach(value);
            context.Entry(value).State = EntityState.Added;
        }

        public void NotifyAboutNew(DbContext context, TEntity entity)
        {
            NotifyAboutChange(context, entity);
        }
    }
}
