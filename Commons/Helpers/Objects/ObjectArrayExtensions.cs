using System;
using System.Linq;

namespace Commons.Helpers.Objects
{
    public static class ObjectArrayExtensions
    {
        public static object[][] For<T>(this object[][] source, Func<T, T> function) where T : class
        {
            foreach (var sourceSubArray in source)
            {
                for (var index = 0; index < sourceSubArray.Length; index++)
                {
                    var TElement = sourceSubArray[index] as T;

                    if (TElement != null)
                    {
                        sourceSubArray[index] = function.Invoke(TElement);
                    }
                }
            }

            return source;
        }


        public static T[] GetRange<T>(this T[] source, int startIndex, int count)
        {
            return source.Skip(startIndex).Take(count).ToArray();
        }
    }
}