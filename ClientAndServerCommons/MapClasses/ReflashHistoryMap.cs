using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using FluentNHibernate.Mapping;
using NHibernateContext.Helpers;

namespace ClientAndServerCommons.MapClasses
{
    public class ReflashHistoryMap:ClassMap<ReflashHistory>
    {
        public ReflashHistoryMap()
        {
            Table("ReflashHistory");


            Id(x => x.Id)
                .Column("Id").Unique().Not.Nullable()
                .GeneratedBy.Identity();


            Map(x => x.UserId)
                .Column("UserId")
                .Not.Nullable();

            Map(x => x.ReslashFileName)
                .Column("ReslashFileName")
                .Length(255)
                .Not.Nullable();

            Map(x => x.Vin)
                .Column("Vin")
                .Length(255)
                .Not.Nullable();

            Map(x => x.Cvn)
                .Column("Cvn")
                .Length(255)
                .Not.Nullable();

            Map(x => x.ReflashStatus)
                .Column("ReflashStatus")
                .Not.Nullable();

            Map(x => x.PaymentStatus)
                .Column("PaymentStatus")
                .Not.Nullable();

            Map(x => x.ReflashDateTime)
                .Column("ReflashDateTime")
                .MapDateTime()
                .Not.Nullable();

            HasMany(x => x.Review)
                .Table("Review")
                .KeyColumn("ReflashHistoryId")
                .LazyLoad()
                .BatchSize(20)
                .Cascade.None();

            //References(x => x.User)
            //    .Column("UserId")
            //    .Not.Nullable()
            //    .LazyLoad()
            //    .Cascade.None();

            //References(x => x.Review)
            //   .Column("Review")
            //   .Nullable()
            //   .LazyLoad()
            //   .Cascade.None();
        }
    }
}
