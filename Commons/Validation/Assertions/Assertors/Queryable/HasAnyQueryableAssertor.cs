using System.Linq;

namespace Commons.Validation.Assertions.Assertors.Queryable
{
    public class HasAnyQueryableAssertor<T> : QueryableAssertor<T>
    {
        public HasAnyQueryableAssertor(IQueryable<T> validatable) : base(validatable)
        {
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.Any() == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key });
            }
        }
    }
}