using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxEditors.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xListBox.ListEditItems
{
    public static class ListEditItemExtensions
    {
        public static ListEditDataItemWrapper _DataItemWrapper(this ListEditItem source)
        {
            return ListEditItemMembersRepository.DataItemWrapperGetter.Invoke(source);
        }


        public static object DataItem(this ListEditItem source)
        {
            var dataItemWrapper = source._DataItemWrapper();

            return dataItemWrapper != null ? dataItemWrapper.DataItem : null;
        }

        public static T DataItem<T>(this ListEditItem source)
        {
            return (T) source.DataItem();
        }
    }
}