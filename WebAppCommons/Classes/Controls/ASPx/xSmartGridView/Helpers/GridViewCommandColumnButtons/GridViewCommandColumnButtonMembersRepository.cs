using System;
using System.Reflection;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewCommandColumnButtons
{
    public class GridViewCommandColumnButtonMembersRepository
    {
        private static readonly object getIsVisible_lockingObject = new object();

        private static Func<GridViewCommandColumnButton, bool> getIsVisible_MethodDelegate;

        public static Func<GridViewCommandColumnButton, bool> GetIsVisible
        {
            get
            {
                if (getIsVisible_MethodDelegate != null)
                {
                    return getIsVisible_MethodDelegate;
                }

                lock (getIsVisible_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (getIsVisible_MethodDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        getIsVisible_MethodDelegate = (Func<GridViewCommandColumnButton, bool>)
                            typeof(GridViewCommandColumnButton).FetchMethodDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "GetIsVisible"
                            );
                    }

                    return getIsVisible_MethodDelegate;
                }
            }
        }


        private static readonly object columnGetter_lockingObject = new object();

        private static Func<GridViewCommandColumnButton, GridViewCommandColumn> column_GetterDelegate;

        public static Func<GridViewCommandColumnButton, GridViewCommandColumn> ColumnGetter
        {
            get
            {
                if (column_GetterDelegate != null)
                {
                    return column_GetterDelegate;
                }

                lock (columnGetter_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (column_GetterDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        column_GetterDelegate = (Func<GridViewCommandColumnButton, GridViewCommandColumn>)
                            typeof(GridViewCommandColumnButton).FetchPropertyGetterDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "Column"
                            );
                    }

                    return column_GetterDelegate;
                }
            }
        } 
    }
}