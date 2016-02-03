using DevExpress.Web.ASPxHiddenField;
using WebAppCommons.Classes.Controls.PersistedStates.StateContainers.Base;
using WebAppCommons.Classes.Controls.PersistedStates.StateObjects;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateContainers
{
    public class HiddenFieldStateContainer : BasePersistedStateContainer
    {
        private ASPxHiddenField DataContainer { get; set; }



        public HiddenFieldStateContainer(ASPxHiddenField persistedDataContainer)
        {
            DataContainer = persistedDataContainer;
        }



        private string ACTUAL_KEY(string key)
        {
            return key;
        }


        protected override bool HAS_ENTRY(string key)
        {
            return DataContainer.Contains(ACTUAL_KEY(key));
        }

        protected override void CREATE_ENTRY(string key, AbstractControlStateObject stateObject)
        {
            DataContainer.Add(ACTUAL_KEY(key), SERIALIZE(stateObject));
        }

        protected override AbstractControlStateObject READ_ENTRY(string key)
        {
            return (AbstractControlStateObject)DESERIALIZE((string)DataContainer[ACTUAL_KEY(key)]);
        }

        protected override void UPDATE_ENTRY(string key, AbstractControlStateObject stateObject)
        {
            DataContainer[ACTUAL_KEY(key)] = SERIALIZE(stateObject);
        }

        protected override void DELETE_ENTRY(string key)
        {
            DataContainer.Remove(ACTUAL_KEY(key));
        }
    }
}