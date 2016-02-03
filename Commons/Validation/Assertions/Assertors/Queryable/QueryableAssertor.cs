using System.Linq;

namespace Commons.Validation.Assertions.Assertors.Queryable
{
    public abstract class QueryableAssertor<T> : BaseAssertor
    {
        public IQueryable<T> Validatable { get; protected set; }


        protected QueryableAssertor(IQueryable<T> validatable)
        {
            Validatable = validatable;
        }
    }
}