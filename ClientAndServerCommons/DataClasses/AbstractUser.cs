using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using ClientAndServerCommons.Helpers;
using ClientAndServerCommons.Interfaces;

namespace ClientAndServerCommons.DataClasses
{
    public class AbstractUser : AbstractDataObject, IEnableable
    {
        [DataMember]
        public virtual string LastName { get; set; }
        [DataMember]
        public virtual string FirstName { get; set; }
        [DataMember]
        public virtual string MiddleName { get; set; }
        [DataMember]
        public virtual string Login { get; set; }
        [DataMember]
        public virtual string PasswordHash { get; set; }
        [DataMember]
        public virtual bool Enabled { get; set; }
        [DataMember]
        public virtual string UserType { get; set; }
        //[DataMember]
        //public virtual IList<ReflashHistory> ReflashHistory { get; set; }
        //[DataMember]
        //public virtual IList<ReflashRequest> Requests { get; set; }

    }
}