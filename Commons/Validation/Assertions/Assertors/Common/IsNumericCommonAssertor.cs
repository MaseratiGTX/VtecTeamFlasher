using System;
using System.Linq;

namespace Commons.Validation.Assertions.Assertors.Common
{
    public class IsNumericCommonAssertor<T> : CommonAssertor<T>
    {
        public IsNumericCommonAssertor(T validatable) : base(validatable)
        {
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.ToString().All(Char.IsDigit) == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key });
            }
        }
    }
}