using System;
using System.Linq.Expressions;

namespace NHibernateContext.CustomQuery.Helpers
{
    public static class ExpressionExtensions
    {
        public static ExpressionValue Evaluate(this Expression source)
        {
            if(source.NodeType == ExpressionType.Constant)
            {
                return new ExpressionValue(((ConstantExpression) source).Value);
            }


            if (source.CouldNOTBeEvaluted()) return new ExpressionValue();


            try
            {
                return new ExpressionValue(Expression.Lambda(source).Compile().DynamicInvoke());
            }
            catch (Exception)
            {
                return new ExpressionValue();
            }
        }

        private static bool CouldNOTBeEvaluted(this Expression source)
        {
            var lambdaExpression = source as LambdaExpression;
            
            if(lambdaExpression != null)
            {
                return lambdaExpression.Body.CouldNOTBeEvaluted();
            }

            
            var binaryExpression = source as BinaryExpression;
            
            if(binaryExpression != null)
            {
                return binaryExpression.Left.CouldNOTBeEvaluted() || binaryExpression.Right.CouldNOTBeEvaluted();
            }


            var memberExpression = source as MemberExpression;

            if (memberExpression != null)
            {
                return memberExpression.Expression.CouldNOTBeEvaluted();
            }


            var parameterExpression = source as ParameterExpression;

            if (parameterExpression != null)
            {
                return true;
            }

            return false;
        }
    }
}