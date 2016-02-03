using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
using DevExpress.Web.Data;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Events.Args
{
    public class ASPxGridViewTableDataRowEventArgs : ASPxGridViewTableRowEventArgs
    {
        protected virtual ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) ((GridViewTableRow) Row).Grid; }
        }

        protected virtual WebDataProxy DataProxy
        {
            get { return Grid.DataProxy; }
        }


        protected IValueProvider RowValueProvider
        {
            get { return Row as IValueProvider; }
        }



        public ASPxGridViewTableDataRowEventArgs(GridViewTableRow row, object keyValue) : base(row, keyValue)
        {
        }

        internal ASPxGridViewTableDataRowEventArgs(GridViewTableRow row) : this(row, null)
        {
        }



        public object GetItem()
        {
            return GetItem(VisibleIndex);
        }

        public T GetItem<T>() where T : class
        {
            return GetItem<T>(VisibleIndex);
        }

        public object GetFieldValue(string fieldName)
        {
            return RowValueProvider != null ? RowValueProvider.GetValue(fieldName) : GetFieldValue(VisibleIndex, fieldName);
        }


        public object GetItem(int visibleRowIndex)
        {
            return visibleRowIndex != ASPxGridView.InvalidRowIndex ? Grid.GetRow(visibleRowIndex) : null;
        }

        public T GetItem<T>(int visibleRowIndex)
        {
            return (T) GetItem(visibleRowIndex);
        }

        public object GetFieldValue(int visibleRowIndex, string fieldName)
        {
            return DataProxy.GetRowValue(visibleRowIndex, fieldName);
        }
    }
}