using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClientAndServerCommons.DataClasses
{
    public class ReflashHistory:AbstractDataObject
    {
        [DataMember]
        public virtual int UserId { get; set; }
        [DataMember]
        public virtual string BinaryFileName { get; set; }
        [DataMember]
        public virtual string CarVin { get; set; }
        [DataMember]
        public virtual string PreviousBinaryName { get; set; }
        [DataMember]
        public virtual int Status { get; set; }
        [DataMember]
        public virtual DateTime ReflashDate { get; set; }
        [DataMember]
        public virtual string Price { get; set; }
        [DataMember]
        public virtual Review Review { get; set; }
        //[DataMember]
        //public virtual User User { get; set; }
    }
}
