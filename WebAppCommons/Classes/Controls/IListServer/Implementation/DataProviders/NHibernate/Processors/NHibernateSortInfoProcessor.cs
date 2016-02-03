using System;
using System.Collections.Generic;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.InterpritationResults;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors
{
    public class NHibernateSortInfoProcessor
    {
        public const string ORDER_TEMPLATE_PLACEHOLDER = "[ORDER]";

        public const string ItemSeparator = ", ";


        public string BaseAlias { get; private set; }

        public Dictionary<string, string> SpecialMappings { get; private set; }



        public NHibernateSortInfoProcessor(string baseAlias)
        {
            BaseAlias = baseAlias;

            SpecialMappings = new Dictionary<string, string>();
        }



        public NHibernateSortInfoProcessor AddMapping(string propertyName, string mapping)
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

        public NHibernateSortInfoProcessor AddMappings(IDictionary<string, string> mappings)
        {
            foreach (var mapping in mappings)
            {
                AddMapping(mapping.Key, mapping.Value);
            }

            return this;
        }



        public bool HasSpecialMappingsFor(IEnumerable<ServerModeOrderDescriptor> groupSortInfo)
        {
            foreach (var sortInfo in groupSortInfo)
            {
                var operandProperty = sortInfo.SortExpression as OperandProperty;

                if (operandProperty == null)
                {
                    throw new NotSupportedException("Не поддерживаем SortExpression отличный от 'OperandProperty'. Переданное значение SortExpression: '{0}'".FillWith(sortInfo.SortExpression.TypeName()));
                }

                var propertyName = operandProperty.PropertyName;

                if (SpecialMappings.ContainsKey(propertyName))
                {
                    return true;
                }
            }

            return false;
        }



        public SortInfoInterpritationResult Process(IEnumerable<ServerModeOrderDescriptor> sortInfo)
        {
            if (sortInfo == null) return new SortInfoInterpritationResult();

            var resultString = sortInfo.ToString(x =>
            {
                var operandProperty = x.SortExpression as OperandProperty;

                if (operandProperty != null)
                {
                    var propertyName = operandProperty.PropertyName;
                    var propertySortOrder = x.IsDesc ? "DESC" : "ASC";


                    var template = string.Empty;

                    if (SpecialMappings.ContainsKey(propertyName))
                    {
                        var specialMapping = SpecialMappings[propertyName];

                        if (specialMapping.Contains(BaseAlias))
                        {
                            template = specialMapping;
                        }
                        else
                        {
                            template = BaseAlias + "." + specialMapping;
                        }

                        if (specialMapping.Contains(ORDER_TEMPLATE_PLACEHOLDER) == false)
                        {
                            template = template + " " + ORDER_TEMPLATE_PLACEHOLDER;
                        }
                    }
                    else
                    {
                        template = BaseAlias + "." + propertyName + " " + ORDER_TEMPLATE_PLACEHOLDER;
                    }

                    return template.Replace(ORDER_TEMPLATE_PLACEHOLDER, propertySortOrder);
                }

                throw new NotSupportedException("Не поддерживаем SortExpression отличный от 'OperandProperty'. Переданное значение SortExpression: '{0}'".FillWith(x.SortExpression.TypeName()));
            },
                ItemSeparator
            );

            return new SortInfoInterpritationResult
            {
                ResultString = resultString
            };
        }
    }
}