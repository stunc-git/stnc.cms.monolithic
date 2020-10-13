using Stnc.CMS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stnc.CMS.Entities.Concrete
{
    // burada fluent validaiton kullanılmamasının sebebi generic olarak map yaptığım için
    // diğerleriStnc.CMS.Business\ValidationRules\FluentValidation\ altındadır
    public class DekamProjeLaboratuvarlar : ITablo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen isim alanını doldurunuz")]
        public string Name { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<DekamProjeTakip> DekamProjeTakip { get; set; }
    }
}