using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Commons.Exceptions;
using Commons.Helpers.Objects;
using Commons.Reflections;

namespace Commons.ParameterStrings
{
    public class ParameterStringParser<T> where T : class, new()
    {
        private Dictionary<string, string> MemberMap { get; set; }
        public bool AcceptEmptyMemberValue { get; set; }


        public ParameterStringParser()
        {
            MemberMap = new Dictionary<string, string>();
            AcceptEmptyMemberValue = false;
        }


        public ParameterStringParser<T> AddMemberMapping(string memberKey, Expression<Func<T, object>> memberExpression)
        {
            Expression expression = memberExpression;

            if (expression.NodeType == ExpressionType.Lambda)
            {
                expression = ((LambdaExpression)expression).Body;
            }

            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                var memberName = ((MemberExpression)expression).Member.Name;

                if (MemberMap.ContainsKey(memberKey))
                {
                    MemberMap[memberKey] = memberName;
                }

                MemberMap.Add(memberKey, memberName);
            }
            else if (expression.NodeType == ExpressionType.Convert)
            {
                var operand = ((UnaryExpression)expression).Operand;


                if (operand.NodeType == ExpressionType.MemberAccess)
                {
                    var memberName = ((MemberExpression)operand).Member.Name;

                    if (MemberMap.ContainsKey(memberKey))
                    {
                        MemberMap[memberKey] = memberName;
                    }

                    MemberMap.Add(memberKey, memberName);
                }
            }
            else
            {
                throw new Exception("Переданное выражение не является 'MemberAccess'");
            }

            return this;
        }


        public T Parse(string sourceString)
        {
            return Parse(sourceString, null);
        }


        public T Parse(string sourceString, Dictionary<string, object> defaultMemberValues)
        {
            var keyValueDictionary = SplitOnKeyValuePairs(sourceString, AcceptEmptyMemberValue);

            var result = new T();

            foreach (var key in keyValueDictionary.Keys)
            {
                if (MemberMap.ContainsKey(key))
                {
                    var memberName = MemberMap[key];
                    var memberValue = keyValueDictionary[key];

                    result.SetValue(memberName, memberValue);
                }
                else
                {
                    throw new FormattedException("Указанный ключ '{0}' не имеет сопоставления с членом класса '{1}'", key, typeof(T).FullName);
                }
            }


            if (defaultMemberValues.IsNotNull())
            {
                foreach (var key in defaultMemberValues.Keys)
                {
                    if (keyValueDictionary.ContainsKey(key) == false)
                    {
                        var memberName = MemberMap[key];
                        var memberValue = defaultMemberValues[key];

                        result.SetValue(memberName, memberValue);
                    }
                }
            }


            return result;
        }


        private static Dictionary<string, string> SplitOnKeyValuePairs(string sourceString, bool acceptEmptyMemberValue)
        {
            var propertyKeyValueDictionary = new Dictionary<string, string>();

            var keyValueTemplates = sourceString.Split(';').Select(x => x.Trim()).Where(x => x.IsNotEmpty()).ToList();

            foreach (var keyValueTemplate in keyValueTemplates)
            {
                var keyValuePair = keyValueTemplate.Split('=').Select(x => x.Trim()).ToList();

                if (keyValuePair.Count == 2)
                {
                    var key = keyValuePair[0];

                    if (key.IsEmpty())
                    {
                        throw new Exception(
                            string.Format("Переданная строка содержит пустой ключ - '{0}'", keyValueTemplate)
                        );
                    }

                    var value = keyValuePair[1];

                    if (value.IsEmpty() && acceptEmptyMemberValue == false)
                    {
                        throw new Exception(
                            string.Format("Переданная строка содержит пустое значение для ключа - '{0}'", keyValueTemplate)
                        );
                    }


                    if (propertyKeyValueDictionary.ContainsKey(key))
                    {
                        propertyKeyValueDictionary[key] = value;
                    }
                    else
                    {
                        propertyKeyValueDictionary.Add(key, value);
                    }
                }
                else
                {
                    throw new Exception(
                        string.Format("Переданная строка содержит неверный формат - не можем определить ключ для одного из параметров - см. '{0}'", keyValueTemplate)
                    );
                }
            }

            return propertyKeyValueDictionary;
        }
    }
}