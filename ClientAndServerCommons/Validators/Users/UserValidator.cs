using ClientAndServerCommons.DataClasses;
using Commons.Validation.Assertions;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Validators.Users
{
    public class UserValidator : ADOPersistenseValidator<User>
    {
        public UserValidator(IADORepository adoRepository)
            : base(adoRepository)
        {

        }
        public override void OnSave()
        {
            base.OnSave();

            //TODO: возможно это стоит переделать.

            AssertionHelper
                .AssertIsNotEmpty(Validatable.Login)
                .Return("UserName", "Имя пользователя должно быть задано.");



        }
    }
}
