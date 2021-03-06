﻿using System;

namespace Stnc.CMS.Entities.Concrete
{
    public class StShoppingCartItem
    {
        public int Id { get; set; }
        public int HayvaniIrkFiyatID { get; set; }
        public int DekamProjeTakipID { get; set; }//new 
        public string HayvanIrkAdi { get; set; }
        public string  HayvanAdi { get; set; }
        public string HayvanIrkFiyatTipYasBilgisi { get; set; }
        public int  IstenenHayvanSayisi { get; set; }
        public int  DestekIstenenHayvanSayisi { get; set; }
        public int  BakimDestegiGunSayisi { get; set; }
        public int   Otenazi { get; set; }
        public decimal   OtenaziUcreti { get; set; }
        public decimal   OtenaziToplamUcreti { get; set; }
        public decimal HayvanFiyati { get; set; }
        public decimal GunlukBakimUcreti { get; set; }
        public string DestekTalepTurleri { get; set; }
        public bool DeneyHayvaniCinsiyet { get; set; }
        public string HayvanAgirlik { get; set; }
        public decimal ToplamFiyat { get; set; }
        //burada shop cart
      //  public string ShoppingCartId { get; set; }
        public string DestekTalepTurleriJson { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
       // public DekamProjeDeneyHayvaniIrkFiyat Cart { get; set; }
    }
}