using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DTO.DTOs.GorevDtos
{
    public class GorevListDto
    {
        public int Id { get; set; }

        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public DateTime OlusturulmaTarih { get; set; }

        public int AciliyetId { get; set; }
        public Aciliyet Aciliyet { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
