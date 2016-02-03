using System.ComponentModel;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Events.Args
{
    public class ASPxCancelSearchingEventArgs : CancelEventArgs
    {
        public string FilterExpression { get; set; }
        public string SearchDetails { get; set; }



        public ASPxCancelSearchingEventArgs()
        {
            FilterExpression = null;
            SearchDetails = null;
        }


        internal string CalculateFilterExpression()
        {
            return FilterExpression ?? string.Empty;
        }

        internal string CalculateSearchDetails()
        {
            return SearchDetails ?? string.Empty;
        }
    }
}