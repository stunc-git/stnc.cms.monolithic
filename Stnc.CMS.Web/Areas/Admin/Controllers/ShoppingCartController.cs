using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.DataAccess.ShoppingCartLib;
using Stnc.CMS.Web.StringInfo;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IShopDal _shopService;

        public ShoppingCartController(ShoppingCart shoppingCart, IShopDal shopService)
        {
            _shopService = shopService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            //bool isValidAmount = true;
            _shoppingCart.GetShoppingCartItems();

            var model = new ShoppingCartIndex
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };

            //if (!isValidAmount)
            //{
            //    ViewBag.InvalidAmountText = "*There were not enough items in stock to add*";
            //}
            return View("Index", model);
        }

        [HttpGet]
        [Route("/ShoppingCart/Add/{id}")]
        public IActionResult Add(int id, [FromQuery] string catID)
        {
            int? amount = 5;
            var cart = _shopService.GetById(id);

            bool isValidAmount = false;

            if (cart != null)
            {
                isValidAmount = _shoppingCart.AddToCart(cart, amount.Value);
            }

            return Index();
            //return Index(isValidAmount, returnUrl);
        }

        public IActionResult Remove(int foodId)
        {
            var food = _shopService.GetById(foodId);
            if (food != null)
            {
                _shoppingCart.RemoveFromCart(food);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Back(string returnUrl = "/")
        {
            return Redirect(returnUrl);
        }
    }
}