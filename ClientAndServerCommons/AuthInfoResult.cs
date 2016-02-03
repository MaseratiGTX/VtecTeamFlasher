using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ClientAndServerCommons.DataClasses;

namespace ClientAndServerCommons
{
    [DataContract]
    public class AuthInfoResult
    {
        public AuthInfoResult()
        {
            Code = (int) AuthenticationCode.Failed;
            Message = string.Empty;
        }

        public AuthInfoResult(int code, string message)
        {
            Code = code;
            Message = message;
        }

        [DataMember]
        public User User { get; set; }
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}

