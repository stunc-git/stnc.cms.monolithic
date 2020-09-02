using Microsoft.AspNetCore.Identity;
using Stnc.CMS.Entities.Interfaces;
using System.Collections.Generic;

namespace Stnc.CMS.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITablo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } = "default.png";

        public List<Bildirim> Bildirimler { get; set; }
        public List<Gorev> Gorevler { get; set; }
        public List<Posts> Posts { get; set; }
        // public object Posts { get; set; }
        public List<DekamProjeDeneyHayvaniIrk> DekamProjeDeneyHayvaniIrk { get; set; }
        public List<DekamProjeDeneyHayvaniTur> DekamProjeDeneyHayvaniTur { get; set; }
        public List<DekamProjeLaboratuvarlar> DekamProjeLaboratuvarlar { get; set; }
        public List<DekamProjeTeknikDestekTalepHayvanSayisi> DekamProjeTeknikDestekTalepHayvanSayisi { get; set; }
        public List<DekamProjeTeknikDestekTalepSure> DekamProjeTeknikDestekTalepSure { get; set; }
        public List<DekamProjeTeknikDestekTalepTur> DekamProjeTeknikDestekTalepTur { get; set; }
        public List<DekamProjeTakip> DekamProjeTakip { get; set; }
    }
}