using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.SqlCommand;
using NHibernate.Type;
using NHibernate.Util;
using NHibernateContext.Helpers.Criterion;

namespace NHibernateContext.CustomCriterions
{
    [Serializable]
    public class SimpleByteExpression : AbstractCriterion
    {
        public IProjection Projection { get; protected set; }
        
        public string Operation { get; protected set; }

        public byte[] Value { get; protected set; }



        public SimpleByteExpression(IProjection projection, string operation, byte[] value)
        {
            Projection = projection;
            Operation = operation;
            Value = value;
        }



        public override string ToString()
        {
            return Projection + Operation + ValueString();
        }

    
        public override SqlString ToSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            var columnName = Projection.GetColumnName(criteria, criteriaQuery, enabledFilters);
            var parameter = criteriaQuery.NewQueryParameter(GetParameterTypedValue()).Single();

            return new SqlStringBuilder(3)
                .Add(columnName)
                .Add(Operation)
                .Add(parameter)
                .ToSqlString();
        }


        public override TypedValue[] GetTypedValues(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return Projection.GetTypedValues(criteria, criteriaQuery)
                .Concat(GetParameterTypedValue())
                .ToArray();
        }

        
        public override IProjection[] GetProjections()
        {
            return new[] { Projection };
        }



        protected string ValueString()
        {
            return ObjectHelpers.IdentityToString(Value);
        }


        protected TypedValue GetParameterTypedValue()
        {
            return Value.ToTypedValue(
                x => TypeFactory.GetBinaryType(x.Length)
            );
        }
    }
}