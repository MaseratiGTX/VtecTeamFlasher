using System;
using System.Reflection;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewPagerBarTemplateContainers
{
    public static class GridViewPagerBarTemplateContainerMembersRepository
    {
        private static readonly object pagerIdGetter_lockingObject = new object();

        private static Func<GridViewPagerBarTemplateContainer, string> pagerId_GetterDelegate;

        public static Func<GridViewPagerBarTemplateContainer, string> PagerIdGetter
        {
            get
            {
                if (pagerId_GetterDelegate != null)
                {
                    return pagerId_GetterDelegate;
                }

                lock (pagerIdGetter_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (pagerId_GetterDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        pagerId_GetterDelegate = (Func<GridViewPagerBarTemplateContainer, string>)
                            typeof(GridViewPagerBarTemplateContainer).FetchPropertyGetterDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "PagerId"
                            );
                    }

                    return pagerId_GetterDelegate;
                }
            }
        }
    }
}