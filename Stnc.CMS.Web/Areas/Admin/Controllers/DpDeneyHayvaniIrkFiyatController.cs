using AutoMapper;
using Core.Flash;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class DpDeneyHayvaniIrkFiyatController : BaseIdentityController
    {
        private readonly IDeneyHayvaniIrkFiyatService _deneyHayvaniIrkFiyatService;
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniIrkFiyat> Myrepo;
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniTur> DeneyHayvaniTurRepo;
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniIrk> DeneyHayvaniIrkRepo;
        private readonly IMapper _mapper;
        private readonly IFlasher f;

        //buranın ajax kontrolleri yazılacak
        public DpDeneyHayvaniIrkFiyatController(IFlasher f, IDeneyHayvaniIrkFiyatService deneyHayvaniIrkFiyatService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            this.f = f;
            _mapper = mapper;

            Myrepo = new EfGenericRepository<DekamProjeDeneyHayvaniIrkFiyat>();
            DeneyHayvaniTurRepo = new EfGenericRepository<DekamProjeDeneyHayvaniTur>();
            DeneyHayvaniIrkRepo = new EfGenericRepository<DekamProjeDeneyHayvaniIrk>();
            _deneyHayvaniIrkFiyatService = deneyHayvaniIrkFiyatService;
        }

        public IActionResult Index()
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Fiyatlandırma";

            TempData["Active"] = TempdataInfo.Category;

            return View(_mapper.Map<List<DeneyHayvaniIrkFiyatListAllDto>>(_deneyHayvaniIrkFiyatService.GetAll()));
        }

        public IActionResult Create()
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Fiyat Ekleme";

            TempData["Active"] = TempdataInfo.Category;

            ViewBag.HayvaniTurCategories = new SelectList(DeneyHayvaniTurRepo.GetAll(), "Id", "Name");

           // ViewBag.HayvaniIrkCategories = new SelectList(DeneyHayvaniIrkRepo.GetAll(), "Id", "Name");

            return View(new DeneyHayvaniIrkFiyatCreateDto()); //burası dto dan gelcek
          //  return View(new DekamProjeDeneyHayvaniIrkFiyat());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DekamProjeDeneyHayvaniIrkFiyat model)
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Fiyat Ekleme";
var us = new CultureInfo("en-US");
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                _deneyHayvaniIrkFiyatService.Kaydet(new DekamProjeDeneyHayvaniIrkFiyat
                {
                    Isım = model.Isım,
                    Fiyat = model.Fiyat,
                    AppUserId = user.Id,
                    DeneyHayvaniTurID = model.DeneyHayvaniTurID,
                    DeneyHayvaniIrkID = model.DeneyHayvaniIrkID,
                });

                f.Flash(Types.Success, "Kayıt başarı ile eklendi", dismissable: true);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Fiyat Düzenleme";

            TempData["Active"] = TempdataInfo.Category;

            var data = _deneyHayvaniIrkFiyatService.GetirIdile(id);
            if (data != null)
            {
                ViewBag.HayvaniTurCategories = new SelectList(DeneyHayvaniTurRepo.GetAll(), "Id", "Name", data.DeneyHayvaniTurID);
                ViewBag.HayvaniIrkCategories = new SelectList(DeneyHayvaniIrkRepo.GetAll(), "Id", "Name", data.DeneyHayvaniIrkID);
                return View(_mapper.Map<DeneyHayvaniIrkFiyatUpdateDto>(data));
            }
            else
            {
                f.Flash(Types.Danger, "Böyle bir veri bulunamadı", dismissable: true);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(DeneyHayvaniIrkFiyatUpdateDto model)
        {
            ViewBag.GeneralTitle = "Deney Hayvanı Fiyat Düzenleme";

            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                Myrepo.Guncelle(new DekamProjeDeneyHayvaniIrkFiyat
                {
                    Id = model.Id,
                    Isım = model.Isım,
                    Fiyat = model.Fiyat,
                    AppUserId = user.Id,
                    DeneyHayvaniTurID = model.DeneyHayvaniTurID,
                    DeneyHayvaniIrkID = model.DeneyHayvaniIrkID,
                });
                f.Flash(Types.Success, "Kayıt başarı ile düzenlendi", dismissable: true);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            f.Flash(Types.Success, "Kayıt başarı ile silindi", dismissable: true);
            _deneyHayvaniIrkFiyatService.Sil(new DekamProjeDeneyHayvaniIrkFiyat { Id = id });
            return Json(null);
        }
        public JsonResult IlcelerByIlId(string TurID)
        {
            var context = new StncCMSContext();
            var irklar = context.DekamProjeDeneyHayvaniIrk.Where(s => s.DeneyHayvaniTurID == int.Parse(TurID)).OrderBy(s => s.Name).
                Select(s => new { id = s.Id,  Content = s.Name }).ToList();
            return Json(irklar);
        }



        //[HttpPost]
        //public JsonResult IlIlce(int? ilID, string tip)
        //{
        //    //EntityFramework ile veritabanı modelimizi oluşturduk ve
        //    //IlilceDBEntities ile db nesnesi oluşturduk.
        //    //  IlilceDBEntities db = new IlilceDBEntities();

        //    var db = new StncCMSContext();
        //    //geriye döndüreceğim sonucListim
        //    List<SelectListItem> sonuc = new List<SelectListItem>();
        //    //bu işlem başarılı bir şekilde gerçekleşti mi onun kontrolunnü yapıyorum
        //    bool basariliMi = true;
        //    try
        //    {
        //        switch (tip)
        //        {
        //            case "ilGetir":
        //                //veritabanımızdaki iller tablomuzdan illerimizi sonuc değişkenimze atıyoruz
        //                foreach (var il in db.DekamProjeDeneyHayvaniIrk.ToList());
        //                {
        //                    sonuc.Add(new SelectListItem
        //                    {
        //                        Text = il.   ,
        //                        Value = il.IlID.ToString()
        //                    });
        //                }
        //                break;
        //            case "ilceGetir":
        //                //ilcelerimizi getireceğiz ilimizi selecten seçilen ilID sine göre
        //                foreach (var ilce in db.Ilceler.Where(il => il.IlID == ilID).ToList())
        //                {
        //                    sonuc.Add(new SelectListItem
        //                    {
        //                        Text = ilce.Ilce,
        //                        Value = ilce.IlceID.ToString()
        //                    });
        //                }
        //                break;

        //            default:
        //                break;

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //hata ile karşılaşırsak buraya düşüyor
        //        basariliMi = false;
        //        sonuc = new List<SelectListItem>();
        //        sonuc.Add(new SelectListItem
        //        {
        //            Text = "Bir hata oluştu :(",
        //            Value = "Default"
        //        });

        //    }
        //    //Oluşturduğum sonucları json olarak geriye gönderiyorum
        //    return Json(new { ok = basariliMi, text = sonuc });
        //}



    }
}