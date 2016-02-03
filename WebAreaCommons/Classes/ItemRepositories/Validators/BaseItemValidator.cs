using ClientAndServerCommons;

namespace WebAreaCommons.Classes.ItemRepositories.Validators
{
    public abstract class BaseItemValidator<T> : IPersistValidator where T : AbstractDataObject
    {
        protected SessionBasedItemsRepository<T> ItemsRepository { get; set; }
        protected T Validatable { get; set; }



        protected BaseItemValidator(SessionBasedItemsRepository<T> itemsRepository)
        {
            ItemsRepository = itemsRepository;
        }



        public BaseItemValidator<T> Validate(T entity)
        {
            Validatable = entity;

            return this;
        }

        public IPersistValidator Validate(AbstractDataObject entity)
        {
            return Validate((T)entity);
        }

        public abstract void OnSave();
        public abstract void OnDelete();
    }
}