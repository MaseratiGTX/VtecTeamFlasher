using System;

namespace Commons.Exceptions
{
    public static class ExceptionHelper
    {
        public static T Fetch<T>(this Exception source) where T : Exception
        {
            if (source == null) return null;

            if (source is T) return (T) source;

            return source.InnerException.Fetch<T>();
        }
    }
}