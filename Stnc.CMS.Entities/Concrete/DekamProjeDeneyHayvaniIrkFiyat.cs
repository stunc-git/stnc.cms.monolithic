using Stnc.CMS.Entities.Interfaces;
using System;

namespace Stnc.CMS.Entities.Concrete
{
    public class DekamProjeDeneyHayvaniIrkFiyat : ITablo
    {
        public int Id { get; set; }
        public string YasBilgisi { get; set; }

        public decimal Fiyat { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        // public List<DekamProjeTakip> DekamProjeTakip { get; set; }
        public int? DekamProjeDeneyHayvaniTurId { get; set; }
        public DekamProjeDeneyHayvaniTur DekamProjeDeneyHayvaniTur { get; set; }

        public int? DekamProjeDeneyHayvaniIrkId { get; set; }
        public DekamProjeDeneyHayvaniIrk DekamProjeDeneyHayvaniIrk { get; set; }
    }
}