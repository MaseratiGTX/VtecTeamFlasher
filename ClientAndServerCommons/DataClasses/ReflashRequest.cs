using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClientAndServerCommons.DataClasses
{
    public class ReflashRequest:AbstractDataObject
    {
        [DataMember]
        public virtual byte[] StockFile { get; set; }
        [DataMember]
        public virtual string EcuCode { get; set; }
        [DataMember]
        public virtual int RequestStatus { get; set; }
        [DataMember]
        public virtual int UserId { get; set; }
        [DataMember]
        public virtual DateTime RequestDateTime { get; set; }
    }
}
