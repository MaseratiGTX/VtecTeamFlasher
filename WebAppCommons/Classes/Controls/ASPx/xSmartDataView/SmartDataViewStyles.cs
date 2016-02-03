using System.Web.UI.WebControls;
using DevExpress.Web.ASPxDataView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartDataView
{
    public class SmartDataViewStyles : DataViewStyles
    {
        public SmartDataViewStyles(ASPxSmartDataView dataView) : base(dataView)
        {
        }


        protected override Unit GetItemSpacing()
        {
            return Unit.Pixel(5);
        }

        protected override Unit GetItemWidth()
        {
            return Unit.Empty;
        }
    }
}