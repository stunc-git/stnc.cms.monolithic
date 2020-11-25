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
    public class DProjeDeneyHayvaniTurController : BaseIdentityController
    {
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniTur> Myrepo;
        private readonly IFlasher f;

        public DProjeDeneyHayvaniTurController(IFlasher f, UserManager<AppUser> userManager) : base(userManager)
        {
            this.f = f;
            Myrepo = new EfGenericRepository<DekamProjeDeneyHayvaniTur>();
        }

        public IActionResult Index()
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Türleri";
            TempData["Active"] = TempdataInfo.Category;
            var all = Myrepo.GetAll();
            return View(all);
        }

        public IActionResult Create()
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Türü Ekle";
            TempData["Active"] = TempdataInfo.Category;
            return View(new DekamProjeDeneyHayvaniTur());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DekamProjeDeneyHayvaniTur model)
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Tür Ekleme";
            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                Myrepo.Save(new DekamProjeDeneyHayvaniTur
                {
                    Name = model.Name,
                    GunlukBakimUcret = model.GunlukBakimUcret,
                    OtenaziUcret = model.OtenaziUcret,
                    AppUserId = user.Id,
                });

                f.Flash(Types.Success, "Kaydınız başarı ile eklendi", dismissable: true);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Türü Düzenleme";

            TempData["Active"] = TempdataInfo.Category;
            var data = this.Myrepo.GetID(id);
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
        public async Task<IActionResult> Update(DekamProjeDeneyHayvaniTur model)
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Türü Düzenleme";

            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                Myrepo.Update(new DekamProjeDeneyHayvaniTur
                {
                    Id = model.Id,
                    Name = model.Name,
                    OtenaziUcret = model.OtenaziUcret,
                    GunlukBakimUcret = model.GunlukBakimUcret,

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

            Myrepo.Delete(new DekamProjeDeneyHayvaniTur { Id = id });
            return Json(null);
        }
    }
}