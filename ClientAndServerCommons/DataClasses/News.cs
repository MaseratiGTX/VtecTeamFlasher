using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClientAndServerCommons.DataClasses
{
    public class News : AbstractDataObject
    {
        [DataMember]
        public virtual DateTime Date { get; set; }
        [DataMember]
        public virtual string Caption { get; set; }
        [DataMember]
        public virtual string Text { get; set; }

    }
}
