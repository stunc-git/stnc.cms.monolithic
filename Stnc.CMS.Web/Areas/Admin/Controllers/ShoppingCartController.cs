using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.DataAccess.ShoppingCartLib;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.StringInfo;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stnc.CMS.Web.BaseControllers;
using System;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    public class PostToCart
    {
        public int BaseId { get; set; }
        public int IstenenHayvanSayisi { get; set; }
        public int DestekIstenenHayvanSayisi { get; set; }
        public int BakimDestegiGunSayisi { get; set; }
        public int OtenaziIstek { get; set; }
        public string destekTalepTurLeri { get; set; }
        public int HayvanYas { get; set; }
        public int HayvanAgirlik { get; set; }
        public bool DeneyHayvaniCinsiyet { get; set; }
        public string ReturnType { get; set; }
    }

    public class DestekTalepTurleriJson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ShoppingCartController : BaseIdentityController
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IShopDal _shopService;
        private readonly IDeneyHayvaniIrkFiyatService _deneyHayvaniIrkFiyatService;
        private readonly EfGenericRepository<DekamProjeTeknikDestekTalepTur> _dekamProjeTeknikDestekTalepTur_Repo;

        public ShoppingCartController(ShoppingCart shoppingCart, IShopDal shopService, IDeneyHayvaniIrkFiyatService deneyHayvaniIrkFiyatService, UserManager<AppUser> userManager) : base(userManager)
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
        public async Task <JsonResult> Add(PostToCart cartData)
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            decimal destekTalepTurLeriToplamFiyat;
            decimal fiyatToplami;
            decimal otenaziUcretToplami;
            string[] destektalepturleris;
            string destektalepturleriStr = null;
            string JsonOutput = null;
            decimal hayvanSayisiFiyati;
            decimal bakimDestegiGunlukUcretToplami;
            decimal destekIstenenUcretToplami;
            int? returnId;
            returnId = 0;
            destekTalepTurLeriToplamFiyat = 0;
            hayvanSayisiFiyati = 0;
            bakimDestegiGunlukUcretToplami = 0;
            destekIstenenUcretToplami = 0;
            fiyatToplami = 0;
            otenaziUcretToplami = 0;

          


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

            var hayvanFiyatlari = _deneyHayvaniIrkFiyatService.GetDeneyHayvaniIrkFiyatID(cartData.BaseId);

            // DestekTalepTurleriJson destekjson = new DestekTalepTurleriJson();

            List<DestekTalepTurleriJson> destekjson = new List<DestekTalepTurleriJson>();

            //   destekjson.ID = returndata.Id;
            // destekjson = new DestekTalepTurleriJson() { ID=0,Name="",Price=1 };

            if (cartData.destekTalepTurLeri != null)
            {
                //destekTalepTurLeriIds = cartData.destekTalepTurLeri.Split(',');
                destektalepturleris = cartData.destekTalepTurLeri.Split(',');

                foreach (string part in destektalepturleris)
                {
                    //Console.WriteLine(part);
                    var returndata = this._dekamProjeTeknikDestekTalepTur_Repo.GetirIdile(int.Parse(part));

                    destektalepturleriStr += part + ',';

                    destekTalepTurLeriToplamFiyat += returndata.Price;

                    destekjson.Add(new DestekTalepTurleriJson()
                    {
                        ID = returndata.Id,
                        Name = returndata.Name,
                        Price = returndata.Price,
                    });
                }
            }

            JsonOutput = JsonConvert.SerializeObject(destekjson);

            hayvanSayisiFiyati = hayvanFiyatlari.Fiyat * cartData.IstenenHayvanSayisi;

            bakimDestegiGunlukUcretToplami = cartData.BakimDestegiGunSayisi * hayvanFiyatlari.GunlukBakimUcreti;

            destekIstenenUcretToplami = bakimDestegiGunlukUcretToplami * cartData.DestekIstenenHayvanSayisi;

            if (cartData.DestekIstenenHayvanSayisi > cartData.IstenenHayvanSayisi)
            {
                return Json(new { status = "hata", mesaj = "Destek istenen Hayvan Sayısı adeti İstenen Hayvan Sayısı adetinden büyük olamaz" });
            }

            if (cartData.OtenaziIstek == 1)
            {
                otenaziUcretToplami = hayvanFiyatlari.OtenaziUcret * cartData.IstenenHayvanSayisi;
            }

            fiyatToplami = hayvanSayisiFiyati + destekIstenenUcretToplami + otenaziUcretToplami + destekTalepTurLeriToplamFiyat;

            if (fiyatToplami == 0)
            {
                return Json(new { status = "hata", mesaj = "Sipariş Tutarınız 0 TL, Sepete Eklenemedi " });
            }

       
            if (cartData.ReturnType == "ekle"){
                if (hayvanFiyatlari != null)
                {
                    if (fiyatToplami != 0)
                    {



                       

                      var returnData=  _shopService.SaveReturn(
                           new StShoppingCartItem
                           {
                               HayvaniIrkFiyatID = hayvanFiyatlari.Id,
                               HayvanIrkAdi = hayvanFiyatlari.TurAdi,
                               HayvanAdi = hayvanFiyatlari.IrkAdi,
                               HayvanIrkFiyatTipYasBilgisi = hayvanFiyatlari.YasBilgisi,
                               IstenenHayvanSayisi = cartData.IstenenHayvanSayisi,
                               BakimDestegiGunSayisi = cartData.BakimDestegiGunSayisi,
                               DestekIstenenHayvanSayisi = cartData.DestekIstenenHayvanSayisi,
                               Otenazi = cartData.OtenaziIstek,
                               HayvanAgirlik = cartData.HayvanAgirlik,
                               DeneyHayvaniCinsiyet = cartData.DeneyHayvaniCinsiyet,
                               OtenaziUcreti = hayvanFiyatlari.OtenaziUcret,
                               OtenaziToplamUcreti = otenaziUcretToplami,
                               HayvanFiyati = hayvanFiyatlari.Fiyat,
                               GunlukBakimUcreti = hayvanFiyatlari.GunlukBakimUcreti,
                               DestekTalepTurleri = destektalepturleriStr,
                               DestekTalepTurleriJson = JsonOutput,
                               ToplamFiyat = fiyatToplami,
                               AppUserId = user.Id,
                           }

                          );

                        returnId=returnData.Id;
                    }
                }
                 var JsonData = _shopService.GetCartUserIdList(user.Id);
                Console.WriteLine(JsonData);
                return Json(new { status = "ok", SuccessCartItems = JsonData, returnID= returnId, destekTalepTurleri= JsonOutput, fiyatToplam = fiyatToplami });
            }
            else
            {
                return Json(new { status = "ok", fiyatToplam = fiyatToplami });
            }
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