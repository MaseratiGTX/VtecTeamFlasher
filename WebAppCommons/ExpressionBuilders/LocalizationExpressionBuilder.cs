using System.CodeDom;
using System.Web.Compilation;
using System.Web.UI;
using Commons.Localization.Extensions;
using WebAppCommons.Classes.CodeExpressions;

namespace WebAppCommons.ExpressionBuilders
{
    [ExpressionPrefix("Localize")]
    public class LocalizationExpressionBuilder : EvaluableExpressionBuilder
    {
        public override object EvaluateExpression(object target, BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            // ReSharper disable InvokeAsExtensionMethod
            return LocalizationExtensions.Localize(entry.Expression.Trim());
            // ReSharper restore InvokeAsExtensionMethod
        }

        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            return CodeExpressionHelper.MakeStaticMethodInvokeExpression(
                typeof(LocalizationExtensions), "Localize", entry.Expression.Trim()
            );
        }
    }
}