using System;
using System.Collections.Generic;
using Commons.Helpers.Objects;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.ASPx.xCriteriaOperator.Filtration;

namespace WebAppCommons.Classes.Controls.ASPx.xCriteriaOperator
{
    public static class FilterExpresssionExtensions
    {
        public static Dictionary<string, object> FetchPropertyValues(this string filterExpression)
        {
            var filterCriteria = CriteriaOperator.Parse(filterExpression);

            return filterCriteria.FetchPropertyValues(
                new Dictionary<BinaryOperatorType, Func<ConstantValue, object>>
                    {
                        {BinaryOperatorType.Equal, x => x.Value},
                        // Удаляем форматирование примененное во время построения фильтра  
                        // (см. FilterHelper.ToFilterPattern())
                        {BinaryOperatorType.Like, x => x.Value.As<string>().RemoveFilterSpecialCharacters()},
                    }
            );
        }
    }
}