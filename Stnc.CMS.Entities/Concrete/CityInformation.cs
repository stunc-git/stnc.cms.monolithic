using Stnc.CMS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public class CityInformation : ITablo
    {
        public int Id { get; set; }

        public int Population { get; set; }

        public string OtherName { get; set; }

        public string MayorName { get; set; }

        public IList<City> City { get; set; }

    }
}
