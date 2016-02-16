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

            //HasMany(x => x.ReflashHistory)
            //    .Table("ReflashHistory")
            //    .KeyColumn("UserId")
            //    .LazyLoad()
            //    .BatchSize(20)
            //    .Cascade.None();

            //HasMany(x => x.Requests)
            //    .Table("Requests")
            //    .KeyColumn("UserId")
            //    .LazyLoad()
            //    .BatchSize(20)
            //    .Cascade.None();

            Map(x => x.City)
                .Column("City")
                .Length(255)
                .Nullable();

            Map(x => x.Phone)
                .Column("Phone")
                .Length(50)
                .Nullable();

            Map(x => x.Skype)
                .Column("Skype")
                .Length(100)
                .Nullable();

            Map(x => x.VK)
                .Column("VK")
                .Length(255)
                .Nullable();

            Map(x => x.Viber)
                .Column("Viber")
                .Nullable();

            Map(x => x.WhatsApp)
                .Column("WhatsApp")
                .Nullable();

        }
    }
}
