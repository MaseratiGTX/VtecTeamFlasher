namespace WebAppCommons.Classes.Controls.ASPx.xTextEdit.TextEditProperties
{
    public static class TextEditPropertiesExtensions
    {
        public static string _NullTextInternal(this DevExpress.Web.ASPxEditors.TextEditProperties source)
        {
            return TextEditPropertiesMembersRepository.NullTextInternalGetter.Invoke(source);
        }

        public static void _NullTextInternal(this DevExpress.Web.ASPxEditors.TextEditProperties source, string value)
        {
            TextEditPropertiesMembersRepository.NullTextInternalSetter.Invoke(source, value);
        }
    }
}