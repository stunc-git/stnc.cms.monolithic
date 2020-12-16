using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AddressId { get; set; } // notice nullabe foreign key!
        public virtual Address Address { get; set; }
    }
}
