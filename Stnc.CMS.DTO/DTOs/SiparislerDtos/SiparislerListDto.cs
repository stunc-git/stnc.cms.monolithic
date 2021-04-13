using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DTO.DTOs.SiparislerDtos
{
    public class SiparislerListDto
    {
        public int Id { get; set; }
        public string ProjeYurutucusu { get; set; }
        public string ProjeYurutukurumu { get; set; }
        public string ProjeYurutuTelefon { get; set; }
        public string SorumluArastirmaci { get; set; }
        public string SorumluArastirmaciTelefon { get; set; }
        public string EtikKurulOnayNumarasi { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int LaboratuvarID { get; set; }
        public virtual DekamProjeLaboratuvarlar Laboratuvar { get; set; }

    }
}
