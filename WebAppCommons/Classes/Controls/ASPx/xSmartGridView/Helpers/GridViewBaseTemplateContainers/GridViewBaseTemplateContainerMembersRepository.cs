using System;
using System.Reflection;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewBaseTemplateContainers
{
    public class GridViewBaseTemplateContainerMembersRepository
    {
        private static readonly object getID_lockingObject = new object();

        private static Func<GridViewBaseTemplateContainer, string> getID_MethodDelegate;

        public static Func<GridViewBaseTemplateContainer, string> GetID
        {
            get
            {
                if (getID_MethodDelegate != null)
                {
                    return getID_MethodDelegate;
                }

                lock (getID_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (getID_MethodDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        getID_MethodDelegate = (Func<GridViewBaseTemplateContainer, string>)
                            typeof(GridViewBaseTemplateContainer).FetchMethodDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "GetID"
                            );
                    }

                    return getID_MethodDelegate;
                }
            }
        } 
    }
}