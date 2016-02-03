using System.CodeDom;
using System.Web.Compilation;
using System.Web.UI;

namespace WebAppCommons.Classes.CodeExpressions
{
    public abstract class EvaluableExpressionBuilder : ExpressionBuilder
    {
        public override bool SupportsEvaluate
        {
            get { return true; }
        }

        public abstract override object EvaluateExpression(object target, BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context);
        
        public abstract override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context);
    }
}