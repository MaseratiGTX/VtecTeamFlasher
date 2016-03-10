using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using ClientAndServerCommons.Helpers;

namespace ClientAndServerCommons.DataClasses
{
    public class User:AbstractUser
    {
        [DataMember]
        public virtual string City { get; set; }
        [DataMember]
        public virtual string Phone { get; set; }
        [DataMember]
        public virtual string Skype { get; set; }
        [DataMember]
        public virtual string VK { get; set; }
        [DataMember]
        public virtual bool Viber { get; set; }
        [DataMember]
        public virtual bool WhatsApp { get; set; }
        [DataMember]
        public virtual string OpenModules { get; set; }
        [DataMember]
        public virtual string Token { get; set; }
         
    }
}
