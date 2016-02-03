using Commons.Localization.Extensions;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Events.Args;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers
{
    public static class ASPxPerformSearchingEventArgsExtensions
    {
        public static void AddSummaryLocalized(this ASPxPerformSearchingEventArgs source, string summary)
        {
            source.AddSummary(summary.Localize());
        }

        public static void AddSummaryLocalized(this ASPxPerformSearchingEventArgs source, string summaryCaption, object value)
        {
            source.AddSummary(summaryCaption.Localize(), value);
        }

        public static void AddSummaryLocalized(this ASPxPerformSearchingEventArgs source, string summaryTemplate, params object[] parameters)
        {
            source.AddSummary(summaryTemplate.Localize(), parameters);
        }
    }
}