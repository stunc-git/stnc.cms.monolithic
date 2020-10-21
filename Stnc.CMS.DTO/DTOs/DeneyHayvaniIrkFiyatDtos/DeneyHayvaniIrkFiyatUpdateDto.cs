using Stnc.CMS.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos
{
    public class DeneyHayvaniIrkFiyatUpdateDto
    {
        public int Id { get; set; }
        public string Isım { get; set; }
        public int DekamProjeDeneyHayvaniTurId { get; set; }
        public int DeneyHayvaniIrkID { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}