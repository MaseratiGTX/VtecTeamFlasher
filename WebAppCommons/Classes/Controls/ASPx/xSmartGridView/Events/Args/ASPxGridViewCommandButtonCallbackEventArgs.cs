using System;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Events.Args
{
    public class ASPxGridViewCommandButtonCallbackEventArgs : EventArgs
    {
        public ColumnCommandButtonType ButtonType { get; protected set; }
        
        public int VisibleIndex { get; protected set; }



        public ASPxGridViewCommandButtonCallbackEventArgs(ColumnCommandButtonType buttonType, int visibleIndex)
        {
            ButtonType = buttonType;
            VisibleIndex = visibleIndex;
        }
    }
}