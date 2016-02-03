using FluentNHibernate.Mapping;

namespace ClientAndServerCommons.MapClasses
{
    public class EntityContextMap : ClassMap<EntityContext>
    {
        public EntityContextMap()
        {
            Table("entitycontext");


            DiscriminateSubClassesOnColumn("entitycontexttype")
                .Length(50)
                .Not.Nullable();


            Id(x => x.Id).CustomSqlType("bigserial").GeneratedBy.Native();


            Map(x => x.Description).Column("description").CustomSqlType("character (200)").Nullable();
        }
    }
}