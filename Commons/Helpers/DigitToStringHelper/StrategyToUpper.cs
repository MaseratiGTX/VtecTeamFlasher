using System.Text;

namespace Commons.Helpers.DigitToStringHelper
{
    /// <summary>
    /// —тратеги€ расстановки заглавных букв.
    /// </summary>
    public abstract class StrategyToUpper
    {
        /// <summary>
        /// ApplyStrategy стратегию к <paramref name="sb"/>.
        /// </summary>
        public abstract void ApplyStrategy(StringBuilder sb);

        class AllChars : StrategyToUpper
        {
            public override void ApplyStrategy(StringBuilder sb)
            {
                for (int i = 0; i < sb.Length; ++i)
                {
                    sb[i] = char.ToUpperInvariant(sb[i]);
                }
            }
        }

        class NoOneChar : StrategyToUpper
        {
            public override void ApplyStrategy(StringBuilder sb)
            {
            }
        }

        class FirstChar : StrategyToUpper
        {
            public override void ApplyStrategy(StringBuilder sb)
            {
                sb[0] = char.ToUpperInvariant(sb[0]);
            }
        }

        public static readonly StrategyToUpper ALLChars = new AllChars();
        public static readonly StrategyToUpper NOONEChars = new NoOneChar();
        public static readonly StrategyToUpper FIRSTChar = new FirstChar();
    }
}