using System.Reflection;

namespace Commons.Reflections.AttachedProperty
{
    public class AttachedPropertyGetter<T> : AttachedMethodInfo<T>
    {
        public AttachedPropertyGetter(T sourceObject, MethodInfo methodInfo) : base(sourceObject, methodInfo)
        {
        }


        public object Invoke()
        {
            return MethodInfo.Invoke(SourceObject, null);
        }
    }
}