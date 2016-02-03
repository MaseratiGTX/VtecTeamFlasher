namespace Commons.Validation.Exceptions
{
    public class CommonValidationException : BaseValidationException
    {  
        public int Code { get; set; }

        public CommonValidationException(string message) : base(message)
        {
        }

        public CommonValidationException(string message, int code, object context = null) : base(message,context)
        {
            Code = code;
        }
    }
}