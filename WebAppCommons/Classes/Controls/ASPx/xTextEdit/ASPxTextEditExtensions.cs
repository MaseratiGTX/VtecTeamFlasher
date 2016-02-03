using DevExpress.Web.ASPxEditors;
using WebAppCommons.Classes.Controls.ASPx.xTextEdit.TextEditProperties;

namespace WebAppCommons.Classes.Controls.ASPx.xTextEdit
{
    public static class ASPxTextEditExtensions
    {
        public static string NullText(this ASPxTextEdit source)
        {
            return source._Properties()._NullTextInternal();
        }

        public static void NullText(this ASPxTextEdit source, string value)
        {
            source._Properties()._NullTextInternal(value);
        }


        public static DevExpress.Web.ASPxEditors.TextEditProperties _Properties(this ASPxTextEdit source)
        {
            return ASPxTextEditMembersRepository.PropertiesGetter.Invoke(source);
        }
    }
}