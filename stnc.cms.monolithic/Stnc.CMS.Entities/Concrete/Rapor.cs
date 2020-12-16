using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.Entities.Interfaces;

namespace Stnc.CMS.Entities.Concrete
{
    public class Rapor : ITablo
    {
        public int Id { get; set; }
        public string Tanim { get; set; }
        public string Detay { get; set; }

        public int GorevId { get; set; }
        public Gorev Gorev { get; set; }
    }
}
