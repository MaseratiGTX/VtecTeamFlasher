namespace NHibernateContext.CustomQuery.Helpers
{
    public class ExpressionValue
    {
        public bool HasValue { get; private set; }
        public object Value { get; private set; }

        
        public ExpressionValue()
        {
            HasValue = false;
            Value = null;
        }

        public ExpressionValue(object value)
        {
            HasValue = true;
            Value = value;
        }
    }
}