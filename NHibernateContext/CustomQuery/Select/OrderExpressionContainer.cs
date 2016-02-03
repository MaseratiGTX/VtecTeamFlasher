using System.Linq.Expressions;

namespace NHibernateContext.CustomQuery.Select
{
    public class OrderExpressionContainer
    {
        public Expression Expression { get; set; }
        public bool IsDescending { get; set; }
    }
}