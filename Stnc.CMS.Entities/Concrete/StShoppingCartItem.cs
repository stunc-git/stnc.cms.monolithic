namespace Stnc.CMS.Entities.Concrete
{
    public class StShoppingCartItem
    {
        public int Id { get; set; }
        public int HayvaniIrkFiyatID { get; set; }
        public int GunlukUcretId { get; set; }
        public int TeknikDestekId { get; set; }

        public decimal ToplamFiyat { get; set; }

        //burada shop cart
        public string ShoppingCartId { get; set; }
        public StCart Cart { get; set; }

    }
}
