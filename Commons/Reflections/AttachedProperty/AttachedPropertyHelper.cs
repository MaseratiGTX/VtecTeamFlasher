namespace Commons.Reflections.AttachedProperty
{
    public static class AttachedPropertyHelper
    {
        public static AttachedPropertyInfo<T> Property<T>(this T source, string propertyName)
        {
            var sourceType = source.GetType();
            var propertyInfo = sourceType.GetProperty(propertyName);

            if (propertyInfo == null) return null;

            return new AttachedPropertyInfo<T>(source, propertyInfo);
        }
    }
}