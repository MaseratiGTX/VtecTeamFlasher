using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClientAndServerCommons.DataClasses
{
    public class ReflashStorage : AbstractDataObject
    {
        [DataMember]
        public virtual int CarManufacturerId { get; set; }
        [DataMember]
        public virtual string Model { get; set; }
        [DataMember]
        public virtual DateTime YearOfRelease { get; set; }
        [DataMember]
        public virtual string TransmissionType { get; set; }
        [DataMember]
        public virtual string EcuBinaryNumber { get; set; }
        [DataMember]
        public virtual string AltEcuCode { get; set; } 
        [DataMember]
        public virtual string ReflashFileName { get; set; } 
        [DataMember]
        public virtual byte[] ReflashBinary { get; set; } 
        [DataMember]
        public virtual string Description { get; set; } 
        [DataMember]
        public virtual DateTime DateOfLoad { get; set; } 
        [DataMember]
        public virtual int UserId { get; set; }
    }
}

