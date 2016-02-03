using System;
using System.Reflection;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewCommandColumnCustomButtons
{
    public class GridViewCommandColumnCustomButtonMembersRepository
    {
        private static readonly object isVisible_lockingObject = new object();

        private static Func<GridViewCommandColumnCustomButton, GridViewTableCommandCellType, bool, bool> isVisible_MethodDelegate;

        public static Func<GridViewCommandColumnCustomButton, GridViewTableCommandCellType, bool, bool> IsVisible
        {
            get
            {
                if (isVisible_MethodDelegate != null)
                {
                    return isVisible_MethodDelegate;
                }

                lock (isVisible_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (isVisible_MethodDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        isVisible_MethodDelegate = (Func<GridViewCommandColumnCustomButton, GridViewTableCommandCellType, bool, bool>)
                            typeof(GridViewCommandColumnCustomButton).FetchMethodDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "IsVisible", typeof(GridViewTableCommandCellType), typeof(bool)
                            );
                    }

                    return isVisible_MethodDelegate;
                }
            }
        } 
    }
}