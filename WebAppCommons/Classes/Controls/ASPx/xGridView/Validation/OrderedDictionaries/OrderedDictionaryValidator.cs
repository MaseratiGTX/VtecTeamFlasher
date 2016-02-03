using System.Collections.Generic;
using System.Collections.Specialized;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using Commons.Validation.Exceptions;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xGridView.Validation.OrderedDictionaries
{
    public class OrderedDictionaryValidator
    {
        public ASPxGridView SourceASPxGridView { get; private set; }
        public OrderedDictionary Validatable { get; private set; }



        public OrderedDictionaryValidator(ASPxGridView sourceASPxGridView)
        {
            SourceASPxGridView = sourceASPxGridView;
        }



        public OrderedDictionaryValidator Validate(OrderedDictionary newValues)
        {
            Validatable = newValues;

            return this;
        }



        public OrderedDictionaryValidator AssertNotNull(string messageFormat, string fieldName)
        {
            var validatableValue = GetFieldValidatableValue(fieldName);

            if (validatableValue == null)
            {
                Return(messageFormat, fieldName);
            }

            return this;
        }

        public OrderedDictionaryValidator AssertNotNull(string messageFormat, params string[] fieldNames)
        {
            return AssertNotNull(messageFormat, (IEnumerable<string>)fieldNames);
        }

        public OrderedDictionaryValidator AssertNotNull(string messageFormat, IEnumerable<string> fieldNames)
        {
            foreach (var fieldName in fieldNames)
            {
                AssertNotNull(messageFormat, fieldName);
            }

            return this;
        }



        private void Return(string messageFormat, string fieldName)
        {
            throw new ValidationException(messageFormat.FillWith(CalculateFormatArgs(fieldName)), fieldName);
        }


        private object GetFieldValidatableValue(string fieldName)
        {
            return Validatable.Contains(fieldName) ? Validatable[fieldName] : null;
        }


        private object[] CalculateFormatArgs(string fieldName)
        {
            var validatableValue = GetFieldValidatableValue(fieldName);

            var fieldColumn = SourceASPxGridView.ColumnOf(fieldName);

            var columnCaption = Clean(fieldColumn != null ? fieldColumn.Caption : null);
            var editFormCaption = Clean(fieldColumn != null ? fieldColumn.EditFormSettings.Caption : null);


            return new[] { fieldName, validatableValue, columnCaption, editFormCaption };
        }

        private static string Clean(string source)
        {
            if (source.IsEmpty()) return source;

            return source.Trim().TrimEnd(':');
        }
    }
}