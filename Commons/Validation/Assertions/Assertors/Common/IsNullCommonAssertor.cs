using Commons.Helpers.Objects;

namespace Commons.Validation.Assertions.Assertors.Common
{
    public class IsNullCommonAssertor<T> : CommonAssertor<T>
    {
        public IsNullCommonAssertor(T validatable) : base(validatable)
        {
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.IsNull() == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key });
            }
        }
    }
}