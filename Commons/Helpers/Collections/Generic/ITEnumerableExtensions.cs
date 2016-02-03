using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Objects;

namespace Commons.Helpers.Collections.Generic
{
    public static class ITEnumerableExtensions
    {
        public static IEnumerable<T> Concat<T>(this T source, IEnumerable<T> collection)
        {
            return new [] {source}.Concat(collection);
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, params T[] items)
        {
            return source.Concat((IEnumerable<T>) items);
        } 

        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable) action(item);
        }

        

        public static IEnumerable<T> Evict<T>(this IEnumerable<T> source, Func<T, bool> predicate) 
        {
            return source.Where(x => predicate.Invoke(x) == false);
        }

        public static IEnumerable<T> EvictNull<T>(this IEnumerable<T> source) 
        {
            return source.Evict(x => (object)x == null);
        }

        public static IEnumerable<T> EvictEmpty<T>(this IEnumerable<T> source) 
        {
            return source.Evict(x => x.IsEmpty());
        }

        public static IEnumerable<T> NotEmpty<T>(this IEnumerable<T> source)
        {
            return source.EvictEmpty();
        }


        public static IEnumerable<T> DistinctBy<T, F>(this IEnumerable<T> source, Func<T, F> keySelector)
        {
            var keySet = new HashSet<F>();

            return source.Where(element => keySet.Add(keySelector(element)));
        }


        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, IComparer<T> comparer)
        {
            return source.OrderBy(x => x, comparer);
        }

        public static IEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, IEnumerable<TKey> keys, Func<T, TKey> keySelector)
        {
            var resultLookup = source.ToLookup(keySelector);

            return keys.Distinct().SelectMany(key => resultLookup[key]);
        }


        public static string Inline<T>(this IEnumerable<T> source, string separator)
        {
            return source.ToString(x => x.ToString(), separator);
        }

        public static string Inline<T>(this IEnumerable<T> source)
        {
            return source.Inline(DEFAULT_TOSTRING_SEPARATOR);
        }


        #region IMPLEMENTATION OF IEnumerable<T>.ToString(x => function) EXTENSIONS
        
        public const string DEFAULT_TOSTRING_SEPARATOR = ", ";

        public static string ToString<T>(this IEnumerable<T> source, string separator)
        {
            return source.ToString(x => x, separator);
        }

        public static string ToString<T, TResult>(this IEnumerable<T> source, Func<T, TResult> function)
        {
            return source.ToString(function, DEFAULT_TOSTRING_SEPARATOR);
        }

        public static string ToString<T, TResult>(this IEnumerable<T> source, Func<T, TResult> function, string separator)
        {
            if (source == null) return null;
            

            var result = String.Empty;

            var isSeparatorUsed = false;
            foreach (var item in source)
            {
                isSeparatorUsed = true;
                result += function.Invoke(item) + separator;
            }

            return isSeparatorUsed ? result.Substring(0, result.Length - separator.Length) : result;
        }

        #endregion
    }
}