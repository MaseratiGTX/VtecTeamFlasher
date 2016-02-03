using System.Collections.Specialized;
using Commons.Helpers;
using Commons.Helpers.Objects;
using WebAreaCommons.Classes.ItemRepositories.Validators;

namespace WebAreaCommons.Pages.Helpers.Users
{
    public static class UsersPageNewValuesHelper
    {
        public static void AddPasswordHash(this OrderedDictionary newValues)
        {
            newValues.Add("PasswordHash", CreatePasswordFrom(newValues));
        }

        public static void UpdatePasswordHash(this OrderedDictionary newValues)
        {
            if (newValues.HasPasswordContext())
            {
                newValues.AddPasswordHash();
            }
        }


        public static string CreatePasswordFrom(OrderedDictionary newValues)
        {
            var password = newValues["Password"].As<string>();
            var confirmPassword = newValues["ConfirmPassword"].As<string>();

            new PasswordValidator().Validate(password, confirmPassword);

            return password.ComputeSHA256Hash();
        }

        public static bool HasPasswordContext(this OrderedDictionary newValues)
        {
            var password = newValues["Password"].As<string>();
            var confirmPassword = newValues["ConfirmPassword"].As<string>();

            return password.IsNotEmpty() || confirmPassword.IsNotEmpty();
        }
    }
}