using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos
{
    public class DeneyHayvaniIrkFiyatCreateDto
    {
        public int Id { get; set; }
        public string YasBilgisi { get; set; }
        public int DeneyHayvaniTurID { get; set; }
        public int DeneyHayvaniIrkID { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}