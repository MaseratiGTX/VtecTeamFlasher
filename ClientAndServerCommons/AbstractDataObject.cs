using System;
using System.Runtime.Serialization;

namespace ClientAndServerCommons
{
    [Serializable]
    [DataContract]
    public class AbstractDataObject
    {
        [DataMember]
        public virtual int Id { get; set; }
    }
}
