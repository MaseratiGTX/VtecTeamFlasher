using System;
using Commons.Helpers.DigitToStringHelper.Languages;

namespace Commons.Helpers.DigitToStringHelper
{
    public static class DigitToStringHelper
    {
        public static string SumConvertToString(decimal decimalNumber, CurrencyType currencyType, string language)
        {
            var integralDecimalPart = Math.Truncate(Math.Abs(decimalNumber));

            var fractionalDecimalPart = (uint)(Math.Truncate((Math.Abs(decimalNumber) - integralDecimalPart) * 100));


            var convertedNumber = new DigitLanguageFactory().
                            CreateDigit(language).
                            ConvertToString(integralDecimalPart, currencyType.BaseUnit).
                            AddSignPart(decimalNumber).
                            GetConvertedNumber();


            return string.Format("{0} {1} ", convertedNumber, AddFractionalPart(fractionalDecimalPart, currencyType, language));
        }


        private static string AddFractionalPart(uint fractionalPart, CurrencyType currencyType, string language)
        {
            return new DigitLanguageFactory().
                            CreateDigit(language).ConvertToString(fractionalPart, currencyType.FractionalUnit).
                            GetConvertedNumber().
                            ToString();
        }
    }
}