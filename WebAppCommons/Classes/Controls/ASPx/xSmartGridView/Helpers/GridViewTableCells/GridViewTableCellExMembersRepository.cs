using System;
using System.Reflection;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewTableCells
{
    public class GridViewTableCellExMembersRepository
    {
        private static readonly object removeBottomBorderGetter_lockingObject = new object();

        private static Func<GridViewTableCellEx, bool> removeBottomBorder_GetterDelegate;

        public static Func<GridViewTableCellEx, bool> RemoveBottomBorderGetter
        {
            get
            {
                if (removeBottomBorder_GetterDelegate != null)
                {
                    return removeBottomBorder_GetterDelegate;
                }

                lock (removeBottomBorderGetter_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (removeBottomBorder_GetterDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        removeBottomBorder_GetterDelegate = (Func<GridViewTableCellEx, bool>)
                            typeof(GridViewTableCellEx).FetchPropertyGetterDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "RemoveBottomBorder"
                            );
                    }

                    return removeBottomBorder_GetterDelegate;
                }
            }
        }


        private static readonly object removeBottomBorderSetter_lockingObject = new object();

        private static Action<GridViewTableCellEx, bool> removeBottomBorder_SetterDelegate;

        public static Action<GridViewTableCellEx, bool> RemoveBottomBorderSetter
        {
            get
            {
                if (removeBottomBorder_SetterDelegate != null)
                {
                    return removeBottomBorder_SetterDelegate;
                }

                lock (removeBottomBorderSetter_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (removeBottomBorder_SetterDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        removeBottomBorder_SetterDelegate = (Action<GridViewTableCellEx, bool>)
                            typeof(GridViewTableCellEx).FetchPropertySetterDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "RemoveBottomBorder"
                            );
                    }

                    return removeBottomBorder_SetterDelegate;
                }
            }
        }
    }
}