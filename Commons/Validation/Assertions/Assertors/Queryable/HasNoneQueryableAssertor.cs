using System.Linq;
using Commons.Helpers;

namespace Commons.Validation.Assertions.Assertors.Queryable
{
    public class HasNoneQueryableAssertor<T> : QueryableAssertor<T>
    {
        public HasNoneQueryableAssertor(IQueryable<T> validatable) : base(validatable)
        {
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.None() == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key });
            }
        }
    }
}