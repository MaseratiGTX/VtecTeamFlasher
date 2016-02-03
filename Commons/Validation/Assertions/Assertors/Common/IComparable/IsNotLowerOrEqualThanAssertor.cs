using System;
using Commons.Helpers.Comparasion;

namespace Commons.Validation.Assertions.Assertors.Common.IComparable
{
    public class IsNotLowerOrEqualThanAssertor<T> : CommonAssertor<T> where T : IComparable<T>
    {
        public T Value { get; protected set; }


        public IsNotLowerOrEqualThanAssertor(T validatable, T value) : base(validatable)
        {
            Value = value;
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.IsLowerOrEqualThan(Value))
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key, Value });
            }
        }
    }
}