using System;
using Commons.Helpers.Objects;
using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx
{
    public static class ASPxEditHelper
    {
        public static bool HasValue<T>(this T source) where T : ASPxEdit
        {
            return source.GetValue() != null;
        }


        public static object GetValue(this ASPxEdit source)
        {
            if (source is ASPxComboBox)
            {
                var comboBox = (ASPxComboBox)source;

                if (comboBox.SelectedItem != null)
                {
                    return comboBox.SelectedItem.Value;
                }

                return comboBox.Value;
            }


            if (source is ASPxTextBox || source is ASPxMemo || source is ASPxButtonEdit)
            {
                var textBox = (ASPxTextEdit)source;

                if (textBox.Text != default(string))
                {
                    return textBox.Text;
                }

                return textBox.Value;
            }


            if (source is ASPxDateEdit)
            {
                var dateEdit = (ASPxDateEdit)source;

                if (dateEdit.Date != default(DateTime))
                {
                    return dateEdit.Date;
                }

                return dateEdit.Value;
            }


            if (source is ASPxTimeEdit)
            {
                var dateEdit = (ASPxTimeEdit)source;

                if (dateEdit.DateTime != default(DateTime))
                {
                    return dateEdit.DateTime;
                }

                return dateEdit.Value;
            }


            if (source is ASPxSpinEdit || source is ASPxCheckBox || source is ASPxRadioButtonList)
            {
                return source.Value;
            }


            throw new NotSupportedException(String.Format("Передан не поддерживаемый тип объекта: '{0}'", source.TypeName()));
        }

        public static T GetValue<T>(this ASPxEdit source)
        {
            return source.GetValue().As<T>();
        }


        public static T SetValue<T>(this T source, object value) where T : ASPxEdit
        {
            source.Value = value;

            return source;
        }
    }
}