using System;
using System.Collections.Generic;
using Commons.Helpers.Collections.Generic;
using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.ASPx.xCriteriaOperator
{
    public class CriteriaOperatorPropertyValueFetcher
    {
        public CriteriaOperator Source { get; private set; }

        private Dictionary<BinaryOperatorType, Func<ConstantValue, object>> CalculationFunctionsRepository { get; set; }



        public CriteriaOperatorPropertyValueFetcher(CriteriaOperator source)
        {
            Source = source;

            CalculationFunctionsRepository = new Dictionary<BinaryOperatorType, Func<ConstantValue, object>>();
        }



        public CriteriaOperatorPropertyValueFetcher Register(IDictionary<BinaryOperatorType, Func<ConstantValue, object>> calculationFunctions)
        {
            foreach (var calculationFunction in calculationFunctions)
            {
                Register(calculationFunction);
            }

            return this;
        }

        public CriteriaOperatorPropertyValueFetcher Register(KeyValuePair<BinaryOperatorType, Func<ConstantValue, object>> calculationFunction)
        {
            return Register(calculationFunction.Key, calculationFunction.Value);
        }

        public CriteriaOperatorPropertyValueFetcher Register(BinaryOperatorType operatorType, Func<ConstantValue, object> calculationFunction)
        {
            CalculationFunctionsRepository[operatorType] = calculationFunction;

            return this;
        }



        public Dictionary<string, object> Fetch()
        {
            var result = new Dictionary<string, object>();

            result.Apply(Fetch(Source));

            return result;
        }


        private Dictionary<string, object> Fetch(CriteriaOperator source)
        {
            var result = new Dictionary<string, object>();


            var groupOperator = source as GroupOperator;

            if (groupOperator != null)
            {
                result.Apply(Fetch(groupOperator));

                return result;
            }


            var aggregateOperand = source as AggregateOperand;

            if (aggregateOperand != null)
            {
                result.Apply(Fetch(aggregateOperand));

                return result;
            }


            var binaryOperator = source as BinaryOperator;

            if (binaryOperator != null)
            {
                result.Apply(Fetch(binaryOperator));

                return result;
            }


            return result;
        }


        private Dictionary<string, object> Fetch(GroupOperator source)
        {
            var result = new Dictionary<string, object>();


            var operands = source.Operands;

            foreach (var operand in operands)
            {
                result.Apply(Fetch(operand));
            }


            return result;
        }


        private KeyValuePair<string, object> Fetch(AggregateOperand source)
        {
            var basePropertyOperand = source.CollectionProperty;
            var subPropertyOperator = source.Condition;


            var binaryOperator = subPropertyOperator as BinaryOperator;

            if (binaryOperator != null)
            {
                var subPropertyFetchingResult = Fetch(binaryOperator);

                var basePropertyName = basePropertyOperand.PropertyName;
                var subPropertyName = subPropertyFetchingResult.Key;


                var propertyName = basePropertyName + "." + subPropertyName;
                var propertyValue = subPropertyFetchingResult.Value;

                return new KeyValuePair<string, object>(propertyName, propertyValue);
            }


            return new KeyValuePair<string, object>();
        }


        private KeyValuePair<string, object> Fetch(BinaryOperator source)
        {
            var operandProperty = source.LeftOperand as OperandProperty;

            if (operandProperty == null) return new KeyValuePair<string, object>();

            var propertyName = operandProperty.PropertyName;


            if (CalculationFunctionsRepository.ContainsKey(source.OperatorType) == false) return new KeyValuePair<string, object>();

            var calculationFunction = CalculationFunctionsRepository[source.OperatorType];


            var constantValue = source.RightOperand as ConstantValue;

            if (constantValue == null) return new KeyValuePair<string, object>();

            var propertyValue = calculationFunction.Invoke(constantValue);


            return new KeyValuePair<string, object>(propertyName, propertyValue);
        }
    }
}