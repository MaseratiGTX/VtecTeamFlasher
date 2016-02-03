using System;
using System.Web.UI;
using WebAppCommons.Classes.Controls.PersistedStates.StateObjects;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateManagers.Base
{
    public interface IControlStateManager
    {
        Type TSourceType { get; }
        Type TStateType { get; }


        IControlStateManager SetSourceControl(Control value);


        AbstractControlStateObject CalculateStateObject();

        void ApplyStateObject(AbstractControlStateObject stateObject);
    }
}