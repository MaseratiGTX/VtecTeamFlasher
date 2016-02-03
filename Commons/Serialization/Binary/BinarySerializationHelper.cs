using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Commons.Serialization.Interfaces;

namespace Commons.Serialization.Binary
{
    public class BinarySerializationHelper : ISerializationHelper
    {
        private BinaryFormatter BinaryFormatter { get; set; }


        public BinarySerializationHelper()
        {
            BinaryFormatter = new BinaryFormatter();
        }


        public string SerializeObject(object entity)
        {
            using (var memorystream = new MemoryStream())
            {
                BinaryFormatter.Serialize(memorystream, entity);

                return Convert.ToBase64String(memorystream.ToArray());
            }
        }

        public object DeserializeObject(string serializedEntity)
        {
            var sourceBytes = Convert.FromBase64String(serializedEntity);

            using (var memoryStream = new MemoryStream(sourceBytes))
            {
                return BinaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}