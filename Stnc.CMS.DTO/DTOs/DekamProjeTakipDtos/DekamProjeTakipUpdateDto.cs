using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DTO.DTOs.DekamProjeTakipDtos
{
    public class DekamProjeTakipUpdateDto
    {
        public int Id { get; set; }
        public string ProjeYurutucusu { get; set; }
        public string ProjeYurutukurumu { get; set; }
        public string ProjeYurutuTelefon { get; set; }
        public string SorumluArastirmaci { get; set; }
        public string SorumluArastirmaciTelefon { get; set; }
        public string EtikKurulOnayNumarasi { get; set; }
        public DateTime? EtikKurulOnayTarihi { get; set; }
        public DateTime? ProjeBaslangicTarihi { get; set; }
        public DateTime? ProjeBitisTarihi { get; set; }

        public int DeneyHayvaniCinsiyet { get; set; }//erkeke dişi sadece iki adet
        public int DeneyHayvaniSayisi { get; set; }
        public int DeneyHayvaniYasi { get; set; }
        public int DeneyHayvaniAgirligi { get; set; }

        public int TeknikDestekSuresiID { get; set; }
        public int TeknikDestekTuruID { get; set; }
        public int TeknikHayvanSayisiID { get; set; }
        public int LaboratuvarID { get; set; }
        public DateTime? LaboratuvarBaslangicTarihi { get; set; }
        public DateTime? LaboratuvarBitisTarihi { get; set; }
        public int DeneyHayvaniIrkID { get; set; }
        public int? DeneyHayvaniTurID { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
