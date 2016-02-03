using System.Text;
using Commons.Helpers.Objects;

namespace Commons.Helpers.DigitToStringHelper
{
    public static class StringBuilderExtension
    {
        public static void AppendString(this StringBuilder source, string stringToAppend)
        {
            if (stringToAppend.IsEmpty())
            {
                return;
            }

            if (source.Length > 0)
            {
                source.Append(' ');
            }

            source.Append(stringToAppend);
        }
    }
}
