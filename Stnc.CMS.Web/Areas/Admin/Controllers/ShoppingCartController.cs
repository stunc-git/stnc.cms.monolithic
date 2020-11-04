using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.DataAccess.ShoppingCartLib;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.StringInfo;
using System.Collections.Generic;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    public class PostToCart
    {
        public int BaseId { get; set; }
        public int IstenenHayvanSayisi { get; set; }
        public int DestekIstenenHayvanSayisi { get; set; }
        public bool OtenaziIstek { get; set; }
        public string destekTalepTurLeri { get; set; }
    }

    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IShopDal _shopService;
        private readonly IDeneyHayvaniIrkFiyatService _deneyHayvaniIrkFiyatService;
        private readonly EfGenericRepository<DekamProjeTeknikDestekTalepTur> _dekamProjeTeknikDestekTalepTur_Repo;
        public ShoppingCartController(ShoppingCart shoppingCart, IShopDal shopService, IDeneyHayvaniIrkFiyatService deneyHayvaniIrkFiyatService)
        {
            _deneyHayvaniIrkFiyatService = deneyHayvaniIrkFiyatService;
            _shopService = shopService;
            _shoppingCart = shoppingCart;
            _dekamProjeTeknikDestekTalepTur_Repo = new EfGenericRepository<DekamProjeTeknikDestekTalepTur>();
        }

        public IActionResult Index()
        {
            //bool isValidAmount = true;
            _shoppingCart.GetShoppingCartItems();

            var model = new ShoppingCartIndex
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = 10,// _shoppingCart.GetShoppingCartTotal(),
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
        public JsonResult Add(PostToCart cartData)
        {
            decimal? amount;
            decimal? destekTalepTurLeriToplamFiyat;

            if (cartData.BaseId == null)
            {
                List<SelectListItem> sonuc = new List<SelectListItem>();
                sonuc.Add(new SelectListItem
                {
                    Text = "Bir hata oluştu :(",
                    Value = "Default"
                });

                return Json(sonuc);
            }

            // var cart = _shopService.GetById(employeeData.BaseId);

            var obj = _deneyHayvaniIrkFiyatService.GetDeneyHayvaniIrkFiyatID(cartData.BaseId);

            // FirstName = HttpContext.Request.Form["BaseId"],
            
            if (cartData.destekTalepTurLeri != null)
            {
               string[] destekTalepTurLeriIds = cartData.destekTalepTurLeri.Split(',');
            }

            // TODO: fiyat hesaplama alanında  yapılacak 
            var returndata= this._dekamProjeTeknikDestekTalepTur_Repo.GetirIdile(5);
            amount= returndata.Price;

            //foreach (var destekTalepTurID in destekTalepTurLeriIds)
            //{
            //    destekTalepTurLeriToplamFiyat += 
            //}




            //       destekTalepTurLeriToplamFiyat += amount;




            /*
            if (obj != null)
            {
                _shopService.SaveReturn(new StShoppingCartItem
                {
                    HayvaniIrkFiyatID = cartData.BaseId,
                    BakimDestegiGunSayisi=cartData.DestekIstenenHayvanSayisi,
                    IstenenHayvanSayisi = cartData.IstenenHayvanSayisi,
                    Otenazi = cartData.OtenaziIstek,
                    DestekTalepTurleriJson = cartData.destekTalepTurLeri,

                });
            }
            */


            return Json(obj);

            //return Index(isValidAmount, returnUrl);
        }

        public IActionResult Remove(int foodId)
        {
            //var food = _shopService.GetById(foodId);
            //if (food != null)
            //{
            //    _shoppingCart.RemoveFromCart(food);
            //}
            return RedirectToAction("Index");
        }

        public IActionResult Back(string returnUrl = "/")
        {
            return Redirect(returnUrl);
        }
    }
}