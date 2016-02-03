using System;
using Commons.Helpers.CommonObjects;

namespace Commons.Helpers.Objects
{
    public static class ObjectExtensions
    {
        public static bool IsInstanceOf(this object source, Type type)
        {
            if (type == null) return false;

            return type.IsInstanceOfType(source);
        }

        public static bool IsNotInstanceOf(this object source, Type type)
        {
            return source.IsInstanceOf(type) == false;
        }


        public static bool IsInstanceOf<T>(this object source)
        {
            return source.IsInstanceOf(typeof(T));
        }

        public static bool IsNotInstanceOf<T>(this object source)
        {
            return source.IsNotInstanceOf(typeof (T));
        }
        


        public static T As<T>(this object source)
        {
            var resultType = typeof (T);

            if (resultType.IsEnum)
            {
                return (T)Enum.ToObject(typeof(T), source);
            }

            return (T) Convert.ChangeType(source, resultType);
        }


        public static string TypeName(this object source)
        {
            if (source == null) return "NULL";

            return source.GetType().Name;
        }

        

        public static string Format(this object source, string format = "'{0}'", string emptyText = null)
        {
            return source.IsNotEmpty() ? format.FillWith(source) : emptyText;
        }
    }
}