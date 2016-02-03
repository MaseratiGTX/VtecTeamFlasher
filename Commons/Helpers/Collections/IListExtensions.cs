using System.Collections;
using System.Collections.Generic;

namespace Commons.Helpers.Collections
{
    public static class IListExtensions
    {
        public static object[] ToArray(this IList source)
        {
            var itemsCount = source.Count;

            var result = new object[itemsCount];

            for (var index = 0; index < itemsCount; index++)
            {
                result[index] = source[index];
            }

            return result;
        }


        public static IList AddItems<T>(this IList source, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                source.Add(item);
            }

            return source;
        }


        public static bool HasMoreThan<T>(this List<T> source, int minElementsCount) where T : class
        {
            return source.Count > minElementsCount;
        }

        public static bool DoesNotHasMoreThan<T>(this List<T> source, int minElementsCount) where T : class
        {
            return source.HasMoreThan(minElementsCount) == false;
        }
    }
}