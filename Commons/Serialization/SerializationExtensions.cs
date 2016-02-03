using System;
using Commons.Serialization.Base64;
using Commons.Serialization.JSON;
using Commons.Serialization.XML;

namespace Commons.Serialization
{
    public static class SerializationExtensions
    {
        public static string SerializeToJSON<T>(this T source)
        {
            return new JSONSerializationHelper<T>().Serialize(source);
        }

        public static T DeserializeFromJSON<T>(this string source)
        {
            return new JSONSerializationHelper<T>().Deserialize(source);
        }



        public static string SerializeToXML<T>(this T source)
        {
            return new XmlSerializationHelper<T>().Serialize(source);
        }

        public static T DeserializeFromXML<T>(this string source)
        {
            return new XmlSerializationHelper<T>().Deserialize(source);
        }


        public static string Serialize<T>(this T source) where T : class, new()
        {
            return source.SerializeToXML().SerializeToBase64();
        }

        public static T Deserialize<T>(this string source) where T : class, new()
        {
            try
            {
                return source.DeserializeFromBase64().DeserializeFromXML<T>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static byte[] SerializeToBytes<T>(this T source) where T : class, new()
        {
            return new XmlSerializationHelper<T>().Serialize(source).GetBytes();
        }

        public static T DeserializeFromBytes<T>(this byte[] source) where T : class, new()
        {
            try
            {
                return new XmlSerializationHelper<T>().Deserialize(source.Decode());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}