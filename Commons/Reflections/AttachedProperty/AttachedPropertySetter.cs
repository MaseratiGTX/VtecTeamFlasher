using System.Reflection;

namespace Commons.Reflections.AttachedProperty
{
    public class AttachedPropertySetter<T> : AttachedMethodInfo<T>
    {
        public AttachedPropertySetter(T sourceObject, MethodInfo methodInfo) : base(sourceObject, methodInfo)
        {
        }


        public void Invoke(object value)
        {
            MethodInfo.Invoke(SourceObject, new[] { value });
        }
    }
}