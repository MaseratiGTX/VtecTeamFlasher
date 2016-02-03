using System;
using System.Collections;
using Commons.Helpers.Collections;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Items;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Factories
{
    public class SummaryRepositoryItemFactory
    {
        private IEnumerator DataSourceEnumerator { get; set; }



        public SummaryRepositoryItemFactory(object[] dataSource)
        {
            SetDataSource(dataSource);
        }



        public SummaryRepositoryItemFactory SetDataSource(object[] dataSource)
        {
            DataSourceEnumerator = dataSource.GetEnumerator();

            return this;
        }



        public SummaryRepositoryItemFactory Reset()
        {
            DataSourceEnumerator.Reset();

            return this;
        }



        public ISummaryRepositoryItem Produce(ServerModeSummaryDescriptor summaryDescriptor)
        {
            return ProduceFor(summaryDescriptor);
        }

        public ISummaryRepositoryItem ProduceFor(ServerModeSummaryDescriptor summaryDescriptor)
        {
            var summaryType = summaryDescriptor.SummaryType;

            switch (summaryType)
            {
                case Aggregate.Avg:
                    return ProduceAVGItem(summaryDescriptor);
                case Aggregate.Count:
                    return ProduceSimpleItem(summaryDescriptor);
                case Aggregate.Min:
                    return ProduceSimpleItem(summaryDescriptor);
                case Aggregate.Max:
                    return ProduceSimpleItem(summaryDescriptor);
                case Aggregate.Sum:
                    return ProduceSimpleItem(summaryDescriptor);
                default:
                    throw new NotSupportedException("Не поддерживаем SummaryType отличный от 'Avg', 'Count', 'Min', 'Max', 'Sum'. Переданное значение SummaryType: '{0}'".FillWith(summaryType));
            }
        }


        private AVGSummaryRepositoryItem ProduceAVGItem(ServerModeSummaryDescriptor sourceDescriptor)
        {
            var itemSum = DataSourceEnumerator.FetchNext().As<decimal>();
            var itemCount = DataSourceEnumerator.FetchNext().As<int>();

            var itemValue = itemSum / itemCount;


            return new AVGSummaryRepositoryItem(sourceDescriptor)
            {
                Sum = itemSum,
                Count = itemCount,

                Value = itemValue
            };
        }


        private SimpleSummaryRepositoryItem ProduceSimpleItem(ServerModeSummaryDescriptor sourceDescriptor)
        {
            var itemValue = DataSourceEnumerator.FetchNext();

            return new SimpleSummaryRepositoryItem(sourceDescriptor)
            {
                Value = itemValue
            };
        }
    }
}