using System;
using Commons.Helpers.Comparasion;

namespace Commons.Validation.Assertions.Assertors.Common.IComparable
{
    public class IsEqualToCommonAssertor<T> : CommonAssertor<T> where T : IComparable<T>
    {
        public T Value { get; protected set; }


        public IsEqualToCommonAssertor(T validatable, T vallue) : base(validatable)
        {
            Value = vallue;
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.IsEqual(Value) == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key, Value });
            }
        }


        public override void Return<TReturnException>(string messageFormat)
        {
            if (Validatable.IsEqual(Value) == false)
            {
                ReturnResult<TReturnException>(null, messageFormat, null, new object[] { Value });
            }
        }
    }
}