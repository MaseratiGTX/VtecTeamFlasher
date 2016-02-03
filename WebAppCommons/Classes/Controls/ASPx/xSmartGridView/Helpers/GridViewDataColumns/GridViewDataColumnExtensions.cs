using System;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewDataColumns
{
    public static class GridViewDataColumnExtensions
    {
        public static Type _GetDataType(this GridViewDataColumn source)
        {
            return GridViewDataColumnMembersRepository.GetDataType.Invoke(source);
        }
    }
}