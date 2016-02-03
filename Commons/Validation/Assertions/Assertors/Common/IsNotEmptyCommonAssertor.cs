using Commons.Helpers.Objects;

namespace Commons.Validation.Assertions.Assertors.Common
{
    public class IsNotEmptyCommonAssertor<T> : CommonAssertor<T>
    {
        public IsNotEmptyCommonAssertor(T validatable) : base(validatable)
        {
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.IsNotEmpty() == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key });
            }
        }
    }
}