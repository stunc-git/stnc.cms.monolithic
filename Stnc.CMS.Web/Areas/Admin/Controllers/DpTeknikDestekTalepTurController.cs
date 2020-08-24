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
    public class DpTeknikDestekTalepTurController : BaseIdentityController
    {
        private readonly EfGenericRepository<DekamProjeTeknikDestekTalepTur> Myrepo;
        private readonly IFlasher f;
        public DpTeknikDestekTalepTurController(IFlasher f, UserManager<AppUser> userManager) : base(userManager)
        {
            this.f = f;
            Myrepo = new EfGenericRepository<DekamProjeTeknikDestekTalepTur>();
        }

        public IActionResult Index()
        {
            ViewBag.GeneralTitle = "Teknik Destek Talep Türleri";
            TempData["Active"] = TempdataInfo.Category;
            var all = Myrepo.GetAll();
            return View(all);
        }

        public IActionResult Create()
        {
            ViewBag.GeneralTitle = "Teknik Destek Talep Türü Ekleme";
            TempData["Active"] = TempdataInfo.Category;
            return View(new DekamProjeTeknikDestekTalepTur());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DekamProjeTeknikDestekTalepTur model)
        {
            ViewBag.GeneralTitle = "Teknik Destek Talep Türü Ekleme";
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                Myrepo.Kaydet(new DekamProjeTeknikDestekTalepTur
                {
                    Name = model.Name,
                    AppUserId = user.Id,
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            ViewBag.GeneralTitle = "Teknik Destek Talep Türü Düzenleme";

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
        public async Task<IActionResult> Update(DekamProjeTeknikDestekTalepTur model)
        {
            ViewBag.GeneralTitle = "Teknik Destek Talep Türü Düzenleme";

            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                Myrepo.Guncelle(new DekamProjeTeknikDestekTalepTur
                {
                    Id = model.Id,
                    Name = model.Name,
                    AppUserId = user.Id,
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Myrepo.Sil(new DekamProjeTeknikDestekTalepTur { Id = id });
            return Json(null);
        }
    }
}