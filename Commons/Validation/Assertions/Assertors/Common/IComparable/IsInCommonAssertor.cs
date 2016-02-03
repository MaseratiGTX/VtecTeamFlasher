using System;
using System.Collections.Generic;
using Commons.Helpers.Objects;

namespace Commons.Validation.Assertions.Assertors.Common.IComparable
{
    public class IsInCommonAssertor<T> : CommonAssertor<T> where T : IComparable<T>
    {
        public IEnumerable<T> Values { get; protected set; }


        public IsInCommonAssertor(T validatable, IEnumerable<T> values) : base(validatable)
        {
            Values = values;
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Validatable.In(Values) == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key, Values });
            }
        }
    }
}