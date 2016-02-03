using System;
using System.Text;

namespace Commons.Helpers.DigitToStringHelper
{
    /// <summary>
    /// DigitClass ��� �������������� ����� � ������� �� ������� �����.
    /// </summary>
    /// <example>
    /// CDigit.SumConvertToString (1, DigitKindAndQuantity.ManLike); // "����"
    /// CDigit.SumConvertToString (2, DigitKindAndQuantity.Feminish); // "���"
    /// CDigit.SumConvertToString (21, DigitKindAndQuantity.Neutral); // "�������� ����"
    /// </example>
    /// <example>
    /// CDigit.SumConvertToString (5, new Unit (
    ///  DigitKindAndQuantity.ManLike, "����", "�����", "������"), sb); // "���� ������"
    /// </example>
    public static class CDigit
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
        public static StringBuilder ConvertToString(decimal decimalDigit, IUnit unit, StringBuilder result)
        {
            string error = CheckDigit(decimalDigit);
            if (error != null) throw new ArgumentException(error, "�����");

            // ������������� ������ �������� � ���� �������, ��� decimal.
            if (decimalDigit <= uint.MaxValue)
            {
                ConvertToString((uint)decimalDigit, unit, result);
            }
            else if (decimalDigit <= ulong.MaxValue)
            {
                ConvertToString((ulong)decimalDigit, unit, result);
            }
            else
            {
                MyStringBuilder mySb = new MyStringBuilder(result);

                decimal div1000 = Math.Floor(decimalDigit / 1000);
                HightDigitClassesToString(div1000, 0, mySb);
                DigitClassToString((uint)(decimalDigit - div1000 * 1000), unit, mySb);
            }

            return result;
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
        public static StringBuilder ConvertToString(double doubleDigit, IUnit unit, StringBuilder result)
        {
            string error = CheckDigit(doubleDigit);
            if (error != null) throw new ArgumentException(error, "�����");

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
                MyStringBuilder mySb = new MyStringBuilder(result);

                double div1000 = Math.Floor(doubleDigit / 1000);
                HightDigitClassesToString(div1000, 0, mySb);
                DigitClassToString((uint)(doubleDigit - div1000 * 1000), unit, mySb);
            }

            return result;
        }

        /// <summary>
        /// �������� ������� ����� � ������������� �������� ���������.
        /// </summary>
        /// <returns> <paramref name="result"/> </returns>
        public static StringBuilder ConvertToString(ulong ulongDigit, IUnit unit, StringBuilder result)
        {
            if (ulongDigit <= uint.MaxValue)
            {
                ConvertToString((uint)ulongDigit, unit, result);
            }
            else
            {
                MyStringBuilder mySb = new MyStringBuilder(result);

                ulong div1000 = ulongDigit / 1000;
                HightDigitClassesToString(div1000, 0, mySb);
                DigitClassToString((uint)(ulongDigit - div1000 * 1000), unit, mySb);
            }

            return result;
        }

        /// <summary>
        /// �������� ������� ����� � ������������� �������� ���������.
        /// </summary>
        /// <returns> <paramref name="result"/> </returns>
        public static StringBuilder ConvertToString(uint uintDigit, IUnit unit, StringBuilder result)
        {
            MyStringBuilder mySb = new MyStringBuilder(result);

            if (uintDigit == 0)
            {
                mySb.Append("����");
                mySb.Append(unit.GenitivePlural);
            }
            else
            {
                uint div1000 = uintDigit / 1000;
                HightDigitClassesToString(div1000, 0, mySb);
                DigitClassToString(uintDigit - div1000 * 1000, unit, mySb);
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
        static void HightDigitClassesToString(decimal decimalDigit, int digitClassNumber, MyStringBuilder sb)
        {
            if (decimalDigit == 0) return; // ����� ��������

            // �������� � StringBuilder ������� ������� �������.
            decimal div1000 = Math.Floor(decimalDigit / 1000);
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(decimalDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        static void HightDigitClassesToString(double doubleDigit, int digitClassNumber, MyStringBuilder sb)
        {
            if (doubleDigit == 0) return; // ����� ��������

            // �������� � StringBuilder ������� ������� �������.
            double div1000 = Math.Floor(doubleDigit / 1000);
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(doubleDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        static void HightDigitClassesToString(ulong ulongDigit, int digitClassNumber, MyStringBuilder sb)
        {
            if (ulongDigit == 0) return; // ����� ��������

            // �������� � StringBuilder ������� ������� �������.
            ulong div1000 = ulongDigit / 1000;
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(ulongDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        static void HightDigitClassesToString(uint uintDigit, int digitClassNumber, MyStringBuilder sb)
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
        private static void DigitClassToString(uint digitBefore999, IUnit unit, MyStringBuilder sb)
        {
            uint countOfUnity = digitBefore999 % 10;
            uint countOfDecades = (digitBefore999 / 10) % 10;
            uint countOfHundreds = (digitBefore999 / 100) % 10;

            sb.Append(Hundreds[countOfHundreds]);

            if ((digitBefore999 % 100) != 0)
            {
                Decades[countOfDecades].ToDigitString(sb, countOfUnity, unit.DigitKindAndQuantity);
            }

            // �������� �������� ������ � ������ �����.
            sb.Append(ConformCurrencyTypeWithDigit(unit, digitBefore999));
        }

        #endregion

        #region CheckDigit

        /// <summary>
        /// ���������, �������� �� decimalDigit ��� �������� ������ 
        /// <see cref="ToNoun"/>.
        /// </summary>
        /// <returns>
        /// �������� ����������� ����������� ��� null.
        /// </returns>
        public static string CheckDigit(decimal decimalDigit)
        {
            if (decimalDigit < 0)
                return "CDigit ������ ���� ������ ��� ����� ����.";

            if (decimalDigit != decimal.Floor(decimalDigit))
                return "CDigit �� ������ ��������� ������� �����.";

            return null;
        }

        /// <summary>
        /// ���������, �������� �� doubleDigit ��� �������� ������ 
        /// <see cref="ConvertToString(double,IUnit,System.Text.StringBuilder)"/>.
        /// </summary>
        /// <returns>
        /// �������� ����������� ����������� ��� null.
        /// </returns>
        public static string CheckDigit(double doubleDigit)
        {
            if (doubleDigit < 0)
                return "CDigit ������ ���� ������ ��� ����� ����.";

            if (doubleDigit != Math.Floor(doubleDigit))
                return "CDigit �� ������ ��������� ������� �����.";

            if (doubleDigit > MaxDouble)
            {
                return "CDigit ������ ���� �� ������ " + MaxDouble + ".";
            }

            return null;
        }

        #endregion

        #region ConformCurrencyTypeWithDigit

        /// <summary>
        /// ConformCurrencyTypeWithDigit �������� ������� ��������� � ������.
        /// ��������, ������������ ������� (�����, �����, ������) 
        /// � ������ 23 ��� "�����", � � ������ 25 - "������".
        /// </summary>
        public static string ConformCurrencyTypeWithDigit(IUnit unit, uint uintDigit)
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
        public static string ConformCurrencyTypeWithDigit(IUnit unit, decimal decimalDigit)
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
            public abstract void ToDigitString(MyStringBuilder sb, uint countOfUnits, DigitKindAndQuantity digitKind);
        }

        class FirstDecade : Decade
        {
            public override void ToDigitString(MyStringBuilder sb, uint countOfUnits, DigitKindAndQuantity digitKind)
            {
                sb.Append(UnityToString(countOfUnits, digitKind));
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

            public override void ToDigitString(MyStringBuilder sb, uint countOfUnits, DigitKindAndQuantity digitKind)
            {
                sb.Append(stringLikeDecade[countOfUnits]);
            }
        }

        class UsualDecade : Decade
        {
            public UsualDecade(string decadeName)
            {
                this.decadeName = decadeName;
            }

            private readonly string decadeName;

            public override void ToDigitString(MyStringBuilder sb, uint countOfUnits, DigitKindAndQuantity digitKind)
            {
                sb.Append(this.decadeName);

                if (countOfUnits == 0)
                {
                    // ����� "��������", "��������" � �.�. �� ����� "����" (������)
                }
                else
                {
                    sb.Append(UnityToString(countOfUnits, digitKind));
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

        #region MaxDouble

        /// <summary>
        /// ������������ ����� ���� double, ������������ � ���� �������.
        /// </summary>
        /// <remarks>
        /// �������������� ������ �� ���������� ����������� �������.
        /// ���� �������� ��� ������, ��� ����� ������������� ���������.
        /// </remarks>
        public static double MaxDouble
        {
            get
            {
                if (maxDouble == 0)
                {
                    maxDouble = CalcMaxDouble();
                }

                return maxDouble;
            }
        }

        private static double maxDouble = 0;

        static double CalcMaxDouble()
        {
            double max = Math.Pow(1000, DigitClasses.Length + 1);

            double d = 1;

            while (max - d == max)
            {
                d *= 2;
            }

            return max - d;
        }

        #endregion

        #region ��������������� ������

        #region �����

        #endregion
        #region MyStringBuilder

        /// <summary>
        /// ��������������� �����, ����������� <see cref="StringBuilder"/>.
        /// ����� �������� <see cref="MyStringBuilder.Append"/> ��������� �������.
        /// </summary>
        class MyStringBuilder
        {
            public MyStringBuilder(StringBuilder sb)
            {
                this.sb = sb;
            }

            readonly StringBuilder sb;
            bool insertSpace = false;

            /// <summary>
            /// ��������� ����� <paramref name="s"/>,
            /// �������� ����� ��� ������, ���� �����.
            /// </summary>
            public void Append(string s)
            {
                if (string.IsNullOrEmpty(s)) return;

                if (this.insertSpace)
                {
                    this.sb.Append(' ');
                }
                else
                {
                    this.insertSpace = true;
                }

                this.sb.Append(s);
            }

            public override string ToString()
            {
                return sb.ToString();
            }
        }

        #endregion

        #endregion

        #region ���������� ������ SumConvertToString, ������������ string

        /// <summary>
        /// ���������� ������� ����� ��������� �������.
        /// </summary>
        public static string ConvertToString(decimal decimalDigit, IUnit unit)
        {
            return ConvertToString(decimalDigit, unit, StrategyToUpper.NOONEChars);
        }

        /// <summary>
        /// ���������� ������� �����.
        /// </summary>
        public static string ConvertToString(decimal decimalDigit, IUnit unit, StrategyToUpper strategyToUpper)
        {
            return ApplyCaps(ConvertToString(decimalDigit, unit, new StringBuilder()), strategyToUpper);
        }

        /// <summary>
        /// ���������� ������� ����� ��������� �������.
        /// </summary>
        public static string ConvertToString(double doubleDigit, IUnit unit)
        {
            return ConvertToString(doubleDigit, unit, StrategyToUpper.NOONEChars);
        }

        /// <summary>
        /// ���������� ������� �����.
        /// </summary>
        public static string ConvertToString(double doubleDigit, IUnit unit, StrategyToUpper strategyToUpper)
        {
            return ApplyCaps(ConvertToString(doubleDigit, unit, new StringBuilder()), strategyToUpper);
        }

        /// <summary>
        /// ���������� ������� ����� ��������� �������.
        /// </summary>
        public static string ConvertToString(ulong ulongDigit, IUnit unit)
        {
            return ConvertToString(ulongDigit, unit, StrategyToUpper.NOONEChars);
        }

        /// <summary>
        /// ���������� ������� �����.
        /// </summary>
        public static string ConvertToString(ulong ulongDigit, IUnit unit, StrategyToUpper strategyToUpper)
        {
            return ApplyCaps(ConvertToString(ulongDigit, unit, new StringBuilder()), strategyToUpper);
        }

        /// <summary>
        /// ���������� ������� ����� ��������� �������.
        /// </summary>
        public static string ConvertToString(uint uintDigit, IUnit unit)
        {
            return ConvertToString(uintDigit, unit, StrategyToUpper.NOONEChars);
        }

        /// <summary>
        /// ���������� ������� �����.
        /// </summary>
        public static string ConvertToString(uint uintDigit, IUnit unit, StrategyToUpper strategyToUpper)
        {
            return ApplyCaps(ConvertToString(uintDigit, unit, new StringBuilder()), strategyToUpper);
        }

        internal static string ApplyCaps(StringBuilder sb, StrategyToUpper strategyToUpper)
        {
            strategyToUpper.ApplyStrategy(sb);
            return sb.ToString();
        }

        #endregion
    }
}