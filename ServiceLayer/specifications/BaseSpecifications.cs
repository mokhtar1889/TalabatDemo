using DomainLayer.Contracts;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {

        protected BaseSpecifications(Expression<Func<TEntity, bool>>? criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {

            OrderBy = orderByExpression;
        }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByExpressionDescending)
        {

            OrderByDescending = orderByExpressionDescending;
        }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpressions) {

            IncludeExpressions.Add(includeExpressions);
        }

        public int? Skip { get; private set; }
        public int? Take { get; private set; }
        public bool IsPaginated { get; set; }
        protected void ApplyPagination(int pageSize, int pageIndex) {

            IsPaginated = true;
            Take = pageSize;
            Skip = (pageIndex-1) * pageSize;
        }
    }
}
