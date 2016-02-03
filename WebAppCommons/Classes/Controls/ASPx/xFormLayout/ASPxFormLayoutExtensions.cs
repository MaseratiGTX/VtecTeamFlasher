using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.Objects;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxFormLayout;

namespace WebAppCommons.Classes.Controls.ASPx.xFormLayout
{
    public static class ASPxFormLayoutExtensions
    {
        public static ASPxFormLayout ApplyDataSource<T>(this ASPxFormLayout source, T dataSource)
            where T : class
        {
            source.DataSource = dataSource;
            source.DataBind();

            return source;
        }


        public static OrderedDictionary NewValues(this ASPxFormLayout source)
        {
            return source.GetControlValues<ASPxEdit>(x => x.Value);
        }

        public static OrderedDictionary GetControlValues<T>(this ASPxFormLayout source, Func<T, object> valueSelector) 
            where T : Control
        {
            var result = new OrderedDictionary();

            source
                .GetItems<LayoutItem>()
                .Where(x => x.FieldName.IsNotEmpty())
                .Each(x =>
                    {
                        var nestedControl = x.GetNestedControl() as T;

                        if (nestedControl != null)
                        {
                            result.Add(x.FieldName, valueSelector(nestedControl));
                        }
                    }
                );

            return result;
        }


        public static IEnumerable<T> GetItems<T>(this ASPxFormLayout source) where T : LayoutItemBase
        {
            return source.Items.GetItems<T>();
        }

        private static IEnumerable<T> GetItems<T>(this LayoutItemCollection source) where T : LayoutItemBase
        {
            foreach (var item in source)
            {
                var groupItem = item as LayoutGroupBase;

                if (groupItem != null)
                {
                    foreach (var childItem in groupItem.Items.GetItems<T>())
                    {
                        yield return childItem;
                    }
                }

                if (item is T)
                {
                    yield return item as T;
                }
            }
        }


        public static void SetFocus(this ASPxFormLayout source, string fieldName)
        {
            source.FindNestedControlByFieldName(fieldName).IfFound(x => x.Focus());
        }

        public static void SetFocusByID(this ASPxFormLayout source, string controlIdPart)
        {
            source.FindControlSmart(x => IsEmptyExtensions.IsNotEmpty(x.ID) && x.ID.Contains(controlIdPart)).IfFound(x => x.Focus());
        }
    }
}
