using System;
using NHibernate;
using NHibernate.Type;

namespace NHibernateContext.Interceptors
{
    public class CommonSessionLocalInterceptor : EmptyInterceptor
    {
        public override bool OnLoad(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            RestoreDatabaseDateTimeKind(state, types);

            return true;
        }


        private static void RestoreDatabaseDateTimeKind(object[] state, IType[] types)
        {
            Substitute<DateTime>(state, types,
                x => x.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(x, DateTimeKind.Local) : x
            );
        }


        private static void Substitute<T>(object[] state, IType[] types, Func<T, T> substitutionFunction)
        {
            for (var index = 0; index < state.Length; index++)
            {
                var currentState = state[index];
                var currentType = types[index];

                if (currentState != null && currentType.ReturnedClass == typeof(T))
                {
                    state[index] = substitutionFunction.Invoke((T)currentState);
                }
            }
        }
    }
}