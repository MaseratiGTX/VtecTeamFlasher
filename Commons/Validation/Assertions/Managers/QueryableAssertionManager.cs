using System.Linq;
using Commons.Validation.Assertions.Assertors.Queryable;

namespace Commons.Validation.Assertions.Managers
{
    public class QueryableAssertionManager<T>
    {
        public IQueryable<T> Validatable { get; private set; }



        public QueryableAssertionManager(IQueryable<T> validatable)
        {
            Validatable = validatable;
        }



        public QueryableAssertor<T> HasAny()
        {
            return new HasAnyQueryableAssertor<T>(Validatable);
        }

        public QueryableAssertor<T> HasNone()
        {
            return new HasNoneQueryableAssertor<T>(Validatable);
        }
    }
}