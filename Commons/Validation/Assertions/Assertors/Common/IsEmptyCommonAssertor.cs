using Commons.Helpers.Objects;

namespace Commons.Validation.Assertions.Assertors.Common
{
    public class IsEmptyCommonAssertor<T> : CommonAssertor<T>
    {
        public IsEmptyCommonAssertor(T validatable) : base(validatable)
        {
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.IsEmpty() == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key });
            }
        }
    }
}