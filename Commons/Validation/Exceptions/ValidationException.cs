namespace Commons.Validation.Exceptions
{
    public class ValidationException : BaseValidationException
    {
        public string FieldName { get; set; }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, string fieldName, object context = null)
            : base(message, context)
        {
            FieldName = fieldName;
        }
    }
}