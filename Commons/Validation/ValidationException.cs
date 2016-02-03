using System;

namespace com.neoservice.neofiscal.Commons.Validation
{
    public class ValidationException : Exception
    {
        public int Code { get; private set; }
        public object Context { get; private set; }


        public ValidationException(string message) : base(message)
        {
            Code = ValidationCodesRepository.AnotherReasonValidationFailed;
        }


        public ValidationException(int code, string message) : base(message)
        {
            Code = code;
        }


        public ValidationException(int code, object context, string message) : base(message)
        {
            Code = code;
            Context = context;
        }
    }
}