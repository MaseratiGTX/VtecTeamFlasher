using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Commons.Helpers.Objects;
using NHibernate;
using NHibernateContext.CustomQuery.Helpers;
using NHibernateContext.CustomQuery.Select.LockingModes;

namespace NHibernateContext.CustomQuery.Select
{
    public class SelectQuery<T> where T: class
    {
        private ISession Session { get; set; }

        private List<Expression<Func<T, bool>>> WhereExpressions { get; set; }
        private List<OrderExpressionContainer> OrderExpressions { get; set; }
        private LockingHints QueryLockHints { get; set; }
        


        public SelectQuery(ISession session)
        {
            Session = session;

            WhereExpressions = new List<Expression<Func<T, bool>>>();
            OrderExpressions = new List<OrderExpressionContainer>();
            QueryLockHints = null;
        }



        public SelectQuery<T> Where(Expression<Func<T, bool>> expression)
        {
            WhereExpressions.Add(expression);

            return this;
        }

        public SelectQuery<T> Using(IEnumerable<Expression<Func<T, bool>>> expressions)
        {
            if (expressions.IsEmpty()) return this;
            
            WhereExpressions.AddRange(expressions);

            return this;
        }



        public SelectQuery<T> OrderBy<F>(Expression<Func<T, F>> expression)
        {
            OrderExpressions.Add(new OrderExpressionContainer {Expression = expression, IsDescending = false});

            return this;
        }

        public SelectQuery<T> OrderByDescending<F>(Expression<Func<T, F>> expression)
        {
            OrderExpressions.Add(new OrderExpressionContainer { Expression = expression, IsDescending = true });

            return this;
        }

        public SelectQuery<T> Using(IEnumerable<OrderExpressionContainer> expressions)
        {
            if (expressions.IsEmpty()) return this;

            OrderExpressions.AddRange(expressions);

            return this;
        }



        public SelectQuery<T> With(LockingHints lockHints)
        {
            QueryLockHints = lockHints;

            return this;
        }

        public SelectQuery<T> WithoutLock()
        {
            QueryLockHints = null;

            return this;
        }



        public List<T> List(int? maxResultCount = null)
        {
            var queryBuilder = new NHibernateQueryBuilder<T>().BuildQuery(WhereExpressions, OrderExpressions);

            var queryResults = Session
                    .CreateQuery(queryBuilder.QueryString)
                    .WithParameters(queryBuilder.QueryParameters)
                    .WithLockMode(queryBuilder.Alias, QueryLockHints)
                    .WithMaxResultCount(maxResultCount);

            return queryResults.List().Cast<T>().ToList();
        }


        public T SingleOrDefault()
        {
            return List(2).SingleOrDefault();
        }

        public T FirstOrDefault()
        {
            return List(1).FirstOrDefault();
        }
    }
}