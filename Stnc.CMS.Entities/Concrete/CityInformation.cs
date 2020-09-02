using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public class CityInformation
    {
        public int Id { get; set; }

        public int Population { get; set; } = 34324324;

        public string OtherName { get; set; } = "Frodo3";

        public string MayorName { get; set; } = "Frodo4";

        public City City { get; set; }
    }
}
