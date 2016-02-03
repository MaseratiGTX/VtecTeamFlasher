using NHibernate;
using NHibernate.Dialect;
using NHibernate.Dialect.Function;
using NHibernate.Mapping;
using NHibernate.SqlTypes;
using NHibernateContext.CustomDialects.Functions;

namespace NHibernateContext.CustomDialects
{
    public class MsSql2008CustomDialect : MsSql2008Dialect
    {
        public MsSql2008CustomDialect()
        {
            RegisterFunction("CONCAT_SMART", new CONCAT_SMARTFunction());
            RegisterFunction("DAY_OF_WEEK_TO_INT_SMART", new DAY_OF_WEEK_TO_INT_SMARTFunction());
            RegisterFunction("FIRST_NBYTES", new SQLFunctionTemplate(NHibernateUtil.BinaryBlob, "CAST(?1 AS varbinary(?2))")); //TODO: возможно переделать
        }


        public override string AppendLockHint(LockMode lockMode, string tableName)
        {
            if (lockMode.Equals(LockMode.UpgradeNoWait))
            {
                return tableName + " with (updlock, rowlock, readpast)";
            }

            return base.AppendLockHint(lockMode, tableName);
        }


        public override string GetCastTypeName(SqlType sqlType)
        {
//            NHibernate версии 4.0.3.GA имеет одну интересную особенность:
//            Какой бы размер не был указан у параметра sqlType переданного в этот метод 
//            на уровне MS SQL Server размер параметра транслируется в размерность Column.DefaultLength.
//            Иными словами Projections.Cast(TypeFactory.GetBinaryType([SIZE]), IProjection projection) 
//            вне зависимости от значения [SIZE] будет транслирован в SQL вида CAST(... AS VARBINARY(255))

//            Мы решаем эту проблему использованием значений Length и Precision если они указанны у sqlType:

            if (sqlType.LengthDefined || sqlType.PrecisionDefined)
            {
                return GetTypeName(sqlType, sqlType.Length, sqlType.Precision, sqlType.Scale);    
            }

//            и "придерживаемся" "нативного" поведения в случае если имеем дело с типом у которого не указаны Length или Precision:

            return GetTypeName(sqlType, Column.DefaultLength, Column.DefaultPrecision, Column.DefaultScale);
        }
    }
}