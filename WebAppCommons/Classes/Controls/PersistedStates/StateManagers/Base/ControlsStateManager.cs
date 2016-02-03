using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateManagers.Base
{
    public class ControlsStateManager
    {
        private Dictionary<Type, IControlStateManager> ManagersMap { get; set; }


        public ControlsStateManager()
        {
            ManagersMap = new Dictionary<Type, IControlStateManager>();

            //РАНЕЕ ПЛАНИРОВАЛОСЬ ЧТО AbstractPersistedStateContainer (HiddenFieldStateContainer/SessionStateContainer) будут работать со "сложными" контролами - как минимум с ASPxPanelBase и ASPxGridView
            AddManager(new ASPxEditStateManager());
        }


        public ControlsStateManager AddManager<T>(T stateManager) where T : IControlStateManager
        {
            ManagersMap.Add(stateManager.TSourceType, stateManager);

            return this;
        }


        public IControlStateManager ManagerOf(Control control)
        {
            foreach (var TSource in ManagersMap.Keys)
            {
                if (TSource.IsInstanceOfType(control))
                {
                    return ManagersMap[TSource].SetSourceControl(control);
                }
            }

            throw new NotSupportedException();
        }
    }
}