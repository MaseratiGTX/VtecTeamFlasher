using System.Web.UI;
using Commons.Helpers.Objects;
using Commons.Localization.Extensions;

namespace WebAppCommons.Classes.Helpers
{
    public static class PageTitleExtensions
    {
        public const string PAGE_TITLE_PLACEHOLDER = "[PAGE_TITLE]";
        public const string IGNORE_BASE_MARKER = "[IGNORE_BASE]";
        public const char BASE_PART_START_MARKER = '<';
        public const char BASE_PART_END_MARKER = '>';


        public static string MakeSmartTitle(this Page source, string titleTemplate)
        {
            var pageTitle = source.Title;
            var localizedTitleTemplate = titleTemplate.Localize();

            if (pageTitle.IsEmpty())
            {
                return localizedTitleTemplate
                    .Replace(PAGE_TITLE_PLACEHOLDER, "")
                    .ExtractBaseTitlePart();
            }

            if (pageTitle.StartsWith(IGNORE_BASE_MARKER))
            {
                return pageTitle
                    .Substring(IGNORE_BASE_MARKER.Length)
                    .Trim()
                    .Localize();
            }

            return localizedTitleTemplate
                .Replace(PAGE_TITLE_PLACEHOLDER, pageTitle.Localize())
                .Replace(BASE_PART_START_MARKER.ToString(), "")
                .Replace(BASE_PART_END_MARKER.ToString(), "");
        }


        private static string ExtractBaseTitlePart(this string source)
        {
            var result = string.Empty;

            var shouldUseCurrentChar = false;

            foreach (var character in source)
            {
                if (character == BASE_PART_START_MARKER)
                {
                    shouldUseCurrentChar = true;
                    continue;
                }

                if (character == BASE_PART_END_MARKER)
                {
                    shouldUseCurrentChar = false;
                    continue;
                }

                if (shouldUseCurrentChar)
                {
                    result = result + character;
                }
            }

            return result;
        }
    }
}