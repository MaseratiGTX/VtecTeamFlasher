using System;
using System.Reflection;
using Commons.Exceptions;

namespace Commons.Reflections
{
    public static class SimpleReflectionExtensions
    {
        public static MemberInfo GetMemberByExactName(this Type sourceType, string memberName)
        {
            var memberSearchingResult = sourceType.GetMember(memberName);

            if (memberSearchingResult.Length == 0)
            {
                throw new FormattedException("Не можем найти член класса '{0}' с именем '{1}'", sourceType.FullName, memberName);
            }

            return memberSearchingResult[0];
        }


        public static T SetValue<T>(this T sourceObject, string memberName, object memberValue) where T : class, new()
        {
            var member = sourceObject.GetType().GetMemberByExactName(memberName);

            if (member.MemberType == MemberTypes.Property)
            {
                ((PropertyInfo)member).SetValue(sourceObject, memberValue, null);

                return sourceObject;
            }

            if (member.MemberType == MemberTypes.Field)
            {
                ((FieldInfo)member).SetValue(sourceObject, memberValue);

                return sourceObject;
            }

            throw new FormattedException("Член класса '{0}' с именем '{1}' не является свойством или полем", typeof(T).FullName, memberName);
        }


        public static object GetValue<T>(this T sourceObject, string memberName)
        {
            var member = sourceObject.GetType().GetMemberByExactName(memberName);

            if (member.MemberType == MemberTypes.Property)
            {
                return ((PropertyInfo)member).GetValue(sourceObject, null);
            }

            if (member.MemberType == MemberTypes.Field)
            {
                return ((FieldInfo)member).GetValue(sourceObject);
            }

            throw new FormattedException("Член класса '{0}' с именем '{1}' не является свойством или полем", typeof(T).FullName, memberName);
        }
    }
}