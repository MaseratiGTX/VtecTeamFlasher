using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.Objects;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.InterpritationResults;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors
{
    public class NHibernateJoinProcessor
    {
        public const string ItemSeparator = " ";


        public string BaseAlias { get; private set; }

        public Dictionary<string, JoinContext> JOINContextRepository { get; private set; }



        public NHibernateJoinProcessor(string baseAlias)
        {
            BaseAlias = baseAlias;

            JOINContextRepository = new Dictionary<string, JoinContext>();
        }



        public NHibernateJoinProcessor RegisterPermanentJOINContext(string section, string mapping, string alias)
        {
            RegisterJOINContext(section, mapping, alias, true);

            return this;
        }

        public NHibernateJoinProcessor RegisterPossibleJOINContext(string section, string mapping, string alias)
        {
            RegisterJOINContext(section, mapping, alias, false);

            return this;
        }


        public NHibernateJoinProcessor RegisterJOINContext(string section, string mapping, string alias, bool isPermanent)
        {
            RegisterJOINContext(
                new JoinContext
                {
                    Section = section,
                    Mapping = mapping,
                    Alias = alias,
                    IsPermanent = isPermanent
                }
            );

            return this;
        }

        public NHibernateJoinProcessor RegisterJOINContext(JoinContext joinContext)
        {
            if (JOINContextRepository.ContainsKey(joinContext.Section) == false)
            {
                JOINContextRepository.Add(joinContext.Section, joinContext);
            }
            else
            {
                JOINContextRepository[joinContext.Section] = joinContext;
            }

            return this;
        }



        public T Process<T>(T source) where T : BaseInterpritationResult
        {
            source.UsedJOINS = new List<JoinContext>();


            if (source.ResultString.IsEmpty())
            {
                return source;
            }


            foreach (var joinContext in JOINContextRepository.Values)
            {
                if (source.ResultString.Contains(joinContext.Section))
                {
                    source.UsedJOINS.Add(joinContext);

                    source.ResultString = source.ResultString.Replace(joinContext.Section + " ", joinContext.Alias + " ").Replace(joinContext.Section + ".", joinContext.Alias + ".");
                }
            }

            return source;
        }



        public string PrepareJoinSection(params IEnumerable<JoinContext>[] usedJOINs)
        {
            var emptySource = new[] { new List<JoinContext>() };

            var aggregatedJOINs = (usedJOINs ?? emptySource).Aggregate((x, y) => x.Concat(y));

            return PrepareJoinSection(aggregatedJOINs, true, true);
        }

        public string PrepareSimpleJoinSection(params IEnumerable<JoinContext>[] usedJOINs)
        {
            var emptySource = new[] { new List<JoinContext>() };

            var aggregatedJOINs = (usedJOINs ?? emptySource).Aggregate((x, y) => x.Concat(y));

            return PrepareJoinSection(aggregatedJOINs, false, false);
        }


        public string PrepareJoinSection(IEnumerable<JoinContext> usedJOINs, bool usePermanentJOINs, bool useFETCHing)
        {
            var permanentJoinsPart = new List<JoinContext>();

            if (usePermanentJOINs)
            {
                permanentJoinsPart = JOINContextRepository.Values.Where(x => x.IsPermanent).ToList();
            }

            var usedJoinsPart = new List<JoinContext>();

            if (usedJOINs != null)
            {
                usedJoinsPart.AddRange(usedJOINs);
            }


            var joinContexts = permanentJoinsPart.Concat(usedJoinsPart).DistinctBy(x => x.Section);


            return joinContexts.ToString(x =>
            {
                var result = x.Mapping;

                if (result.EndsWith(" " + x.Alias) == false)
                {
                    result = result + " " + x.Alias;
                }

                if (useFETCHing == false)
                {
                    result = result.Replace(" FETCH", "");
                }

                return result;
            },

                ItemSeparator
            );
        }
    }
}