using System;
using System.Text;

namespace Commons.Helpers.DigitToStringHelper.Languages
{
    public class CDigitKz : LanguageDigit
    {
        public override LanguageDigit ConvertToString(decimal number, IUnit unit)
        {
            CheckNumber(number);
            

            if (number <= uint.MaxValue)
            {
                return ConvertToString((uint)number, unit);
            }
            
            if (number <= ulong.MaxValue)
            {
                return ConvertToString((ulong)number, unit);
            }
            


            decimal div1000 = Math.Floor(number / 1000);

            HightDigitClassesToString(div1000, 0, convertedNumber);

            DigitClassToString((uint)(number - div1000 * 1000), unit, convertedNumber);


            return this;
        }


        public LanguageDigit ConvertToString(double number, IUnit unit)
        {
            CheckNumber(number);


            if (number <= uint.MaxValue)
            {
                return ConvertToString((uint)number, unit);
            }
            
            if (number <= ulong.MaxValue)
            {
                return ConvertToString((ulong)number, unit);
            }
            
            
            double div1000 = Math.Floor(number / 1000);

            HightDigitClassesToString(div1000, 0, convertedNumber);

            DigitClassToString((uint)(number - div1000 * 1000), unit, convertedNumber);
            

            return this;
        }


        /// <summary>
        /// Получить пропись числа с согласованной единицей измерения.
        /// </summary>
        /// <returns> <paramref name="result"/> </returns>
        public LanguageDigit ConvertToString(ulong ulongDigit, IUnit unit, StringBuilder result)
        {
            if (ulongDigit <= uint.MaxValue)
            {
                ConvertToString((uint)ulongDigit, unit, result);
            }
            else
            {
                ulong div1000 = ulongDigit / 1000;
                HightDigitClassesToString(div1000, 0, result);
                DigitClassToString((uint)(ulongDigit - div1000 * 1000), unit, result);
            }

            return this;
        }


        public LanguageDigit ConvertToString(uint uintDigit, IUnit unit)
        {
            if (uintDigit == 0)
            {
                convertedNumber.AppendString("нөл");

                convertedNumber.AppendString(unit.GenitivePlural);
            }
            else
            {
                uint div1000 = uintDigit / 1000;

                HightDigitClassesToString(div1000, 0, convertedNumber);
                DigitClassToString(uintDigit - div1000 * 1000, unit, convertedNumber);
            }

            return this;
        }

        
        static void HightDigitClassesToString(decimal decimalDigit, int digitClassNumber, StringBuilder sb)
        {
            if (decimalDigit == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            decimal div1000 = Math.Floor(decimalDigit / 1000);
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(decimalDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        static void HightDigitClassesToString(double doubleDigit, int digitClassNumber, StringBuilder sb)
        {
            if (doubleDigit == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            double div1000 = Math.Floor(doubleDigit / 1000);
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(doubleDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        static void HightDigitClassesToString(ulong ulongDigit, int digitClassNumber, StringBuilder sb)
        {
            if (ulongDigit == 0) return; // конец рекурсии

            // Записать в StringBuilder пропись старших классов.
            ulong div1000 = ulongDigit / 1000;
            HightDigitClassesToString(div1000, digitClassNumber + 1, sb);

            uint digitBefore999 = (uint)(ulongDigit - div1000 * 1000);
            if (digitBefore999 == 0) return;

            DigitClassToString(digitBefore999, DigitClasses[digitClassNumber], sb);
        }

        static void HightDigitClassesToString(uint uintDigit, int digitClassNumber, StringBuilder sb)
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

       
        private static void DigitClassToString(uint digitBefore999, IUnit unit, StringBuilder sb)
        {
            uint countOfUnity = digitBefore999 % 10;
            uint countOfDecades = (digitBefore999 / 10) % 10;
            uint countOfHundreds = (digitBefore999 / 100) % 10;

            sb.AppendString(Hundreds[countOfHundreds]);

            if ((digitBefore999 % 100) != 0)
            {
                Decades[countOfDecades].ToDigitString(sb, countOfUnity, unit.DigitKindAndQuantity);
            }

            // Добавить название класса в нужной форме.
            sb.AppendString(ConformCurrencyTypeWithDigit(unit, digitBefore999));
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

            if (countOfDecades == 1)
                return unit.GenitivePlural;

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
            new DigitNotChangingByKinds ("бір"),
            new DigitNotChangingByKinds ("екі"),
            new DigitNotChangingByKinds ("үш"),
            new DigitNotChangingByKinds ("төрт"),
            new DigitNotChangingByKinds ("бес"),
            new DigitNotChangingByKinds ("алты"),
            new DigitNotChangingByKinds ("жеті"),
            new DigitNotChangingByKinds ("сегіз"),
            new DigitNotChangingByKinds ("тоғыз"),
        };

        #endregion
        #region Decades

        static readonly Decade[] Decades = new Decade[]
        {
            new FirstDecade (),
            new SecondDecade (),
            new UsualDecade ("жиырма"),
            new UsualDecade ("отыз"),
            new UsualDecade ("қырық"),
            new UsualDecade ("елу"),
            new UsualDecade ("алпыс"),
            new UsualDecade ("жетпіс"),
            new UsualDecade ("сексен"),
            new UsualDecade ("тоқсан")
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
                "он",
                "он бір",
                "он екі",
                "он үш",
                "он төрт",
                "он бес",
                "он алты",
                "он жеті",
                "он сегіз",
                "он тоғыз"
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
                sb.AppendString(decadeName);

                if (countOfUnits == 0)
                {
                    // После "двадцать", "тридцать" и т.д. не пишут "ноль" (единиц)
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
            "жүз",
            "екі жүз",
            "үш жүз",
            "төрт жүз",
            "бес жүз",
            "алты жүз",
            "жеті жүз",
            "сегіз жүз",
            "тоғыз жүз"
        };

        #endregion
        #region DigitClasses

        #region ThousandsDigitsClass

        class ThousandsDigitsClass : IUnit
        {
            public string SubjectiveCase { get { return "мың"; } }
            public string GenitiveOnly { get { return "мың"; } }
            public string GenitivePlural { get { return "мың"; } }
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
            public string GenitiveOnly { get { return this.infiniteForm; } }
            public string GenitivePlural { get { return this.infiniteForm; } }
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

        public LanguageDigit ConvertToString(ulong ulongDigit, IUnit unit)
        {
            return ConvertToString(ulongDigit, unit, StrategyToUpper.NOONEChars);
        }

        public LanguageDigit ConvertToString(ulong ulongDigit, IUnit unit, StrategyToUpper strategyToUpper)
        {
            ConvertToString(ulongDigit, unit);

            return ApplyCaps(strategyToUpper);
        }


        internal LanguageDigit ApplyCaps(StrategyToUpper strategyToUpper)
        {
            strategyToUpper.ApplyStrategy(convertedNumber);

            return this;
        }

        public override LanguageDigit AddSignPart(decimal number)
        {
            if (number < 0)
            {
                convertedNumber.Insert(0, "минус ");
            }

            return this;
        }
    }
}