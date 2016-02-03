using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Commons.Validation.Assertions.Assertors.Common;
using Commons.Validation.Assertions.Assertors.Common.IComparable;

namespace Commons.Validation.Assertions.Managers
{
    public class IComparableAssertionManager<T> : CommonAssertionManager<T> where T : IComparable<T>
    {
        public IComparableAssertionManager(T validatable) : base(validatable)
        {
        }



        public CommonAssertor<T> IsIn(IEnumerable<T> values)
        {
            return new IsInCommonAssertor<T>(Validatable, values);
        }

        public CommonAssertor<T> IsIn(params T[] values)
        {
            return IsIn((IEnumerable<T>) values);
        }

        public CommonAssertor<T> IsNotIn(IEnumerable<T> values)
        {
            return new IsNotInCommonAssertor<T>(Validatable, values);
        }

        public CommonAssertor<T> IsNotIn(params T[] values)
        {
            return IsNotIn((IEnumerable<T>) values);
        }


        public CommonAssertor<T> IsEqualTo(T value)
        {
            return new IsEqualToCommonAssertor<T>(Validatable, value);
        }

        public CommonAssertor<T> IsNotEqualTo(T value)
        {
            return new IsNotEqualToCommonAssertor<T>(Validatable, value);
        }


        public CommonAssertor<T> IsBetween(T rangeStart, T rangeEnd)
        {
            return new IsBetweenIncludeBordersAssertor<T>(Validatable, rangeStart, rangeEnd);
        }

        public CommonAssertor<T> IsBetweenExclude(T rangeStart, T rangeEnd)
        {
            return new IsBetweenExcludeBordersAssertor<T>(Validatable, rangeStart, rangeEnd);
        }


        public CommonAssertor<T> IsLowerThan(T value)
        {
            return new IsLowerThanAssertor<T>(Validatable, value);
        }

        public CommonAssertor<T> IsNotLowerThan(T value)
        {
            return new IsNotLowerThanAssertor<T>(Validatable, value);
        }

        public CommonAssertor<T> IsLowerOrEqualThan(T value)
        {
            return new IsLowerOrEqualThanAssertor<T>(Validatable, value);
        }

        public CommonAssertor<T> IsNotLowerOrEqualThan(T value)
        {
            return new IsNotLowerOrEqualThanAssertor<T>(Validatable, value);
        }


        public CommonAssertor<T> IsGreaterThan(T value)
        {
            return new IsGreaterThanAssertor<T>(Validatable, value);
        }

        public CommonAssertor<T> IsNotGreaterThan(T value)
        {
            return new IsNotGreaterThanAssertor<T>(Validatable, value);
        }

        public CommonAssertor<T> IsGreaterOrEqualThan(T value)
        {
            return new IsGreaterOrEqualThanAssertor<T>(Validatable, value);
        }

        public CommonAssertor<T> IsNotGreaterOrEqualThan(T value)
        {
            return new IsNotGreaterOrEqualThanAssertor<T>(Validatable, value);
        }

        
        public CommonAssertor<T> Match(string pattern)
        {
            return Match(new Regex(pattern));
        }

        public CommonAssertor<T> Match(string pattern, RegexOptions options)
        {
            return Match(new Regex(pattern, options));
        }

        public CommonAssertor<T> Match(Regex regex)
        {
            return new MatchAssertor<T>(Validatable, regex);
        }

    }
}