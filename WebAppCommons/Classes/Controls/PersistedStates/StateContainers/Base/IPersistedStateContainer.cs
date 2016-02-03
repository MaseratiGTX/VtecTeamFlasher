using System.Web.UI;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateContainers.Base
{
    public interface IPersistedStateContainer
    {
        IPersistedStateContainer Save(Control control);
        IPersistedStateContainer Restore(Control control);
        IPersistedStateContainer Clear(Control control);
    }
}