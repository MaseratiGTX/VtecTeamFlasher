namespace Commons.Serialization.Interfaces
{
    public interface ITSerializationHelper<T>
    {
        string Serialize(T entity);
        T Deserialize(string serializedEntity);
    }
}