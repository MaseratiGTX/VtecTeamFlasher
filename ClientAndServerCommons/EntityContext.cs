using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientAndServerCommons
{
    public abstract class EntityContext : AbstractDataObject
    {
        public virtual string Description { get; set; }
    }
}
