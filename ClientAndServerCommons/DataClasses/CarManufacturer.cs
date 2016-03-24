using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ClientAndServerCommons.DataClasses
{
    public class CarManufacturer : AbstractDataObject
    {
        [DataMember]
        public virtual string Manufacturer { get; set; }
    }
}
