using ClientAndServerCommons;

namespace WebAreaCommons.Classes.ItemRepositories.Validators
{
    public interface IValidator<TValidatorType> where TValidatorType : class
    {
        TValidatorType Validate(AbstractDataObject entity);
    }
}
