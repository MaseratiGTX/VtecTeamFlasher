using System;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateObjects
{
    [Serializable]
    public class ASPxEditState : AbstractControlStateObject
    {
        public virtual object Value { get; set; }
        public virtual bool ClientEnabled { get; set; }
    }
}