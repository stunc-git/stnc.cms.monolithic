using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public  class City
    {
        public int Id { get; set; }

        public string Name { get; set; } = "adana";

        public int CityInformationId { get; set; } = 2;

        public CityInformation CityInformation { get; set; }
    }
}
