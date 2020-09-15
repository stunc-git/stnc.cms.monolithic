﻿using Stnc.CMS.Entities.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Stnc.CMS.Entities.Concrete
{
    public  class City : ITablo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityInformationId { get; set; }

        public CityInformation CityInformation { get; set; }
    }
}