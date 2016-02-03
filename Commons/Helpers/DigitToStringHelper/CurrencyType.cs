namespace Commons.Helpers.DigitToStringHelper
{
    public class CurrencyType
    {
        public IUnit BaseUnit { get; private set; }

        public IUnit FractionalUnit { get; private set; }



        public CurrencyType(IUnit basePart, IUnit fractional)
        {
            BaseUnit = basePart;
            FractionalUnit = fractional;
        }
    }
}