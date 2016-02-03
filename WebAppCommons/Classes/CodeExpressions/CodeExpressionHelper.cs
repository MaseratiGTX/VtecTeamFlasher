using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace WebAppCommons.Classes.CodeExpressions
{
    public static class CodeExpressionHelper
    {
        public static CodeMethodInvokeExpression MakeStaticMethodInvokeExpression(Type targetType, string methodName, params object[] methodParameters)
        {
            return MakeStaticMethodInvokeExpression(targetType, methodName, methodParameters, x => new CodePrimitiveExpression(x));
        }

        public static CodeMethodInvokeExpression MakeStaticMethodInvokeExpression(Type targetType, string methodName, IEnumerable<object> methodParameters, Func<object, CodeExpression> convertionRule)
        {
            return MakeStaticMethodInvokeExpression(targetType, methodName, methodParameters != null ? methodParameters.Select(convertionRule).ToArray() : null);
        }

        public static CodeMethodInvokeExpression MakeStaticMethodInvokeExpression(Type targetType, string methodName, params CodeExpression[] expressionParameters)
        {
            return new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(targetType), methodName, expressionParameters);
        }
    }
}