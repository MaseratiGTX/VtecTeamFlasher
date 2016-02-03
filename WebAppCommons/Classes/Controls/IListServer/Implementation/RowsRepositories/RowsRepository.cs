using System;
using System.Collections.Generic;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.Base;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.RowsRepositories
{
    public class RowsRepository<T> where T : class
    {
        public IDataProvider<T> DataProvider { get; private set; }
        public int PageSize { get; private set; }

        private List<T> Items { get; set; }



        public RowsRepository(IDataProvider<T> dataProvider, int pageSize)
        {
            DataProvider = dataProvider;
            PageSize = pageSize;

            Reset();
        }

        public RowsRepository<T> Reset()
        {
            Items = new List<T>();

            return this;
        }


        public T this[int index]
        {
            get
            {
                InitializeItemAt(index);

                return Items[index];
            }
        }


        private void InitializeItemAt(int index)
        {
            if (HasItemAt(index) == false)
            {
                var items = DataProvider.Fetch().Items(index, PageSize);

                foreach (var item in items)
                {
                    AddOrUpdateItemAt(index++, item);
                }
            }
        }

        private bool HasItemAt(int index)
        {
            return index < Items.Count && Items[index] != null;
        }

        private void AddOrUpdateItemAt(int index, T item)
        {
            if (index > Items.Count)
            {
                var difference = index - Items.Count;

                for (var counter = 0; counter < difference; counter++)
                {
                    Items.Add(null);
                }
            }

            if (index == Items.Count)
            {
                Items.Add(item);
            }
            else
            {
                Items[index] = item;
            }
        }



        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            return Items.FindIndex(startIndex, count, ExcludeNullItems(match));
        }

        public int FindIndex(int startIndex, Predicate<T> match)
        {
            return Items.FindIndex(startIndex, ExcludeNullItems(match));
        }

        public int FindIndex(Predicate<T> match)
        {
            return Items.FindIndex(ExcludeNullItems(match));
        }


        private Predicate<T> ExcludeNullItems(Predicate<T> predicate)
        {
            return x => x != null && predicate(x);
        }
    }
}