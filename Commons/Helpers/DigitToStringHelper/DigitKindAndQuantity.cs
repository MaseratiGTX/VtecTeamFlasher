namespace Commons.Helpers.DigitToStringHelper
{
    /// <summary>
    /// ��������� ��� � �����.
    /// ����� ������������ � �������� ��������� "������� ���������" ������ 
    /// <see cref="CDigit.ToNoun"/>.
    /// ��������� ����� � ������ ������������ ���� � ���.
    /// </summary>
    /// <example>
    /// CDigit.SumConvertToString (2, DigitKindAndQuantity.ManLike); // "���"
    /// CDigit.SumConvertToString (2, DigitKindAndQuantity.Feminish); // "���"
    /// CDigit.SumConvertToString (21, DigitKindAndQuantity.Neutral); // "�������� ����"
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