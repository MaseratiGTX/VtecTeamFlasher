using System;
using System.Web.UI;
using WebAppCommons.Classes.Controls.PersistedStates.StateObjects;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateManagers.Base
{
    public abstract class BaseControlStateManager<TSource, TState> : IControlStateManager
        where TSource : Control
        where TState : AbstractControlStateObject, new()
    {
        public Type TSourceType
        {
            get { return typeof(TSource); }
        }

        public Type TStateType
        {
            get { return typeof(TState); }
        }


        public TSource SourceControl { get; set; }

        public IControlStateManager SetSourceControl(Control value)
        {
            SourceControl = (TSource)value;

            return this;
        }



        public virtual TState CalculateState()
        {
            return new TState
            {
                ID = SourceControl.ID
            };
        }

        public virtual void ApplyState(TState state)
        {
        }


        public virtual AbstractControlStateObject CalculateStateObject()
        {
            return CalculateState();
        }

        public virtual void ApplyStateObject(AbstractControlStateObject stateObject)
        {
            ApplyState((TState)stateObject);
        }
    }
}