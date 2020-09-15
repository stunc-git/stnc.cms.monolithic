using Stnc.CMS.Entities.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Stnc.CMS.Entities.Concrete
{
    public  class Cheese : ITablo
    {
        public int DepartmanID { get; set; }

        public string Name { get; set; }
        public string Description  { get; set; }

        public int CatID { get; set; }

        public virtual CheeseCategory CheeseCategory { get; set; }
    }
}