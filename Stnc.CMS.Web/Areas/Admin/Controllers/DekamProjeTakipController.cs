using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.DTO.DTOs.DekamProjeTakipDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System.Collections.Generic;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class DekamProjeTakipController : BaseIdentityController
    {
        private readonly IDekamProjeTakipService _dekamProjeTakipService;
        private readonly IMapper _mapper;
        private readonly EfGenericRepository<DekamProjeTeknikDestekTalepSure> TeknikDestekTalepSureRepo;
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniIrk> DekamProjeDeneyHayvaniIrkRepo;
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniTur> DekamProjeDeneyHayvaniTurRepo;
        private readonly EfGenericRepository<DekamProjeLaboratuvarlar> DekamProjeLaboratuvarlarRepo;
        private readonly EfGenericRepository<DekamProjeTeknikDestekTalepHayvanSayisi> DekamProjeTeknikDestekTalepHayvanSayisiRepo;
        private readonly EfGenericRepository<DekamProjeTeknikDestekTalepTur> DekamProjeTeknikDestekTalepTurRepo;
        public DekamProjeTakipController(IDekamProjeTakipService dekamProjeTakipService, IMapper mapper, UserManager<AppUser> userManager) : base(userManager)
        {
            _mapper = mapper;
            _dekamProjeTakipService = dekamProjeTakipService;
            TeknikDestekTalepSureRepo = new EfGenericRepository<DekamProjeTeknikDestekTalepSure>();
            DekamProjeDeneyHayvaniIrkRepo = new EfGenericRepository<DekamProjeDeneyHayvaniIrk>();
            DekamProjeDeneyHayvaniTurRepo = new EfGenericRepository<DekamProjeDeneyHayvaniTur>();
            DekamProjeLaboratuvarlarRepo = new EfGenericRepository<DekamProjeLaboratuvarlar>();
            DekamProjeTeknikDestekTalepHayvanSayisiRepo = new EfGenericRepository<DekamProjeTeknikDestekTalepHayvanSayisi>();
            DekamProjeTeknikDestekTalepTurRepo = new EfGenericRepository<DekamProjeTeknikDestekTalepTur>();
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Category;
            ViewBag.GeneralTitle = "Proje Takip";
            return View(_mapper.Map<List<DekamProjeTakipListDto>>(_dekamProjeTakipService.ProjeList()));
        }

        public IActionResult Create()
        {
            TempData["Active"] = TempdataInfo.Category;
            ViewBag.GeneralTitle = "Proje Takip";
            ViewBag.DeneyHayvaniIrkCategories = new SelectList(DekamProjeDeneyHayvaniIrkRepo.GetAll(), "Id", "Name");
            ViewBag.DeneyHayvaniTurCategories = new SelectList(DekamProjeDeneyHayvaniTurRepo.GetAll(), "Id", "Name");
            ViewBag.LaboratuvarlarCategories = new SelectList(DekamProjeLaboratuvarlarRepo.GetAll(), "Id", "Name");
            ViewBag.TeknikDestekTalepHayvanSayisiCategories = new SelectList(DekamProjeTeknikDestekTalepHayvanSayisiRepo.GetAll(), "Id", "Name");
            ViewBag.TeknikDestekTalepSureCategories = new SelectList(TeknikDestekTalepSureRepo.GetAll(), "Id", "Name");
            ViewBag.ProjeTeknikDestekTalepTurCategories = new SelectList(DekamProjeTeknikDestekTalepTurRepo.GetAll(), "Id", "Name");
            return View(new DekamProjeTakipCreateDto());
        }
        /*
        [HttpPost]
        public IActionResult Create(CategoryAddDto model)
        {
            if (ModelState.IsValid)
            {
                _categoryservice.Kaydet(new Category()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Slug = SlugHelper(model.Name),
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateCategory(int id)
        {
            TempData["Active"] = TempdataInfo.Category;
            return View(_mapper.Map<CategoryUpdateDto>(_categoryservice.GetirIdile(id)));
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _categoryservice.Guncelle(new Category
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Slug = SlugHelper(model.Slug),
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryservice.Sil(new Category { Id = id });
            return Json(null);
        }
        */
    }
}