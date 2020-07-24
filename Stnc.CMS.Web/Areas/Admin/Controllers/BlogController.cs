using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DTO.DTOs.PostDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.StringInfo;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class BlogController : Controller
    {

        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public BlogController(IPostService postService,  IMapper mapper)
        {
            _mapper = mapper;
   
            _postService = postService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Post;
            return View(_mapper.Map<List<PostListAllDto>>(_postService.PostList()));
        }
     


        /*
        public IActionResult EkleGorev()
        {
            TempData["Active"] = TempdataInfo.Post;

            ViewBag.Aciliyetler = new (_postService.GetirHepsi(), "Id", "Tanim");
            return View(new GorevAddDto());
        }

        [HttpPost]
        public IActionResult EkleGorev(GorevAddDto model)
        {
            if (ModelState.IsValid)
            {
                _gorevService.Kaydet(new Gorev
                {
                    Aciklama = model.Aciklama,
                    Ad = model.Ad,
                    AciliyetId = model.AciliyetId,

                });

                return RedirectToAction("Index");
            }
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim");
            return View(model);
        }
        */


        
    }
}