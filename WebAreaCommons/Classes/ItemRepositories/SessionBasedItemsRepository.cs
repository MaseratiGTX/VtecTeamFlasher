using System;
using System.Collections.Generic;
using System.Web.SessionState;
using ClientAndServerCommons;
using Commons.Helpers.Objects;
using WebAppCommons.Classes.Helpers;
using WebAreaCommons.Classes.ItemRepositories.Validators;

namespace WebAreaCommons.Classes.ItemRepositories
{
    public class SessionBasedItemsRepository<T> where T : AbstractDataObject
    {
        public BaseItemValidator<T> ItemValidator { get; private set; }

        public HttpSessionState SessionState { get; private set; }
        public Guid PageGuid { get; private set; }
        public string RepositoryName { get; private set; }

        public List<T> Items { get; private set; }



        public SessionBasedItemsRepository()
        {
            ItemValidator = new EmptyItemValidator<T>(this);

            Items = new List<T>();
        }



        public SessionBasedItemsRepository<T> SetItemValidator(BaseItemValidator<T> value)
        {
            ItemValidator = value;    
            
            return this;
        }


        public SessionBasedItemsRepository<T> SetSessionState(HttpSessionState value)
        {
            SessionState = value;

            return this;
        }

        public SessionBasedItemsRepository<T> SetPageGuid(Guid value)
        {
            PageGuid = value;

            return this;
        }

        public SessionBasedItemsRepository<T> SetPageGuid(string value)
        {
            var pageGuid = value.SafelyParseGuid();

            if (pageGuid.HasValue == false) throw new ArgumentNullException("value", "PageGuid не может быть пустым.");

            return SetPageGuid(pageGuid.Value);
        }

        public SessionBasedItemsRepository<T> SetRepositoryName(string value)
        {
            RepositoryName = value;

            return this;
        }



        public SessionBasedItemsRepository<T> Initialize(IEnumerable<T> sourceItems)
        {
            var result = new List<T>();

            foreach (var item in sourceItems)
            {
                item.Id = result.Count + 1;

                result.Add(item);
            }


            Items = result;

            PersistState();

            return this;
        }


        public SessionBasedItemsRepository<T> RestoreState()
        {
            Items = SessionState.GetValue<List<T>>(PageGuid, RepositoryName, "ITEMS");

            return this;
        }

        public SessionBasedItemsRepository<T> PersistState()
        {
            SessionState.SetValue(PageGuid, RepositoryName, "ITEMS", Items);

            return this;
        }


        public T Save(T item)
        {
            ItemValidator.Validate(item).OnSave();

            return item.IsNewEntry() ? Insert(item) : Update(item);
        }


        private T Insert(T item)
        {
            item.Id = Items.Count + 1;

            Items.Add(item);
            PersistState();

            return item;
        }

        private T Update(T item)
        {
            var itemIndex = Items.FindIndex(x => x.Id == item.Id);

            if (itemIndex == -1)
            {
                return Insert(item);
            }

            Items[itemIndex] = item;
            PersistState();

            return item;
        }


        public void Delete(T item)
        {
            ItemValidator.Validate(item).OnDelete();

            var itemIndex = Items.FindIndex(x => x.Id == item.Id);

            if (itemIndex == -1)
            {
                return;
            }

            Items.RemoveAt(itemIndex);
            PersistState();
        }
    }
}