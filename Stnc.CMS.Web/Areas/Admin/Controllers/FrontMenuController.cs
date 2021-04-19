using AutoMapper;
using Core.Flash;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class FrontMenuController : BaseIdentityController
    {
        private readonly IOptionsService _optionsService;
        private readonly IMapper _mapper;
        private readonly IFlasher f;

        public FrontMenuController(IFlasher f, IOptionsService optionsService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            this.f = f;
            _mapper = mapper;
            _optionsService = optionsService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Post;
            ViewBag.GeneralTitle = "Ön Sayfa Menü Yapılandırıcı";
            return View();
        }


   
        public IActionResult AutoLoadMenu()
        {
            var sonuc = _optionsService.GetOptionName("front-menu");
            return Ok(sonuc);
        }

        public IActionResult DefaultLoadMenu()
        {
            var sonuc = _optionsService.GetOptionNameDefault("front-menu-default");
            return Ok(sonuc);
        }

        [HttpPost]
        public IActionResult Update()
        {
            //    var user = await GetUserLoginInfo().ConfigureAwait(false);
            string saveData = HttpContext.Request.Form["saveData"];

            if (ModelState.IsValid)
            {
                _optionsService.Update("front-menu", saveData);

                f.Flash(Types.Success, "Kaydınız başarı ile düzenlendi", dismissable: true);

                return RedirectToAction("Index");
            }

            return View();
        }

    }
}