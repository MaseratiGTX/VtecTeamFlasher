using System;
using System.Collections;

namespace Commons.Helpers.Collections
{
    public static class IEnumerableExtensions
    {
        public static bool HasZeroLength(this IEnumerable source)
        {
            return source.GetEnumerator().MoveNext() == false;
        }


        public static void Each<T>(this IEnumerable enumerable, Action<T> action)
        {
            foreach (var item in enumerable) action((T) item);
        }
    }
}