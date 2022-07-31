using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserManagementSystem.Common
{
    public static class IQueriableExtension
    {
        public static IQueryable<T> GetPaged<T>(this IQueryable<T> query, PageItem page) where T : class
        {          

            page.PageCount = (query.Count() + page.PageSize - 1) / page.PageSize;

            int position = (page.CurrentPage - 1) * page.PageSize;
            return query.Skip(position).Take(page.PageSize);
           
        }

        public static IQueryable<T> GetOrdered<T>(this IQueryable<T> query, OrderItem order) where T : class
        {
            if (order.Key == null)
                return query;
            Expression<Func<T, string>> parameter = CreateSelectorExpression<T>(order.Key);
            
            return order.Direction.Equals(Direction.Asc) ? query.OrderBy(CreateSelectorExpression<T>(order.Key)) : 
                                               query.OrderByDescending(CreateSelectorExpression<T>(order.Key));
        }

        public static Expression<Func<T, string>> CreateSelectorExpression<T>(string propertyName)
        {
            try
            {
                var parameterExpression = Expression.Parameter(typeof(T));
                return (Expression<Func<T, string>>)Expression.Lambda(Expression.PropertyOrField(parameterExpression, propertyName),
                                                                        parameterExpression);
            }
            catch(Exception)
            {
                throw new AppException(propertyName + " is not valid order property.");
            }
        }
    }
}
