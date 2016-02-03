using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClientAndServerCommons
{
    [DataContract]
    public enum AuthenticationCode
    {
        [EnumMember]
        Success = 0,
        [EnumMember]
        Failed = 1,
    }
}
