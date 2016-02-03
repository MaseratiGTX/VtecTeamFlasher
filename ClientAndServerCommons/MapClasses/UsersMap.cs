using ClientAndServerCommons.DataClasses;
using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernateContext.Helpers;

namespace ClientAndServerCommons.MapClasses
{
    public class UsersMap: ClassMap<User>
    {
        public UsersMap()
        {

            Table("Users");


            Id(x => x.Id)
                .Column("Id").Unique().Not.Nullable()
                .GeneratedBy.Identity();


            Map(x => x.FirstName)
                .Column("FirstName")
                .Length(255)
                .Not.Nullable();

            Map(x => x.LastName)
                .Column("LastName")
                .Length(255)
                .Not.Nullable();

            Map(x => x.MiddleName)
                .Column("MiddleName")
                .Length(255)
                .Nullable();

            Map(x => x.Login)
                .Column("Login")
                .Length(255)
                .Not.Nullable();

            Map(x => x.PasswordHash)
                .Column("PasswordHash")
                .Length(255)
                .Nullable();


            Map(x => x.Enabled)
                .Column("Enabled")
                .Not.Nullable();

            Map(x => x.UserType)
                .Column("UserType")
                .Not.Nullable();

        }
    }
}
