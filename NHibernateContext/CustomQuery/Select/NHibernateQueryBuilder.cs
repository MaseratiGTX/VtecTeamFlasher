using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernateContext.CustomQuery.Helpers;

namespace NHibernateContext.CustomQuery.Select
{
    public class NHibernateQueryBuilder<T> where T: class 
    {
        public string Alias { get; private set; }
        public string QueryString { get; private set; }
        public List<NamedParameter> QueryParameters { get; private set; }
        
        
        public NHibernateQueryBuilder()
        {
            InitializeBuilder();
        }


        private void InitializeBuilder()
        {
            Alias = "x";
            QueryString = "SELECT" + " " + Alias + " " + "FROM" + " " + typeof (T) + " " + Alias;
            QueryParameters = new List<NamedParameter>();
        }



        public NHibernateQueryBuilder<T> BuildQuery(ICollection<Expression<Func<T, bool>>> whereExpressions, ICollection<OrderExpressionContainer> orderExpressions)
        {
            InitializeBuilder();
            

            if (whereExpressions.Count == 0) return this;
            
            
            const string whereExpressionsConcatinationElement = " " + "AND" + " ";

            var whereElement = whereExpressions.Aggregate(string.Empty, (current, expression) => current + TransformWhereExpressionToHQL(expression) + whereExpressionsConcatinationElement);

            QueryString += " " + "WHERE" + " " + whereElement.Substring(0, whereElement.Length - (whereExpressionsConcatinationElement).Length);


            
            if (orderExpressions.Count == 0) return this;


            const string orderExpressionsConcatinationElement = "," + " ";

            var orderElement = orderExpressions.Aggregate(string.Empty, (current, orderExpression) => current + TransformOrderExpressionToHQL(orderExpression.Expression, orderExpression.IsDescending) + orderExpressionsConcatinationElement);

            QueryString += " " + "ORDER BY" + " " + orderElement.Substring(0, orderElement.Length - (orderExpressionsConcatinationElement).Length);


            return this;
        }


        private string TransformWhereExpressionToHQL(Expression expression)
        {
            if(expression.NodeType == ExpressionType.Lambda)
            {
                return "(" + TransformWhereExpressionToHQL(((LambdaExpression) expression).Body) + ")";
            }
            

            if(expression.NodeType == ExpressionType.Call)
            {
                var methodCallExpression = (MethodCallExpression) expression;

                if (methodCallExpression.Method.Name == InConditionMethodContainer.IsInMethodName)
                {
                    var parameterEvaluationResult = methodCallExpression.Arguments[1].Evaluate();
                    
                    if(parameterEvaluationResult.HasValue)
                    {
                        var parameter = QueryParameters.AddParameter(parameterEvaluationResult.Value);

                        return TransformWhereExpressionToHQL(methodCallExpression.Arguments[0]) + " " + "IN" + " " + "(" + ":" + parameter.Name + ")";
                    }
                }

                if (methodCallExpression.Method.Name == InConditionMethodContainer.IsNotInMethodName)
                {
                    var parameterEvaluationResult = methodCallExpression.Arguments[1].Evaluate();
                    
                    if(parameterEvaluationResult.HasValue)
                    {
                        var parameter = QueryParameters.AddParameter(parameterEvaluationResult.Value);

                        return TransformWhereExpressionToHQL(methodCallExpression.Arguments[0]) + " " + "NOT IN" + " " + "(" + ":" + parameter.Name + ")";
                    }
                }
            }


            if(expression.NodeType == ExpressionType.Equal)
            {                
                var leftPartTransformed = TransformWhereExpressionToHQL(((BinaryExpression) expression).Left);


                var rightPartExpression = ((BinaryExpression) expression).Right;
                
                var rightPartValue = rightPartExpression.Evaluate();
                
                if(rightPartValue.HasValue)
                {
                    if(rightPartValue.Value == null)
                    {
                        return leftPartTransformed + " " + "IS NULL";
                    }
                    
                    var parameter = QueryParameters.AddParameter(rightPartValue.Value);

                    return leftPartTransformed + " " + "=" + " " + ":" + parameter.Name;
                }
                
                return leftPartTransformed + " " + "=" + " " + TransformWhereExpressionToHQL(rightPartExpression);
            }

            if (expression.NodeType == ExpressionType.NotEqual)
            {
                var leftPartTransformed = TransformWhereExpressionToHQL(((BinaryExpression)expression).Left);


                var rightPartExpression = ((BinaryExpression)expression).Right;

                var expressionValue = rightPartExpression.NodeType == ExpressionType.Constant ? new ExpressionValue(((ConstantExpression)rightPartExpression).Value) : rightPartExpression.Evaluate();

                if (expressionValue.HasValue)
                {
                    if (expressionValue.Value == null)
                    {
                        return leftPartTransformed + " " + "IS NOT NULL";
                    }

                    var parameter = QueryParameters.AddParameter(expressionValue.Value);

                    return leftPartTransformed + " " + "<>" + " " + ":" + parameter.Name;
                }

                return leftPartTransformed + " " + "<>" + " " + TransformWhereExpressionToHQL(rightPartExpression);
            }


            if(expression.NodeType == ExpressionType.GreaterThan)
            {
                var leftPartTransformed = TransformNOTNullWhereExpression(((BinaryExpression)expression).Left);
                var rightPartTransformed = TransformNOTNullWhereExpression(((BinaryExpression)expression).Right);
                
                return leftPartTransformed + " " + ">" + " " + rightPartTransformed;
            }

            if(expression.NodeType == ExpressionType.GreaterThanOrEqual)
            {
                var leftPartTransformed = TransformNOTNullWhereExpression(((BinaryExpression)expression).Left);
                var rightPartTransformed = TransformNOTNullWhereExpression(((BinaryExpression)expression).Right);

                return leftPartTransformed + " " + ">=" + " " + rightPartTransformed;
            }


            if (expression.NodeType == ExpressionType.LessThan)
            {
                var leftPartTransformed = TransformNOTNullWhereExpression(((BinaryExpression)expression).Left);
                var rightPartTransformed = TransformNOTNullWhereExpression(((BinaryExpression)expression).Right);

                return leftPartTransformed + " " + "<" + " " + rightPartTransformed;
            }

            if (expression.NodeType == ExpressionType.LessThanOrEqual)
            {
                var leftPartTransformed = TransformNOTNullWhereExpression(((BinaryExpression)expression).Left);
                var rightPartTransformed = TransformNOTNullWhereExpression(((BinaryExpression)expression).Right);

                return leftPartTransformed + " " + "<=" + " " + rightPartTransformed;
            }


            if (expression.NodeType == ExpressionType.AndAlso)
            {
                return "(" + TransformWhereExpressionToHQL(((BinaryExpression)expression).Left) + ")" + " " + "AND" + " " + "(" + TransformWhereExpressionToHQL(((BinaryExpression)expression).Right) + ")";
            }

            if (expression.NodeType == ExpressionType.OrElse)
            {
                return "(" + TransformWhereExpressionToHQL(((BinaryExpression)expression).Left) + ")" + " " + "OR" + " " + "(" + TransformWhereExpressionToHQL(((BinaryExpression)expression).Right) + ")";
            }


            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                return TransformWhereExpressionToHQL(((MemberExpression)expression).Expression) + "." + ((MemberExpression)expression).Member.Name;
            }

            if (expression.NodeType == ExpressionType.Parameter)
            {
                return Alias;
            }

            if (expression.NodeType == ExpressionType.Constant)
            {
                var parameter = QueryParameters.AddParameter(((ConstantExpression) expression).Value);

                return ":" + parameter.Name;
            }

            throw new Exception("Переданное выражение слишком сложное для преобразования в HQL - преобразование не может быть выполнено.");
        }


        private string TransformNOTNullWhereExpression(Expression expression)
        {
            var expressionValue = expression.Evaluate();

            if (expressionValue.HasValue)
            {
                if (expressionValue.Value == null)
                {
                    throw new NullReferenceException("Значение не может быть Null");
                }

                var parameter = QueryParameters.AddParameter(expressionValue.Value);

                return ":" + parameter.Name;
            }
            
            return TransformWhereExpressionToHQL(expression);
        }

        private string TransformOrderExpressionToHQL(Expression expression, bool isDescending)
        {
            if(expression.NodeType == ExpressionType.Lambda)
            {
                return TransformOrderExpressionToHQL(((LambdaExpression) expression).Body, isDescending);
            }


            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                return TransformOrderExpressionToHQL(((MemberExpression)expression).Expression, isDescending) + "." + ((MemberExpression)expression).Member.Name + (isDescending ? " " + "DESC" : string.Empty);
            }

            if (expression.NodeType == ExpressionType.Parameter)
            {
                return Alias;
            }

            throw new Exception("Переданное выражение слишком сложное для преобразования в HQL - преобразование не может быть выполнено.");
        }
    }
}