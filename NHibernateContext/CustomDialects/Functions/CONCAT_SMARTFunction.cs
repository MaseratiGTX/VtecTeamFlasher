using System.Collections;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using NHibernate;
using NHibernate.Dialect.Function;
using NHibernate.Engine;
using NHibernate.SqlCommand;
using NHibernate.Type;

namespace NHibernateContext.CustomDialects.Functions
{
    public class CONCAT_SMARTFunction : StandardSQLFunction
    {
        public CONCAT_SMARTFunction()
            : base(null)
        {
        }


        public override IType ReturnType(IType columnType, IMapping mapping)
        {
            return NHibernateUtil.StringClob;
        }

        public override SqlString Render(IList args, ISessionFactoryImplementor factory)
        {
            return SqlString.Parse(
                args.Cast<object>()
                    .Select(x => x.ToString())
                    .ToString(x => "ISNULL(" + x + ", '')", " + ' ' + ")
            );
        }
    }
}