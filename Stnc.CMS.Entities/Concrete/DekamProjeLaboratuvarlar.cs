using Stnc.CMS.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace Stnc.CMS.Entities.Concrete
{
    public class DekamProjeLaboratuvarlar : ITablo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<DekamProjeTakip> DekamProjeTakip { get; set; }

    }
}