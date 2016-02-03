using System;
using System.Reflection;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewDataColumns
{
    public class GridViewDataColumnMembersRepository
    {
        private static readonly object getDataType_lockingObject = new object();

        private static Func<GridViewDataColumn, Type> getDataType_MethodDelegate;

        public static Func<GridViewDataColumn, Type> GetDataType
        {
            get
            {
                if (getDataType_MethodDelegate != null)
                {
                    return getDataType_MethodDelegate;
                }

                lock (getDataType_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (getDataType_MethodDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        getDataType_MethodDelegate = (Func<GridViewDataColumn, Type>)
                            typeof(GridViewDataColumn).FetchMethodDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "GetDataType"
                            );
                    }

                    return getDataType_MethodDelegate;
                }
            }
        }
    }
}