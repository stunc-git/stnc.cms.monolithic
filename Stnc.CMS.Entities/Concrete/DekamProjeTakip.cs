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
        public DateTime? EtikKurulOnayTarihi { get; set; }
        public DateTime? ProjeBaslangicTarihi { get; set; }
        public DateTime? ProjeBitisTarihi { get; set; }



        /*
          public int DeneyHayvaniSayisi { get; set; }
        public int DeneyHayvaniCinsiyet { get; set; }//erkeke dişi sadece iki adet
        public int DeneyHayvaniYasi { get; set; }
        public int DeneyHayvaniAgirligi { get; set; }
        */
        public DateTime? LaboratuvarBaslangicTarihi { get; set; }
        public DateTime? LaboratuvarBitisTarihi { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public int LaboratuvarID { get; set; }
        public virtual DekamProjeLaboratuvarlar DekamProjeLaboratuvarlar { get; set; }


    }
}