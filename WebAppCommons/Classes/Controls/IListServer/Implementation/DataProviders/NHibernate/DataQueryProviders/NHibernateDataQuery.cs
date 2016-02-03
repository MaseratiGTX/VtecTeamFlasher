using System;
using System.Collections;
using System.Collections.Generic;
using Commons.Helpers.Objects;
using Commons.Logging;
using NHibernate;
using NHibernate.Type;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.DataQueryProviders
{
    public class NHibernateDataQuery
    {
        public ISession NHSession { get; private set; }

        public string QueryString { get; private set; }
        public Dictionary<string, object> Parameters { get; private set; }
        public int FirstResult { get; private set; }
        public int MaxResults { get; private set; }



        public NHibernateDataQuery(ISession nhSession)
        {
            NHSession = nhSession;

            Parameters = new Dictionary<string, object>();
            FirstResult = -1;
            MaxResults = -1;
        }



        public NHibernateDataQuery SetQueryString(string value)
        {
            QueryString = value;

            return this;
        }


        public NHibernateDataQuery SetParameters(Dictionary<string, object> value)
        {
            Parameters = value;

            return this;
        }

        public NHibernateDataQuery SetFirstResult(int value)
        {
            FirstResult = value;

            return this;
        }

        public NHibernateDataQuery SetMaxResults(int value)
        {
            MaxResults = value;

            return this;
        }


        public IList List()
        {
            try
            {
                return PrepareQuery(NHSession).List();
            }
            catch (Exception ex)
            {
                Log.Error(ex);

                throw;
            }
        }

        public IList<T> List<T>()
        {
            try
            {
                return PrepareQuery(NHSession).List<T>();
            }
            catch (Exception ex)
            {
                Log.Error(ex);

                throw;
            }
        }


        private IQuery PrepareQuery(ISession session)
        {
            var query = session.CreateQuery(QueryString);

            if (Parameters.IsNotEmpty())
            {
                foreach (var parameter in Parameters)
                {
                    var parameterName = parameter.Key;
                    var parameterValue = parameter.Value;

                    if (parameterValue is string)
                    {
                        var parameterLength = ((string)parameterValue).Length;
                        var parameterType = TypeFactory.GetStringType(parameterLength);

                        query.SetParameter(parameterName, parameterValue, parameterType);

                        continue;
                    }

                    if (parameterValue is ICollection && (parameterValue is byte[]) == false) //TODO: необходимо избавиться от условия (parameterValue is byte[]) == false
                    {
                        query.SetParameterList(parameterName, (ICollection)parameterValue);

                        continue;
                    }

                    query.SetParameter(parameterName, parameterValue);
                }
            }

            if (FirstResult != -1)
            {
                query.SetFirstResult(FirstResult);
            }

            if (MaxResults != -1)
            {
                query.SetMaxResults(MaxResults);
            }


            return query;
        }
    }
}