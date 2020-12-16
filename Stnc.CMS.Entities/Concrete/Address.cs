using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
       public int PersonId { get; set; }
       public virtual Person Person { get; set; }
    }
}
