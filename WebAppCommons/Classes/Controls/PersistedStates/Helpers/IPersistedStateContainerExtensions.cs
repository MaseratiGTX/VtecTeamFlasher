using System.Collections.Generic;
using System.Web.UI;
using WebAppCommons.Classes.Controls.PersistedStates.StateContainers.Base;

namespace WebAppCommons.Classes.Controls.PersistedStates.Helpers
{
    public static class IPersistedStateContainerExtensions
    {
        public static IPersistedStateContainer Save(this IPersistedStateContainer source, IEnumerable<Control> controls)
        {
            foreach (var control in controls)
            {
                source.Save(control);
            }

            return source;
        }

        public static IPersistedStateContainer Save(this IPersistedStateContainer source, params Control[] controls)
        {
            return source.Save((IEnumerable<Control>)controls);
        }
    }
}