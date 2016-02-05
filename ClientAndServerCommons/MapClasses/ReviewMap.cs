using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using FluentNHibernate.Mapping;
using NHibernateContext.Helpers;

namespace ClientAndServerCommons.MapClasses
{
    public class ReviewMap:ClassMap<Review>
    {
        public ReviewMap()
        {
            Table("Review");


            Id(x => x.Id)
                .Column("Id").Unique().Not.Nullable()
                .GeneratedBy.Identity();


            Map(x => x.ReflashHistoryId)
                .Column("ReflashHistoryId")
                .Not.Nullable();

            Map(x => x.UserName)
                .Column("UserName")
                .Length(255)
                .Not.Nullable();

            Map(x => x.SourceUrl)
                .Column("SourceUrl")
                .Length(255)
                .Nullable();

            Map(x => x.UserReview)
                .Column("UserReview")
                .Length(255)
                .Not.Nullable();

            Map(x => x.ReviewDateTime)
                .Column("ReviewDateTime")
                .MapDateTime()
                .Not.Nullable();

        }
    }
}
