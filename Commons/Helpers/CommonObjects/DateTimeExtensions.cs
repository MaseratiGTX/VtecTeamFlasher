using System;
using System.Globalization;

namespace Commons.Helpers.CommonObjects
{
    public static class DateTimeExtensions
    {
        private static string TransformToString(this DateTime? source, Func<DateTime, string> transformationFunction, string nullText)
        {
            return source.HasValue ? transformationFunction.Invoke(source.Value) : nullText;
        }



        public static string ToInvariantString(this DateTime source, string format)
        {
            return source.ToString(format, CultureInfo.InvariantCulture);
        }

        public static string ToInvariantString(this DateTime? source, string format)
        {
            return source.ToInvariantString(format, null);
        }

        public static string ToInvariantString(this DateTime? source, string format, string nullText)
        {
            return source.TransformToString(x => x.ToInvariantString(format), nullText);
        }



        public static string ToShortTimeString(this DateTime source)
        {
            return source.ToInvariantString(DateTimeFormats.SHORT_TIME);
        }

        public static string ToShortTimeString(this DateTime? source)
        {
            return source.ToShortTimeString(null);
        }

        public static string ToShortTimeString(this DateTime? source, string nullText)
        {
            return source.TransformToString(x => x.ToShortTimeString(), nullText);
        }


        public static string ToTimeString(this DateTime source)
        {
            return source.ToInvariantString(DateTimeFormats.TIME);
        }

        public static string ToTimeString(this DateTime? source)
        {
            return source.ToTimeString(null);
        }

        public static string ToTimeString(this DateTime? source, string nullText)
        {
            return source.TransformToString(x => x.ToTimeString(), nullText);
        }


        public static string ToFullTimeString(this DateTime source)
        {
            return source.ToInvariantString(DateTimeFormats.FULL_TIME);
        }

        public static string ToFullTimeString(this DateTime? source)
        {
            return source.ToFullTimeString(null);
        }

        public static string ToFullTimeString(this DateTime? source, string nullText)
        {
            return source.TransformToString(x => x.ToFullTimeString(), nullText);
        }



        public static string ToDateString(this DateTime source)
        {
            return source.ToInvariantString(DateTimeFormats.DATE);
        }

        public static string ToDateString(this DateTime? source)
        {
            return source.ToDateString(null);
        }

        public static string ToDateString(this DateTime? source, string nullText)
        {
            return source.TransformToString(x => x.ToDateString(), nullText);
        }
        
        

        public static string ToShortDateTimeString(this DateTime source)
        {
            return source.ToInvariantString(DateTimeFormats.SHORT_DATE_TIME);
        }

        public static string ToShortDateTimeString(this DateTime? source)
        {
            return source.ToShortDateTimeString(null);
        }

        public static string ToShortDateTimeString(this DateTime? source, string nullText)
        {
            return source.TransformToString(x => x.ToShortDateTimeString(), nullText);
        }

        
        public static string ToDateTimeString(this DateTime source)
        {
            return source.ToInvariantString(DateTimeFormats.DATE_TIME);
        }

        public static string ToDateTimeString(this DateTime? source)
        {
            return source.ToDateTimeString(null);
        }

        public static string ToDateTimeString(this DateTime? source, string nullText)
        {
            return source.TransformToString(x => x.ToDateTimeString(), nullText);
        }

        
        public static string ToFullDateTimeString(this DateTime source)
        {
            return source.ToInvariantString(DateTimeFormats.FULL_DATE_TIME);
        }

        public static string ToFullDateTimeString(this DateTime? source)
        {
            return source.ToFullDateTimeString(null);
        }

        public static string ToFullDateTimeString(this DateTime? source, string nullText)
        {
            return source.TransformToString(x => x.ToFullDateTimeString(), nullText);
        }



        public static DateTime DayBegin(this DateTime source)
        {
            return source.Date;
        }

        public static DateTime? DayBegin(this DateTime? source)
        {
            if (source.HasValue == false) return null;

            return source.Value.DayBegin();
        }

        
        public static DateTime DayEnd(this DateTime source)
        {
            return source.Date + new TimeSpan(23, 59, 59);
        }

        public static DateTime? DayEnd(this DateTime? source)
        {
            if (source.HasValue == false) return null;

            return source.Value.DayEnd();
        }



        public static bool IsBetween(this DateTime source, DateTime firstDateTime, DateTime secondDateTime)
        {
            return firstDateTime <= source && source <= secondDateTime;
        }

        public static bool IsBetweenExclude(this DateTime source, DateTime firstDateTime, DateTime secondDateTime)
        {
            return firstDateTime < source && source < secondDateTime;
        }


        public static int DifferenceDays(this DateTime? source, DateTime date)
        {
            return source.HasValue ? DifferenceDays(source.Value, date) : 0;
        }

        public static int DifferenceDays(this DateTime source, DateTime date)
        {
            return (source.Date - date.Date).Days;
        }
    }
}