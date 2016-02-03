using NHibernateContext.ADORepository;

namespace WebAreaCommons.Classes.DataProviders.ADO
{
    //public class ClientEntityDataProvider : ADODataProvider<ClientEntity>
    //{
    //    public ClientEntityDataProvider(IADORepository adoRepository, params object[] parameters) 
    //        : base(adoRepository, parameters)
    //    {
    //    }


    //    protected override void ContextInitialization(params object[] parameters)
    //    {
    //        ENABLE_INSENSITIVE_COLLATION_FIX();

    //        JoinProcessor
    //            .RegisterPermanentJOINContext("[BASEALIAS].Contract", "LEFT JOIN FETCH [BASEALIAS].Contract", "cc")
    //            .RegisterPermanentJOINContext("cc.ContractTemplate", "LEFT JOIN FETCH cc.ContractTemplate", "cct")
    //            .RegisterPermanentJOINContext("[BASEALIAS].Node", "LEFT JOIN FETCH [BASEALIAS].Node", "ne");

    //        SortInfoProcessor
    //            .AddMapping("Node.Id", "[BASEALIAS].Node.Name [ORDER]")
    //            .AddMapping("Contract.ContractTemplate.Id", "[BASEALIAS].Contract.ContractTemplate.Name [ORDER]");

    //        GroupPropertiesProcessor
    //            .AddMapping("Contract.ConclusionDateTime", "CAST([BASEALIAS].Contract.ConclusionDateTime AS Date)")
    //            .AddMapping("Contract.ExpirationDateTime", "CAST([BASEALIAS].Contract.ExpirationDateTime AS Date)");
    //    }
    //}
}