using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClientAndServerCommons.DataClasses
{
    public class Review:AbstractDataObject
    {
        [DataMember]
        public virtual string UserName { get; set; }
        [DataMember]
        public virtual string SourceUrl { get; set; }
        [DataMember]
        public virtual string UserReview { get; set; }
        [DataMember]
        public virtual DateTime ReviewDateTime { get; set; }
    }
}
