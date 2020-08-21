using Stnc.CMS.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Stnc.CMS.Entities.Concrete
{
    public class DekamProjeDeneyHayvaniIrk : ITablo
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Lütfen isim alanını doldurunuz")]
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
       // public DekamProjeTakip DekamProjeTakip { get; set; }

    }
}