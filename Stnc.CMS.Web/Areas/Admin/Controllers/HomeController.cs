using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {


        public HomeController( UserManager<AppUser> userManager) : base(userManager)
        {

        }

        /*
            - Atanmayı Bekleyen Gorev Sayısı
            - Tamamlanmış Görev Sayısı
            - Okunmamış Bildirim Sayısı
            - Toplam Yazılmış Rapor Sayısı
        */

        public async Task<IActionResult> Index()
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);
            TempData["Active"] = TempdataInfo.Anasayfa;

            return View();
        }
    }
}