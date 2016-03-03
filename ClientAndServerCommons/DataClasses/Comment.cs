using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClientAndServerCommons.DataClasses
{
    public class Comment : AbstractDataObject
    {
        [DataMember]
        public virtual int RequestId { get; set; }
        [DataMember]
        public virtual DateTime CommentDate { get; set; }
        [DataMember]
        public virtual int UserId { get; set; }
        [DataMember]
        public virtual string CommentText { get; set; }
        [DataMember]
        public virtual User User { get; set; }

    }
}
