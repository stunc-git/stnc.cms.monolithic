using Stnc.CMS.DataAccess.ShoppingCartLib;

namespace Stnc.CMS.ShoppingCartLib
{
    public class ShoppingCartIndex
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public string ReturnUrl { get; set; }

    }
}
