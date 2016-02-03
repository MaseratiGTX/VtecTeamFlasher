using System;
using System.Collections;
using Commons.Helpers.Collections;

namespace Commons.Helpers.Objects
{
    public static class IsEmptyExtensions
    {
        public static bool IsNull(this object source)
        {
            return source == null;
        }

        public static bool IsNotNull(this object source)
        {
            return source.IsNull() == false;
        }



        public static bool Found(this object source)
        {
            return source.IsNotEmpty();
        }

        public static bool NotFound(this object source)
        {
            return source.IsEmpty();
        }


        public static bool IsEmpty(this object source)
        {
            if (source is string)
            {
                return IsEmpty(((string)source));
            }

            if (source is IEnumerable)
            {
                return IsEmpty(((IEnumerable)source));
            }

            return source == null;
        }

        public static bool IsEmpty(this string source)
        {
            return String.IsNullOrEmpty(source);
        }

        public static bool IsEmpty(this IEnumerable source)
        {
            return source == null || source.HasZeroLength();
        }


        public static bool IsNotEmpty(this object source)
        {
            return source.IsEmpty() == false;
        }
    }
}