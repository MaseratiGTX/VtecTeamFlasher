using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using FluentNHibernate.Mapping;
using NHibernateContext.Helpers;

namespace ClientAndServerCommons.MapClasses
{
    public class NewsMap : ClassMap<News>
    {
        public NewsMap()
        {
            Table("News");


            Id(x => x.Id)
                .Column("Id").Unique().Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.Date)
                .Column("Date")
                .MapDateTime()
                .Not.Nullable();

            Map(x => x.Text)
                .Column("Text")
                .MapNVarcharMax()
                .Not.Nullable();
            
            Map(x => x.Caption)
                .Column("Caption")
                .Length(100)
                .Not.Nullable();

         }
    }
}
