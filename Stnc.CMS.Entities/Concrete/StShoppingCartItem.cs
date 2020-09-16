namespace Stnc.CMS.Entities.Concrete
{
    public class StShoppingCartItem
    {
        public int Id { get; set; }
        public StCart Cart { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
