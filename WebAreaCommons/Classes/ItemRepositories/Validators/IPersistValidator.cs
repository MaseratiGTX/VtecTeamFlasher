namespace WebAreaCommons.Classes.ItemRepositories.Validators
{
    public interface IPersistValidator : IValidator<IPersistValidator>
    {
        void OnSave();
        void OnDelete();
    }
}
