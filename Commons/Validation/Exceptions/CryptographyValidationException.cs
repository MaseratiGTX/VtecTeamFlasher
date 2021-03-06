﻿namespace com.neoservice.neofiscal.Commons.Validation.Exceptions
{
    public class CryptographyValidationException : ValidationException
    {
        public int Code { get; private set; }
        public object Context { get; private set; }


        public CryptographyValidationException(string message) : base(message)
        {
            Code = ValidationCodesRepository.AnotherReasonValidationFailed;
        }

        public CryptographyValidationException(string fieldName, string message) : base(fieldName, message)
        {
            Code = ValidationCodesRepository.AnotherReasonValidationFailed;
        }


        public CryptographyValidationException(int code, string message) : base(message)
        {
            Code = code;
        }


        public CryptographyValidationException(int code, object context, string message) : base(message)
        {
            Code = code;
            Context = context;
        }
    }
}