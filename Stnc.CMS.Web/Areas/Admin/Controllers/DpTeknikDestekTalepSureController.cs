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
    public class DpTeknikDestekTalepSureController : BaseIdentityController
    {
        private readonly EfGenericRepository<DekamProjeTeknikDestekTalepSure> Myrepo;
        private readonly IFlasher f;
        public DpTeknikDestekTalepSureController(IFlasher f, UserManager<AppUser> userManager) : base(userManager)
        {
            this.f = f;
            Myrepo = new EfGenericRepository<DekamProjeTeknikDestekTalepSure>();
        }

        public IActionResult Index()
        {
            ViewBag.GeneralTitle = "Teknik Destek Talep Süresi";
            TempData["Active"] = TempdataInfo.Category;
            var all = Myrepo.GetAll();
            return View(all);
        }

        public IActionResult Create()
        {
            ViewBag.GeneralTitle = "Teknik Destek Talep Süresi Ekleme";
            TempData["Active"] = TempdataInfo.Category;
            return View(new DekamProjeTeknikDestekTalepSure());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DekamProjeTeknikDestekTalepSure model)
        {
            ViewBag.GeneralTitle = "Teknik Destek Talep Süresi Ekleme";
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                Myrepo.Kaydet(new DekamProjeTeknikDestekTalepSure
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
            ViewBag.GeneralTitle = "Teknik Destek Talep Süresi Düzenleme";

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
        public async Task<IActionResult> Update(DekamProjeTeknikDestekTalepSure model)
        {
            ViewBag.GeneralTitle = "Teknik Destek Talep Süresi Düzenleme";

            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                Myrepo.Guncelle(new DekamProjeTeknikDestekTalepSure
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

            Myrepo.Sil(new DekamProjeTeknikDestekTalepSure { Id = id });
            return Json(null);
        }
    }
}