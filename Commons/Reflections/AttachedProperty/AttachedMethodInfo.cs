using System.Reflection;

namespace Commons.Reflections.AttachedProperty
{
    public class AttachedMethodInfo<T>
    {
        public T SourceObject { get; set; }

        public MethodInfo MethodInfo { get; set; }


        public AttachedMethodInfo(T sourceObject, MethodInfo methodInfo)
        {
            SourceObject = sourceObject;
            MethodInfo = methodInfo;
        }
    }
}