using System;
using Commons.Helpers.Objects;

namespace Commons.Helpers.Comparasion
{
    public static class IComparableExtensions
    {
        public static bool IsEqual<T>(this T source, T value) where T : IComparable<T>
        {
            if (source.IsNull())
            {
                return value.IsNull();
            }

            return source.CompareTo(value) == 0;
        }

        public static bool IsNotEqual<T>(this T source, T value) where T : IComparable<T>
        {
            return source.IsEqual(value) == false;
        }


        public static bool IsLowerThan<T>(this T source, T value) where T : IComparable<T>
        {
            return source.CompareTo(value) < 0;
        }

        public static bool IsLowerOrEqualThan<T>(this T source, T value) where T : IComparable<T>
        {
            return source.CompareTo(value) <= 0;
        }


        public static bool IsGreaterThan<T>(this T source, T value) where T : IComparable<T>
        {
            return source.CompareTo(value) > 0;
        }

        public static bool IsGreaterOrEqualThan<T>(this T source, T value) where T : IComparable<T>
        {
            return source.CompareTo(value) >= 0;
        }
    }
}