using System.Text.RegularExpressions;
using Commons.Localization.Extensions;
using Commons.Validation.Assertions;

namespace WebAreaCommons.Classes.ItemRepositories.Validators
{
    public class PasswordValidator
    {
        private readonly Regex symbolRegex = new Regex(@"\W");
        private readonly Regex digitRegex = new Regex(@"\d");
        private readonly Regex wordAndDigitRegex = new Regex(@"\w");


        public void Validate(string password, string confirmPassword)
        {
            AssertionHelper
                .AssertIsNotEmpty(password)
                .Return("Password", "Пароль пользователя не может быть пустым.".Localize());

            AssertionHelper
                .AssertThat(password.Length)
                .IsGreaterOrEqualThan(6)
                .Return("Password", "Пароль должен состоять не менее чем из 6 символов.".Localize());

            AssertionHelper
                .AssertThat(password.Length)
                .IsLowerOrEqualThan(255)
                .Return("Password", "Пароль должен состоять не более чем из 255 символов.".Localize());

            AssertionHelper
                .AssertThat(password)
                .IsEqualTo(confirmPassword)
                .Return("ConfirmPassword", "Пароль и подтверждение пароля не совпадают.".Localize());

            //AssertionHelper
            //    .AssertTrue(symbolRegex.IsMatch(password) && 
            //                digitRegex.IsMatch(password) &&
            //                (wordAndDigitRegex.Matches(password).Count - digitRegex.Matches(password).Count) > 0)
            //    .Return("Password", "Пароль должен содержать буквы, цифры и символы.".Localize());


            AssertionHelper
                .AssertThat(password.IndexOf(' '))
                .IsLowerOrEqualThan(-1)
                .Return("Password", "Пароль не должен содержать символов пробела.".Localize());
        }
    }
}