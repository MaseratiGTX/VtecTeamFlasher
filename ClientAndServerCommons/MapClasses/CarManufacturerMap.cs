using ClientAndServerCommons.DataClasses;
using FluentNHibernate.Mapping;

namespace ClientAndServerCommons.MapClasses
{
    public class CarManufacturerMap : ClassMap<CarManufacturer>
    {
        public CarManufacturerMap()
        {
            Table("CarManufacturer");


            Id(x => x.Id)
                .Column("Id").Unique().Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.Manufacturer)
                .Column("Manufacturer")
                .Length(100)
                .Not.Nullable();

         }
    }
}
