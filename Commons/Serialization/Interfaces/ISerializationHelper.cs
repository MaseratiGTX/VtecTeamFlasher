namespace Commons.Serialization.Interfaces
{
    public interface ISerializationHelper
    {
        string SerializeObject(object entity);
        object DeserializeObject(string serializedEntity);
    }
}