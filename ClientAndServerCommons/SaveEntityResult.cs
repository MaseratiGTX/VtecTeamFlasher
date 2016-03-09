using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClientAndServerCommons
{
    [DataContract]
    public class SaveEntityResult
    {
        [DataMember]
        public int EntityId { get; set; }
        [DataMember]
        public bool Result { get; set; }
    }
}
