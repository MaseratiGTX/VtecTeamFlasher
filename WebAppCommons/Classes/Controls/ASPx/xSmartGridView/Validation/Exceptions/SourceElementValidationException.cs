using System;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation.Exceptions
{
    public class SourceElementValidationException : Exception
    {
        public string FieldName { get; private set; }


        public SourceElementValidationException(string message) : base(message)
        {
        }

        public SourceElementValidationException(string message, string fieldName) : this(message)
        {
            FieldName = fieldName;
        }
    }
}