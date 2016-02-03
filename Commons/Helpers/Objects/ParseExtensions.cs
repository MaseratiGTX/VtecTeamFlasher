using System;
using System.Globalization;
using System.Linq;

namespace Commons.Helpers.Objects
{
    public static class ParseExtensions
    {
        public static bool ParseBool(this string source)
        {
            return bool.Parse(source);
        }

        public static int ParseInt(this string source)
        {
            return int.Parse(source);
        }

        public static long ParseLong(this string source)
        {
            return long.Parse(source);
        }

        public static decimal ParseDecimal(this string source)
        {
            return decimal.Parse(source);
        }

        public static double ParseDouble(this string source)
        {
            return double.Parse(source);
        }

        public static float ParseFloat(this string source)
        {
            return float.Parse(source);
        }

        public static DateTime ParseDateTime(this string source, string format)
        {
            return DateTime.ParseExact(source, format, CultureInfo.InvariantCulture);
        }

        public static T ParseEnum<T>(this string source)
        {
            return (T) Enum.Parse(typeof (T), source);
        }

        public static Guid ParseGuid(this string source)
        {
            return Guid.Parse(source);
        }



        public static bool? ParseBool(this object source)
        {
            return (source as string).SafelyParseBool();
        }

        public static int? ParseInt(this object source)
        {
            return (source as string).SafelyParseInt();
        }

        public static long? ParseLong(this object source)
        {
            return (source as string).SafelyParseLong();
        }

        public static decimal? ParseDecimal(this object source)
        {
            return (source as string).SafelyParseDecimal();
        }

        public static double? ParseDouble(this object source)
        {
            return (source as string).SafelyParseDouble();
        }

        public static double? ParseFloat(this object source)
        {
            return (source as string).SafelyParseFloat();
        }

        public static DateTime? ParseDateTime(this object source, string format)
        {
            return (source as string).SafelyParseDateTime(format);
        }

        public static Guid? ParseGuid(this object source)
        {
            return (source as string).SafelyParseGuid();
        }



        public static bool? SafelyParseBool(this string source)
        {
            try
            {
                return source.ParseBool();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int? SafelyParseInt(this string source)
        {
            try
            {
                return source.ParseInt();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static long? SafelyParseLong(this string source)
        {
            try
            {
                return source.ParseLong();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static decimal? SafelyParseDecimal(this string source)
        {
            try
            {
                return source.ParseDecimal();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static double? SafelyParseDouble(this string source)
        {
            try
            {
                return source.ParseDouble();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static float? SafelyParseFloat(this string source)
        {
            try
            {
                return source.ParseFloat();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime? SafelyParseDateTime(this string source, string format)
        {
            try
            {
                return source.ParseDateTime(format);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Guid? SafelyParseGuid(this string source)
        {
            try
            {
                return source.ParseGuid();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool TryParseExtended(this string source, out decimal result)
        {
            var reversedDecimalString = source.Reverse().ToArray();


            var groupSeparator = ",";
            var integralPartSeparator = ".";


            for (var i = 0; i < reversedDecimalString.Length; i++)
            {
                if (Char.IsDigit(reversedDecimalString[i]) == false)
                {
                    if (i == 2)
                    {
                        integralPartSeparator = Convert.ToString(reversedDecimalString[i]);

                        while (Char.IsDigit(reversedDecimalString[++i]) == false)
                        {
                            integralPartSeparator += reversedDecimalString[i];
                        }
                    }


                    if (i > 2)
                    {
                        groupSeparator = Convert.ToString(reversedDecimalString[i]);

                        while (++i < reversedDecimalString.Length && Char.IsDigit(reversedDecimalString[i]) == false)
                        {
                            groupSeparator += reversedDecimalString[i];
                        }
                    }
                }
            }


            var numberFormatInfo = new NumberFormatInfo
            {
                CurrencyGroupSeparator = groupSeparator,
                PercentGroupSeparator = groupSeparator,
                NumberGroupSeparator = groupSeparator,
                CurrencyDecimalSeparator = integralPartSeparator,
                NumberDecimalSeparator = integralPartSeparator,
                PercentDecimalSeparator = integralPartSeparator
            };


            result = 0.0m;

            try
            {
                result = decimal.Parse(source, numberFormatInfo);
            }
            catch
            {
                return false;
            }


            return true;
        }
    }
}