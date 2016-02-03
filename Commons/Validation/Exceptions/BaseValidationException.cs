using System;

namespace Commons.Validation.Exceptions
{
    public abstract class BaseValidationException: Exception
    {
        public object Context { get; private set; }

        protected BaseValidationException(string message) : base(message)
        {
        }

        protected BaseValidationException(string message, object context) : this(message)
        {
            Context = context;
        }
    }
}