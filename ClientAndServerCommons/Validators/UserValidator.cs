using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using Commons.Validation.Assertions;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Validators
{
    public class UserValidator : ADOPersistenseValidator<User>
    {
        public UserValidator(IADORepository adoRepository) : base(adoRepository)
        {

        }

        public override void OnSave()
        {
            base.OnSave();

            //TODO: возможно это стоит переделать.

            //AssertionHelper
            //    .AssertIsNotEmpty(Validatable.Login)
            //    .Return("PrinterJob.PrinterName", "Имя принтера должно быть задано.");



        }
    }
}
