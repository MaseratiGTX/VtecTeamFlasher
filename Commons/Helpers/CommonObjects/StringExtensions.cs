using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Commons.Helpers.Objects;
using Newtonsoft.Json.Linq;

namespace Commons.Helpers.CommonObjects
{
    public static class StringExtensions
    {
        public static string FirstLetterToUpper(this string source)
        {
            if (source == null)
                return null;

            if (source.Length > 1)
                return char.ToUpperInvariant(source[0]) + source.Substring(1);

            return source.ToUpper();
        }


        public static string Truncate(this string source, int maxLength, string continuePart = "...")
        {
            if (source == null) return null;

            if (source.Length > maxLength)
            {
                var basePart = source.Substring(0, maxLength - continuePart.Length).TrimEnd();

                return basePart + continuePart;
            }

            return source;
        }


        public static string WrapHTMLTo(this string source, int maxLength)
        {
            return source.WrapSmartTo(maxLength, "<br/>");
        }

        public static string WrapTEXTTo(this string source, int maxLength)
        {
            return source.WrapSmartTo(maxLength, "/r/n");
        }

        public static string WrapSmartTo(this string source, int maxLength, string lineBreak)
        {
            return source.WrapSmartTo(maxLength, lineBreak, ' ', ',', '.', '?', '!', ';', '(', ')', '/', '\'', '"');
        }

        // ReSharper disable MethodOverloadWithOptionalParameter
        public static string WrapSmartTo(this string source, int maxLength, string lineBreak, params char[] separators)
        {
            if (source == null) return null;

            if (maxLength <= 0) return null;

            separators = separators ?? new char[] { };


            var result = string.Empty;

            var currentLineLength = 0;
            var currentTextItemLength = 0;

            for (var index = 0; index < source.Length; index++)
            {
                var currentChar = source[index];

                result = result + currentChar;

                currentLineLength = currentLineLength + 1;
                currentTextItemLength = currentTextItemLength + 1;

                if (currentChar.In(separators) || index + 1 == source.Length)
                {
                    while (currentLineLength > maxLength)
                    {
                        if (result.Length != currentTextItemLength)
                        {
                            result =
                                result.Substring(0, result.Length - currentTextItemLength) +
                                lineBreak +
                                result.Substring(result.Length - currentTextItemLength, currentTextItemLength);
                        }

                        currentLineLength = currentTextItemLength;
                        currentTextItemLength = currentTextItemLength - maxLength;
                    }

                    currentTextItemLength = 0;
                }
            }

            return result;
        }
        // ReSharper restore MethodOverloadWithOptionalParameter

        public static string WrapWith(this string source, string prefix, string postfix)
        {
            return prefix + source + postfix;
        }


        public static string Remove(this string source, string substring)
        {
            return source.Replace(substring, String.Empty);
        }

        public static string Remove(this string source, params string[] substrings)
        {
            return source.Remove((IEnumerable<string>)substrings);
        }

        public static string Remove(this string source, IEnumerable<string> substrings)
        {
            return substrings.Aggregate(source, (result, substring) => result.Remove(substring));
        }



        public static string Add(this string source, string nextChainElement)
        {
            if (source.IsEmpty()) return source;
            if (nextChainElement.IsEmpty()) return source;

            if (source.EndsWith(nextChainElement)) return source;

            return source + nextChainElement;
        }


        public static string AddLine(this string source, string nextChainElement)
        {
            return source.Add(nextChainElement + "\r\n");
        }


        public static string FillWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }


        public static string CustomTrim(this string source)
        {
            if (source == null) return null;

            return source.Trim();
        }


        public static bool IsJsonObject(this string source)
        {
            try
            {
                JObject.Parse(source);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static string EncodeLineBreaks(this string source)
        {
            return source.Replace("\r", "&#13;")
                         .Replace("\n", "&#10;");
        }

        public static string DecodeLineBreaks(this string source)
        {
            return source.Replace("&#13;", "\r")
                         .Replace("&#10;", "\n");
        }
        
        public static bool EqualAny(this string source, params string[] otherStrings)
        {
            return otherStrings.Any(x => source.Equals(x, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool NotEqualAny(this string source, params string[] otherStrings)
        {
            return source.EqualAny(otherStrings) == false;
        }


        public static bool EndsWithAny(this string source, params string[] endsWithStrings)
        {
            return endsWithStrings.Any(endsWithString => source.EndsWith(endsWithString, StringComparison.InvariantCultureIgnoreCase));
        }


        //TODO: пересмотреть
        public static bool ToBooleanValueExtended(this string source)
        {
            if (source.IsEmpty())
            {
                return true;
            }


            if (source.ToUpper().Equals("TRUE") || source.Equals("1"))
            {
                return true;
            }

            if (source.ToUpper().Equals("FALSE") || source.Equals("0"))
            {
                return false;
            }


            throw new Exception("BooleanFormatException");
        }

        //TODO: пересмотреть
        public static decimal ParseDecimalExtended(this string source)
        {
            if (source.Contains(".") && source.Contains(","))
            {
                throw new Exception("DecimalFormatException");
            }


            var normalizedSource = source.Replace(',', '.');

            if (normalizedSource.Count(x => x.Equals('.')) > 1)
            {
                throw new Exception("DecimalFormatException");
                
            }


            return decimal.Parse(normalizedSource, CultureInfo.InvariantCulture);
        }


        public static string AddItem(this string source, string item, string separator)
        {
            if (source.IsEmpty()) return item;

            return source + separator + item;
        }
    }
}