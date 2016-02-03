using System;
using System.Linq;
using Commons.Validation.Assertions.Assertors.Common;
using Commons.Validation.Assertions.Assertors.Queryable;
using Commons.Validation.Assertions.Managers;

namespace Commons.Validation.Assertions
{
    public static class AssertionHelper
    {
        public static IComparableAssertionManager<T> AssertThat<T>(T source) where T : IComparable<T>
        {
            return new IComparableAssertionManager<T>(source);
        }


        public static CommonAssertor<T> AssertIsNull<T>(T source)
        {
            return new CommonAssertionManager<T>(source).IsNull();
        }

        public static CommonAssertor<T> AssertIsNotNull<T>(T source)
        {
            return new CommonAssertionManager<T>(source).IsNotNull();
        }

        public static CommonAssertor<T> AssertIsEmpty<T>(T source)
        {
            return new CommonAssertionManager<T>(source).IsEmpty();
        }

        public static CommonAssertor<T> AssertIsNotEmpty<T>(T source)
        {
            return new CommonAssertionManager<T>(source).IsNotEmpty();
        }

        public static CommonAssertor<T> AssertIsNumeric<T>(T source)
        {
            return new CommonAssertionManager<T>(source).IsNumeric();
        }


        public static CommonAssertor<bool> AssertTrue(bool source)
        {
            return AssertThat(source).IsEqualTo(true);
        } 

        public static CommonAssertor<bool> AssertFalse(bool source)
        {
            return AssertThat(source).IsEqualTo(false);    
        } 


        public static QueryableAssertor<T> AssertAny<T>(IQueryable<T> source)
        {
            return new QueryableAssertionManager<T>(source).HasAny();
        }

        public static QueryableAssertor<T> AssertNone<T>(IQueryable<T> source)
        {
            return new QueryableAssertionManager<T>(source).HasNone();
        }
    }
}