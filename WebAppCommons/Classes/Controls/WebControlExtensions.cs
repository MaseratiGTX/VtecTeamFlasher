using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;

namespace WebAppCommons.Classes.Controls
{
    public static class WebControlExtensions
    {
        public static T SetStyle<T>(this T source, string name, string value) where T: WebControl
        {
            return source.SetStyle(name, value, "");
        } 

        public static T SetStyle<T>(this T source, string name, object value, object defaultValue) where T: WebControl
        {
            RenderUtils.SetStyleAttribute(source, name, value, defaultValue);

            return source;
        }


        public static T AddCssClass<T>(this T source, string className) where T : WebControl
        {
            source.CssClass = RenderUtils.CombineCssClasses(source.CssClass, className);

            return source;
        }
    }
}