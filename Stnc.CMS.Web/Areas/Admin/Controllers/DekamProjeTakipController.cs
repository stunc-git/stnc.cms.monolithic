using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.DTO.DTOs.DekamProjeTakipDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Stnc.CMS.Web.Areas.Admin.Controllers
{

    public class DekamProjeToCart
    {
     //   public int BaseId { get; set; }
        public string ProjeYurutucusu { get; set; }
        public string ProjeYurutuKurumu { get; set; }
        public string ProjeYurutuTelefon { get; set; }
        public string SorumluArastirmaci { get; set; }
        public string SorumluArastirmaciTelefon { get; set; }
        public string EtikKurulOnayNumarasi { get; set; }
        public DateTime EtikKurulOnayTarihi { get; set; }
        public DateTime ProjeBaslangicTarihi { get; set; }
        public DateTime ProjeBitisTarihi { get; set; }
        public int LaboratuvarID { get; set; }
        public DateTime LaboratuvarBaslangicTarihi { get; set; }
        public DateTime LaboratuvarBitisTarihi { get; set; }
    }


    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class DekamProjeTakipController : BaseIdentityController
    {
        private readonly IDekamProjeTakipService _dekamProjeTakipService;
        private readonly IDeneyHayvaniIrkFiyatService _deneyHayvaniIrkFiyatService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniIrk> DekamProjeDeneyHayvaniIrkRepo;
        private readonly EfGenericRepository<DekamProjeDeneyHayvaniTur> DekamProjeDeneyHayvaniTurRepo;
        private readonly EfGenericRepository<DekamProjeLaboratuvarlar> DekamProjeLaboratuvarlarRepo;
        private readonly EfGenericRepository<DekamProjeTeknikDestekTalepTur> DekamProjeTeknikDestekTalepTurRepo;


        public DekamProjeTakipController(IDekamProjeTakipService dekamProjeTakipService, IDeneyHayvaniIrkFiyatService deneyHayvaniIrkFiyatService, IDosyaService dosyaService, IMapper mapper, UserManager<AppUser> userManager) : base(userManager)
        {
            _mapper = mapper;
            _dekamProjeTakipService = dekamProjeTakipService;
            _deneyHayvaniIrkFiyatService = deneyHayvaniIrkFiyatService;
            DekamProjeDeneyHayvaniIrkRepo = new EfGenericRepository<DekamProjeDeneyHayvaniIrk>();

            DekamProjeDeneyHayvaniTurRepo = new EfGenericRepository<DekamProjeDeneyHayvaniTur>();
            DekamProjeLaboratuvarlarRepo = new EfGenericRepository<DekamProjeLaboratuvarlar>();
            DekamProjeTeknikDestekTalepTurRepo = new EfGenericRepository<DekamProjeTeknikDestekTalepTur>();
            _dosyaService = dosyaService;

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
            ViewBag.Name = HttpContext.Session.GetString("DekamSessionCartData");
            ViewBag.DeneyHayvaniIrkCategories = new SelectList(DekamProjeDeneyHayvaniIrkRepo.GetAll(), "Id", "Name");
            ViewBag.DeneyHayvaniTurCategories = new SelectList(DekamProjeDeneyHayvaniTurRepo.GetAll(), "Id", "Name");
            ViewBag.LaboratuvarlarCategories = new SelectList(DekamProjeLaboratuvarlarRepo.GetAll(), "Id", "Name");
            return View(new DekamProjeTakipCreateDto());
        }

        [HttpPost]
        //[Route("/ShoppingCart/Add")]
        //TODO: henuz bitmedi  
        public async Task<JsonResult> Save(DekamProjeToCart addData)
        {
            AppUser user = await GetUserLoginInfo();

            int? returnId;
            returnId = 0;
            //projeYurutucusu

            var returnData = _dekamProjeTakipService.SaveReturn(
                 new DekamProjeTakip {
                     ProjeYurutucusu = addData.ProjeYurutucusu,
                     ProjeBaslangicTarihi=addData.ProjeBaslangicTarihi,
                     ProjeBitisTarihi=addData.ProjeBitisTarihi,
                     ProjeYurutukurumu=addData.ProjeYurutuKurumu,
                     ProjeYurutuTelefon=addData.ProjeYurutuTelefon,
                     SorumluArastirmaci=addData.SorumluArastirmaci,
                     SorumluArastirmaciTelefon=addData.SorumluArastirmaciTelefon,
                     EtikKurulOnayNumarasi=addData.EtikKurulOnayNumarasi,
                     EtikKurulOnayTarihi=addData.EtikKurulOnayTarihi,
                     LaboratuvarID=addData.LaboratuvarID,
                     LaboratuvarBaslangicTarihi=addData.LaboratuvarBaslangicTarihi,
                     LaboratuvarBitisTarihi=addData.LaboratuvarBitisTarihi,
                     AppUserId=user.Id
                 } );

            returnId = returnData.Id;
            string[] destektalepturleris;
            destektalepturleris = HttpContext.Session.GetString("DekamSessionCartData").Split(',');

            foreach (string part in destektalepturleris)
            {
                /*
                destekjson.Add(new DestekTalepTurleriJson()
                {
                    ID = returndata.Id,
                    Name = returndata.Name,
                    Price = returndata.Price,
                });
                */
            }

            return Json(new { status = "ok" });


        }
        //[HttpPost]
        //public async Task<IActionResult> Store(PostAddDto model)
        //{

        //}


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


        public IActionResult GetirPdf()
        {
            var path = _dosyaService.AktarMockup();
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
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