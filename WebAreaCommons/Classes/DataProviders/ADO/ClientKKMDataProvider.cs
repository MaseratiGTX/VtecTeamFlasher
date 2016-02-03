namespace WebAreaCommons.Classes.DataProviders.ADO
{
    //public class ClientKKMDataProvider : EntityContextADODataProvider<KKM>
    //{
    //    //public ClientKKMDataProvider(IADORepository adoRepository, EntityContext entityContext, AbstractAreaUser currentUserContext) 
    //    //    : base(adoRepository, entityContext, currentUserContext)
    //    //{
    //    //}


    //    //protected override void ContextInitialization(params object[] parameters)
    //    //{
    //    //    var entityContext = (EntityContext) parameters[0];
    //    //    var clientAreaUser = parameters[1] as ClientAreaUser;

    //    //    JoinProcessor
    //    //        .RegisterPermanentJOINContext("[BASEALIAS].CashDesk", "LEFT JOIN FETCH [BASEALIAS].CashDesk", "cd")
    //    //        .RegisterPermanentJOINContext("[BASEALIAS].CurrentRegistrationCard", "LEFT JOIN FETCH [BASEALIAS].CurrentRegistrationCard", "crc")
    //    //        .RegisterPermanentJOINContext("crc.SuperviseTaxation", "LEFT JOIN FETCH crc.SuperviseTaxation", "st")
    //    //        .RegisterPermanentJOINContext("[BASEALIAS].EntityContext", "LEFT JOIN FETCH [BASEALIAS].EntityContext", "ec");


    //    //    if (clientAreaUser != null && clientAreaUser.Department != null)
    //    //    {
    //    //        FilterCriteriaProcessor_ApplyUserContext(clientAreaUser);
    //    //    }
    //    //    else
    //    //    {
    //    //        FilterCriteriaProcessor_ApplyEntityContext(entityContext);
    //    //    }
    //    //}


    //    //private void FilterCriteriaProcessor_ApplyUserContext(ClientAreaUser user)
    //    //{
    //    //    var fullNodePath = user.Department.GetFullNodePath();

    //    //    FilterCriteriaProcessor.RegisterPermanentCriteria(
    //    //            new BinaryOperator(
    //    //                new FirstNbytesOperandOperator("CashDesk.NodePath", fullNodePath.Length),
    //    //                new ConstantValue(fullNodePath), BinaryOperatorType.Equal
    //    //        )
    //    //    );
    //    //}
    //}
}