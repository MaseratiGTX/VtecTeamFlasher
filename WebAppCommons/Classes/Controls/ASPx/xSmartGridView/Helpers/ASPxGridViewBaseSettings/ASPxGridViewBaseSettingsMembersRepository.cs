using System;
using System.Reflection;
using System.Web.UI;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.ASPxGridViewBaseSettings
{
    public static class ASPxGridViewBaseSettingsMembersRepository
    {
        private static readonly object gridGetter_lockingObject = new object();

        private static Func<DevExpress.Web.ASPxGridView.ASPxGridViewBaseSettings, ASPxGridView> grid_GetterDelegate;

        public static Func<DevExpress.Web.ASPxGridView.ASPxGridViewBaseSettings, ASPxGridView> GridGetter
        {
            get
            {
                if (grid_GetterDelegate != null)
                {
                    return grid_GetterDelegate;
                }

                lock (gridGetter_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (grid_GetterDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        grid_GetterDelegate = (Func<DevExpress.Web.ASPxGridView.ASPxGridViewBaseSettings, ASPxGridView>)
                            typeof(DevExpress.Web.ASPxGridView.ASPxGridViewBaseSettings).FetchPropertyGetterDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "Grid"
                            );
                    }

                    return grid_GetterDelegate;
                }
            }
        }


        private static readonly object getStateManagedObject_lockingObject = new object();

        private static Func<DevExpress.Web.ASPxGridView.ASPxGridViewBaseSettings, IStateManager[]> getStateManagedObject_MethodDelegate;

        public static Func<DevExpress.Web.ASPxGridView.ASPxGridViewBaseSettings, IStateManager[]> GetStateManagedObjects
        {
            get
            {
                if (getStateManagedObject_MethodDelegate != null)
                {
                    return getStateManagedObject_MethodDelegate;
                }

                lock (getStateManagedObject_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (getStateManagedObject_MethodDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        getStateManagedObject_MethodDelegate = (Func<DevExpress.Web.ASPxGridView.ASPxGridViewBaseSettings, IStateManager[]>)
                            typeof(DevExpress.Web.ASPxGridView.ASPxGridViewBaseSettings).FetchMethodDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "GetStateManagedObjects"
                            );
                    }

                    return getStateManagedObject_MethodDelegate;
                }
            }
        }
    }
}