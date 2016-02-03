using System;
using Commons.Helpers.Comparasion;

namespace Commons.Validation.Assertions.Assertors.Common.IComparable
{
    public class IsGreaterOrEqualThanAssertor<T> : CommonAssertor<T> where T : IComparable<T>
    {
        public T Value { get; protected set; }


        public IsGreaterOrEqualThanAssertor(T validatable, T value) : base(validatable)
        {
            Value = value;
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.IsGreaterOrEqualThan(Value) == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key, Value });
            }
        }
    }
}