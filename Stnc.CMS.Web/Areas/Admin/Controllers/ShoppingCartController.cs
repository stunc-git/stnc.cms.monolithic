using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.DataAccess.ShoppingCartLib;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{


    public class Person
    {
        public string FirstName { get; set; }
        public string IstenenHayvanSayisi { get; set; }
        public int BaseId { get; set; }
    }



    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IShopDal _shopService;
        private readonly IDeneyHayvaniIrkFiyatService _deneyHayvaniIrkFiyatService;
        public ShoppingCartController(ShoppingCart shoppingCart, IShopDal shopService, IDeneyHayvaniIrkFiyatService deneyHayvaniIrkFiyatService)
        {
            _deneyHayvaniIrkFiyatService = deneyHayvaniIrkFiyatService;
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

        [HttpPost]
        // [Route("/ShoppingCart/Add/{id}")] //get e göre 
        //https://peterdaugaardrasmussen.com/2017/09/18/getting-raw-post-data-from-web-api-request-in-controller/
        //https://andrewlock.net/model-binding-json-posts-in-asp-net-core/
        // HttpContext.Request.Form["UserName"]
        [Route("/ShoppingCart/Add")]
      //  public IActionResult Add(int id, [FromQuery] string catID)
        public JsonResult Add(Person employeeData)
        {
            int? amount = 5;
            var cart = _shopService.GetById(employeeData.BaseId);

            _deneyHayvaniIrkFiyatService.GetDeneyHayvaniIrkFiyatID(employeeData.BaseId);
            
            bool isValidAmount = false;

            if (cart != null)
            {
                isValidAmount = _shoppingCart.AddToCart(cart, amount.Value);
            }
            Person obj = new Person()
            {
                BaseId = employeeData.BaseId,
                FirstName = HttpContext.Request.Form["BaseId"],
            };

            return Json(obj);

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