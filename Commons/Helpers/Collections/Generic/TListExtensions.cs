using System.Collections.Generic;

namespace Commons.Helpers.Collections.Generic
{
    public static class TListExtensions
    {
        public static List<T> AddItem<T>(this List<T> source, T item) where T : class
        {
            source.Add(item);

            return source;
        }

        public static List<T> AddItems<T>(this List<T> source, params T[] items) where T : class
        {
            return source.AddItems((IEnumerable<T>)items);
        }

        public static List<T> AddItems<T>(this List<T> source, IEnumerable<T> items) where T : class
        {
            foreach (var item in items)
            {
                source.Add(item);
            }

            return source;
        }
    }
}