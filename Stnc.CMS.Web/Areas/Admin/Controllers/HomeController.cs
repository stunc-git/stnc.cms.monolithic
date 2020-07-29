using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IGorevService _gorevService;
        private readonly IPostService _postService;
        private readonly IBildirimService _bildirimService;
        private readonly IRaporService _raporService;

        public HomeController(IGorevService gorevService, IPostService postService, IBildirimService bildirimService, UserManager<AppUser> userManager, IRaporService raporService) : base(userManager)
        {
            _raporService = raporService;
            _postService = postService;
            _bildirimService = bildirimService;
            _gorevService = gorevService;
        }

        /* 
         - Atanmayı Bekleyen Gorev Sayısı
         - Tamamlanmış Görev Sayısı
         - Okunmamış Bildirim Sayısı
         - Toplam Yazılmış Rapor Sayısı
         */
        public async Task<IActionResult> Index()
        {

            var user = await GetUserLoginInfo();
            TempData["Active"] = TempdataInfo.Anasayfa;
            ViewBag.AtanmayiBekleyenGorevSayisi = _gorevService.GetirGorevSayisiAtanmayiBekleyen();

            ViewBag.TamamlanmisGorevSayisi = _gorevService.GetirGorevTamamlanmis();

            ViewBag.OkunmamisBildirimSayisi = _bildirimService.GetirOkunmayanSayisiileAppUserId(user.Id);

           // ViewBag.ToplamRaporSayisi = _raporService.GetirRaporSayisi();
           ViewBag.ToplamRaporSayisi = _postService.GetTotalPost();
            return View();
        }

    }
}