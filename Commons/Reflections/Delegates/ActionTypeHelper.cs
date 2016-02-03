using System;

namespace Commons.Reflections.Delegates
{
    public static class ActionTypeHelper
    {
        public static Type ProvideActionType(int genericArgumentsCount)
        {
            switch (genericArgumentsCount)
            {
                case 00: return typeof(Action);
                case 01: return typeof(Action<>);
                case 02: return typeof(Action<,>);
                case 03: return typeof(Action<,,>);
                case 04: return typeof(Action<,,,>);
                case 05: return typeof(Action<,,,,>);
                case 06: return typeof(Action<,,,,,>);
                case 07: return typeof(Action<,,,,,,>);
                case 08: return typeof(Action<,,,,,,,>);
                case 09: return typeof(Action<,,,,,,,,>);
                case 10: return typeof(Action<,,,,,,,,,>);
                case 11: return typeof(Action<,,,,,,,,,,>);
                case 12: return typeof(Action<,,,,,,,,,,,>);
                case 13: return typeof(Action<,,,,,,,,,,,,>);
                case 14: return typeof(Action<,,,,,,,,,,,,,>);
                case 15: return typeof(Action<,,,,,,,,,,,,,,>);
                case 16: return typeof(Action<,,,,,,,,,,,,,,,>);

                default:
                    throw new NotSupportedException("Не поддерживаем значение параметра 'genericArgumentsCount' вне диапазона 00..16.");
            }
        }

        public static Type MakeActionType(params Type[] inTypeArguments)
        {
            var typeGenericArguments = inTypeArguments ?? new Type[] {};

            var actionType = ProvideActionType(typeGenericArguments.Length);

            return actionType.IsGenericType == false? actionType : actionType.MakeGenericType(typeGenericArguments);
        }
    }
}