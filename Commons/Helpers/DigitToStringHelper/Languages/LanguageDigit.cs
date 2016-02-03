using System;
using System.Text;

namespace Commons.Helpers.DigitToStringHelper.Languages
{
    public abstract class LanguageDigit
    {
        protected StringBuilder convertedNumber = new StringBuilder();



        public abstract LanguageDigit ConvertToString(decimal number, IUnit unit);

        public abstract LanguageDigit AddSignPart(decimal number);

        protected abstract double GetMaxDouble();


        public StringBuilder GetConvertedNumber()
        {
            return convertedNumber;
        }

        protected static void CheckNumber(decimal decimalNumber)
        {
            if (decimalNumber < 0)
                throw new Exception("Значение должно быть больше или равно нулю.");

            if (decimalNumber != decimal.Floor(decimalNumber))
                throw new Exception("Значение не должно содержать дробной части.");
        }


        protected void CheckNumber(double number)
        {
            if (number < 0)
            {
                throw new Exception("Значение должно быть больше или равно нулю.");
            }

            if (number != Math.Floor(number))
            {
                throw new Exception("Значение не должно содержать дробной части.");
            }

            if (number > GetMaxDouble())
            {
                throw new Exception(string.Format("Значение должно быть не больше {0}.", GetMaxDouble()));
            }
        }
    }
}
