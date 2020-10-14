using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos
{
    public class DeneyHayvaniIrkFiyatListAllDto
    {
        public int Id { get; set; }
        public string Isım { get; set; }

        public decimal Fiyat { get; set; }
        public string UserName { get; set; }
        public string HayvaniTurAdi { get; set; }
        public string HayvaniIrkAdi { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int? DekamProjeDeneyHayvaniTurId { get; set; }
        public DekamProjeDeneyHayvaniTur DekamProjeDeneyHayvaniTur { get; set; }

        public int? DekamProjeDeneyHayvaniIrkId { get; set; }
        public DekamProjeDeneyHayvaniIrk DekamProjeDeneyHayvaniIrk { get; set; }
    }
}