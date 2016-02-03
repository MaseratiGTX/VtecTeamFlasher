using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Items;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Aggregators
{
    public class SummaryRepositoryItemAggregator
    {
        public ISummaryRepositoryItem Aggregate(IEnumerable<ISummaryRepositoryItem> summaryRepositoryItems)
        {
            var source = summaryRepositoryItems as List<ISummaryRepositoryItem> ?? summaryRepositoryItems.ToList();


            var itemsContext = CalculateItemsContext(source);


            var result = CreateResultItem(itemsContext);

            var aggregateAction = CalculateAggregateAction(itemsContext);

            foreach (var item in source)
            {
                aggregateAction.Invoke(result, item);
            }

            return result;
        }


        private static SummaryRepositoryItemsContext CalculateItemsContext(List<ISummaryRepositoryItem> source)
        {
            return new SummaryRepositoryItemsContext(source.First().SourceDescriptor).Check(source);
        }


        private static ISummaryRepositoryItem CreateResultItem(SummaryRepositoryItemsContext itemsContext)
        {
            return (ISummaryRepositoryItem)Activator.CreateInstance(itemsContext.ItemsType, itemsContext.ItemsDescriptor);
        }

        private static Action<ISummaryRepositoryItem, ISummaryRepositoryItem> CalculateAggregateAction(SummaryRepositoryItemsContext itemsContext)
        {
            var summaryType = itemsContext.ItemsSummaryType;

            switch (summaryType)
            {
                case DevExpress.Data.Filtering.Aggregate.Avg:
                    return AVGAggregateAction;
                case DevExpress.Data.Filtering.Aggregate.Count:
                    return COUNTAggregateAction;
                case DevExpress.Data.Filtering.Aggregate.Max:
                    return MAXAggregateAction;
                case DevExpress.Data.Filtering.Aggregate.Min:
                    return MINAggregateAction;
                case DevExpress.Data.Filtering.Aggregate.Sum:
                    return SUMAggregateAction;
                default:
                    throw new NotSupportedException("Не поддерживаем SummaryType отличный от 'Avg', 'Count', 'Min', 'Max', 'Sum'. Переданное значение SummaryType: '{0}'".FillWith(summaryType));
            }
        }


        private static void AVGAggregateAction(ISummaryRepositoryItem result, ISummaryRepositoryItem item)
        {
            var x = (AVGSummaryRepositoryItem)result;
            var y = (AVGSummaryRepositoryItem)item;

            x.Sum += y.Sum;
            x.Count += y.Count;

            x.Value = x.Sum / x.Count;
        }

        private static void COUNTAggregateAction(ISummaryRepositoryItem result, ISummaryRepositoryItem item)
        {
            var x = (SimpleSummaryRepositoryItem)result;
            var y = (SimpleSummaryRepositoryItem)item;


            x.Value = x.Value == null ? y.Value : x.Value.As<int>() + y.Value.As<int>();
        }

        private static void MAXAggregateAction(ISummaryRepositoryItem result, ISummaryRepositoryItem item)
        {
            var x = (SimpleSummaryRepositoryItem)result;
            var y = (SimpleSummaryRepositoryItem)item;

            var xValue = (IComparable)x.Value;
            var yValue = (IComparable)y.Value;

            x.Value = xValue == null ? yValue : xValue.CompareTo(yValue) > 0 ? xValue : yValue;
        }

        private static void MINAggregateAction(ISummaryRepositoryItem result, ISummaryRepositoryItem item)
        {
            var x = (SimpleSummaryRepositoryItem)result;
            var y = (SimpleSummaryRepositoryItem)item;

            var xValue = (IComparable)x.Value;
            var yValue = (IComparable)y.Value;

            x.Value = xValue == null ? yValue : xValue.CompareTo(yValue) > 0 ? yValue : xValue;
        }

        private static void SUMAggregateAction(ISummaryRepositoryItem result, ISummaryRepositoryItem item)
        {
            var x = (SimpleSummaryRepositoryItem)result;
            var y = (SimpleSummaryRepositoryItem)item;

            x.Value = x.Value == null ? y.Value : Convert.ChangeType(x.Value.As<decimal>() + y.Value.As<decimal>(), x.Value.GetType());
        }
    }
}