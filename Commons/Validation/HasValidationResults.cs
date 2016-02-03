using Commons.Validation.Exceptions;

namespace Commons.Validation
{
    public class HasValidationResults
    {
        protected void Return(string message)
        {
            throw new CommonValidationException(message, ValidationCodesRepository.AnotherReasonValidationFailed);
        }

        protected void Return(int code, string message)
        {
            throw new CommonValidationException(message, code);
        }

        protected void Return(int code, object context, string message)
        {
            throw new CommonValidationException(message, code, context);
        }
    }
}