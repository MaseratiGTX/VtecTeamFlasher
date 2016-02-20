using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using FluentNHibernate.Mapping;
using NHibernateContext.Helpers;

namespace ClientAndServerCommons.MapClasses
{
    public class ReflashRequestMap:ClassMap<ReflashRequest>
    {
        public ReflashRequestMap()
        {
            Table("Requests");


            Id(x => x.Id)
                .Column("Id").Unique().Not.Nullable()
                .GeneratedBy.Identity();


            Map(x => x.UserId)
                .Column("UserId")
                .Not.Nullable();

            Map(x => x.StockFile)
                .Column("StockFile")
                .MapVarbinaryMax()
                .Nullable();

            Map(x => x.AdditionalMessage)
                .Column("AdditionalMessage")
                .Nullable();
            
            Map(x => x.StockFileName)
                .Column("StockFileName")
                .Nullable();

            Map(x => x.EcuCode)
                .Column("EcuCode")
                .Length(255)
                .Not.Nullable(); 
            
            Map(x => x.Car)
                .Column("Car")
                .Length(50)
                .Nullable();
            
            Map(x => x.Vin)
                .Column("Vin")
                .Length(100)
                .Nullable();

            Map(x => x.RequestStatus)
                .Column("RequestStatus")
                .Not.Nullable();

            Map(x => x.RequestDateTime)
                .Column("RequestDateTime")
                .MapDateTime()
                .Not.Nullable();

            //References(x => x.User)
            //    .Column("UserId")
            //    .Not.Nullable()
            //    .LazyLoad()
            //    .Cascade.None();
            
        }
    }
}
