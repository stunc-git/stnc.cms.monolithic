namespace Stnc.CMS.DTO.DTOs.ShopCartDto
{
    public class DestekTalepTurleriJsonDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ShopCartAjaxListDto
    {
        public int Id { get; set; }
        public int HayvaniIrkFiyatID { get; set; }
        public int SiparislerID { get; set; }
        public string HayvanIrkAdi { get; set; }
        public string HayvanAdi { get; set; }
        public string HayvanIrkFiyatTipYasBilgisi { get; set; }
        public int IstenenHayvanSayisi { get; set; }
        public int DestekIstenenHayvanSayisi { get; set; }
        public int BakimDestegiGunSayisi { get; set; }
        public int Otenazi { get; set; }
        public decimal OtenaziUcreti { get; set; }
        public decimal OtenaziToplamUcreti { get; set; }
        public decimal HayvanFiyati { get; set; }
        public decimal GunlukBakimUcreti { get; set; }
        public string DestekTalepTurleri { get; set; }
        public bool DeneyHayvaniCinsiyet { get; set; }
        public string HayvanAgirlik { get; set; }
        public decimal ToplamFiyat { get; set; }

        //burada shop cart
        //  public string ShoppingCartId { get; set; }
        //    public DestekTalepTurleriJsonDto DestekTalepTurleriJson { get; set; }

       public dynamic DestekTalepTurleriJson { get; set; }
        public string DestekTalepTurleriJsonRead { get; set; }

        public string DestekTalepTurleriJsonVal { get; set; }

        public int? AppUserId { get; set; }
    }
}