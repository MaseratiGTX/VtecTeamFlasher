using System.Data;
using NHibernate.Driver;
using NHibernate.SqlTypes;

namespace NHibernateContext.CustomDrivers
{
    public class MSSQL2008CustomDriver : Sql2008ClientDriver
    {
        protected override void InitializeParameter(IDbDataParameter dbParam, string name, SqlType sqlType)
        {
            base.InitializeParameter(dbParam, name, sqlType);

//            NHibernate версии 4.0.3.GA имеет одну интересную особенность:
//            Какой бы размер не был указан для параметра при осуществлении выборки из БД 
//            на уровне MS SQL Server размер параметра транслируется в размерность 4000 или MAX.
//            При определенных обстоятельствах это приводит к усложнению плана выполнения запроса 
//            на стороне MS SQL Server, что в свою очередь приводит к "удорожанию" выборки.

//            Проведенное исследование показало, что в рамках 3.3.0.CR1 был реализован тикет NH-3036 (Wrong SqlType size set for LIKE statement) 
//            (см. https://nhibernate.jira.com/browse/NH-3036). В рамках реализации данного тикета NH перестал "передавать" размер параметра указанный 
//            на уровне NHibernate на уровень БД - был закомментирован следующий участок кода в NHibernate.Driver.SqlClientDriver:
//            ===============================================================================
//            no longer override the defaults using data from SqlType, since LIKE expressions needs larger columns
//            https://nhibernate.jira.com/browse/NH-3036
//            if (sqlType.LengthDefined && !IsText(dbParam, sqlType) && !IsBlob(dbParam, sqlType))
//            {
//                dbParam.Size = sqlType.Length;
//            }
            
//            Стоит отметить, что тикет NH-3036 тесно связан с:
//            * NH-2528 (Throw exception instead of silently truncate string and blob data) 
//            * NH-3403 (Wrong parameter size in query with MsSql2000Dialect,MsSql2005Dialect and MsSql2008Dialect). 
//            Причем на момент написания данного комментария NH-3403 был открыт и планировался к реализации в 4.1.0. 

//            Учитывая что проблема описанная в NH-3036 для нашего случая не является существенной,
//            то в качестве временного решения по проблеме размера параметра запроса на уровне БД мы будем 
//            использовать закомментированный в основной версии NH код:

            if (sqlType.LengthDefined && !IsText(dbParam, sqlType) && !IsBlob(dbParam, sqlType))
            {
            	dbParam.Size = sqlType.Length;
            }

//            ВНИМАНИЕ! Стоит однозначно вернуться к пересмотру данного решения после выпуска решения по NH-3403 в одной из стабильных версий NH.

//            ПРИМЕЧАНИЕ: проблема описанная в NH-3036 в общем-то сама по себе крайне спорна, т.к. NH сам НЕ "занимается" добавлением символов '%' в начало и конец строки при постороении LIKE конструкций. 
//            Соответственно, если в качестве параметра LIKE передается значение по длине равное максимальной длине колонки, при этом еще и "завернутое" в '%', то отчасти это проблема разработчика, 
//            так как разработчик в этом случае сознательно пытается провести поиск по значению которое превышает максимальное возможное значение для данной колонки. 
//            Иными словами пытается сделать поиск по критерию LIKE когда возможен поиск только по критерию EQUAL.
        }
    }
}