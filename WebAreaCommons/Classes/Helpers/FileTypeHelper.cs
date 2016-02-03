namespace WebAreaCommons.Classes.Helpers
{
    public static class FileTypeHelper
    {
        public static string Clear(this string contentType)
        {
            if(contentType.StartsWith("[") && contentType.EndsWith("]"))
            {
                return contentType.Substring(1, contentType.Length - 2);
            }

            return null;
        }
    }
}
