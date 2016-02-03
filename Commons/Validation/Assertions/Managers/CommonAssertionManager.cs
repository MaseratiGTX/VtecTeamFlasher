using Commons.Validation.Assertions.Assertors.Common;

namespace Commons.Validation.Assertions.Managers
{
    public class CommonAssertionManager<T>
    {
        public T Validatable { get; private set; }



        public CommonAssertionManager(T validatable)
        {
            Validatable = validatable;
        }



        public CommonAssertor<T> IsNull()
        {
            return new IsNullCommonAssertor<T>(Validatable);
        }

        public CommonAssertor<T> IsNotNull()
        {
            return new IsNotNullCommonAssertor<T>(Validatable);
        }


        public CommonAssertor<T> IsEmpty()
        {
            return new IsEmptyCommonAssertor<T>(Validatable);
        }

        public CommonAssertor<T> IsNotEmpty()
        {
            return new IsNotEmptyCommonAssertor<T>(Validatable);
        }


        public CommonAssertor<T> IsNumeric()
        {
            return new IsNumericCommonAssertor<T>(Validatable);
        }
    }
}