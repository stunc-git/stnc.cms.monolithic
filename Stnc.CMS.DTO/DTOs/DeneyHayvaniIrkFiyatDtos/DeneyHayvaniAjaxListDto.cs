using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos
{
    public class DeneyHayvaniIrkFiyatAjaxListDto
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public decimal Fiyat { get; set; }
        public string TurAdi { get; set; }
        public string IrkAdi { get; set; }
        public decimal GunlukBakimUcreti { get; set; }
        public decimal OtenaziUcret { get; set; }
    }
}