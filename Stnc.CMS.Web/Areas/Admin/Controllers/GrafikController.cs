using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.Web.StringInfo;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class GrafikController : Controller
    {
        /*
        En çok görev tamamlamış 5 personel.
        En çok görev almış 5 personel. (Alp- 2 görevde çalışıyor)
            Group by.
        */

        private readonly IAppUserService _appUserService;

        public GrafikController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Grafik;
            return View();
        }

   
    }
}