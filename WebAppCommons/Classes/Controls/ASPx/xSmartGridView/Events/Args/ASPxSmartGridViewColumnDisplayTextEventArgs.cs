using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Events.Args
{
    public class ASPxSmartGridViewColumnDisplayTextEventArgs : ASPxGridViewColumnDisplayTextEventArgs,ICustomColumnText
    {
        public ASPxSmartGridViewColumnDisplayTextEventArgs(GridViewDataColumn column, int visibleRowIndex, object _value) : base(column, visibleRowIndex, _value)
        {
        }
    }
}
