using System.Collections.Generic;
using System.Linq;

namespace Commons.Helpers.Comparasion
{
    public static class BaseEqualityExtensions
    {
        public static bool AreEqual(this object source, object other)
        {
            if (ReferenceEquals(source, other)) return true;

            if (source == null || other == null) return false;

            return source.Equals(other);
        }

        public static bool AreNotEqual(this object source, object other)
        {
            return source.AreEqual(other) == false;
        }


        public static bool AreEqual<T>(this IEnumerable<T> source, IEnumerable<T> other)
        {
            if (ReferenceEquals(source, other)) return true;

            if (source == null || other == null) return false;

            return source.SequenceEqual(other);
        }

        public static bool AreNotEqual<T>(this IEnumerable<T> source, IEnumerable<T> other)
        {
            return source.AreEqual(other) == false;
        }


        public static bool AreEqual<T>(this IEnumerable<T> source, IEnumerable<T> other, IEqualityComparer<T> equalityComparer)
        {
            if (ReferenceEquals(source, other)) return true;

            if (source == null || other == null) return false;

            return source.SequenceEqual(other, equalityComparer);
        }

        public static bool AreNotEqual<T>(this IEnumerable<T> source, IEnumerable<T> other, IEqualityComparer<T> equalityComparer)
        {
            return source.AreEqual(other, equalityComparer) == false;
        }


        public static bool AreEqual<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> other)
        {
            if (ReferenceEquals(source, other)) return true;

            if (source == null || other == null) return false;


            if (source.Count != other.Count) return false;


            var comparer = EqualityComparer<TValue>.Default;

            foreach (var keyValuePair in source)
            {
                TValue secondValue;

                if (other.TryGetValue(keyValuePair.Key, out secondValue) == false) return false;

                if (comparer.Equals(keyValuePair.Value, secondValue) == false) return false;
            }

            return true;
        }

        public static bool AreNotEqual<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> other)
        {
            return source.AreEqual(other) == false;
        }
    }
}