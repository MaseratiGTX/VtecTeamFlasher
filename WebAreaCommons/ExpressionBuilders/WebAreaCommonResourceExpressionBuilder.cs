using System.CodeDom;
using System.Web.Compilation;
using System.Web.UI;
using WebAppCommons.Classes.CodeExpressions;
using WebAreaCommons.ResourceRepositories;

namespace WebAreaCommons.ExpressionBuilders
{
    [ExpressionPrefix("WebAreaCommonResource")]
    public class WebAreaCommonResourceExpressionBuilder : EvaluableExpressionBuilder
    {
        public override object EvaluateExpression(object target, BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            return WebAreaCommonResources.ProvideURLFor(entry.Expression.Trim());
        }

        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            return CodeExpressionHelper.MakeStaticMethodInvokeExpression(
                typeof(WebAreaCommonResources), "ProvideURLFor", entry.Expression.Trim()
            );
        }
    }
}