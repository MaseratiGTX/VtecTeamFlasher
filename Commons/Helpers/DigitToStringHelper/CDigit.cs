using System;
using System.Text;

namespace Commons.Helpers.DigitToStringHelper
{
    /// <summary>
    /// DigitClass для преобразования чисел в пропись на русском языке.
    /// </summary>
    /// <example>
    /// CDigit.SumConvertToString (1, DigitKindAndQuantity.ManLike); // "один"
    /// CDigit.SumConvertToString (2, DigitKindAndQuantity.Feminish); // "две"
    /// CDigit.SumConvertToString (21, DigitKindAndQuantity.Neutral); // "двадцать одно"
    /// </example>
    /// <example>
    /// CDigit.SumConvertToString (5, new Unit (
    ///  DigitKindAndQuantity.ManLike, "метр", "метра", "метров"), sb); // "пять метров"
    /// </example>
    public static class CDigit
    {
        /// <summary>
        /// Получить пропись числа с согласованной единицей измерения.
        /// </summary>
        /// <param name="decimalDigit"> CDigit должно быть целым, неотрицательным. </param>
        /// <param name="unit"></param>
        /// <param name="result"> Сюда записывается результат. </param>
        /// <returns> <paramref name="result"/> </returns>
        /// <exception cref="ArgumentException">
        /// Если decimalDigit меньше нуля или не целое. 
        /// </exception>
        public static StringBuilder ConvertToString(decimal decimalDigit, IUnit unit, StringBuilder result)
        {
            string error = CheckDigit(decimalDigit);
            if (error != null) throw new ArgumentException(error, "число");

            // Целочисленные версии работают в разы быстрее, чем decimal.
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
        /// Получить пропись числа с согласованной единицей измерения.
        /// </summary>
        /// <param name="doubleDigit"> 
        /// CDigit должно быть целым, неотрицательным, не большим <see cref="MaxDouble"/>. 
        /// </param>
        /// <param name="unit"></param>
        /// <param name="result"> Сюда записывается результат. </param>
        /// <exception cref="ArgumentException">
        /// Если doubleDigit меньше нуля, не целое или больше <see cref="MaxDouble"/>. 
        /// </exception>
        /// <returns> <paramref name="result"/> </returns>
        /// <remarks>
        /// float по умолчанию преобразуется к double, поэтому нет перегрузки для float.
        /// В результате ошибок округления возможно расхождение цифр прописи и
        /// строки, выдаваемой double.ToString ("R"), начиная с 17 значащей цифры.
        /// </remarks>
        public static StringBuilder ConvertToString(double doubleDigit, IUnit unit, StringBuilder result)
        {
            string error = CheckDigit(doubleDigit);
            if (error != null) throw new ArgumentException(error, "число");

            if (doubleDigit <= uint.MaxValue)
            {
                ConvertToString((uint)doubleDigit, unit, result);
            }
            else if (doubleDigit <= ulong.MaxValue)
            {
                // SumConvertToString с ulong выполняется в среднем в 2 раза быстрее.
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
        /// Получить пропись числа с согласованной единицей измерения.
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
        /// Получить пропись числа с согласованной единицей измерения.
        /// </summary>
        /// <returns> <paramref name="result"/> </returns>
        public static StringBuilder ConvertToString(uint uintDigit, IUnit unit, StringBuilder result)
        {
            MyStringBuilder mySb = new MyStringBuilder(result);

            if (uintDigit == 0)
            {
                mySb.Append("ноль");
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
        /// Записывает в <paramref name="sb"/> пропись числа, начиная с самого 
        /// старшего класса до класса с номером <paramref name="digitClassNumber"/>.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="decimalDigit"></param>
        /// <param name="digitClassNumber">0 = класс тысяч, 1 = миллионов и т.д.</param>
        /// <remarks>
        /// В методе применена рекурсия, чтобы обеспечить запись в StringBuilder 
        /// в нужном порядке - от старших классов к младшим.
        /// </remarks>
        static void HightDigitClassesToString(decimal decimalDigit, int digitClassNumber, MyStringBuilder sb)
        {
            if (decimalDigit == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            decimal div1000 = Math.Floor(decimalDigit / 1000);
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(decimalDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        static void HightDigitClassesToString(double doubleDigit, int digitClassNumber, MyStringBuilder sb)
        {
            if (doubleDigit == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            double div1000 = Math.Floor(doubleDigit / 1000);
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(doubleDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        static void HightDigitClassesToString(ulong ulongDigit, int digitClassNumber, MyStringBuilder sb)
        {
            if (ulongDigit == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            ulong div1000 = ulongDigit / 1000;
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(ulongDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        static void HightDigitClassesToString(uint uintDigit, int digitClassNumber, MyStringBuilder sb)
        {
            if (uintDigit == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            uint div1000 = uintDigit / 1000;
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = uintDigit - div1000 * 1000;
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        #region DigitClassToString

        /// <summary>
        /// Формирует запись класса с названием, например,
        /// "125 тысяч", "15 рублей".
        /// Для 0 записывает только единицу измерения в род.мн.
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

            // Добавить название класса в нужной форме.
            sb.Append(ConformCurrencyTypeWithDigit(unit, digitBefore999));
        }

        #endregion

        #region CheckDigit

        /// <summary>
        /// Проверяет, подходит ли decimalDigit для передачи методу 
        /// <see cref="ToNoun"/>.
        /// </summary>
        /// <returns>
        /// Описание нарушенного ограничения или null.
        /// </returns>
        public static string CheckDigit(decimal decimalDigit)
        {
            if (decimalDigit < 0)
                return "CDigit должно быть больше или равно нулю.";

            if (decimalDigit != decimal.Floor(decimalDigit))
                return "CDigit не должно содержать дробной части.";

            return null;
        }

        /// <summary>
        /// Проверяет, подходит ли doubleDigit для передачи методу 
        /// <see cref="ConvertToString(double,IUnit,System.Text.StringBuilder)"/>.
        /// </summary>
        /// <returns>
        /// Описание нарушенного ограничения или null.
        /// </returns>
        public static string CheckDigit(double doubleDigit)
        {
            if (doubleDigit < 0)
                return "CDigit должно быть больше или равно нулю.";

            if (doubleDigit != Math.Floor(doubleDigit))
                return "CDigit не должно содержать дробной части.";

            if (doubleDigit > MaxDouble)
            {
                return "CDigit должно быть не больше " + MaxDouble + ".";
            }

            return null;
        }

        #endregion

        #region ConformCurrencyTypeWithDigit

        /// <summary>
        /// ConformCurrencyTypeWithDigit название единицы измерения с числом.
        /// Например, согласование единицы (рубль, рубля, рублей) 
        /// с числом 23 даёт "рубля", а с числом 25 - "рублей".
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
        /// ConformCurrencyTypeWithDigit название единицы измерения с числом.
        /// Например, согласование единицы (рубль, рубля, рублей) 
        /// с числом 23 даёт "рубля", а с числом 25 - "рублей".
        /// </summary>
        public static string ConformCurrencyTypeWithDigit(IUnit unit, decimal decimalDigit)
        {
            return ConformCurrencyTypeWithDigit(unit, (uint)(decimalDigit % 100));
        }

        #endregion

        #region Единицы

        static string UnityToString(uint uintUnity, DigitKindAndQuantity digitKind)
        {
            return arrDigits[uintUnity].DigitToString(digitKind);
        }

        abstract class Digit
        {
            public abstract string DigitToString(DigitKindAndQuantity род);
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
            new DigitChangingByKind ("один", "одна", "одно", "одни"),
            new DigitChangingByKind ("два", "две", "два", "двое"),
            new DigitChangingByKind ("три", "трое"),
            new DigitChangingByKind ("четыре", "четверо"),
            new DigitNotChangingByKinds ("пять"),
            new DigitNotChangingByKinds ("шесть"),
            new DigitNotChangingByKinds ("семь"),
            new DigitNotChangingByKinds ("восемь"),
            new DigitNotChangingByKinds ("девять"),
        };

        #endregion
        #region Decades

        static readonly Decade[] Decades = new Decade[]
        {
            new FirstDecade (),
            new SecondDecade (),
            new UsualDecade ("двадцать"),
            new UsualDecade ("тридцать"),
            new UsualDecade ("сорок"),
            new UsualDecade ("пятьдесят"),
            new UsualDecade ("шестьдесят"),
            new UsualDecade ("семьдесят"),
            new UsualDecade ("восемьдесят"),
            new UsualDecade ("девяносто")
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
                "десять",
                "одиннадцать",
                "двенадцать",
                "тринадцать",
                "четырнадцать",
                "пятнадцать",
                "шестнадцать",
                "семнадцать",
                "восемнадцать",
                "девятнадцать"
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
                    // После "двадцать", "тридцать" и т.д. не пишут "ноль" (единиц)
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
            "сто",
            "двести",
            "триста",
            "четыреста",
            "пятьсот",
            "шестьсот",
            "семьсот",
            "восемьсот",
            "девятьсот"
        };

        #endregion
        #region DigitClasses

        #region ThousandsDigitsClass

        class ThousandsDigitsClass : IUnit
        {
            public string SubjectiveCase { get { return "тысяча"; } }
            public string GenitiveOnly { get { return "тысячи"; } }
            public string GenitivePlural { get { return "тысяч"; } }
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
            public string GenitiveOnly { get { return this.infiniteForm + "а"; } }
            public string GenitivePlural { get { return this.infiniteForm + "ов"; } }
            public DigitKindAndQuantity DigitKindAndQuantity { get { return DigitKindAndQuantity.ManLike; } }
        }

        #endregion

        /// <summary>
        /// DigitClass - группа из 3 цифр.  Есть классы единиц, тысяч, миллионов и т.д.
        /// </summary>
        static readonly IUnit[] DigitClasses = new IUnit[]
        {
            new ThousandsDigitsClass (),
            new DigitClass ("миллион"),
            new DigitClass ("миллиард"),
            new DigitClass ("триллион"),
            new DigitClass ("квадриллион"),
            new DigitClass ("квинтиллион"),
            new DigitClass ("секстиллион"),
            new DigitClass ("септиллион"),
            new DigitClass ("октиллион"),
 
            // Это количество классов покрывает весь диапазон типа decimal.
        };

        #endregion

        #region MaxDouble

        /// <summary>
        /// Максимальное число типа double, представимое в виде прописи.
        /// </summary>
        /// <remarks>
        /// Рассчитывается исходя из количества определённых классов.
        /// Если добавить ещё классы, оно будет автоматически увеличено.
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

        #region Вспомогательные классы

        #region Форма

        #endregion
        #region MyStringBuilder

        /// <summary>
        /// Вспомогательный класс, аналогичный <see cref="StringBuilder"/>.
        /// Между вызовами <see cref="MyStringBuilder.Append"/> вставляет пробелы.
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
            /// Добавляет слово <paramref name="s"/>,
            /// вставляя перед ним пробел, если нужно.
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

        #region Перегрузки метода SumConvertToString, возвращающие string

        /// <summary>
        /// Возвращает пропись числа строчными буквами.
        /// </summary>
        public static string ConvertToString(decimal decimalDigit, IUnit unit)
        {
            return ConvertToString(decimalDigit, unit, StrategyToUpper.NOONEChars);
        }

        /// <summary>
        /// Возвращает пропись числа.
        /// </summary>
        public static string ConvertToString(decimal decimalDigit, IUnit unit, StrategyToUpper strategyToUpper)
        {
            return ApplyCaps(ConvertToString(decimalDigit, unit, new StringBuilder()), strategyToUpper);
        }

        /// <summary>
        /// Возвращает пропись числа строчными буквами.
        /// </summary>
        public static string ConvertToString(double doubleDigit, IUnit unit)
        {
            return ConvertToString(doubleDigit, unit, StrategyToUpper.NOONEChars);
        }

        /// <summary>
        /// Возвращает пропись числа.
        /// </summary>
        public static string ConvertToString(double doubleDigit, IUnit unit, StrategyToUpper strategyToUpper)
        {
            return ApplyCaps(ConvertToString(doubleDigit, unit, new StringBuilder()), strategyToUpper);
        }

        /// <summary>
        /// Возвращает пропись числа строчными буквами.
        /// </summary>
        public static string ConvertToString(ulong ulongDigit, IUnit unit)
        {
            return ConvertToString(ulongDigit, unit, StrategyToUpper.NOONEChars);
        }

        /// <summary>
        /// Возвращает пропись числа.
        /// </summary>
        public static string ConvertToString(ulong ulongDigit, IUnit unit, StrategyToUpper strategyToUpper)
        {
            return ApplyCaps(ConvertToString(ulongDigit, unit, new StringBuilder()), strategyToUpper);
        }

        /// <summary>
        /// Возвращает пропись числа строчными буквами.
        /// </summary>
        public static string ConvertToString(uint uintDigit, IUnit unit)
        {
            return ConvertToString(uintDigit, unit, StrategyToUpper.NOONEChars);
        }

        /// <summary>
        /// Возвращает пропись числа.
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