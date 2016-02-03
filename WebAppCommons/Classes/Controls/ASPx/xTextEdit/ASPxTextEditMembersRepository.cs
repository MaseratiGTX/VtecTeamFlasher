using System;
using System.Reflection;
using Commons.Reflections.Delegates;
using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx.xTextEdit
{
    public static class ASPxTextEditMembersRepository
    {
        private static readonly object propertiesGetter_lockingObject = new object();

        private static Func<ASPxTextEdit, DevExpress.Web.ASPxEditors.TextEditProperties> properties_GetterDelegate;

        public static Func<ASPxTextEdit, DevExpress.Web.ASPxEditors.TextEditProperties> PropertiesGetter
        {
            get
            {
                if (properties_GetterDelegate != null)
                {
                    return properties_GetterDelegate;
                }

                lock (propertiesGetter_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (properties_GetterDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        properties_GetterDelegate = (Func<ASPxTextEdit, DevExpress.Web.ASPxEditors.TextEditProperties>)
                            typeof(ASPxTextEdit).FetchPropertyGetterDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly, "Properties"
                            );
                    }

                    return properties_GetterDelegate;
                }
            }
        }
    }
}