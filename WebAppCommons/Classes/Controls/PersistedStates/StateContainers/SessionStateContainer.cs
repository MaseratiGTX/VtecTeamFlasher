using System.Web.SessionState;
using Commons.Helpers.Objects;
using WebAppCommons.Classes.Controls.PersistedStates.StateContainers.Base;
using WebAppCommons.Classes.Controls.PersistedStates.StateObjects;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateContainers
{
    public class SessionStateContainer : BasePersistedStateContainer
    {
        private HttpSessionState DataContainer { get; set; }

        public string ContextId { get; set; }



        public SessionStateContainer(HttpSessionState persistedDataContainer)
            : this(persistedDataContainer, "DEFAULT_CONTEXT")
        {
        }

        public SessionStateContainer(HttpSessionState persistedDataContainer, string contextId)
        {
            DataContainer = persistedDataContainer;

            ContextId = contextId;
        }



        public SessionStateContainer SetContextId(string value)
        {
            ContextId = value;

            return this;
        }



        private string ACTUAL_KEY(string key)
        {
            return string.Format("{0}: {1}", ContextId, key);
        }


        protected override bool HAS_ENTRY(string key)
        {
            return DataContainer[ACTUAL_KEY(key)].NotFound() == false;
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