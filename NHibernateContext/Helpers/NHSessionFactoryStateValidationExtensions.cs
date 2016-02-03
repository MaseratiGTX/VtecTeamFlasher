using System;
using NHibernate;

namespace NHibernateContext.Helpers
{
    public static class NHSessionFactoryStateValidationExtensions
    {
        public static ISessionFactory EnsureHasClassMetadata(this ISessionFactory source)
        {
            if (source.GetAllClassMetadata().Count == 0)
            {
                throw new Exception("В NHSessionFactory отсутствуют какие-либо ClassMetadata: вероятно MappingAssembly указана некорректно.");
            }

            return source;
        }
    }
}