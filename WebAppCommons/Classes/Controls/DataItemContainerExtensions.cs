using System.Web.UI;

namespace WebAppCommons.Classes.Controls
{
    public static class DataItemContainerExtensions
    {
        public static IDataItemContainer DataItemContainer(this object source)
        {
            var sourceControl = source as Control;

            if (sourceControl != null)
            {
                return (IDataItemContainer) sourceControl.DataItemContainer;
            }

            return null;
        }

        public static object DataItemContainer(this object source, string fieldName)
        {
            return source.DataItemContainer().GetFieldValue(fieldName);
        }

        public static T DataItemContainer<T>(this object source, string fieldName)
        {
            return source.DataItemContainer().GetFieldValue<T>(fieldName);
        }


        public static object GetFieldValue(this Control source, string fieldName)
        {
            return (source as IDataItemContainer).GetFieldValue(fieldName);
        }

        public static T GetFieldValue<T>(this Control source, string fieldName)
        {
            return (source as IDataItemContainer).GetFieldValue<T>(fieldName);
        }


        public static object GetFieldValue(this IDataItemContainer source, string fieldName)
        {
            if (source == null) return null;

            if (source.DataItem == null) return null;

            return DataBinder.Eval(source.DataItem, fieldName);
        }

        public static T GetFieldValue<T>(this IDataItemContainer source, string fieldName)
        {
            return (T)source.GetFieldValue(fieldName);
        }
    }
}