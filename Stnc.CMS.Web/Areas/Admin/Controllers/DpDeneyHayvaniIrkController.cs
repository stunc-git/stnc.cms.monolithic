using Core.Flash;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class DpDeneyHayvaniIrkController : BaseIdentityController
    {
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniIrk> Myrepo;
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniTur> DeneyHayvaniTurRepo;
        private readonly IFlasher f;

        public DpDeneyHayvaniIrkController(IFlasher f, UserManager<AppUser> userManager) : base(userManager)
        {
            this.f = f;
            Myrepo = new EfGenericRepository<DekamProjeDeneyHayvaniIrk>();
            DeneyHayvaniTurRepo = new EfGenericRepository<DekamProjeDeneyHayvaniTur>();
        }

        public IActionResult Index()
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Irkları";
            TempData["Active"] = TempdataInfo.Category;

            var all = Myrepo.GetAll();
            return View(all);
        }

        public IActionResult Create()
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Irkı Ekleme";
            TempData["Active"] = TempdataInfo.Category;
            ViewBag.Categories = new SelectList(DeneyHayvaniTurRepo.GetAll(), "Id", "Name");
            return View(new DekamProjeDeneyHayvaniIrk());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DekamProjeDeneyHayvaniIrk model)
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Irkı Ekleme";
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                Myrepo.Kaydet(new DekamProjeDeneyHayvaniIrk
                {
                    Name = model.Name,
                    AppUserId = user.Id,
                    DeneyHayvaniTurID = model.DeneyHayvaniTurID,
                });

                f.Flash(Types.Success, "Kaydınız başarı ile eklendi", dismissable: true);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Irkı Düzenleme";

            TempData["Active"] = TempdataInfo.Category;

            var data = this.Myrepo.GetirIdile(id);

            ViewBag.Categories = new SelectList(DeneyHayvaniTurRepo.GetAll(), "Id", "Name", data.DeneyHayvaniTurID);

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
        public async Task<IActionResult> Update(DekamProjeDeneyHayvaniIrk model)
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Irkı Düzenleme";

            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                Myrepo.Guncelle(new DekamProjeDeneyHayvaniIrk
                {
                    Id = model.Id,
                    Name = model.Name,
                    AppUserId = user.Id,
                    DeneyHayvaniTurID = model.DeneyHayvaniTurID,
                });
                f.Flash(Types.Success, "Kaydınız başarı ile düzenlendi", dismissable: true);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            f.Flash(Types.Success, "Kaydınız başarı ile silindi", dismissable: true);
            Myrepo.Sil(new DekamProjeDeneyHayvaniIrk { Id = id });
            return Json(null);
        }
    }
}