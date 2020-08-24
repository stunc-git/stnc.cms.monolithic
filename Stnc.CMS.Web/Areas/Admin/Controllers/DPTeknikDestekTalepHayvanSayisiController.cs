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
    public class DPTeknikDestekTalepHayvanSayisiController : BaseIdentityController
    {
        private readonly EfGenericRepository<DekamProjeTeknikDestekTalepHayvanSayisi> Myrepo;
        private readonly IFlasher f;
        public DPTeknikDestekTalepHayvanSayisiController(IFlasher f, UserManager<AppUser> userManager) : base(userManager)
        {
            this.f = f;
            Myrepo = new EfGenericRepository<DekamProjeTeknikDestekTalepHayvanSayisi>();
        }

        public IActionResult Index()
        {
            ViewBag.GeneralTitle = "Destek Hayvan Sayısı";
            TempData["Active"] = TempdataInfo.Category;
            var all = Myrepo.GetAll();
            return View(all);
        }

        public IActionResult Create()
        {
            ViewBag.GeneralTitle = "Destek Hayvan Sayısı Ekle";
            TempData["Active"] = TempdataInfo.Category;
            return View(new DekamProjeTeknikDestekTalepHayvanSayisi());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DekamProjeTeknikDestekTalepHayvanSayisi model)
        {
            ViewBag.GeneralTitle = "Destek Hayvan Sayısı Ekleme";
            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                Myrepo.Kaydet(new DekamProjeTeknikDestekTalepHayvanSayisi
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
            ViewBag.GeneralTitle = "Destek Hayvan Sayısı Düzenleme";

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
        public async Task<IActionResult> Update(DekamProjeTeknikDestekTalepHayvanSayisi model)
        {
            ViewBag.GeneralTitle = "Destek Hayvan Sayısı Düzenleme";

            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                Myrepo.Guncelle(new DekamProjeTeknikDestekTalepHayvanSayisi
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
            Myrepo.Sil(new DekamProjeTeknikDestekTalepHayvanSayisi { Id = id });
            return Json(null);
        }
    }
}