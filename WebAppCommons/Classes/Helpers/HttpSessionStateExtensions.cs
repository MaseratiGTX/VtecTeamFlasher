using System;
using System.Web.SessionState;

namespace WebAppCommons.Classes.Helpers
{
    public static class HttpSessionStateExtensions
    {
        public static T GetValue<T>(this HttpSessionState source, string key)
        {
            if (source[key] != null)
            {
                return (T)Convert.ChangeType(source[key], typeof(T));
            }

            return default(T);
        }


        public static void SetValue(this HttpSessionState source, string key, object value)
        {
            source[key] = value;
        }

        public static bool Contains(this HttpSessionState source, string key)
        {
            return source[key] != null;
        }

        public static bool Contains(this HttpSessionState source, object keyId, string key)
        {
            return source[String.Format("{0}_{1}", key, keyId)] != null;
        }


        public static T GetValue<T>(this HttpSessionState source, object keyId, string key)
        {
            var completeKey = String.Format("{0}_{1}", key, keyId);

            if (source[completeKey] != null)
            {
                return (T)Convert.ChangeType(source[completeKey], typeof(T));
            }

            return default(T);
        }


        public static void SetValue(this HttpSessionState source, object keyId, string key, object value)
        {
            source[String.Format("{0}_{1}", key, keyId)] = value;
        }


        public static void Remove(this HttpSessionState source, object keyId, string key)
        {
            source.Remove(String.Format("{0}_{1}", key, keyId));
        }



        private static string ConstructActualKey(Guid pageGUID, string keyContext, string keyName)
        {
            return string.Format("{0}_{1}_{2}", pageGUID.ToString(), keyContext, keyName);
        }

        public static HttpSessionState SetValue<T>(this HttpSessionState source, Guid pageGUID, string keyContext, string keyName, T value)
        {
            source[ConstructActualKey(pageGUID, keyContext, keyName)] = value;

            return source;
        }

        public static object HasValue(this HttpSessionState source, Guid pageGUID, string keyContext, string keyName)
        {
            return source[ConstructActualKey(pageGUID, keyContext, keyName)] != null;
        }

        public static object GetValue(this HttpSessionState source, Guid pageGUID, string keyContext, string keyName)
        {
            return source[ConstructActualKey(pageGUID, keyContext, keyName)];
        }

        public static T GetValue<T>(this HttpSessionState source, Guid pageGUID, string keyContext, string keyName)
        {
            return (T)source.GetValue(pageGUID, keyContext, keyName);
        }
    }
}