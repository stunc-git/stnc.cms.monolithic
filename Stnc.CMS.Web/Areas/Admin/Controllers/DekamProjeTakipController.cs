using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.DTO.DTOs.DekamProjeTakipDtos;
using Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class DekamProjeTakipController : BaseIdentityController
    {
        private readonly IDekamProjeTakipService _dekamProjeTakipService;
        private readonly IDeneyHayvaniIrkFiyatService _deneyHayvaniIrkFiyatService;
        private readonly IMapper _mapper;
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniIrk> DekamProjeDeneyHayvaniIrkRepo;
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniTur> DekamProjeDeneyHayvaniTurRepo;
        private readonly EfGenericRepository<DekamProjeLaboratuvarlar> DekamProjeLaboratuvarlarRepo;
        private readonly EfGenericRepository<DekamProjeTeknikDestekTalepTur> DekamProjeTeknikDestekTalepTurRepo;


        public DekamProjeTakipController(IDekamProjeTakipService dekamProjeTakipService, IDeneyHayvaniIrkFiyatService deneyHayvaniIrkFiyatService, IMapper mapper, UserManager<AppUser> userManager) : base(userManager)
        {
            _mapper = mapper;
            _dekamProjeTakipService = dekamProjeTakipService;
            _deneyHayvaniIrkFiyatService = deneyHayvaniIrkFiyatService;
            DekamProjeDeneyHayvaniIrkRepo = new EfGenericRepository<DekamProjeDeneyHayvaniIrk>();

            DekamProjeDeneyHayvaniTurRepo = new EfGenericRepository<DekamProjeDeneyHayvaniTur>();
            DekamProjeLaboratuvarlarRepo = new EfGenericRepository<DekamProjeLaboratuvarlar>();
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
            return View(new DekamProjeTakipCreateDto());
        }

        //çoklu view
        //buradaki amaç çoklu view model yapısını gondermek 
        //shopcart yeni yada eski hallerindede vardı sanırım 
        public IActionResult CreateNEW___Not_used()
        {
            TempData["Active"] = TempdataInfo.Category;
            ViewBag.GeneralTitle = "Proje Takip";
            ViewBag.DeneyHayvaniIrkCategories = new SelectList(DekamProjeDeneyHayvaniIrkRepo.GetAll(), "Id", "Name");
            ViewBag.DeneyHayvaniTurCategories = new SelectList(DekamProjeDeneyHayvaniTurRepo.GetAll(), "Id", "Name");
            ViewBag.LaboratuvarlarCategories = new SelectList(DekamProjeLaboratuvarlarRepo.GetAll(), "Id", "Name");
            //http://www.dotnet-stuff.com/tutorials/aspnet-mvc/way-to-use-multiple-models-in-a-view-in-asp-net-mvc
            DekamProjeTakipCreateDto vmDemo = new DekamProjeTakipCreateDto();
            vmDemo.allEmployees = DekamProjeTeknikDestekTalepTurRepo.GetAll();
            /* //view kodu
              @foreach (var item in Model.allEmployees)
            {
            <input type="checkbox" name="name" style="width:60px" value="@item.Name" /> @item.Price
            }

            */


            return View(vmDemo);
        }

        /// <summary>
        /// ajax result
        /// </summary>
        /// <param name="TurID"></param>
        /// <returns></returns>
        public JsonResult FiyatSec(string TurID)
        {

      
            var teknikDestekTalepTur = DekamProjeTeknikDestekTalepTurRepo.GetAll();
            try
            {
                var data = _deneyHayvaniIrkFiyatService.DeneyHayvaniIrkFiyatListesiTurID(int.Parse(TurID));

                if (data.Any())
                {
                    return Json(new { status = "ok", cartSelectItems = data, teknikDestekTalepTurleri = teknikDestekTalepTur });
                }
                else
                {
                    return Json(new { status = "empty" });
                }
            }
            catch (Exception)
            {
                List<SelectListItem> sonuc = new List<SelectListItem>();
                sonuc.Add(new SelectListItem
                {
                    Text = "Bir hata oluştu :(",
                    Value = "Default"
                });

                return Json(sonuc);
            }
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