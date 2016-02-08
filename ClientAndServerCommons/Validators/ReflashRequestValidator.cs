using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using Commons.Validation.Assertions;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Validators
{
    public class ReflashRequestValidator: ADOPersistenseValidator<ReflashRequest>
    {
        public ReflashRequestValidator(IADORepository adoRepository)
            : base(adoRepository)
        {

        }

        public override void OnSave()
        {
            base.OnSave();

            //TODO: возможно это стоит переделать.

            //AssertionHelper
            //    .AssertIsNotEmpty(Validatable.EcuCode)
            //    .Return("ReflashRequest.EcuCode", "Номер Компьютера должен быть указан");

        }
    }
}
