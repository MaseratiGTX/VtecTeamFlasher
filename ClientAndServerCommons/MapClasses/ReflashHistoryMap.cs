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

            Map(x => x.BinaryFileName)
                .Column("BinaryFileName")
                .Length(255)
                .Not.Nullable();

            Map(x => x.CarVin)
                .Column("CarVin")
                .Length(255)
                .Not.Nullable();
            
            Map(x => x.Price)
                .Column("Price")
                .Length(100)
                .Not.Nullable();
            
            Map(x => x.Status)
                .Column("Status")
                .Not.Nullable();

            Map(x => x.ReflashDate)
                .Column("ReflashDate")
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
