using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.ASPx.xCriteriaOperator
{
    public static class CriteriaOperatorExtensions
    {
        public static Dictionary<string, object> FetchPropertyValues(this CriteriaOperator source)
        {
            return new CriteriaOperatorPropertyValueFetcher(source).Fetch();
        }

        public static Dictionary<string, object> FetchPropertyValues(this CriteriaOperator source, IDictionary<BinaryOperatorType, Func<ConstantValue, object>> calculationFunctions)
        {
            return new CriteriaOperatorPropertyValueFetcher(source).Register(calculationFunctions).Fetch();
        }

        public static Dictionary<string, object> FetchPropertyValues(this CriteriaOperator source, KeyValuePair<BinaryOperatorType, Func<ConstantValue, object>> calculationFunction)
        {
            return new CriteriaOperatorPropertyValueFetcher(source).Register(calculationFunction).Fetch();
        }

        public static Dictionary<string, object> FetchPropertyValues(this CriteriaOperator source, BinaryOperatorType operatorType, Func<ConstantValue, object> calculationFunction)
        {
            return new CriteriaOperatorPropertyValueFetcher(source).Register(operatorType, calculationFunction).Fetch();
        }
    }
}