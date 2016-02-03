using System;
using System.Reflection;
using Commons.Reflections.Delegates;

namespace WebAppCommons.Classes.Controls.ASPx.xTextEdit.TextEditProperties
{
    public static class TextEditPropertiesMembersRepository
    {
        private static readonly object nullTextInternalGetter_lockingObject = new object();

        private static Func<DevExpress.Web.ASPxEditors.TextEditProperties, string> nullTextInternal_GetterDelegate;

        public static Func<DevExpress.Web.ASPxEditors.TextEditProperties, string> NullTextInternalGetter
        {
            get
            {
                if (nullTextInternal_GetterDelegate != null)
                {
                    return nullTextInternal_GetterDelegate;
                }

                lock (nullTextInternalGetter_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (nullTextInternal_GetterDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        nullTextInternal_GetterDelegate = (Func<DevExpress.Web.ASPxEditors.TextEditProperties, string>)
                            typeof(DevExpress.Web.ASPxEditors.TextEditProperties).FetchPropertyGetterDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "NullTextInternal"
                            );
                    }

                    return nullTextInternal_GetterDelegate;
                }
            }
        }


        private static readonly object nullTextInternalSetter_lockingObject = new object();

        private static Action<DevExpress.Web.ASPxEditors.TextEditProperties, string> nullTextInternal_SetterDelegate;

        public static Action<DevExpress.Web.ASPxEditors.TextEditProperties, string> NullTextInternalSetter
        {
            get
            {
                if (nullTextInternal_SetterDelegate != null)
                {
                    return nullTextInternal_SetterDelegate;
                }

                lock (nullTextInternalSetter_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if (nullTextInternal_SetterDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        nullTextInternal_SetterDelegate = (Action<DevExpress.Web.ASPxEditors.TextEditProperties, string>)
                            typeof(DevExpress.Web.ASPxEditors.TextEditProperties).FetchPropertySetterDelegate(
                                BindingFlags.NonPublic | BindingFlags.Instance, "NullTextInternal"
                            );
                    }

                    return nullTextInternal_SetterDelegate;
                }
            }
        }
    }
}