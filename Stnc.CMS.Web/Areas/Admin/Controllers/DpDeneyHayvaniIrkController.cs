using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DTO.DTOs.CategoryDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System.Linq;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class DpDeneyHayvaniIrkController : BaseIdentityController
    {

        public DpDeneyHayvaniIrkController(UserManager<AppUser> userManager) : base(userManager)
        {

        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Category;
            using var context = new StncCMSContext();
            return View(context.Set<DekamProjeDeneyHayvaniIrk>().ToList());
        }

        public IActionResult Create()
        {
            TempData["Active"] = TempdataInfo.Category;
            return View(new DekamProjeDeneyHayvaniIrk());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DekamProjeDeneyHayvaniIrk model)
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            if (ModelState.IsValid)
            {

                using var context = new StncCMSContext();
                context.Set<DekamProjeDeneyHayvaniIrk>().Add(new DekamProjeDeneyHayvaniIrk()
                {
                    Name = model.Name,
                    AppUserId = user.Id,
                });
                context.SaveChanges();


                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["Active"] = TempdataInfo.Category;
            using var context = new StncCMSContext();
            return View(context.Set<DekamProjeDeneyHayvaniIrk>().Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(DekamProjeDeneyHayvaniIrk model)
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {


                using var context = new StncCMSContext();
                context.Set<DekamProjeDeneyHayvaniIrk>().Update(new DekamProjeDeneyHayvaniIrk()
                {
                    Name = model.Name,
                    AppUserId = user.Id,
                });
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            using var context = new StncCMSContext();
            context.Set<DekamProjeDeneyHayvaniIrk>().Remove(new DekamProjeDeneyHayvaniIrk { Id = id });
            context.SaveChanges();
            return Json(null);
        }
    }
}