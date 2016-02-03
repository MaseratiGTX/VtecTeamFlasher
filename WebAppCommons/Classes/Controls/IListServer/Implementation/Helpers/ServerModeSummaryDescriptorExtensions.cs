using System;
using System.Collections.Generic;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using DevExpress.Data;
using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers
{
    public static class ServerModeSummaryDescriptorExtensions
    {
        public static string CalculateKey(this ServerModeSummaryDescriptor source)
        {
            return "|" + CalculateKeyPart(source.SummaryType) + "|" + CalculateKeyPart(source.SummaryExpression) + "|";
        }


        private static string CalculateKeyPart(Aggregate source)
        {
            return source.ToString();
        }

        private static string CalculateKeyPart(CriteriaOperator source)
        {
            var operandProperty = source as OperandProperty;

            if (operandProperty != null)
            {
                return operandProperty.PropertyName;
            }

            throw new NotSupportedException("Не поддерживаем CriteriaOperator отличный от 'OperandProperty'. Переданное значение CriteriaOperator: '{0}'".FillWith(source.TypeName()));
        }



        public static ServerModeSummaryDescriptor CreateDescriptorFor(this Aggregate summaryType, string propertyName)
        {
            return new ServerModeSummaryDescriptor(new OperandProperty(propertyName), summaryType);
        }

        public static ServerModeSummaryDescriptor CreateDescriptorFor(this string propertyName, Aggregate summaryType)
        {
            return new ServerModeSummaryDescriptor(new OperandProperty(propertyName), summaryType);
        }


        public static ICollection<ServerModeSummaryDescriptor> AddSummaryDesciptor(this ICollection<ServerModeSummaryDescriptor> source, Aggregate summaryType, string propertyName)
        {
            var result = source != null
                             ? new List<ServerModeSummaryDescriptor>(source)
                             : new List<ServerModeSummaryDescriptor>();


            var summaryDescriptor = summaryType.CreateDescriptorFor(propertyName);

            result.Add(summaryDescriptor);


            return result;
        }
    }
}