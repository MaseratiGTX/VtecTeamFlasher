using System;

namespace Commons.Reflections
{
    public static class ActivationHelper
    {
        public static T CreateInstance<T>(params object[] args)
        {
            return (T) Activator.CreateInstance(typeof (T), args);
        }
    }
}