using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Comparasion;
using Commons.Helpers.Objects;
using Commons.Logging;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using NHibernateContext.ADORepository;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.Base;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.GroupDataItems;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.DataQueryProviders;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.InterpritationResults;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.QueryInfo;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Templates;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Factories;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;
using Commons.Helpers.Collections;
using Commons.Helpers.Collections.Generic;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate
{
    public abstract class NHibernateDataProviderBase<TSource, TResult> : BaseDataProvider<TResult>
        where TSource : class
        where TResult : class
    {
        protected virtual string BaseAlias
        {
            get { return "x"; }
        }

        protected string SELECTQuery { get; set; }
        protected GROUPQueryInfo GROUPQueryInfo { get; set; }
        protected TOTALQueryInfo TOTALQueryInfo { get; set; }
        protected Dictionary<string, object> QueryPARAMETERS { get; set; }

        protected NHibernateDataQueryProvider DataQueryProvider { get; set; }

        protected NHibernateJoinProcessor JoinProcessor { get; set; }
        protected NHibernateFilterCriteriaProcessor FilterCriteriaProcessor { get; set; }
        protected NHibernateSortInfoProcessor SortInfoProcessor { get; set; }
        protected NHibernateSortInfoProcessor GroupSortInfoProcessor { get; set; }
        protected NHibernatePropertiesCollectionProcessor GroupPropertiesProcessor { get; set; }
        protected NHibernateSummaryProcessor<TSource> GroupSummaryProcessor { get; set; }
        protected NHibernateSummaryProcessor<TSource> TotalSummaryProcessor { get; set; }



        protected NHibernateDataProviderBase(IADORepository ADORepository, params object[] parameters)
        {
            LOG_MUTE();

            DISABLE_INSENSITIVE_COLLATION_FIX();

            DataQueryProvider = new NHibernateDataQueryProvider(ADORepository.NHSession);

            JoinProcessor = new NHibernateJoinProcessor(Placeholders.BASEALIAS);
            FilterCriteriaProcessor = new NHibernateFilterCriteriaProcessor(Placeholders.BASEALIAS);
            SortInfoProcessor = new NHibernateSortInfoProcessor(Placeholders.BASEALIAS);
            GroupPropertiesProcessor = new NHibernatePropertiesCollectionProcessor(Placeholders.BASEALIAS);

            GroupSummaryProcessor = new NHibernateSummaryProcessor<TSource>(Placeholders.BASEALIAS);
            TotalSummaryProcessor = new NHibernateSummaryProcessor<TSource>(Placeholders.BASEALIAS);

            ExecuteContextInitialization(parameters);

            GroupSortInfoProcessor = new NHibernateSortInfoProcessor(Placeholders.BASEALIAS);
            GroupSortInfoProcessor.AddMappings(SortInfoProcessor.SpecialMappings);
            GroupSortInfoProcessor.AddMappings(GroupPropertiesProcessor.SpecialMappings);


            // ReSharper disable DoNotCallOverridableMethodsInConstructor

            PrepareForFetchingProcess();

            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }


        #region CONTEXT INITIALIZATION

        private void ExecuteContextInitialization(params object[] parameters)
        {
            ContextInitialization(parameters);
        }

        protected virtual void ContextInitialization(params object[] parameters)
        {
        }

        #endregion


        #region LOGGING

        private bool SHOULD_LOG;

        protected bool LOG_IS_MUTED
        {
            get { return SHOULD_LOG == false; }
        }

        protected void LOG_MUTE()
        {
            SHOULD_LOG = false;
        }

        protected void LOG_UNMUTE()
        {
            SHOULD_LOG = true;
        }

        private string LOG(string value)
        {
            if (SHOULD_LOG)
            {
                Log.Info(value);
            }

            return value;
        }

        #endregion

        #region INSENSITIVE_COLLATION_FIX

        private bool SHOULD_FIX_INSENSITIVE_COLLATION;

        protected bool INSENSITIVE_COLLATION_FIX_ENABLED
        {
            get { return SHOULD_FIX_INSENSITIVE_COLLATION; }
        }

        protected void ENABLE_INSENSITIVE_COLLATION_FIX()
        {
            SHOULD_FIX_INSENSITIVE_COLLATION = true;
        }

        protected void DISABLE_INSENSITIVE_COLLATION_FIX()
        {
            SHOULD_FIX_INSENSITIVE_COLLATION = false;
        }

        private object[][] FIX_INSENSITIVE_COLLATION(object[][] source)
        {
            // FIX из-за особенностей сравнения строк в MSSQLServer:
            //
            // Если это не оговорено заранее при создании таблиц/колонок, 
            // то строки по умолчанию сравниваются игнорируя их lower/upper CasE.
            // Таким образом колличество групп (строк) на первом уровне может менятся в зависимости от количества уровней группировки.
            //
            // Иными словами, если datasource сначала группируется чисто по строковому полю то количество групп будет 13, 
            // а после добавления еще одого уровня группировки - 18

            if (SHOULD_FIX_INSENSITIVE_COLLATION)
            {
                return source.For<string>(x => x.ToLower());
            }

            return source;
        }

        #endregion

        #region SETTERS FOR QUERY CACHE

        private void SetSELECTQuery(string value)
        {
            if (SELECTQuery.AreNotEqual(value))
            {
                SELECTQuery = value;

                OnItemsChanged();
            }
        }


        private void SetGROUPQueryInfo(string groupQuery, string groupOrderQuery, List<OperandProperty> propertyExpressions, List<ServerModeSummaryDescriptor> summaryDescriptors)
        {
            SetGROUPQueryInfo(
                new GROUPQueryInfo
                {
                    GROUPQuery = groupQuery,
                    GROUPORDERQuery = groupOrderQuery,
                    PropertyExpressions = propertyExpressions,
                    SummaryDescriptors = summaryDescriptors
                }
            );
        }

        private void SetGROUPQueryInfo(GROUPQueryInfo value)
        {
            if (GROUPQueryInfo.AreNotEqual(value))
            {
                GROUPQueryInfo = value;

                OnGroupInfoChanged();
            }
        }


        private void SetTOTALQueryInfo(string totalQuery, List<ServerModeSummaryDescriptor> summaryDescriptors)
        {
            SetTOTALQueryInfo(
                new TOTALQueryInfo
                {
                    TOTALQuery = totalQuery,
                    SummaryDescriptors = summaryDescriptors
                }
            );
        }

        private void SetTOTALQueryInfo(TOTALQueryInfo value)
        {
            if (TOTALQueryInfo.AreNotEqual(value))
            {
                TOTALQueryInfo = value;

                OnTotalSummaryChanged();
            }
        }


        private void SetQueryPARAMETERS(Dictionary<string, object> value)
        {
            if (QueryPARAMETERS.AreNotEqual(value))
            {
                QueryPARAMETERS = value;

                OnItemsChanged();
                OnGroupInfoChanged();
                OnTotalSummaryChanged();
            }
        }

        #endregion


        #region FETCHING

        protected override void PrepareForFetchingProcess()
        {
            var filterCriteriaProcessingResult = JoinProcessor.Process(FilterCriteriaProcessor.Process(FilterCriteria));
            var baseSortInfoProcessingResult = JoinProcessor.Process(SortInfoProcessor.Process(SortInfo));

            var selectQueryJOINSection = JoinProcessor.PrepareJoinSection(filterCriteriaProcessingResult.UsedJOINS, baseSortInfoProcessingResult.UsedJOINS);
            var queryWHERESection = filterCriteriaProcessingResult.ResultString.IsNotEmpty() ? "WHERE " + filterCriteriaProcessingResult.ResultString : string.Empty;
            var queryORDERBYSection = baseSortInfoProcessingResult.ResultString.IsNotEmpty() ? "ORDER BY " + baseSortInfoProcessingResult.ResultString : string.Empty;
            var queryPARAMETERS = filterCriteriaProcessingResult.Parameters;

            SetSELECTQuery(
                FillTemplatePlaceholders(
                    ("SELECT [BASEALIAS] FROM [SOURCETYPE] [BASEALIAS] " +
                    "[QUERY JOIN SECTION]" +
                    "[QUERY WHERE SECTION]" +
                    "[QUERY ORDERBY SECTION]")
                    .Replace("[QUERY JOIN SECTION]", selectQueryJOINSection.Add(" "))
                    .Replace("[QUERY WHERE SECTION]", queryWHERESection.Add(" "))
                    .Replace("[QUERY ORDERBY SECTION]", queryORDERBYSection.Add(" "))
                )
            );


            if (GroupCount > 0)
            {
                var groupSortInfo = SortInfo.Take(GroupCount).ToList();

                var groupSortInfoProcessingResult = JoinProcessor.Process(GroupSortInfoProcessor.Process(groupSortInfo));

                var groupExpressions = groupSortInfo.Select(x => x.SortExpression).ToList();
                var groupPropertiesProcessingResult = JoinProcessor.Process(GroupPropertiesProcessor.Process(groupExpressions));
                var groupSummaryProcessingResult = JoinProcessor.Process(GroupSummaryProcessor.Process(GroupSummaryInfo));


                if (SortInfoProcessor.HasSpecialMappingsFor(groupSortInfo))
                {
                    PrepareGroupFetchingProcessComplicated(
                        filterCriteriaProcessingResult,
                        groupSortInfoProcessingResult,
                        groupPropertiesProcessingResult,
                        groupSummaryProcessingResult
                    );
                }
                else
                {
                    PrepareGroupFetchingProcessSimple(
                        filterCriteriaProcessingResult,
                        groupSortInfoProcessingResult,
                        groupPropertiesProcessingResult,
                        groupSummaryProcessingResult
                    );
                }
            }
            else
            {
                SetGROUPQueryInfo(null);
            }


            var totalSummaryProcessingResult = JoinProcessor.Process(TotalSummaryProcessor.Process(TotalSummaryInfo));
            var totalQueryJOINSection = JoinProcessor.PrepareSimpleJoinSection(
                filterCriteriaProcessingResult.UsedJOINS,
                totalSummaryProcessingResult.UsedJOINS
            );

            SetTOTALQueryInfo(
                FillTemplatePlaceholders(
                    ("SELECT [SUMMARIES] FROM [SOURCETYPE] [BASEALIAS] " +
                    "[QUERY JOIN SECTION]" +
                    "[QUERY WHERE SECTION]")
                    .Replace("[QUERY JOIN SECTION]", totalQueryJOINSection.Add(" "))
                    .Replace("[QUERY WHERE SECTION]", queryWHERESection.Add(" "))
                    .Replace("[SUMMARIES]", totalSummaryProcessingResult.ResultString)
                ),
                totalSummaryProcessingResult.SummaryDescriptors
            );


            SetQueryPARAMETERS(queryPARAMETERS);
        }


        private void PrepareGroupFetchingProcessSimple(FilterInterpritationResult filterCriteriaProcessingResult,
                                                        SortInfoInterpritationResult groupSortInfoProcessingResult,
                                                        PropertiesCollectionProcessingResult groupPropertiesProcessingResult,
                                                        SummaryInterpritationResult groupSummaryProcessingResult)
        {
            var groupQueryJOINSection = JoinProcessor.PrepareSimpleJoinSection(
                filterCriteriaProcessingResult.UsedJOINS,
                groupSortInfoProcessingResult.UsedJOINS,
                groupPropertiesProcessingResult.UsedJOINS,
                groupSummaryProcessingResult.UsedJOINS
            );
            var queryWHERESection = filterCriteriaProcessingResult.ResultString.IsNotEmpty() ? "WHERE " + filterCriteriaProcessingResult.ResultString : string.Empty;
            var groupQueryORDERBYSection = groupSortInfoProcessingResult.ResultString.IsNotEmpty() ? "ORDER BY " + groupSortInfoProcessingResult.ResultString : string.Empty;


            SetGROUPQueryInfo(
                FillTemplatePlaceholders(
                    ("SELECT [PROPERTIES], [SUMMARIES] FROM [SOURCETYPE] [BASEALIAS] " +
                     "[QUERY JOIN SECTION]" +
                     "[QUERY WHERE SECTION]" +
                     "GROUP BY [PROPERTIES] " +
                     "[QUERY ORDERBY SECTION]")
                    .Replace("[QUERY JOIN SECTION]", groupQueryJOINSection.Add(" "))
                    .Replace("[QUERY WHERE SECTION]", queryWHERESection.Add(" "))
                    .Replace("[QUERY ORDERBY SECTION]", groupQueryORDERBYSection.Add(" "))
                    .Replace("[PROPERTIES]", groupPropertiesProcessingResult.ResultString)
                    .Replace("[SUMMARIES]", groupSummaryProcessingResult.ResultString)
                ),
                string.Empty,
                groupPropertiesProcessingResult.PropertyExpressions,
                groupSummaryProcessingResult.SummaryDescriptors
            );
        }

        private void PrepareGroupFetchingProcessComplicated(FilterInterpritationResult filterCriteriaProcessingResult,
                                                             SortInfoInterpritationResult groupSortInfoProcessingResult,
                                                             PropertiesCollectionProcessingResult groupPropertiesProcessingResult,
                                                             SummaryInterpritationResult groupSummaryProcessingResult)
        {
            var groupQueryJOINSection = JoinProcessor.PrepareSimpleJoinSection(
                filterCriteriaProcessingResult.UsedJOINS,
                groupPropertiesProcessingResult.UsedJOINS,
                groupSummaryProcessingResult.UsedJOINS
            );
            var queryWHERESection = filterCriteriaProcessingResult.ResultString.IsNotEmpty() ? "WHERE " + filterCriteriaProcessingResult.ResultString : string.Empty;

            var groupOrderQueryJOINSection = JoinProcessor.PrepareSimpleJoinSection(filterCriteriaProcessingResult.UsedJOINS, groupSortInfoProcessingResult.UsedJOINS);
            var groupOrderQueryORDERBYSection = groupSortInfoProcessingResult.ResultString.IsNotEmpty() ? "ORDER BY " + groupSortInfoProcessingResult.ResultString : string.Empty;


            SetGROUPQueryInfo(
                FillTemplatePlaceholders(
                    ("SELECT [PROPERTIES], [SUMMARIES] FROM [SOURCETYPE] [BASEALIAS] " +
                     "[QUERY JOIN SECTION]" +
                     "[QUERY WHERE SECTION]" +
                     "GROUP BY [PROPERTIES]")
                    .Replace("[QUERY JOIN SECTION]", groupQueryJOINSection.Add(" "))
                    .Replace("[QUERY WHERE SECTION]", queryWHERESection.Add(" "))
                    .Replace("[PROPERTIES]", groupPropertiesProcessingResult.ResultString)
                    .Replace("[SUMMARIES]", groupSummaryProcessingResult.ResultString)
                ),
                FillTemplatePlaceholders(
                    ("SELECT [PROPERTIES] FROM [SOURCETYPE] [BASEALIAS] " +
                     "[QUERY JOIN SECTION]" +
                     "[QUERY WHERE SECTION]" +
                     "[QUERY ORDERBY SECTION]"
                    )
                    .Replace("[QUERY JOIN SECTION]", groupOrderQueryJOINSection.Add(" "))
                    .Replace("[QUERY WHERE SECTION]", queryWHERESection.Add(" "))
                    .Replace("[QUERY ORDERBY SECTION]", groupOrderQueryORDERBYSection.Add(" "))
                    .Replace("[PROPERTIES]", groupPropertiesProcessingResult.ResultString)
                ),
                groupPropertiesProcessingResult.PropertyExpressions,
                groupSummaryProcessingResult.SummaryDescriptors
            );
        }


        protected string FillTemplatePlaceholders(string source, string groupPropertiesPlaceholderValue = null)
        {
            return source
                .Replace(Placeholders.BASEALIAS, BaseAlias)
                .Replace(Placeholders.SOURCETYPE, typeof(TSource).Name)
                .Replace(Placeholders.RESULTTYPE, typeof(TResult).Name)
                .Trim();
        }



        public override TResult[] Items(int firstResult, int maxResults)
        {
            return ExecuteFetchingPostProcess(
                DataQueryProvider
                    .CreateQuery(LOG(SELECTQuery))
                    .SetFirstResult(firstResult)
                    .SetMaxResults(maxResults)
                    .SetParameters(QueryPARAMETERS)
                    .List<TSource>()
            ).ToArray();
        }

        public override List<GroupDataItem> GroupInfoDataItems()
        {
            var groupQueryResult = DataQueryProvider
                .CreateQuery(LOG(GROUPQueryInfo.GROUPQuery))
                .SetParameters(QueryPARAMETERS)
                .List();

            var groupQueryDataSource = FIX_INSENSITIVE_COLLATION(groupQueryResult.Cast<object[]>().ToArray());


            var groupDataItemFactory = new GroupDataItemFactory(GROUPQueryInfo.PropertyExpressions, GROUPQueryInfo.SummaryDescriptors);

            var result = groupQueryDataSource.Select(groupDataItemFactory.Produce).ToList();


            if (GROUPQueryInfo.GROUPORDERQuery.IsNotEmpty())
            {
                var groupOrderQueryResult = DataQueryProvider
                    .CreateQuery(LOG(GROUPQueryInfo.GROUPORDERQuery))
                    .SetParameters(QueryPARAMETERS)
                    .List()
                    .ToArray();

                var groupOrderQueryDataSource = FIX_INSENSITIVE_COLLATION(groupOrderQueryResult.Select(x => x as object[] ?? new[] { x }).ToArray());

                var keysActualOrder = groupOrderQueryDataSource.Select(x => x.CalculateKey()).ToList();

                result = result.OrderBy(keysActualOrder, x => x.Key).ToList();
            }


            return result;
        }

        public override SummaryRepository TotalSummaryRepository()
        {
            var queryResult = DataQueryProvider
                .CreateQuery(LOG(TOTALQueryInfo.TOTALQuery))
                .SetParameters(QueryPARAMETERS)
                .List()[0];


            var dataSource = queryResult as object[] ?? new[] { queryResult };


            var summaryRepositoryItemFactory = new SummaryRepositoryItemFactory(dataSource);

            return new SummaryRepository(
                TOTALQueryInfo.SummaryDescriptors.Select(summaryRepositoryItemFactory.Produce).ToList()
            );
        }

        #endregion

        #region FETCHING POSTPROCESS

        private IEnumerable<TResult> ExecuteFetchingPostProcess(IList<TSource> source)
        {
            return FetchingPostProcess(source);
        }

        protected abstract IEnumerable<TResult> FetchingPostProcess(IList<TSource> source);

        #endregion
    }
}