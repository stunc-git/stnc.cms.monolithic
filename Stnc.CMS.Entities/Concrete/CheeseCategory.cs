using Stnc.CMS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public class CheeseCategory : ITablo
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public virtual ICollection<Cheese> Cheese { get; set; }

    }
}
