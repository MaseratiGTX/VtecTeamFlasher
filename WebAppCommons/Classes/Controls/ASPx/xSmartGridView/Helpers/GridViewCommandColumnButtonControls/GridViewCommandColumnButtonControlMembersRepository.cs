using System;
using System.Reflection;
using System.Web.UI.WebControls;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewCommandColumnButtonControls
{
    public static class GridViewCommandColumnButtonControlMembersRepository
    {
        private static readonly object controlGetter_lockingObject = new object();

        private static Func<GridViewCommandColumnButtonControl, WebControl> control_GetterDelegate;

        public static Func<GridViewCommandColumnButtonControl, WebControl> ControlGetter
        {
            get
            {
                if (control_GetterDelegate != null)
                {
                    return control_GetterDelegate;
                }

                lock (controlGetter_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (control_GetterDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        control_GetterDelegate = (Func<GridViewCommandColumnButtonControl, WebControl>)
                            typeof(GridViewCommandColumnButtonControl).FetchPropertyGetterDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "Control"
                            );
                    }

                    return control_GetterDelegate;
                }
            }
        }
    }
}