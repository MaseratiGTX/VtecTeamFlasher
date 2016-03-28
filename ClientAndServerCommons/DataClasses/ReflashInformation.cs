using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClientAndServerCommons.DataClasses
{
    [Serializable]
    [DataContract]
    public class ReflashInformation
    {
        [DataMember]
        public virtual int ReflashStorageId { get; set; }
        [DataMember]
        public virtual string Model { get; set; }
        [DataMember]
        public virtual string TransmissionType { get; set; }
        [DataMember]
        public virtual string EcuBinaryNumber { get; set; }
        [DataMember]
        public virtual string AltEcuCode { get; set; }
        [DataMember]
        public virtual string ReflashFileName { get; set; }
        [DataMember]
        public virtual string Description { get; set; }

    }
}
