using ClientAndServerCommons.DataClasses;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Validators
{
    public class ReflashStorageValidator : ADOPersistenseValidator<ReflashStorage>
    {
        public ReflashStorageValidator(IADORepository adoRepository)
            : base(adoRepository)
        {

        }

        public override void OnSave()
        {
            base.OnSave();

        }
    }
}
