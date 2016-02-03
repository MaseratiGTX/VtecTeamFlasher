using System.Text.RegularExpressions;

namespace Commons.Validation.Assertions.Assertors.Common.IComparable
{
    public class MatchAssertor<T> : CommonAssertor<T>
    {
        public Regex Regex { get; protected set; }


        public MatchAssertor(T validatable, Regex regex) : base(validatable)
        {
            Regex = regex;
        }


        public override void Return<TReturnException>(object key, string messageFormat, object context = null)
        {
            if (Regex.IsMatch(Validatable.ToString()) == false)
            {
                ReturnResult<TReturnException>(key, messageFormat, context, new object[] { key, Regex.ToString() });
            }
        }
    }
}