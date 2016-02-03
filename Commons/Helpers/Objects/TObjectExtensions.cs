using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons.Helpers.Objects
{
    public static class TObjectExtensions
    {
        public static T IfEmpty<T>(this T source, T another)
        {
            return source.IsNotEmpty() ? source : another;
        }


        public static T IfFound<T>(this T source, Action<T> action)
        {
            if (source.Found())
            {
                action.Invoke(source);
            }

            return source;
        }


        public static bool NotIn<T>(this T source, IEnumerable<T> enumerable)
        {
            return source.In(enumerable) == false;
        }

        public static bool NotIn<T>(this T source, params T[] parameters)
        {
            return source.NotIn((IEnumerable<T>) parameters);
        }

        public static bool In<T>(this T source, IEnumerable<T> enumerable)
        {
            return enumerable.Contains(source);
        }

        public static bool In<T>(this T source, params T[] parameters)
        {
            return source.In((IEnumerable<T>) parameters);
        }


        public static List<T> AsList<T>(this T source)
        {
            var result = new List<T>();

            // ReSharper disable once RedundantCast
            if (((object)source) != null)
            {
                result.Add(source);
            }
            
            return result;
        }
    }
}