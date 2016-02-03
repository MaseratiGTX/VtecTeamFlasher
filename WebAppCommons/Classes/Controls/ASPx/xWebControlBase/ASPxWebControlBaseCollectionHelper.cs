using System.Collections.Generic;
using System.Web.UI;
using Commons.Helpers.Collections.Generic;
using DevExpress.Web.ASPxClasses;

namespace WebAppCommons.Classes.Controls.ASPx.xWebControlBase
{
    public static class ASPxWebControlBaseCollectionHelper
    {
        public static void ResetControlsHierarchy<T>(this IEnumerable<T> source) where T : ASPxWebControlBase
        {
            source.Each(x => x._ResetControlHierarchy());
        }

        public static void ResetChildControlsHierarchy<T>(this Control source) where T : ASPxWebControlBase
        {
            source.ChildControls<T>().ResetControlsHierarchy();
        }
    }
}