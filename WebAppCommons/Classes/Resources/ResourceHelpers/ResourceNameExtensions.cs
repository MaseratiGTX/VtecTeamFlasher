namespace WebAppCommons.Classes.Resources.ResourceHelpers
{
    public static class ResourceNameExtensions
    {
        public static string TryToFix(this string resourceName, string defaultNamespace)
        {
            var result = resourceName.Trim(' ', '.');

            if (result.StartsWith(defaultNamespace))
            {
                return result;
            }

            return defaultNamespace + "." + result;
        }
    }
}