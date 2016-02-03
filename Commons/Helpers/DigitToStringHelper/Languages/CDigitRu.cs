using System;
using System.Text;

namespace Commons.Helpers.DigitToStringHelper.Languages
{

    public class CDigitRu : LanguageDigit
    {
        

        /// <summary>
        /// �������� ������� ����� � ������������� �������� ���������.
        /// </summary>
        /// <param name="decimalDigit"> CDigit ������ ���� �����, ���������������. </param>
        /// <param name="unit"></param>
        /// <param name="result"> ���� ������������ ���������. </param>
        /// <returns> <paramref name="result"/> </returns>
        /// <exception cref="ArgumentException">
        /// ���� decimalDigit ������ ���� ��� �� �����. 
        /// </exception>
        public override LanguageDigit ConvertToString(decimal decimalDigit, IUnit unit)
        {
            
            CheckNumber(decimalDigit);


            // ������������� ������ �������� � ���� �������, ��� decimal.
            if (decimalDigit <= uint.MaxValue)
            {
                ConvertToString((uint)decimalDigit, unit, convertedNumber);
            }
            else if (decimalDigit <= ulong.MaxValue)
            {
                ConvertToString((ulong)decimalDigit, unit, convertedNumber);
            }
            else
            {
                decimal div1000 = Math.Floor(decimalDigit / 1000);
                HightDigitClassesToString(div1000, 0, convertedNumber);
                DigitClassToString((uint)(decimalDigit - div1000 * 1000), unit, convertedNumber);
            }

            return this;
        }

        /// <summary>
        /// �������� ������� ����� � ������������� �������� ���������.
        /// </summary>
        /// <param name="doubleDigit"> 
        /// CDigit ������ ���� �����, ���������������, �� ������� <see cref="MaxDouble"/>. 
        /// </param>
        /// <param name="unit"></param>
        /// <param name="result"> ���� ������������ ���������. </param>
        /// <exception cref="ArgumentException">
        /// ���� doubleDigit ������ ����, �� ����� ��� ������ <see cref="MaxDouble"/>. 
        /// </exception>
        /// <returns> <paramref name="result"/> </returns>
        /// <remarks>
        /// float �� ��������� ������������� � double, ������� ��� ���������� ��� float.
        /// � ���������� ������ ���������� �������� ����������� ���� ������� �
        /// ������, ���������� double.ToString ("R"), ������� � 17 �������� �����.
        /// </remarks>
        public StringBuilder ConvertToString(double doubleDigit, IUnit unit, StringBuilder result)
        {
            CheckNumber(doubleDigit);
            
            if (doubleDigit <= uint.MaxValue)
            {
                ConvertToString((uint)doubleDigit, unit, result);
            }
            else if (doubleDigit <= ulong.MaxValue)
            {
                // SumConvertToString � ulong ����������� � ������� � 2 ���� �������.
                ConvertToString((ulong)doubleDigit, unit, result);
            }
            else
            {

                double div1000 = Math.Floor(doubleDigit / 1000);
                HightDigitClassesToString(div1000, 0, convertedNumber);
                DigitClassToString((uint)(doubleDigit - div1000 * 1000), unit, convertedNumber);
            }

            return result;
        }

        /// <summary>
        /// �������� ������� ����� � ������������� �������� ���������.
        /// </summary>
        /// <returns> <paramref name="result"/> </returns>
        public StringBuilder ConvertToString(ulong ulongDigit, IUnit unit, StringBuilder result)
        {
            if (ulongDigit <= uint.MaxValue)
            {
                ConvertToString((uint)ulongDigit, unit, result);
            }
            else
            {
                ulong div1000 = ulongDigit / 1000;
                HightDigitClassesToString(div1000, 0, convertedNumber);
                DigitClassToString((uint)(ulongDigit - div1000 * 1000), unit, convertedNumber);
            }

            return result;
        }

        /// <summary>
        /// �������� ������� ����� � ������������� �������� ���������.
        /// </summary>
        /// <returns> <paramref name="result"/> </returns>
        public StringBuilder ConvertToString(uint uintDigit, IUnit unit, StringBuilder result)
        {

            if (uintDigit == 0)
            {
                result.AppendString("����");
                result.AppendString(unit.GenitivePlural);
            }
            else
            {
                uint div1000 = uintDigit / 1000;
                HightDigitClassesToString(div1000, 0, result);
                DigitClassToString(uintDigit - div1000 * 1000, unit, result);
            }

            return result;
        }

        /// <summary>
        /// ���������� � <paramref name="sb"/> ������� �����, ������� � ������ 
        /// �������� ������ �� ������ � ������� <paramref name="digitClassNumber"/>.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="decimalDigit"></param>
        /// <param name="digitClassNumber">0 = ����� �����, 1 = ��������� � �.�.</param>
        /// <remarks>
        /// � ������ ��������� ��������, ����� ���������� ������ � StringBuilder 
        /// � ������ ������� - �� ������� ������� � �������.
        /// </remarks>
        void HightDigitClassesToString(decimal decimalDigit, int digitClassNumber, StringBuilder sb)
        {
            if (decimalDigit == 0) return; // ����� ��������

            // �������� � StringBuilder ������� ������� �������.
            decimal div1000 = Math.Floor(decimalDigit / 1000);
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(decimalDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        void HightDigitClassesToString(double doubleDigit, int digitClassNumber, StringBuilder sb)
        {
            if (doubleDigit == 0) return; // ����� ��������

            // �������� � StringBuilder ������� ������� �������.
            double div1000 = Math.Floor(doubleDigit / 1000);
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(doubleDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        void HightDigitClassesToString(ulong ulongDigit, int digitClassNumber, StringBuilder sb)
        {
            if (ulongDigit == 0) return; // ����� ��������

            // �������� � StringBuilder ������� ������� �������.
            ulong div1000 = ulongDigit / 1000;
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(ulongDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        void HightDigitClassesToString(uint uintDigit, int digitClassNumber, StringBuilder sb)
        {
            if (uintDigit == 0) return; // ����� ��������

            // �������� � StringBuilder ������� ������� �������.
            uint div1000 = uintDigit / 1000;
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = uintDigit - div1000 * 1000;
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        #region DigitClassToString

        /// <summary>
        /// ��������� ������ ������ � ���������, ��������,
        /// "125 �����", "15 ������".
        /// ��� 0 ���������� ������ ������� ��������� � ���.��.
        /// </summary>
        private  void DigitClassToString(uint digitBefore999, IUnit unit, StringBuilder sb)
        {
            uint countOfUnity = digitBefore999 % 10;
            uint countOfDecades = (digitBefore999 / 10) % 10;
            uint countOfHundreds = (digitBefore999 / 100) % 10;

            sb.AppendString(Hundreds[countOfHundreds]);

            if ((digitBefore999 % 100) != 0)
            {
                Decades[countOfDecades].ToDigitString(sb, countOfUnity, unit.DigitKindAndQuantity);
            }

            // �������� �������� ������ � ������ �����.
            sb.AppendString(ConformCurrencyTypeWithDigit(unit, digitBefore999));
        }

        #endregion

        #region ConformCurrencyTypeWithDigit

        /// <summary>
        /// ConformCurrencyTypeWithDigit �������� ������� ��������� � ������.
        /// ��������, ������������ ������� (�����, �����, ������) 
        /// � ������ 23 ��� "�����", � � ������ 25 - "������".
        /// </summary>
        public string ConformCurrencyTypeWithDigit(IUnit unit, uint uintDigit)
        {
            uint countOfUnity = uintDigit % 10;
            uint countOfDecades = (uintDigit / 10) % 10;

            if (countOfDecades == 1) return unit.GenitivePlural;
            switch (countOfUnity)
            {
                case 1: return unit.SubjectiveCase;
                case 2:
                case 3:
                case 4: return unit.GenitiveOnly;
                default: return unit.GenitivePlural;
            }
        }

        /// <summary>
        /// ConformCurrencyTypeWithDigit �������� ������� ��������� � ������.
        /// ��������, ������������ ������� (�����, �����, ������) 
        /// � ������ 23 ��� "�����", � � ������ 25 - "������".
        /// </summary>
        public string ConformCurrencyTypeWithDigit(IUnit unit, decimal decimalDigit)
        {
            return ConformCurrencyTypeWithDigit(unit, (uint)(decimalDigit % 100));
        }

        #endregion

        #region �������

        static string UnityToString(uint uintUnity, DigitKindAndQuantity digitKind)
        {
            return arrDigits[uintUnity].DigitToString(digitKind);
        }

        abstract class Digit
        {
            public abstract string DigitToString(DigitKindAndQuantity ���);
        }

        class DigitChangingByKind : Digit, IChangingByKind
        {
            public DigitChangingByKind(
                string manLike,
                string feminish,
                string neutral,
                string plural)
            {
                this.manLike = manLike;
                this.feminish = feminish;
                this.neutral = neutral;
                this.plural = plural;
            }

            public DigitChangingByKind(
                string notPlural,
                string plural)

                : this(notPlural, notPlural, notPlural, plural)
            {
            }

            private readonly string manLike;
            private readonly string feminish;
            private readonly string neutral;
            private readonly string plural;

            #region IChangingByKind Members

            public string ManLike { get { return this.manLike; } }
            public string Feminish { get { return this.feminish; } }
            public string Neutral { get { return this.neutral; } }
            public string Plural { get { return this.plural; } }

            #endregion

            public override string DigitToString(DigitKindAndQuantity DigitKind)
            {
                return DigitKind.GetFormat(this);
            }
        }

        class DigitNotChangingByKinds : Digit
        {
            public DigitNotChangingByKinds(string strDigit)
            {
                this.strDigit = strDigit;
            }

            private readonly string strDigit;

            public override string DigitToString(DigitKindAndQuantity digitKind)
            {
                return this.strDigit;
            }
        }

        private static readonly Digit[] arrDigits = new Digit[]
        {
            null,
            new DigitChangingByKind ("����", "����", "����", "����"),
            new DigitChangingByKind ("���", "���", "���", "����"),
            new DigitChangingByKind ("���", "����"),
            new DigitChangingByKind ("������", "�������"),
            new DigitNotChangingByKinds ("����"),
            new DigitNotChangingByKinds ("�����"),
            new DigitNotChangingByKinds ("����"),
            new DigitNotChangingByKinds ("������"),
            new DigitNotChangingByKinds ("������"),
        };

        #endregion
        #region Decades

        static readonly Decade[] Decades = new Decade[]
        {
            new FirstDecade (),
            new SecondDecade (),
            new UsualDecade ("��������"),
            new UsualDecade ("��������"),
            new UsualDecade ("�����"),
            new UsualDecade ("���������"),
            new UsualDecade ("����������"),
            new UsualDecade ("���������"),
            new UsualDecade ("�����������"),
            new UsualDecade ("���������")
        };

        abstract class Decade
        {
            public abstract void ToDigitString(StringBuilder sb, uint countOfUnits, DigitKindAndQuantity digitKind);
        }

        class FirstDecade : Decade
        {
            public override void ToDigitString(StringBuilder sb, uint countOfUnits, DigitKindAndQuantity digitKind)
            {
                sb.AppendString(UnityToString(countOfUnits, digitKind));
            }
        }

        class SecondDecade : Decade
        {
            static readonly string[] stringLikeDecade = new string[]
            {
                "������",
                "�����������",
                "����������",
                "����������",
                "������������",
                "����������",
                "�����������",
                "����������",
                "������������",
                "������������"
            };

            public override void ToDigitString(StringBuilder sb, uint countOfUnits, DigitKindAndQuantity digitKind)
            {
                sb.AppendString(stringLikeDecade[countOfUnits]);
            }
        }

        class UsualDecade : Decade
        {
            public UsualDecade(string decadeName)
            {
                this.decadeName = decadeName;
            }

            private readonly string decadeName;

            public override void ToDigitString(StringBuilder sb, uint countOfUnits, DigitKindAndQuantity digitKind)
            {
                sb.AppendString(this.decadeName);

                if (countOfUnits == 0)
                {
                    // ����� "��������", "��������" � �.�. �� ����� "����" (������)
                }
                else
                {
                    sb.AppendString(UnityToString(countOfUnits, digitKind));
                }
            }
        }

        #endregion
        #region Hundreds

        static readonly string[] Hundreds = new string[]
        {
            null,
            "���",
            "������",
            "������",
            "���������",
            "�������",
            "��������",
            "�������",
            "���������",
            "���������"
        };

        #endregion
        #region DigitClasses

        #region ThousandsDigitsClass

        class ThousandsDigitsClass : IUnit
        {
            public string SubjectiveCase { get { return "������"; } }
            public string GenitiveOnly { get { return "������"; } }
            public string GenitivePlural { get { return "�����"; } }
            public DigitKindAndQuantity DigitKindAndQuantity { get { return DigitKindAndQuantity.Feminish; } }
        }

        #endregion
        #region DigitClass

        class DigitClass : IUnit
        {
            readonly string infiniteForm;

            public DigitClass(string infiniteForm)
            {
                this.infiniteForm = infiniteForm;
            }

            public string SubjectiveCase { get { return this.infiniteForm; } }
            public string GenitiveOnly { get { return this.infiniteForm + "�"; } }
            public string GenitivePlural { get { return this.infiniteForm + "��"; } }
            public DigitKindAndQuantity DigitKindAndQuantity { get { return DigitKindAndQuantity.ManLike; } }
        }

        #endregion

        /// <summary>
        /// DigitClass - ������ �� 3 ����.  ���� ������ ������, �����, ��������� � �.�.
        /// </summary>
        static readonly IUnit[] DigitClasses = new IUnit[]
        {
            new ThousandsDigitsClass (),
            new DigitClass ("�������"),
            new DigitClass ("��������"),
            new DigitClass ("��������"),
            new DigitClass ("�����������"),
            new DigitClass ("�����������"),
            new DigitClass ("�����������"),
            new DigitClass ("����������"),
            new DigitClass ("���������"),
 
            // ��� ���������� ������� ��������� ���� �������� ���� decimal.
        };

        #endregion

        

        protected override double GetMaxDouble()
        {
            double max = Math.Pow(1000, DigitClasses.Length + 1);

            double d = 1;

            while (max - d == max)
            {
                d *= 2;
            }

            return max - d;
        }

       

       
        internal string ApplyCaps(StringBuilder sb, StrategyToUpper strategyToUpper)
        {
            strategyToUpper.ApplyStrategy(sb);
            return sb.ToString();
        }


        public override LanguageDigit AddSignPart(decimal number)
        {
            if (number < 0)
            {
                convertedNumber.Insert(0, "����� ");
            }

            return this;
        }
        
    }
}