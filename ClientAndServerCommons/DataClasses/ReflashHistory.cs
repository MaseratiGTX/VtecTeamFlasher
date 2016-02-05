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
        public virtual string Cvn { get; set; }
        [DataMember]
        public virtual string ReslashFileName { get; set; }
        [DataMember]
        public virtual string Vin { get; set; }
        [DataMember]
        public virtual int UserId { get; set; }
        [DataMember]
        public virtual DateTime ReflashDateTime { get; set; }
        [DataMember]
        public virtual int ReflashStatus { get; set; }
        [DataMember]
        public virtual int PaymentStatus { get; set; }
        [DataMember]
        public virtual IList<Review> Review { get; set; }
    }
}
