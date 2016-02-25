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
        public virtual byte[] StockBinary { get; set; }
        [DataMember]
        public virtual string EcuNumber { get; set; }
        [DataMember]
        public virtual string BinaryNumber { get; set; }
        [DataMember]
        public virtual byte[] EcuPhoto { get; set; }
        [DataMember]
        public virtual string EcuPhotoFilename { get; set; }
        [DataMember]
        public virtual string CarDescription { get; set; }
        [DataMember]
        public virtual int Status { get; set; }
        [DataMember]
        public virtual int UserId { get; set; }
        [DataMember]
        public virtual DateTime RequestDate { get; set; }
        [DataMember]
        public virtual DateTime? ExpectedResolveDate { get; set; }
        [DataMember]
        public virtual string RequestDetails { get; set; }
        [DataMember]
        public virtual string StockBinaryName { get; set; }
        
        //[DataMember]
        //public virtual User User { get; set; }
    }
}
