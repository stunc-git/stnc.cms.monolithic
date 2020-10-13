using Core.Flash;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class DpLaboratuvarlarController : BaseIdentityController
    {
        private readonly EfGenericRepository<DekamProjeLaboratuvarlar> Myrepo;
        private readonly IFlasher f;
        public DpLaboratuvarlarController(IFlasher f, UserManager<AppUser> userManager) : base(userManager)
        {
            this.f = f;
            Myrepo = new EfGenericRepository<DekamProjeLaboratuvarlar>();
        }

        public IActionResult Index()
        {
            ViewBag.GeneralTitle = "Laboratuvarlar";
            TempData["Active"] = TempdataInfo.Category;
            var all = Myrepo.GetAll();
            return View(all);
        }

        public IActionResult Create()
        {
            ViewBag.GeneralTitle = "Laboratuvar Ekleme";
            TempData["Active"] = TempdataInfo.Category;
            return View(new DekamProjeLaboratuvarlar());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DekamProjeLaboratuvarlar model)
        {
            ViewBag.GeneralTitle = "Laboratuvar Ekleme";
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                Myrepo.Kaydet(new DekamProjeLaboratuvarlar
                {
                    Name = model.Name,
                    AppUserId = user.Id,
                });
                f.Flash(Types.Success, "Kaydınız başarı ile eklendi", dismissable: true);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            ViewBag.GeneralTitle = "Laboratuvar Düzenleme";

            TempData["Active"] = TempdataInfo.Category;
            var data = this.Myrepo.GetirIdile(id);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                f.Flash(Types.Danger, "Böyle bir veri bulunamadı", dismissable: true);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(DekamProjeLaboratuvarlar model)
        {
            ViewBag.GeneralTitle = "Laboratuvar Düzenleme";

            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                Myrepo.Guncelle(new DekamProjeLaboratuvarlar
                {
                    Id = model.Id,
                    Name = model.Name,
                    AppUserId = user.Id,
                });
                f.Flash(Types.Success, "Kaydınız başarı ile düzenlendi", dismissable: true);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            f.Flash(Types.Success, "Kaydınız başarı ile silindi", dismissable: true);
            Myrepo.Sil(new DekamProjeLaboratuvarlar { Id = id });
            return Json(null);
        }
    }
}