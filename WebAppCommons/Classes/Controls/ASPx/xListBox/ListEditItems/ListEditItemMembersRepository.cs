using System;
using System.Reflection;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxEditors.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xListBox.ListEditItems
{
    public class ListEditItemMembersRepository
    {
        private static readonly object dataItemWrapper_lockingObject = new object();

        private static Func<ListEditItem, ListEditDataItemWrapper> dataItemWrapper_GetterDelegate;

        public static Func<ListEditItem, ListEditDataItemWrapper> DataItemWrapperGetter
        {
            get
            {
                if (dataItemWrapper_GetterDelegate != null)
                {
                    return dataItemWrapper_GetterDelegate;
                }

                lock (dataItemWrapper_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (dataItemWrapper_GetterDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        dataItemWrapper_GetterDelegate = (Func<ListEditItem, ListEditDataItemWrapper>)
                            typeof(ListEditItem).FetchPropertyGetterDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "DataItemWrapper"
                            );
                    }

                    return dataItemWrapper_GetterDelegate;
                }
            }
        } 
    }
}