﻿using Stnc.CMS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stnc.CMS.Entities.Concrete
{
    // burada fluent validaiton kullanılmamasının sebebi tek alanlık veri olduğu için
    // diğerleriStnc.CMS.Business\ValidationRules\FluentValidation\ altındadır
    public class DekamProjeDeneyHayvaniIrk : ITablo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen isim alanını doldurunuz")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Lütfen hayvan türünü seçiniz")]
        public int DeneyHayvaniTurID { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public DateTime? DeletedAt { get; set; }

        public int? AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public List<DekamProjeDeneyHayvaniIrkFiyat> DekamProjeDeneyHayvaniIrkFiyat { get; set; }

    }
}