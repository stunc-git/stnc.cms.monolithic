using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.Business.Interfaces;

using Stnc.CMS.DTO.DTOs.CategoryDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.StringInfo;
using System.Collections.Generic;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryservice;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryservice, IMapper mapper)
        {
            _mapper = mapper;
            _categoryservice = categoryservice;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Category;          
            return View(_mapper.Map<List<CategoryListDto>>(_categoryservice.GetirHepsi()));

 
        }

        public IActionResult AddCategory()
        {
            TempData["Active"] = TempdataInfo.Category;
            return View(new CategoryAddDto());
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryAddDto model)
        {
            if (ModelState.IsValid)
            {
                _categoryservice.Kaydet(new Category()
                {
                    Name = model.Name
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }
        /*
        public IActionResult GuncelleAciliyet(int id)
        {
            TempData["Active"] = TempdataInfo.Aciliyet;
            return View(_mapper.Map<AciliyetUpdateDto>(_aciliyetService.GetirIdile(id)));
        }

        [HttpPost]
        public IActionResult GuncelleAciliyet(AciliyetUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Guncelle(new Aciliyet
                {
                    Id = model.Id,
                    Tanim = model.Tanim
                });

                return RedirectToAction("Index");
            }
            return View(model);
           
        }*/
    }
}