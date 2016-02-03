using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.CommonObjects;
using DevExpress.Web.ASPxClasses.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers
{
    public static class ClientScriptHelper
    {
        public static string CreateNewInstanceScript(this string className, params string[] parameters)
        {
            var constructorParameters = parameters.ToString(x => x, ", ") ?? string.Empty;

            return "new {0}({1})".FillWith(className, constructorParameters);
        }

        public static string CreateItemSelectorScript(this string arrayName, int itemIndex)
        {
            return "{0}[{1}]".FillWith(arrayName, itemIndex);
        }


        public static string ToScript(this object value)
        {
            return HtmlConvertor.ToScript(value);
        }


        public static string ToObjectArrayScript(this IEnumerable<string> objects, bool inline = false)
        {
            var elementSeparator = "," + (inline ? " " : "\n");
            
            return "[{0}]".FillWith(objects.ToString(x => x, elementSeparator));
        }

        public static string ToObjectArrayScript<T>(this IEnumerable<T> objects, Func<T, string> selector, bool inline = false)
        {
            return objects.Select(selector).ToObjectArrayScript(inline);
        }


        public static string ToCommonEventHandler(this string clientCode)
        {
            return string.Format(
                "function (s, e) {{ {0} }}", clientCode
            );
        }
    }
}