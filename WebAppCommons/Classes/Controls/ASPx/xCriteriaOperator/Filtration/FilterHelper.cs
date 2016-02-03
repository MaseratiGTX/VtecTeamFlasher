using System.Text.RegularExpressions;
using Commons.Helpers.CommonObjects;

namespace WebAppCommons.Classes.Controls.ASPx.xCriteriaOperator.Filtration
{
    public static class FilterHelper
    {
        public const string VALUE_PLACEHOLDER = "[VALUE]";
        public const string DEFAULT_FILTER_PATTERN = "%[VALUE]%";

        public const string EXACT_KEYWORD = "[EXACT]";


        public static FilterPattern ToFilterPattern(this string source)
        {
            var displayValue = string.Empty;
            var actualValue = string.Empty;

            if (source.IsExactFilter())
            {
                displayValue = source;
                actualValue = displayValue.RemoveKeyWords();
            }
            else
            {
                displayValue = source.RemoveWildcardCharacters().Trim();
                actualValue = displayValue.ApplyFilterPattern(DEFAULT_FILTER_PATTERN);
            }

            return new FilterPattern
            {
                DisplayValue = displayValue,
                ActualValue = actualValue
            };
        }


        public static bool IsExactFilter(this string source)
        {
            return source.StartsWith(EXACT_KEYWORD);
        }


        public static string ApplyFilterPattern(this string source, string filterPattern)
        {
            return filterPattern.Replace(VALUE_PLACEHOLDER, source);
        }


        public static string RemoveKeyWords(this string source)
        {
            return source.Remove(
                new[] { EXACT_KEYWORD }
            );
        }

        public static string RemoveWildcardCharacters(this string source)
        {
            //http://technet.microsoft.com/en-us/library/aa933232%28v=sql.80%29.aspx

            var result = source;
                result = result.Remove("%", "_");
                result = Regex.Replace(result, @"\[.*?\]", string.Empty);

            return result;
        }

        public static string RemoveFilterSpecialCharacters(this string source)
        {
            return source
                .RemoveKeyWords()
                .RemoveWildcardCharacters();
        }
    }
}