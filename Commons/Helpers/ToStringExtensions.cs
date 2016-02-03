using System.Globalization;

namespace Commons.Helpers
{
    public static class ToStringExtensions
    {
        public static string ToStringCultureEn(this decimal source)
        {
            return source.ToString(CultureInfo.GetCultureInfo("en-US"));
        }

        public static string ToStringCultureInvariant(this decimal source)
        {
            return source.ToString("N2", CultureInfo.InvariantCulture);
        }
    }
}