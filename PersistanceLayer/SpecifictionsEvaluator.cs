using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceLayer
{
    public static class SpecifictionsEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> inputQuery , ISpecifications<TEntity , TKey> specifications)where TEntity:BaseEntity<TKey> {

            var query = inputQuery;

            if (specifications.Criteria is not null) {

                query = query.Where(specifications.Criteria);
            }
            if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Count > 0) {

                query = specifications.IncludeExpressions.Aggregate(query, (current, IncludeExpression) => current.Include(IncludeExpression));
            
            }

            return query;
        
        }
    }
}
