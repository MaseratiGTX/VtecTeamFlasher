using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using Commons.Reflections;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.InterpritationResults;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors
{
    public class NHibernateSummaryProcessor<T> where T : class
    {
        public const string ItemSeparator = ", ";


        public string BaseAlias { get; private set; }

        public List<ServerModeSummaryDescriptor> PermanentSummaryDescriptors { get; private set; }

        public Dictionary<string, string> SpecialMappings { get; private set; }



        public NHibernateSummaryProcessor(string baseAlias)
        {
            BaseAlias = baseAlias;

            PermanentSummaryDescriptors = new List<ServerModeSummaryDescriptor>();

            SpecialMappings = new Dictionary<string, string>();
        }



        public NHibernateSummaryProcessor<T> AddSummaryDesciptor(Aggregate aggregateType, string propertyName)
        {
            return AddSummaryDesciptor(aggregateType.CreateDescriptorFor(propertyName));
        }

        public NHibernateSummaryProcessor<T> AddSummaryDesciptor(ServerModeSummaryDescriptor summaryDescriptor)
        {
            PermanentSummaryDescriptors.Add(summaryDescriptor);

            return this;
        }


        public NHibernateSummaryProcessor<T> AddMapping(string propertyName, string mapping)
        {
            if (SpecialMappings.ContainsKey(propertyName) == false)
            {
                SpecialMappings.Add(propertyName, mapping);
            }
            else
            {
                SpecialMappings[propertyName] = mapping;
            }

            return this;
        }



        public SummaryInterpritationResult Process(IEnumerable<ServerModeSummaryDescriptor> totalSummaryInfo)
        {
            var externalSummaryDescriptors = totalSummaryInfo != null ? totalSummaryInfo.ToList() : new List<ServerModeSummaryDescriptor>();

            var summaryDescriptors = PermanentSummaryDescriptors.Concat(externalSummaryDescriptors).DistinctBy(x => x.CalculateKey()).ToList();


            var resultString = summaryDescriptors.ToString(
                x => InterpritateSummaryType(x.SummaryType).Replace("[Expression]", InterpritateExpression(x.SummaryExpression)),
                ItemSeparator
            );


            return new SummaryInterpritationResult
            {
                ResultString = resultString,

                PermanentSummaryDescriptors = PermanentSummaryDescriptors,
                ExternalSummaryDescriptors = externalSummaryDescriptors,

                SummaryDescriptors = summaryDescriptors
            };
        }


        private string InterpritateSummaryType(Aggregate source)
        {
            switch (source)
            {
                case Aggregate.Avg:
                    return "SUM([Expression]), COUNT([Expression])";
                case Aggregate.Count:
                    return "COUNT([Expression])";
                case Aggregate.Min:
                    return "MIN([Expression])";
                case Aggregate.Max:
                    return "MAX([Expression])";
                case Aggregate.Sum:
                    return "SUM([Expression])";

                default:
                    throw new NotSupportedException("Не поддерживаем SummaryType отличный от 'Avg', 'Count', 'Min', 'Max', 'Sum'. Переданное значение SummaryType: '{0}'".FillWith(source));
            }
        }

        private string InterpritateExpression(CriteriaOperator source)
        {
            var operandProperty = source as OperandProperty;

            if (operandProperty != null)
            {
                var propertyName = operandProperty.PropertyName;
                var propertyType = typeof(T).GetPropertyType(propertyName);

                if (propertyType.Implements<IEnumerable>())
                {
                    throw new NotSupportedException("Не поддерживаем вычисление summary над property, которое является какого-либо рода \"перечислением\"");
                }


                var result = string.Empty;

                if (SpecialMappings.ContainsKey(propertyName))
                {
                    var specialMapping = SpecialMappings[propertyName];

                    if (specialMapping.Contains(BaseAlias))
                    {
                        result = specialMapping;
                    }
                    else
                    {
                        result = BaseAlias + "." + specialMapping;
                    }
                }
                else
                {
                    result = BaseAlias + "." + propertyName;
                }

                return result;
            }

            throw new NotSupportedException("Не поддерживаем CriteriaOperator отличный от 'OperandProperty'. Переданное значение CriteriaOperator: '{0}'".FillWith(source.TypeName()));
        }
    }
}