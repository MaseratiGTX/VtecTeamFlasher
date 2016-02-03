using System;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using Commons.Validation.Exceptions;

namespace Commons.Validation.Assertions.Assertors
{
    public abstract class BaseAssertor
    {
        public virtual void Return(string message)
        {
            Return<ValidationException>(message);
        }

        public virtual void Return<T>(string message) where T : BaseValidationException
        {
            Return<T>(null, message);
        }

        public void Return(string fieldName, string message)
        {
            Return<ValidationException>(fieldName, message);
        }

        public void Return(int code, string message, object context = null)
        {
            Return<CommonValidationException>(code, message, context);
        }

        public abstract void Return<T>(object key, string message, object context = null) where T : BaseValidationException;



        protected virtual void ReturnResult<T>(object key, string messageFormat, object context, params object[] args) where T : BaseValidationException
        {
            var message = messageFormat.IsNotEmpty() ? messageFormat.FillWith(args) : string.Empty;
           
            if (key.IsEmpty())
            {
                key = typeof(T) == typeof(ValidationException) ? (object)string.Empty : 0;        
            }

            throw (T) Activator.CreateInstance(typeof(T), message, key, context);
        }
    }
}