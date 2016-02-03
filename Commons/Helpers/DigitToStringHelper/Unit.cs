namespace Commons.Helpers.DigitToStringHelper
{
    /// <summary>
    /// �����, �������� �������� ����� ������� ��������� � ����� ����.
    /// </summary>
    public class Unit : IUnit
    {
        /// <summary> </summary>
        public Unit(
            DigitKindAndQuantity digitKindAndQuantity,
            string ��������,
            string �������,
            string �������)
        {
            this.digitKindAndQuantity = digitKindAndQuantity;
            this._subjectiveCase = ��������;
            this.������� = �������;
            this.������� = �������;
        }

        readonly DigitKindAndQuantity digitKindAndQuantity;
        readonly string _subjectiveCase;
        readonly string �������;
        readonly string �������;

        #region IUnit Members

        string IUnit.SubjectiveCase
        {
            get { return _subjectiveCase; }
        }

        string IUnit.GenitiveOnly
        {
            get { return �������; }
        }

        string IUnit.GenitivePlural
        {
            get { return �������; }
        }

        DigitKindAndQuantity IUnit.DigitKindAndQuantity
        {
            get { return digitKindAndQuantity; }
        }

        #endregion
    }
}