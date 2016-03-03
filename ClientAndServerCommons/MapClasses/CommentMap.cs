using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using FluentNHibernate.Mapping;
using NHibernateContext.Helpers;

namespace ClientAndServerCommons.MapClasses
{
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            Table("Comments");


            Id(x => x.Id)
                .Column("Id").Unique().Not.Nullable()
                .GeneratedBy.Identity();


            Map(x => x.UserId)
                .Column("UserId")
                .Not.Nullable();

            Map(x => x.RequestId)
                .Column("RequestId")
                .Not.Nullable();

            Map(x => x.CommentDate)
                .Column("CommentDate")
                .MapDateTime()
                .Not.Nullable();

            Map(x => x.CommentText)
                .Column("CommentText")
                .Length(1000)
                .Not.Nullable();

            References(x => x.User)
                .Column("UserId")
                .Not.Nullable()
                .Not.LazyLoad()
                .Cascade.None();
            
         }
    }
}
