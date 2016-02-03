using Commons.Helpers.CommonObjects;
using FluentNHibernate.Mapping;

namespace NHibernateContext.Helpers
{
    public static class PropertyPartExtensions
    {
        public static PropertyPart MapDateTime(this PropertyPart source)
        {
            return source
                .CustomType("datetime2");
        }


        public static PropertyPart MapNVarchar(this PropertyPart source, int length)
        {
            return source
                .CustomType("StringClob")
                .CustomSqlType(
                    "nvarchar({0})".FillWith(length.ToSQL())
                 )
                .Length(length);
        }

        public static PropertyPart MapNVarcharMax(this PropertyPart source)
        {
            return source.MapNVarchar(int.MaxValue);
        }


        public static PropertyPart MapVarbinary(this PropertyPart source, int length)
        {
            return source
                .CustomType("BinaryBlob")
                .CustomSqlType(
                    "varbinary({0})".FillWith(length.ToSQL())
                 )
                .Length(length);
        }

        public static PropertyPart MapVarbinaryMax(this PropertyPart source)
        {
            return source.MapVarbinary(int.MaxValue);
        }


        private static string ToSQL(this int length)
        {
            return length == int.MaxValue ? "max" : length.ToString();
        }
    }
}