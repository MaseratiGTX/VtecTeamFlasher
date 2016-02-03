using System;
using System.Collections.Generic;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Items;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Aggregators
{
    public class SummaryRepositoryItemsContext
    {
        public Type ItemsType { get; private set; }
        public ServerModeSummaryDescriptor ItemsDescriptor { get; private set; }
        public string Key { get; private set; }

        public Aggregate ItemsSummaryType
        {
            get { return ItemsDescriptor.SummaryType; }
        }



        public SummaryRepositoryItemsContext(ServerModeSummaryDescriptor itemsDescriptor)
        {
            ItemsDescriptor = itemsDescriptor;

            ItemsType = CalculateItemsType(ItemsDescriptor);

            Key = ItemsDescriptor.CalculateKey();
        }



        private static Type CalculateItemsType(ServerModeSummaryDescriptor summaryDescriptor)
        {
            var summaryType = summaryDescriptor.SummaryType;

            switch (summaryType)
            {
                case Aggregate.Avg:
                    return typeof(AVGSummaryRepositoryItem);
                case Aggregate.Count:
                case Aggregate.Min:
                case Aggregate.Max:
                case Aggregate.Sum:
                    return typeof(SimpleSummaryRepositoryItem);
                default:
                    throw new NotSupportedException("Не поддерживаем SummaryType отличный от 'Avg', 'Count', 'Min', 'Max', 'Sum'. Переданное значение SummaryType: '{0}'".FillWith(summaryType));
            }
        }


        public SummaryRepositoryItemsContext Check(ISummaryRepositoryItem item)
        {
            var itemKey = item.Key;

            if (Key != itemKey)
            {
                throw new ArgumentException(
                    "Переданный на проверку элемент не соответствует общему контексту по ключу:\r\n" +
                    "ItemsContext.Key = '{0}'\r\n".FillWith(Key) +
                    "Item.Key = '{0}'".FillWith(itemKey)
                );
            }


            var itemType = item.GetType();

            if (ItemsType != itemType)
            {
                throw new ArgumentException(
                    "Переданный на проверку элемент не соответствует общему контексту по типу:\r\n" +
                    "ItemsContext.ItemsType = '{0}'\r\n".FillWith(ItemsType.TypeName()) +
                    "Item.GetType() = '{0}'".FillWith(itemType.TypeName())
                );
            }


            return this;
        }

        public SummaryRepositoryItemsContext Check(IEnumerable<ISummaryRepositoryItem> items)
        {
            foreach (var item in items)
            {
                Check(item);
            }

            return this;
        }
    }
}