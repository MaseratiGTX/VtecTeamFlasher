using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xGridView.Validation.OrderedDictionaries
{
    public static class OrderedDictionaryValidationExtensions
    {
        public static OrderedDictionaryValidator Validate(this ASPxGridView source, System.Collections.Specialized.OrderedDictionary newValues)
        {
            return new OrderedDictionaryValidator(source).Validate(newValues);
        }
    }
}