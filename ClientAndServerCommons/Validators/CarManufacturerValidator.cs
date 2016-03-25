using ClientAndServerCommons.DataClasses;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Validators
{
    public class CarManufacturerValidator: ADOPersistenseValidator<CarManufacturer>
    {
        public CarManufacturerValidator(IADORepository adoRepository)
            : base(adoRepository)
        {

        }

        public override void OnSave()
        {
            base.OnSave();

        }
    }
}
