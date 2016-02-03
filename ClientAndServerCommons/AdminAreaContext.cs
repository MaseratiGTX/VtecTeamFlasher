using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientAndServerCommons
{
    public class AdminAreaContext : EntityContext
    {
        public AdminAreaContext()
        {
            Description = "Контекст сущностей РМАС";
        }
    }
}
