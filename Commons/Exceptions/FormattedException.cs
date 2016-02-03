using System;
using Commons.Helpers.CommonObjects;

namespace Commons.Exceptions
{
    public class FormattedException : Exception
    {
        public FormattedException()
        {
        }

        public FormattedException(string messageFomat, params object[] args) : base(messageFomat.FillWith(args))
        {
        }
    }
}