using ClientAndServerCommons;

namespace WebAreaCommons.Classes.ItemRepositories.Validators
{
    public class EmptyItemValidator<T> : BaseItemValidator<T> where T : AbstractDataObject
    {
        public EmptyItemValidator(SessionBasedItemsRepository<T> itemsRepository)
            : base(itemsRepository)
        {
        }


        public override void OnSave()
        {
        }

        public override void OnDelete()
        {
        }
    }
}