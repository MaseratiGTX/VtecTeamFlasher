using System;
using System.Collections.Generic;
using System.ComponentModel;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.Objects;
using Commons.Helpers.CommonObjects;
using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Events.Args
{
    public class ASPxPerformSearchingEventArgs : CancelEventArgs
    {
        public string SummaryTemplate { get; set; }
        public GroupOperatorType CriteriaGroupOperatorType { get; set; }

        public string FilterExpression { get; set; }
        public string SearchDetails { get; set; }

        public List<CriteriaOperator> Criteries { get; private set; }
        public List<String> SearchResultSummaries { get; private set; }



        public ASPxPerformSearchingEventArgs()
        {
            SummaryTemplate = "{0}: \"{1}\"";
            CriteriaGroupOperatorType = GroupOperatorType.And;

            FilterExpression = null;
            SearchDetails = null;

            Criteries = new List<CriteriaOperator>();
            SearchResultSummaries = new List<string>();
        }



        public void AddCriteria(CriteriaOperator criteria)
        {
            Criteries.Add(criteria);
        }

        public void AddCriteria(string propertyName, object value, BinaryOperatorType operatorType)
        {
            AddCriteria(
                new BinaryOperator(propertyName, value, operatorType)
            );
        }


        public void AddSummary(string summary)
        {
            SearchResultSummaries.Add(summary);
        }

        public void AddSummary(string summaryCaption, object value)
        {
            AddSummary(SummaryTemplate, summaryCaption, value);
        }

        public void AddSummary(string summaryTemplate, params object[] parameters)
        {
            AddSummary(string.Format(summaryTemplate, parameters));
        }


        internal string CalculateFilterExpression()
        {
            if (FilterExpression == null)
            {
                if (Criteries.IsEmpty()) return string.Empty;

                return new GroupOperator(CriteriaGroupOperatorType, Criteries.ToArray()).ToString();
            }

            return FilterExpression;
        }

        internal string CalculateSearchDetails()
        {
            return SearchDetails ?? ToHTML(SearchResultSummaries);
        }


        protected string ToHTML(List<string> source)
        {
            if (source.IsEmpty()) return string.Empty;

            return "<ul>" + source.ToString(x => "<li>" + x + "</li>", string.Empty) + "</ul>";
        }
    }
}