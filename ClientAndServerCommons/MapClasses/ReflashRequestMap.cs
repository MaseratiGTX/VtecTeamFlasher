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

            Map(x => x.StockBinary)
                .Column("StockBinary")
                .MapVarbinaryMax()
                .Nullable();

            Map(x => x.EcuNumber)
                .Column("EcuNumber")
                .Length(150)
                .Nullable();

            Map(x => x.BinaryNumber)
                .Column("BinaryNumber")
                .Length(150)
                .Nullable();

            Map(x => x.EcuPhoto)
                .Column("EcuPhoto")
                .MapVarbinaryMax()
                .Nullable();

            Map(x => x.EcuPhotoFilename)
                .Column("EcuPhotoFilename")
                .Length(200)
                .Nullable();

            Map(x => x.CarDescription)
                .Column("CarDescription")
                .Length(400)
                .Not.Nullable();

            Map(x => x.RequestDate)
                .Column("RequestDate")
                .MapDateTime()
                .Nullable();

            Map(x => x.Status)
                .Column("Status")
                .Nullable();

            Map(x => x.ExpectedResolveDate)
                .Column("ExpectedResolveDate")
                .MapDateTime()
                .Nullable();

            Map(x => x.RequestDetails)
                .Column("RequestDetails")
                .Length(255)
                .Nullable();

            Map(x => x.StockBinaryName)
                .Column("StockBinaryName")
                .Length(255)
                .Nullable();

            HasMany(x => x.Comments)
                .Table("Comments")
                .KeyColumn("RequestId")
                .LazyLoad()
                .BatchSize(20)
                .Cascade.None();

            //References(x => x.User)
            //    .Column("UserId")
            //    .Not.Nullable()
            //    .LazyLoad()
            //    .Cascade.None();
            
        }
    }
}
