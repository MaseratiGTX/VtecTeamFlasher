using System;
using System.Reflection;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxClasses;

namespace WebAppCommons.Classes.Controls.ASPx.xWebControlBase
{
    public class ASPxWebControlBaseMembersRepository
    {
        private static readonly object resetControlHierarchy_lockingObject = new object();

        private static Action<ASPxWebControlBase> resetControlHierarchy_MethodDelegate;

        public static Action<ASPxWebControlBase> ResetControlHierarchy
        {
            get
            {
                if (resetControlHierarchy_MethodDelegate != null)
                {
                    return resetControlHierarchy_MethodDelegate;
                }

                lock (resetControlHierarchy_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (resetControlHierarchy_MethodDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        resetControlHierarchy_MethodDelegate = (Action<ASPxWebControlBase>)
                            typeof(ASPxWebControlBase).FetchMethodDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "ResetControlHierarchy"
                            );
                    }

                    return resetControlHierarchy_MethodDelegate;
                }
            }
        }
    }
}