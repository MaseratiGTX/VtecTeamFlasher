namespace Commons.Helpers.DigitToStringHelper
{
    /// <summary>
    /// Указывает род и число.
    /// Может передаваться в качестве параметра "единица измерения" метода 
    /// <see cref="CDigit.ToNoun"/>.
    /// Управляет родом и числом числительных один и два.
    /// </summary>
    /// <example>
    /// CDigit.SumConvertToString (2, DigitKindAndQuantity.ManLike); // "два"
    /// CDigit.SumConvertToString (2, DigitKindAndQuantity.Feminish); // "две"
    /// CDigit.SumConvertToString (21, DigitKindAndQuantity.Neutral); // "двадцать одно"
    /// </example>
    public abstract class DigitKindAndQuantity : IUnit
    {
        internal abstract string GetFormat(IChangingByKind word);

        class _ManLike : DigitKindAndQuantity
        {
            internal override string GetFormat(IChangingByKind word)
            {
                return word.ManLike;
            }
        }

        class _Feminish : DigitKindAndQuantity
        {
            internal override string GetFormat(IChangingByKind word)
            {
                return word.Feminish;
            }
        }

        class _Neutral : DigitKindAndQuantity
        {
            internal override string GetFormat(IChangingByKind word)
            {
                return word.Neutral;
            }
        }

        class _Plural : DigitKindAndQuantity
        {
            internal override string GetFormat(IChangingByKind word)
            {
                return word.Plural;
            }
        }

        public static readonly DigitKindAndQuantity ManLike = new _ManLike();
        public static readonly DigitKindAndQuantity Feminish = new _Feminish();
        public static readonly DigitKindAndQuantity Neutral = new _Neutral();
        public static readonly DigitKindAndQuantity Plural = new _Plural();


        DigitKindAndQuantity IUnit.DigitKindAndQuantity
        {
            get { return this; }
        }

        string IUnit.SubjectiveCase
        {
            get { return null; }
        }

        string IUnit.GenitiveOnly
        {
            get { return null; }
        }

        string IUnit.GenitivePlural
        {
            get { return null; }
        }
    }
}