using System;
using System.Linq;
using System.Reflection;
using Commons.Helpers.Collections.Generic;

namespace Commons.Reflections.Delegates
{
    public static class MethodDelegateExtensions
    {
        public static Delegate FetchPropertyGetterDelegate(this Type source, BindingFlags bindingAttr, string propertyName)
        {
            return source.FetchProperty(bindingAttr, propertyName).Getter()
                .CreateMethodDelegate();
        }

        public static Delegate FetchPropertySetterDelegate(this Type source, BindingFlags bindingAttr, string propertyName)
        {
            return source.FetchProperty(bindingAttr, propertyName).Setter()
                .CreateMethodDelegate();
        }

        public static Delegate FetchMethodDelegate(this Type source, BindingFlags bindingAttr, string methodName, params Type[] parameterTypes)
        {
            return source.FetchMethod(bindingAttr, methodName, parameterTypes)
                .CreateMethodDelegate();
        }


        public static Delegate CreateMethodDelegate(this MethodInfo methodInfo)
        {
            var parametersTypes = methodInfo.GetParameters().Select(x => x.ParameterType);

            var outTypeArgument = methodInfo.ReturnType;
            var inTypeArguments = methodInfo.IsStatic == false ? methodInfo.ReflectedType.Concat(parametersTypes) : parametersTypes;

            var appropriateDelegateType = MakeAppropriateDelegateType(outTypeArgument, inTypeArguments.ToArray());

            return Delegate.CreateDelegate(appropriateDelegateType, methodInfo);
        }


        private static Type MakeAppropriateDelegateType(Type outTypeArgument, params Type[] inTypeArguments)
        {
            if (outTypeArgument == null || outTypeArgument == typeof(void))
            {
                return ActionTypeHelper.MakeActionType(inTypeArguments);
            }

            return FuncTypeHelper.MakeFuncType(outTypeArgument, inTypeArguments);
        }



        private static MethodInfo FetchMethod(this Type source, BindingFlags bindingAttr, string methodName, params Type[] parameterTypes)
        {
            var methodInfo = source.GetMethod(methodName, bindingAttr, Type.DefaultBinder, parameterTypes, null);

            if (methodInfo == null)
            {
                throw new MissingMethodException(string.Format(
                    "У типа '{0}' не найден метод '{1}', соответствующий указанным параметрам.", source.FullName, methodName
                ));
            }
            
            return methodInfo;
        }


        private static PropertyInfo FetchProperty(this Type source, BindingFlags bindingAttr, string propertyName)
        {
            var result = source.GetProperty(propertyName, bindingAttr);

            if (result == null)
            {
                throw new MissingMemberException(string.Format(
                    "У типа '{0}' не найдено свойство '{1}', соответствующее указанным параметрам.", source.FullName, propertyName
                ));
            }

            return result;
        }

        private static MethodInfo Getter(this PropertyInfo source)
        {
            var result = source.GetGetMethod(true);

            if (result == null)
            {
                throw new MissingMethodException(string.Format(
                    "У типа '{0}' отсутсвует getter для свойства '{1}'.", source.ReflectedType, source.Name
                ));
            }

            return result;
        }

        private static MethodInfo Setter(this PropertyInfo source)
        {
            var result = source.GetSetMethod(true);

            if (result == null)
            {
                throw new MissingMethodException(string.Format(
                    "У типа '{0}' отсутсвует setter для свойства '{1}'.", source.ReflectedType, source.Name
                ));
            }

            return result;
        }
    }
}