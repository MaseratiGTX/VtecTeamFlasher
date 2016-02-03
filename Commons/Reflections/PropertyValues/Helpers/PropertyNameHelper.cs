namespace Commons.Reflections.PropertyValues.Helpers
{
    public static class PropertyNameHelper
    {
        public static PropertyNameParts SplitApart(this string propertyName)
        {
            var separatorIndex = propertyName.IndexOf('.');

            var propertyBasePart = separatorIndex != -1 ? propertyName.Substring(0, separatorIndex) : propertyName;
            var propertyOtherPart = separatorIndex != -1 ? propertyName.Substring(separatorIndex + 1, propertyName.Length - separatorIndex - 1) : null;

            return new PropertyNameParts
            {
                BasePart = propertyBasePart,
                OtherPart = propertyOtherPart
            };
        }
    }
}