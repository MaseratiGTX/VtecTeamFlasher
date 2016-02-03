using System.CodeDom;
using System.Web.Compilation;
using System.Web.UI;
using WebAppCommons.Classes.CodeExpressions;
using WebAppCommons.ResourceRepositories;

namespace WebAppCommons.ExpressionBuilders
{
    [ExpressionPrefix("WebAppCommonResource")]
    public class WebAppCommonResourceExpressionBuilder: EvaluableExpressionBuilder
    {
        public override object EvaluateExpression(object target, BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            return WebAppCommonResources.ProvideURLFor(entry.Expression.Trim());
        }

        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            return CodeExpressionHelper.MakeStaticMethodInvokeExpression(
                typeof(WebAppCommonResources), "ProvideURLFor", entry.Expression.Trim()
            );
        }
    }
}