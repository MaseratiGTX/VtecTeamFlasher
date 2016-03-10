using System;

namespace ClientAndServerCommons.DataClasses
{
    public class Token : AbstractDataObject
    {
        public virtual string TokenString { get; set; }
        public virtual DateTime CreateDate { get; set; }
        //public virtual int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
