using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Validators
{
    public class CommentValidator: ADOPersistenseValidator<Comment>
    {
        public CommentValidator(IADORepository adoRepository): base(adoRepository)
        {

        }

        public override void OnSave()
        {
            base.OnSave();

        }
    }
    
}
