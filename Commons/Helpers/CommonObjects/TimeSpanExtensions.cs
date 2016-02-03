using System;
using System.Globalization;

namespace Commons.Helpers.CommonObjects
{
    public static class TimeSpanExtensions
    {
        public static string ToInvariantString(this TimeSpan source, string format)
        {
            return source.ToString(format, CultureInfo.InvariantCulture);
        }


        public static string ToShortTimeString(this TimeSpan source)
        {
            return source.ToInvariantString(TimeSpanFormats.SHORT_TIME);
        }

        public static string ToTimeString(this TimeSpan source)
        {
            return source.ToInvariantString(TimeSpanFormats.TIME);
        }
    }
}
