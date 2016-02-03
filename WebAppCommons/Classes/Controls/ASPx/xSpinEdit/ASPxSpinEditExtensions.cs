using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSpinEdit
{
    public static class ASPxSpinEditExtensions
    {
        public static ASPxSpinEdit ApplyScheme(this ASPxSpinEdit source, ASPxSpinEditSceme spinEditSceme)
        {
            source.MinValue = 0;
            source.Increment = 1;
            source.NumberType = SpinEditNumberType.Float;
            source.DecimalPlaces = 2;

            switch (spinEditSceme)
            {
                case ASPxSpinEditSceme.Numeric:
                    source.MaxValue = int.MaxValue;
                    source.LargeIncrement = 1000;
                    source.DisplayFormatString = "{0:n2}";
                    break;

                case ASPxSpinEditSceme.Percent:
                    source.MaxValue = 100;
                    source.LargeIncrement = 10;
                    source.DisplayFormatString = "{0:n2}%";
                    break;
            }

            return source;
        }

        public static GridViewDataSpinEditColumn ApplyScheme(this GridViewDataSpinEditColumn source, ASPxSpinEditSceme spinEditSceme)
        {
            source.PropertiesSpinEdit.MinValue = 0;
            source.PropertiesSpinEdit.Increment = 1;
            source.PropertiesSpinEdit.NumberType = SpinEditNumberType.Float;
            source.PropertiesSpinEdit.NumberFormat = SpinEditNumberFormat.Number;
            source.PropertiesSpinEdit.DecimalPlaces = 2;
            source.PropertiesSpinEdit.DisplayFormatInEditMode = true;

            switch (spinEditSceme)
            {
                case ASPxSpinEditSceme.Numeric:
                    source.PropertiesSpinEdit.MaxValue = int.MaxValue;
                    source.PropertiesSpinEdit.LargeIncrement = 1000;
                    source.PropertiesSpinEdit.DisplayFormatString = "{0:n2}";
                    break;

                case ASPxSpinEditSceme.Percent:
                    source.PropertiesSpinEdit.MaxValue = 100;
                    source.PropertiesSpinEdit.LargeIncrement = 10;
                    source.PropertiesSpinEdit.DisplayFormatString = "{0:n2}%";
                    break;
            }

            return source;
        }
    }
}