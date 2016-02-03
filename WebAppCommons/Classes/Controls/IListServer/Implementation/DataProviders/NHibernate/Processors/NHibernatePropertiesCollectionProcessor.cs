using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.InterpritationResults;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors
{
    public class NHibernatePropertiesCollectionProcessor
    {
        public const string ItemSeparator = ", ";


        public string BaseAlias { get; private set; }

        public Dictionary<string, string> SpecialMappings { get; private set; }



        public NHibernatePropertiesCollectionProcessor(string baseAlias)
        {
            BaseAlias = baseAlias;

            SpecialMappings = new Dictionary<string, string>();
        }



        public NHibernatePropertiesCollectionProcessor AddMapping(string propertyName, string mapping)
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



        public PropertiesCollectionProcessingResult Process(IEnumerable<CriteriaOperator> expressions)
        {
            if (expressions == null) return new PropertiesCollectionProcessingResult();


            var propertyExpressions = expressions.Select(x =>
            {
                var operandProperty = x as OperandProperty;

                if (operandProperty != null)
                {
                    return operandProperty;
                }

                throw new NotSupportedException("Не поддерживаем expression отличный от 'OperandProperty'. Переданное значение expression: '{0}'".FillWith(x.TypeName()));
            }
                )
                .ToList();


            var resultString = propertyExpressions.ToString(x =>
            {
                var propertyName = x.PropertyName;


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
            },
                ItemSeparator
            );

            return new PropertiesCollectionProcessingResult
            {
                ResultString = resultString,
                PropertyExpressions = propertyExpressions
            };
        }
    }
}