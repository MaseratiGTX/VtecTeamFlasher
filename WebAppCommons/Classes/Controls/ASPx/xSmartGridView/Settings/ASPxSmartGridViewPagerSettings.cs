using System;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings
{
    public class ASPxSmartGridViewPagerSettings : ASPxGridViewPagerSettings
    {
        public new GridViewPagerMode Mode
        {
            get { return base.Mode; }
            set
            {
                if (value == GridViewPagerMode.EndlessPaging)
                {
                    throw new NotSupportedException("EndlessPaging is not supported");
                }

                base.Mode = value;
            }
        }



        public ASPxSmartGridViewPagerSettings(ASPxSmartGridView grid) : base(grid)
        {
        }
    }
}