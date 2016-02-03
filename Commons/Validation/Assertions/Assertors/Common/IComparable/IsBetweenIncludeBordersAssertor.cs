using System;
using Commons.Helpers.Comparasion;

namespace Commons.Validation.Assertions.Assertors.Common.IComparable
{
    public class IsBetweenIncludeBordersAssertor<T> : CommonAssertor<T> where T : IComparable<T>
    {
        public T RangeStart { get; protected set; }
        public T RangeEnd { get; protected set; }


        public IsBetweenIncludeBordersAssertor(T validatable, T rangeStart, T rangeEnd) : base(validatable)
        {
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if ((RangeStart.IsLowerOrEqualThan(Validatable) && Validatable.IsLowerOrEqualThan(RangeEnd)) == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key, RangeStart, RangeEnd });
            }
        }
    }
}