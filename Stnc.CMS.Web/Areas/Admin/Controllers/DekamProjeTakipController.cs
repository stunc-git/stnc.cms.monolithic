
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.Business.Interfaces;

using Stnc.CMS.DTO.DTOs.CategoryDtos;
using Stnc.CMS.DTO.DTOs.DekamProjeTakipDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System;
using System.Collections.Generic;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class DekamProjeTakipController : BaseIdentityController
    {
        private readonly IDekamProjeTakipService _dekamProjeTakipService;
        private readonly IMapper _mapper;
        public DekamProjeTakipController(IDekamProjeTakipService dekamProjeTakipService, IMapper mapper, UserManager<AppUser> userManager) : base(userManager)
        {
            _mapper = mapper;
            _dekamProjeTakipService = dekamProjeTakipService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Category;
            return View(_mapper.Map<List<DekamProjeTakipListDto>>(_dekamProjeTakipService.GetAll()));
        }

        public IActionResult Create()
        {
            TempData["Active"] = TempdataInfo.Category;
            return View(new CategoryAddDto());
        }

        //[HttpPost]
        //public IActionResult AddCategory(CategoryAddDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _categoryservice.Kaydet(new Category()
        //        {
        //            Name = model.Name,
        //            Description = model.Description,
        //            Slug = SlugHelper(model.Name),
        //        });

        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        //public IActionResult UpdateCategory(int id)
        //{
        //    TempData["Active"] = TempdataInfo.Category;
        //    return View(_mapper.Map<CategoryUpdateDto>(_categoryservice.GetirIdile(id)));
        //}

        //[HttpPost]
        //public IActionResult UpdateCategory(CategoryUpdateDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _categoryservice.Guncelle(new Category
        //        {
        //            Id = model.Id,
        //            Name = model.Name,
        //            Description = model.Description,
        //            Slug = SlugHelper(model.Slug),
        //        });

        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        //public IActionResult DeleteCategory(int id)
        //{
        //    _categoryservice.Sil(new Category { Id = id });
        //    return Json(null);
        //}
    }
}