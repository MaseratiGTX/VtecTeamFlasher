using System;
using Commons.Helpers.Comparasion;

namespace Commons.Validation.Assertions.Assertors.Common.IComparable
{
    public class IsNotEqualToCommonAssertor<T> : CommonAssertor<T> where T : IComparable<T>
    {
        public T Value { get; protected set; }


        public IsNotEqualToCommonAssertor(T validatable, T vallue) : base(validatable)
        {
            Value = vallue;
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.IsNotEqual(Value) == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key, Value });
            }
        }
    }
}