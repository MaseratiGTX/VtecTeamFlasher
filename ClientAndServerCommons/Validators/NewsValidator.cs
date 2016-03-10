﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientAndServerCommons.DataClasses;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Validators
{
    public class NewsValidator: ADOPersistenseValidator<News>
    {
        public NewsValidator(IADORepository adoRepository)
            : base(adoRepository)
        {

        }

        public override void OnSave()
        {
            base.OnSave();

        }
    }
}