using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Commons.Reflections;

namespace Commons.ParameterStrings
{
    public class ParameterStringBuilder<T>
    {
        public Dictionary<string, string> MemberMap { get; private set; }


        public ParameterStringBuilder()
        {
            MemberMap = new Dictionary<string, string>();
        }


        public ParameterStringBuilder<T> AddMemberMapping(Expression<Func<T, object>> memberExpression, string memberKey)
        {
            Expression expression = memberExpression;

            if (expression.NodeType == ExpressionType.Lambda)
            {
                expression = ((LambdaExpression)expression).Body;
            }

            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                var memberName = ((MemberExpression)expression).Member.Name;

                if (MemberMap.ContainsKey(memberName))
                {
                    MemberMap[memberName] = memberKey;
                }

                MemberMap.Add(memberName, memberKey);
            }
            else
            {
                throw new Exception("Переданное выражение не является 'MemberAccess'");
            }

            return this;
        }


        public string Build(T sourceObject)
        {
            var result = string.Empty;

            var members = typeof(T).GetMembers().OrderBy(x => x.Name);

            foreach (var member in members)
            {
                if (MemberMap.ContainsKey(member.Name))
                {
                    var memberKey = MemberMap[member.Name];
                    var memberValue = sourceObject.GetValue(member.Name);

                    if (memberValue != null)
                    {
                        result += memberKey + "=" + memberValue + ";";
                    }
                }
            }

            return result;
        }
    }
}