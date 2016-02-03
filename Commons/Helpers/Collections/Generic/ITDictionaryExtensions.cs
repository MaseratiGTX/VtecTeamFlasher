using System.Collections.Generic;
using Commons.Helpers.Objects;

namespace Commons.Helpers.Collections.Generic
{
    public static class ITDictionaryExtensions
    {
        public static TValue Value<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
        {
            return source[key];
        }

        public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue defaultValue = default(TValue))
        {
            TValue result;
            return source.TryGetValue(key, out result) ? result : defaultValue;
        }


        public static IDictionary<TKey, TValue> Apply<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
        {
            return source.Apply(new KeyValuePair<TKey, TValue>(key, value));
        }

        public static IDictionary<TKey, TValue> Apply<TKey, TValue>(this IDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
        {
            if (value.Key.IsEmpty()) return source;

            source[value.Key] = value.Value;

            return source;
        }

        public static IDictionary<TKey, TValue> Apply<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> values)
        {
            foreach (var value in values)
            {
                source.Apply(value);
            }

            return source;
        } 
    }
}