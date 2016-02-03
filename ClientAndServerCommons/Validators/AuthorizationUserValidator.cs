using ClientAndServerCommons.DataClasses;
using Commons.Helpers;
using Commons.Validation.Assertions;

namespace ClientAndServerCommons.Validators
{
    public class AuthorizationUserValidator
    {
        public void Validate(AbstractUser user, string password)
        {
            var source = user != null && user.PasswordHash == password.ComputeSHA256Hash();
            AssertionHelper
                .AssertTrue(source)
                .Return("Login", "Логин или пароль пользователя введен некорректно.");

            AssertionHelper
                .AssertTrue(user.Enabled)
                .Return("Login", "Пользователь с указанным логином не активен.");
        }
    }
}
