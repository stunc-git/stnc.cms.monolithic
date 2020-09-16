using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.DataAccess.ShoppingCartLib;
using Stnc.CMS.ShoppingCartLib;
using Stnc.CMS.Web.StringInfo;
using Stnc.CMS.Entities.Concrete;
namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index(bool isValidAmount = true, string returnUrl = "/")
        {
            _shoppingCart.GetShoppingCartItems();

            var model = new ShoppingCartIndex
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                ReturnUrl = returnUrl
            };

            if (!isValidAmount)
            {
                ViewBag.InvalidAmountText = "*There were not enough items in stock to add*";
            }

            return View("Index", model);

        }


        [HttpGet]
        [Route("/ShoppingCart/Add/{id}/{returnUrl?}")]
        public IActionResult Add(int id, int? amount = 1, string returnUrl = null)
        {
            var food = _foodService.GetById(id);
            returnUrl = returnUrl.Replace("%2F", "/");
            bool isValidAmount = false;
            if (food != null)
            {
                isValidAmount = _shoppingCart.AddToCart(food, amount.Value);
            }

            return Index(isValidAmount, returnUrl);
        }

        public IActionResult Remove(int foodId)
        {
            var food = _foodService.GetById(foodId);
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