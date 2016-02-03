using Commons.Helpers.Objects;

namespace Commons.Validation.Assertions.Assertors.Common
{
    public class IsNotNullCommonAssertor<T> : CommonAssertor<T>
    {
        public IsNotNullCommonAssertor(T validatable) : base(validatable)
        {
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.IsNotNull() == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key });
            }
        }
    }
}