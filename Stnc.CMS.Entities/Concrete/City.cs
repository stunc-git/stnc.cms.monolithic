using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public  class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityInformationId { get; set; }

        public virtual CityInformation CityInfo { get; set; }
    }
}
