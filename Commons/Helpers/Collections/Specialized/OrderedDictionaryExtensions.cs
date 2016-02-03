using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Commons.Helpers.CommonObjects;

namespace Commons.Helpers.Collections.Specialized
{
    public static class OrderedDictionaryExtensions
    {
        public static OrderedDictionary CustomTrim(this OrderedDictionary source)
        {
            if (source == null) return null;


            var result = new OrderedDictionary();


            var keys = source.Keys;

            foreach (var key in keys)
            {
                var value = source[key];


                var stringValue = value as string;

                if (stringValue != null)
                {
                    value = stringValue.CustomTrim();
                }


                result.Add(key, value);
            }


            return result;
        }


        public static OrderedDictionary AddIfHasNo(this OrderedDictionary source, string key, object value)
        {
            if (source.Contains(key)) return source;

            source.Add(key, value);

            return source;
        }

        public static OrderedDictionary ApplyTransformation(this OrderedDictionary source, string key, Func<object, object> transformation)
        {
            if (source.Contains(key) == false) return source;

            source[key] = transformation.Invoke(source[key]);

            return source;
        }



        public static OrderedDictionary Include(this OrderedDictionary source, IDictionary<string, object> values)
        {
            foreach (var value in values)
            {
                source[value.Key] = value.Value;
            }

            return source;
        }


        public static OrderedDictionary Exclude(this OrderedDictionary source, params string[] keys)
        {
            foreach (var key in keys)
            {
                source.Remove(key);
            }

            return source;
        }
    }
}