using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class HomeController : BaseIdentityController
    {


        public HomeController( UserManager<AppUser> userManager) : base(userManager)
        {
 
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);
            TempData["Active"] = TempdataInfo.Anasayfa;

            return View();
        }
    }
}