using Commons.Serialization.Binary;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateContainers.Base
{
    public abstract class BasePersistedStateContainer : AbstractPersistedStateContainer
    {
        protected BinarySerializationHelper SerializationHelper { get; set; }


        protected BasePersistedStateContainer()
        {
            SerializationHelper = new BinarySerializationHelper();
        }


        protected string SERIALIZE(object stateObject)
        {
            return SerializationHelper.SerializeObject(stateObject);
        }

        protected object DESERIALIZE(string source)
        {
            return SerializationHelper.DeserializeObject(source);
        }
    }
}