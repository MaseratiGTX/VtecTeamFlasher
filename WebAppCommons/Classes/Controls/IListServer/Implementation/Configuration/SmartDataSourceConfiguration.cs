using System;
using System.Collections.Generic;
using System.ComponentModel;
using Commons.Validation.Assertions;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.Base;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.Configuration
{
    public class SmartDataSourceConfiguration<T> where T : class
    {
        public string KeyPropertyName { get; protected set; }

        public IDataProvider<T> DataProvider { get; protected set; }

        public int PageSize { get; protected set; }

        public Action<List<PropertyDescriptor>> ItemPropertiesExpandingAction { get; protected set; }



        public SmartDataSourceConfiguration()
        {
            PageSize = 10;
        }



        public SmartDataSourceConfiguration<T> SetKeyPropertyName(string value)
        {
            KeyPropertyName = value;

            return this;
        }

        public SmartDataSourceConfiguration<T> SetDataProvider(IDataProvider<T> value)
        {
            DataProvider = value;

            return this;
        }

        public SmartDataSourceConfiguration<T> SetPageSize(int value)
        {
            PageSize = value;

            return this;
        }

        public SmartDataSourceConfiguration<T> ExpandItemProperties(Action<List<PropertyDescriptor>> action)
        {
            ItemPropertiesExpandingAction = action;

            return this;
        }


        public SmartDataSourceConfiguration<T> EnsureComplete()
        {
            AssertionHelper
                .AssertIsNotEmpty(KeyPropertyName)
                .Return<SmartDataSourceConfigurationException>("KeyPropertyName", "KeyPropertyName должно быть указано");

            AssertionHelper
                .AssertIsNotNull(DataProvider)
                .Return<SmartDataSourceConfigurationException>("DataProvider", "DataProvider должен быть указан");

            AssertionHelper
                .AssertThat(PageSize)
                .IsGreaterThan(0)
                .Return<SmartDataSourceConfigurationException>("PageSize", "PageSize должен быть больше нуля");

            return this;
        }
    }
}