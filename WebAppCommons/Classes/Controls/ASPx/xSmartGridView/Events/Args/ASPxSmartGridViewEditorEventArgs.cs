using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Events.Args
{
    public class ASPxSmartGridViewEditorEventArgs : ASPxGridViewEditorEventArgs,ICustomColumnText
    {
        public ASPxSmartGridViewEditorEventArgs(GridViewDataColumn column, int visibleIndex, ASPxEditBase editor, object keyValue, object value) : base(column, visibleIndex, editor, keyValue, value)
        {
        }
    }
}
