using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Validators
{
    public class ReflashHistoryValidator: ADOPersistenseValidator<ReflashHistory>
    {
        public ReflashHistoryValidator(IADORepository adoRepository): base(adoRepository)
        {

        }

        public override void OnSave()
        {
            base.OnSave();

        }
    }
}
