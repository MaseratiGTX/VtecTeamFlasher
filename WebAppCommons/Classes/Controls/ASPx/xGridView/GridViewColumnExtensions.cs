using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xGridView
{
    public static class GridViewColumnExtensions
    {
        public static IEnumerable<string> FieldNames(this IEnumerable<GridViewColumn> source)
        {
            return source.Select(x => x.FieldName());
        }

        public static string FieldName(this GridViewColumn source)
        {
            var dataColumn = source as GridViewDataColumn;

            if (dataColumn != null)
            {
                return dataColumn.FieldName;
            }

            return string.Empty;
        }


        public static int GroupIndex(this GridViewColumn source)
        {
            var dataColumn = source as GridViewDataColumn;

            if (dataColumn != null)
            {
                return dataColumn.GroupIndex;
            }

            return -1;
        }

        public static bool Grouped(this GridViewColumn source)
        {
            return source.GroupIndex() != -1;
        }

        public static bool NotGrouped(this GridViewColumn source)
        {
            return source.Grouped() == false;
        }


        public static void EditFormCaptionStyle(this GridViewColumn source, Action<GridViewEditFormCaptionStyle> action)
        {
            var dataColumn = source as GridViewDataColumn;

            if (dataColumn != null)
            {
                action.Invoke(dataColumn.EditFormCaptionStyle);
            }
        }
    }
}