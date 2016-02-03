using System;
using System.Linq;

namespace Commons.Reflections.Delegates
{
    public static class FuncTypeHelper
    {
        public static Type ProvideFuncType(int genericArgumentsCount)
        {
            switch (genericArgumentsCount)
            {
                case 01: return typeof(Func<>);
                case 02: return typeof(Func<,>);
                case 03: return typeof(Func<,,>);
                case 04: return typeof(Func<,,,>);
                case 05: return typeof(Func<,,,,>);
                case 06: return typeof(Func<,,,,,>);
                case 07: return typeof(Func<,,,,,,>);
                case 08: return typeof(Func<,,,,,,,>);
                case 09: return typeof(Func<,,,,,,,,>);
                case 10: return typeof(Func<,,,,,,,,,>);
                case 11: return typeof(Func<,,,,,,,,,,>);
                case 12: return typeof(Func<,,,,,,,,,,,>);
                case 13: return typeof(Func<,,,,,,,,,,,,>);
                case 14: return typeof(Func<,,,,,,,,,,,,,>);
                case 15: return typeof(Func<,,,,,,,,,,,,,,>);
                case 16: return typeof(Func<,,,,,,,,,,,,,,,>);
                case 17: return typeof(Func<,,,,,,,,,,,,,,,,>);

                default:
                    throw new NotSupportedException("Не поддерживаем значение параметра 'genericArgumentsCount' вне диапазона 01..17.");
            }
        }

        public static Type MakeFuncType(Type outTypeArgument, params Type[] inTypeArguments)
        {
            if (outTypeArgument == null) throw new ArgumentException("Параметр 'outTypeArgument' не может быть NULL.");
            if (inTypeArguments == null) inTypeArguments = new Type[] {};

            var typeGenericArguments = inTypeArguments.Concat(new[] {outTypeArgument}).ToArray();

            return ProvideFuncType(typeGenericArguments.Length).MakeGenericType(typeGenericArguments);
        }
    }
}