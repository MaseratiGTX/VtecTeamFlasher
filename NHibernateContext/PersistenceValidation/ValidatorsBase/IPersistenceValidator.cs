namespace NHibernateContext.PersistenceValidation.ValidatorsBase
{
    public interface IPersistenceValidator
    {
        object ValidatableObject { get; }

        IPersistenceValidator Validate(object entity);

        void OnSave();
        void OnDelete();

        void DropState();
    }
}