using System;
using System.Reflection;

namespace Commons.Reflections.PropertyManagers
{
    public static class ReflectionHelper
    {
        public static Func<TTarget, object> MakeDelegate<TTarget>(this MethodInfo method) where TTarget : class
        {
            var selfType = MethodBase.GetCurrentMethod().DeclaringType;

            if (selfType == null) return null;

            var methodInfo = selfType.GetMethod("MakeDelegateHelper", BindingFlags.Static | BindingFlags.NonPublic);
            var constructedMethodInfo = methodInfo.MakeGenericMethod(method.ReflectedType, method.ReturnType);
            var result = constructedMethodInfo.Invoke(null, new object[] { method });

            return (Func<TTarget, object>)result;
        }


        // ReSharper disable UnusedMember.Local
        private static Func<TTarget, object> MakeDelegateHelper<TTarget, TReturn>(MethodInfo method) where TTarget : class
        // ReSharper restore UnusedMember.Local
        {
            //(!)WARNING: THIS METHOD IS USED IN MakeDelegate METHOD

            var functionDelegate = (Func<TTarget, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TReturn>), method);

            return target => functionDelegate(target);
        }
    }
}