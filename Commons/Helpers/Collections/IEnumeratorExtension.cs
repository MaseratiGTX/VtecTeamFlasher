using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Commons.Exceptions;

namespace Commons.Helpers.Collections
{
    public static class IEnumeratorExtension
    {
        public static object FetchNext(this IEnumerator source)
        {
            if (source.MoveNext())
            {
                return source.Current;
            }

            throw new ElementNotFoundException();
        }


        public static bool MoveNext<T>(this IEnumerable<IEnumerator<T>> source)
        {
            return source.All(enumerator => enumerator.MoveNext());
        }

        public static List<T> Current<T>(this IEnumerable<IEnumerator<T>> source)
        {
            return source.Select(enumerator => enumerator.Current).ToList();
        }
    }
}