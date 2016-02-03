using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Objects;
using Commons.Reflections.AttachedProperty;
using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx
{
    public static class ASPxEditBaseHelper
    {
        public static T IfEmpty<T>(this T source, Action<T> action) where T : ASPxEditBase
        {
            var itemsCount = source.DataSource.ItemsCount();

            if (itemsCount == 0)
            {
                action.Invoke(source);
            }

            return source;
        }

        public static T IfOne<T>(this T source, Action<T> action) where T : ASPxEditBase
        {
            var itemsCount = source.DataSource.ItemsCount();

            if (itemsCount == 1)
            {
                action.Invoke(source);
            }

            return source;
        }


        public static int ItemsCount(this object dataSource)
        {
            return dataSource != null ? ((IEnumerable<object>)dataSource).Count() : 0;
        }



        public static T Enable<T>(this T source) where T : ASPxEditBase
        {
            source.ClientEnabled = true;

            return source;
        }

        public static T EnableControl<T>(this T source) where T : ASPxEditBase
        {
            return source.Enable();
        }


        public static T Disable<T>(this T source) where T : ASPxEditBase
        {
            source.ClientEnabled = false;

            return source;
        }

        public static T DisableControl<T>(this T source) where T : ASPxEditBase
        {
            return source.Disable();
        }



        public static T ClientEnabled<T>(this T source, bool enabled) where T : ASPxEditBase
        {
            return enabled ? source.Enable() : source.Disable();
        }

        
        public static T ReadOnly<T>(this T source, bool readOnly) where T : ASPxEditBase
        {
            source.ReadOnly = readOnly;

            (source as ASPxButtonEditBase).IfFound(x => x.SetEditButtonsEnableState(readOnly == false));

            return source;
        }


        public static string NullText<T>(this T source)
        {
            var sourceProperty = source.Property("NullText");

            if (sourceProperty.Found())
            {
                return (string) sourceProperty.Value();
            }

            return null;
        }

        public static T NullText<T>(this T source, string value)
        {
            var sourceProperty = source.Property("NullText");

            if (sourceProperty.Found())
            {
                sourceProperty.Set(value);
            }

            return source;
        }

        public static T AddJSProperty<T>(this T source, string name, object value) where T : ASPxEditBase
        {
            source.JSProperties[name] = value;

            return source;
        }
    }
}