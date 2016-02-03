
namespace Commons.Validation.Assertions.Assertors.Common
{
    public abstract class CommonAssertor<T> : BaseAssertor
    {
        public T Validatable { get; protected set; }


        protected CommonAssertor(T validatable)
        {
            Validatable = validatable;
        }
    }
}