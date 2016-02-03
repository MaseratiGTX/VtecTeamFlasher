using Commons.Serialization.Interfaces;
using Newtonsoft.Json;

namespace Commons.Serialization.JSON
{
    public class JSONSerializationHelper<T> : ITSerializationHelper<T>, ISerializationHelper
    {
        public JsonSerializerSettings SerializerSettings { get; private set; }



        public JSONSerializationHelper()
        {
            SerializerSettings = new JsonSerializerSettings();
        }

        public JSONSerializationHelper(JsonSerializerSettings serializerSettings)
        {
            SerializerSettings = serializerSettings;
        }



        public string Serialize(T entity)
        {
            return SerializeObject(entity);
        }

        public T Deserialize(string serializedEntity)
        {
            return (T) JsonConvert.DeserializeObject(serializedEntity, typeof(T), SerializerSettings);
        }


        public string SerializeObject(object entity)
        {
            return JsonConvert.SerializeObject(entity, SerializerSettings);
        }

        public object DeserializeObject(string serializedEntity)
        {
            return JsonConvert.DeserializeObject(serializedEntity, SerializerSettings);
        }
    }
}