using Stnc.CMS.Entities.Interfaces;
using System;

namespace Stnc.CMS.Entities.Concrete
{
    public class GunlukUcretler : ITablo
    {
        public int Id { get; set; }
        public int BakimTurID { get; set; }
        public int DeneyHayvaniTurID { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}