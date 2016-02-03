using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.CriteriaOperators;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.CriteriaOperators.Criterias.Parsers;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.CriteriaOperators.Helpers;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.InterpritationResults;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors
{
    public class NHibernateFilterCriteriaProcessor
    {
        public string BaseAlias { get; private set; }

        private List<CriteriaOperator> PermanentCriteriaRepository { get; set; }
        private Dictionary<string, object> AggregatedParameters { get; set; }


        public NHibernateFilterCriteriaProcessor(string baseAlias)
        {
            BaseAlias = baseAlias;

            PermanentCriteriaRepository = new List<CriteriaOperator>();
            AggregatedParameters = new Dictionary<string, object>();
        }



        public NHibernateFilterCriteriaProcessor RegisterPermanentCriteria(CriteriaOperator criteriaOperator)
        {
            PermanentCriteriaRepository.Add(criteriaOperator);

            return this;
        }


        public FilterInterpritationResult Process(CriteriaOperator filterCriteria)
        {
            AggregatedParameters = new Dictionary<string, object>();


            var actualFilterCriteria = PermanentCriteriaRepository
                .ToGroup(GroupOperatorType.And)
                .ConcatAnd(filterCriteria);


            if (actualFilterCriteria == null)
            {
                return new FilterInterpritationResult();
            }


            var resultString = InterpritateFilter(actualFilterCriteria, BaseAlias);


            return new FilterInterpritationResult
            {
                ResultString = resultString,
                Parameters = AggregatedParameters
            };
        }



        private string InterpritateFilter(CriteriaOperator source, string currentAlias)
        {
            var groupOperator = source as GroupOperator;

            if (groupOperator != null)
            {
                return ProcessGroupOperator(groupOperator, currentAlias);
            }


            var inOperator = source as InOperator;

            if (inOperator != null)
            {
                return ProcessInOperator(inOperator, currentAlias);
            }


            var aggregateOperand = source as AggregateOperand;

            if (aggregateOperand != null)
            {
                return ProcessAggregateOperand(aggregateOperand, currentAlias);
            }


            var binaryOperator = source as BinaryOperator;

            if (binaryOperator != null)
            {
                return ProcessBinaryOperator(binaryOperator, currentAlias);
            }


            var operandProperty = source as OperandProperty;

            if (operandProperty != null)
            {
                return ProcessOperandProperty(operandProperty, currentAlias);
            }


            var constantValue = source as ConstantValue;

            if (constantValue != null)
            {
                return ProcessConstantValue(constantValue);
            }


            var operandValue = source as OperandValue;

            if (operandValue != null)
            {
                return ProcessOperandValue(operandValue);
            }



            throw new NotSupportedException("Не поддерживаем CriteriaOperator отличный от 'GroupOperator', 'AggregateOperand', 'BinaryOperator', 'OperandProperty', 'ConstantValue'. Переданное значение CriteriaOperator: '{0}'".FillWith(source.TypeName()));
        }


        private string ProcessGroupOperator(GroupOperator groupOperator, string alias)
        {
            var groupItemSeparator = Process(groupOperator.OperatorType);

            return
                "(" +
                    groupOperator.Operands.ToString(
                        x => InterpritateFilter(x, alias), groupItemSeparator
                    ) +
                ")";
        }

        private string ProcessInOperator(InOperator inOperator, string alias)
        {
            return InterpritateFilter(inOperator.LeftOperand, alias) + " IN (" + ProcessOperands(inOperator.Operands) + ")";
        }

        private string ProcessOperands(CriteriaOperatorCollection operands)
        {
            var hqlSubQueryCriteria = new HQLSubQueryCriteriaParser().Parse(operands);

            if (hqlSubQueryCriteria != null)
            {
                var parameterNames = hqlSubQueryCriteria.Parameters.Select(ProcessConstantValue);

                var queryTemplate = hqlSubQueryCriteria.QueryTemplate;
                var templateArgs = parameterNames.Cast<object>().ToArray();

                return queryTemplate.FillWith(templateArgs);
            }

            throw new NotSupportedException("Не поддерживаем обработку данной коллекции.");
        }

        private string ProcessAggregateOperand(AggregateOperand aggregateOperand, string alias)
        {
            var aggregateOperandAlias = ProcessOperandProperty(aggregateOperand.CollectionProperty, alias);

            return InterpritateFilter(aggregateOperand.Condition, aggregateOperandAlias);
        }

        private string ProcessBinaryOperator(BinaryOperator binaryOperator, string alias)
        {
            return InterpritateFilter(binaryOperator.LeftOperand, alias) +
                   Process(binaryOperator.OperatorType) +
                   InterpritateFilter(binaryOperator.RightOperand, alias);
        }

        private string ProcessOperandProperty(OperandProperty operandProperty, string alias)
        {
            var operandPropertyName = operandProperty.PropertyName;

            if (operandPropertyName.StartsWith(ConcatOperandOperator.OPERAND_PREFIX))
            {
                return "CONCAT_SMART(" +
                    operandPropertyName
                        .Remove(ConcatOperandOperator.OPERAND_PREFIX)
                        .Split(ConcatOperandOperator.PROPERTY_DELIMETER)
                        .ToString(x => alias + "." + x, ", ") +
                ")";
            }
            

            if (operandPropertyName.StartsWith(FirstNbytesOperandOperator.OPERAND_PREFIX))
            {
                var query = operandPropertyName.Remove(FirstNbytesOperandOperator.OPERAND_PREFIX)
                                .Split(FirstNbytesOperandOperator.DELIMETER);
                
                if (query.Length == 2)
                {
                    return "FIRST_NBYTES({0}.{1}, {2})".FillWith(alias, query[0], query[1]);
                }
            }

            return alias + "." + operandPropertyName;
        }


        private string ProcessConstantValue(ConstantValue constantValue)
        {
            var parameterName = "param" + AggregatedParameters.Count;
            var parameterValue = constantValue.Value;

            if (parameterValue == null)
            {
                return "null";
            }

            AggregatedParameters.Add(parameterName, parameterValue);

            return ":" + parameterName;
        }


        private string ProcessOperandValue(OperandValue operandValue)
        {
            var parameterName = "param" + AggregatedParameters.Count;
            var parameterValue = operandValue.Value;

            if (parameterValue == null)
            {
                return "null";
            }

            AggregatedParameters.Add(parameterName, parameterValue);

            return ":" + parameterName;
        }



        private static string Process(BinaryOperatorType binaryOperatorType)
        {
            switch (binaryOperatorType)
            {
                case BinaryOperatorType.Equal:
                    return " = ";

                case BinaryOperatorType.NotEqual:
                    return " != ";

                case BinaryOperatorType.Greater:
                    return " > ";

                case BinaryOperatorType.GreaterOrEqual:
                    return " >= ";

                case BinaryOperatorType.Less:
                    return " < ";

                case BinaryOperatorType.LessOrEqual:
                    return " <= ";

                case BinaryOperatorType.Like:
                    return " LIKE ";

                case BinaryOperatorType.Minus:
                    return " - ";

                case BinaryOperatorType.Plus:
                    return " + ";

                case BinaryOperatorType.Multiply:
                    return " * ";

                case BinaryOperatorType.Divide:
                    return " / ";

                default:
                    throw new NotSupportedException("Не поддерживаем BinaryOperatorType отличный от 'Equal', 'NotEqual', 'Greater', 'GreaterOrEqual', 'Less', 'LessOrEqual', 'Like', 'Minus', 'Plus', 'Multiply', 'Divide'. Переданное значение BinaryOperatorType: '{0}'".FillWith(binaryOperatorType));
            }
        }


        private static string Process(GroupOperatorType groupOperatorType)
        {
            switch (groupOperatorType)
            {
                case GroupOperatorType.And:
                    return " AND ";

                case GroupOperatorType.Or:
                    return " OR ";

                default:
                    throw new NotSupportedException("Не поддерживаем GroupOperatorType отличный от 'And' или 'Or'. Переданное значение GroupOperatorType: '{0}'".FillWith(groupOperatorType));
            }
        }
    }
}