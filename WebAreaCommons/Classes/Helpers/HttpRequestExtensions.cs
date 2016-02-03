using System;
using System.Web;

namespace WebAreaCommons.Classes.Helpers
{
    public static class HttpRequestExtensions
    {
        public static T GetValue<T>(this HttpRequest source, string queryKey)
        {
            try
            {
                var queryValue = source.QueryString[queryKey];

                return (T)Convert.ChangeType(queryValue, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}