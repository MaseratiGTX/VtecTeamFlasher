using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Commons.Serialization.Interfaces;

namespace Commons.Serialization.XML
{
    public class XmlSerializationHelper<T> : ITSerializationHelper<T>, ISerializationHelper
    {
        private readonly XmlSerializer xmlSerializer;


        public XmlSerializationHelper()
        {
            xmlSerializer = new XmlSerializer(typeof(T));
        }


        public string Serialize(T entity)
        {
            var stringWriter = new StringWriter();
            var xmltWriter = new XmlTextWriter(stringWriter);

            xmlSerializer.Serialize(xmltWriter, entity);

            var result = stringWriter.ToString();

            xmltWriter.Close();
            stringWriter.Close();

            return result;
        }


        public string SerializeObject(object entity)
        {
            return Serialize((T)entity);
        }


        public T Deserialize(string serializedEntity)
        {
            var stringReader = new StringReader(serializedEntity);
            var xmlReader = new XmlTextReader(stringReader);

            var result = (T)xmlSerializer.Deserialize(xmlReader);

            xmlReader.Close();
            stringReader.Close();

            return result;
        }


        public object DeserializeObject(string serializedEntity)
        {
            return Deserialize(serializedEntity);
        }


        public string TrySerialize(T entity)
        {
            try
            {
                return Serialize(entity);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }


        public T TryDeserialize(string serializedEntity)
        {
            try
            {
                return Deserialize(serializedEntity);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}