using Stnc.CMS.Entities.Interfaces;
using System;

namespace Stnc.CMS.Entities.Concrete
{
    public class DekamProjeTakip : ITablo
    {
        public int Id { get; set; }
        public string ProjeYurutucusu { get; set; }
        public string ProjeYurutukurumu { get; set; }
        public string ProjeYurutuTelefon { get; set; }
        public string SorumluArastirmaci { get; set; }
        public string SorumluArastirmaciTelefon { get; set; }
        public string EtikKurulOnayNumarasi { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public int DeneyHayvaniTur { get; set; }
        public int DeneyHayvaniIrk { get; set; }

        public enum DeneyHayvaniCinsiyet
        {
            Erkek = 1,
            Dişi = 2
        }

        public int DeneyHayvaniSayisi { get; set; }
        public int DeneyHayvaniYasi { get; set; }
        public int DeneyHayvaniAgirligi { get; set; }
        public int TeknikDestekSuresi { get; set; }
        public int TeknikDestekTuru { get; set; }
        public int TeknikHayvanSayisi { get; set; }
        public int Laboratuvar { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}