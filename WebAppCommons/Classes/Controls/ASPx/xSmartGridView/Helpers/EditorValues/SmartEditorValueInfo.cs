namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.EditorValues
{
    public class SmartEditorValueInfo
    {
        public int ColumnIndex { get; private set; }
        public object Value { get; private set; }


        public SmartEditorValueInfo(int columnIndex, object value)
        {
            ColumnIndex = columnIndex;
            Value = value;
        }
    }
}