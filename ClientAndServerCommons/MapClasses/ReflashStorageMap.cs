using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using FluentNHibernate.Mapping;
using NHibernateContext.Helpers;

namespace ClientAndServerCommons.MapClasses
{
    public class ReflashStorageMap:ClassMap<ReflashStorage>
    {
        public ReflashStorageMap()
        {
            Table("ReflashStorage");


            Id(x => x.Id)
                .Column("Id").Unique().Not.Nullable()
                .GeneratedBy.Identity();


            Map(x => x.CarManufacturerId)
                .Column("CarManufacturerId")
                .Not.Nullable();

            Map(x => x.Model)
                .Column("Model")
                .Length(100)
                .Not.Nullable();
            
            Map(x => x.YearOfRelease)
               .Column("YearOfRelease")
               .MapDateTime()
               .Not.Nullable();

            Map(x => x.TransmissionType)
               .Column("TransmissionType")
               .Length(50)
               .Not.Nullable();

            Map(x => x.EcuBinaryNumber)
               .Column("EcuBinaryNumber")
               .Length(100)
               .Not.Nullable();

            Map(x => x.AltEcuCode)
              .Column("AltEcuCode")
              .Length(300)
              .Nullable();

            Map(x => x.ReflashFileName)
                .Column("ReflashFileName")
                .Length(250)
                .Not.Nullable();

            Map(x => x.ReflashBinary)
               .Column("ReflashBinary")
               .MapVarbinaryMax()
               .Not.Nullable();

            Map(x => x.Description)
               .Column("Description")
               .MapNVarcharMax()
               .Nullable();

            Map(x => x.DateOfLoad)
               .Column("DateOfLoad")
               .MapDateTime()
               .Not.Nullable(); 

            Map(x => x.UserId)
                .Column("UserId")
                .Not.Nullable();

        }
    }
}
