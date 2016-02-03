using System;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateObjects
{
    [Serializable]
    public abstract class AbstractControlStateObject
    {
        public virtual string ID { get; set; }
    }
}