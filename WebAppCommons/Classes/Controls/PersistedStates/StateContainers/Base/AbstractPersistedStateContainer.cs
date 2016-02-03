using System.Web.UI;
using WebAppCommons.Classes.Controls.PersistedStates.StateManagers.Base;
using WebAppCommons.Classes.Controls.PersistedStates.StateObjects;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateContainers.Base
{
    public abstract class AbstractPersistedStateContainer : IPersistedStateContainer
    {
        protected ControlsStateManager ControlsStateManager { get; set; }


        protected AbstractPersistedStateContainer()
        {
            ControlsStateManager = new ControlsStateManager();
        }


        public IPersistedStateContainer Save(Control control)
        {
            var stateObject = ControlsStateManager.ManagerOf(control).CalculateStateObject();

            var key = CalculateKey(control);

            if (HAS_ENTRY(key) == false)
            {
                CREATE_ENTRY(key, stateObject);
            }
            else
            {
                UPDATE_ENTRY(key, stateObject);
            }

            return this;
        }

        public IPersistedStateContainer Restore(Control control)
        {
            var key = CalculateKey(control);

            if (HAS_ENTRY(key))
            {
                var stateObject = READ_ENTRY(key);

                ControlsStateManager.ManagerOf(control).ApplyStateObject(stateObject);
            }

            return this;
        }

        public IPersistedStateContainer Clear(Control control)
        {
            var key = CalculateKey(control);

            if (HAS_ENTRY(key))
            {
                DELETE_ENTRY(key);
            }

            return this;
        }


        protected abstract bool HAS_ENTRY(string key);
        protected abstract void CREATE_ENTRY(string key, AbstractControlStateObject stateObject);
        protected abstract AbstractControlStateObject READ_ENTRY(string key);
        protected abstract void UPDATE_ENTRY(string key, AbstractControlStateObject stateObject);
        protected abstract void DELETE_ENTRY(string key);


        protected string CalculateKey(Control control)
        {
            return control.ID;
        }
    }
}