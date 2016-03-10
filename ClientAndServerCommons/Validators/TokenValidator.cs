using ClientAndServerCommons.DataClasses;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Validators
{
    public class TokenValidator: ADOPersistenseValidator<Token>
    {
        public TokenValidator(IADORepository adoRepository): base(adoRepository)
        {

        }

        public override void OnSave()
        {
            base.OnSave();

        }
    }
}
