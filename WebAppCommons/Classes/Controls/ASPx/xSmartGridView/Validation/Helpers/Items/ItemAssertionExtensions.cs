using Commons.Helpers.Objects;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation.Exceptions;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation.Helpers.Items
{
    public static class ItemAssertionExtensions
    {
        public static T AssertFound<T>(this T source, string message = null)
        {
            if (source.IsNotNull() == false)
            {
                throw new SourceElementNotFoundException(
                    message ?? "Can not perform the requested action: corresponded item is already removed."
                );
            }
            
            return source;
        }
    }
}