using ClientAndServerCommons.DataClasses;
using FluentNHibernate.Mapping;
using NHibernateContext.Helpers;

namespace ClientAndServerCommons.MapClasses
{
    public class TokenMap: ClassMap<Token>
    {
        public TokenMap()
        {
            Table("Token");


            Id(x => x.Id)
                .Column("Id").Unique().Not.Nullable()
                .GeneratedBy.Identity();


            //Map(x => x.UserId)
            //    .Column("UserId")
            //    .Not.Nullable();

            Map(x => x.TokenString)
                .Column("Token")
                .Not.Nullable();

            Map(x => x.CreateDate)
                .Column("CreateDate")
                .MapDateTime()
                .Not.Nullable();

            References(x => x.User)
               .Column("UserId")
               .Not.LazyLoad()
               .Cascade.None();

         }
    }
}
