using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public class CityInformation
    {
        public int Id { get; set; }

        public int Population { get; set; }

        public string OtherName { get; set; }

        public string MayorName { get; set; }

        public List<City> City { get; set; }
    }
}
