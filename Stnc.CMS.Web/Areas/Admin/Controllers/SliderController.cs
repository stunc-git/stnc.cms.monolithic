using AutoMapper;
using Core.Flash;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DTO.DTOs.SliderDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class SliderController : BaseIdentityController
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        private readonly IFlasher f;

        public SliderController(IFlasher f, ISliderService sliderService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            this.f = f;
            _mapper = mapper;
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Slider;
            return View(_mapper.Map<List<SliderListAllDto>>(_sliderService.SliderList()));
        }

        public IActionResult AddSlider()
        {
            TempData["Active"] = TempdataInfo.Post;
            return View(new SliderAddDto());
        }



        [HttpPost]
        public async Task<IActionResult> AddSlider(SliderAddDto model, IFormFile picture)
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                string pictureDb = null;
                if (picture != null)
                {
                    string pictureName = await Uploader(picture, "slider").ConfigureAwait(false);
                    pictureDb = pictureName;
                }

                _sliderService.Kaydet(new Slider
                {
                    Caption = model.Caption,
                    Excerpt=model.Excerpt,
                    UrlAddress = model.UrlAddress,
                    UrlType = 1,
                    Picture = pictureDb,
                    Status = true,
                    AppUserId = user.Id,
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }


    public IActionResult UpdateSlider(int id)
    {
        TempData["Active"] = TempdataInfo.Slider;
        var post = _sliderService.GetirIdile(id);
        if (post != null)
        {
            return View(_mapper.Map<SliderUpdateDto>(post));
        }
        else
        {
            f.Flash(Types.Danger, "Böyle bir veri bulunamadı", dismissable: true);
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSlider(SliderUpdateDto model, IFormFile picture)
    {
        var user = await GetUserLoginInfo().ConfigureAwait(false);

        string pictureDb = null;

        using var context = new StncCMSContext();

        if (ModelState.IsValid)
        {
            if (picture != null)
            {
                string pictureName = await Uploader(picture, "img").ConfigureAwait(false);
                pictureDb = pictureName;
            }
                var now = DateTime.UtcNow; // current datetime
                _sliderService.Guncelle(new Slider
                {
                    Caption = model.Caption,
                    UrlAddress = model.UrlAddress,
                    Excerpt = model.Excerpt,
                    UrlType = 1,
                    Picture = pictureDb,
                    UpdatedAt = now,
                    Status = true,
                    AppUserId = user.Id,
                });

                return RedirectToAction("Index");
        }

        return View(model);
    }

    public IActionResult DeletePost(int id)
    {
        _sliderService.Sil(new Slider { Id = id });
        return Json(null);
    }
}
}