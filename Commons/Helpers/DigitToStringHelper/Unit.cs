namespace Commons.Helpers.DigitToStringHelper
{
    /// <summary>
    ///  ласс, хран€щий падежные формы единицы измерени€ в €вном виде.
    /// </summary>
    public class Unit : IUnit
    {
        /// <summary> </summary>
        public Unit(
            DigitKindAndQuantity digitKindAndQuantity,
            string имен≈дин,
            string род≈дин,
            string родћнож)
        {
            this.digitKindAndQuantity = digitKindAndQuantity;
            this._subjectiveCase = имен≈дин;
            this.род≈дин = род≈дин;
            this.родћнож = родћнож;
        }

        readonly DigitKindAndQuantity digitKindAndQuantity;
        readonly string _subjectiveCase;
        readonly string род≈дин;
        readonly string родћнож;

        #region IUnit Members

        string IUnit.SubjectiveCase
        {
            get { return _subjectiveCase; }
        }

        string IUnit.GenitiveOnly
        {
            get { return род≈дин; }
        }

        string IUnit.GenitivePlural
        {
            get { return родћнож; }
        }

        DigitKindAndQuantity IUnit.DigitKindAndQuantity
        {
            get { return digitKindAndQuantity; }
        }

        #endregion
    }
}