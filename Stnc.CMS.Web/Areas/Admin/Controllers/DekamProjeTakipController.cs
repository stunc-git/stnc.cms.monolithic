using AutoMapper;
using Core.Flash;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DTO.DTOs.DekamProjeTakipDtos;
using Stnc.CMS.DTO.DTOs.PostDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class DekamProjeTakipController : BaseIdentityController
    {
        private readonly IDekamProjeTakipService _dekamProjeTakipService;
        private readonly IMapper _mapper;
        private readonly IFlasher f;

        public DekamProjeTakipController(IFlasher f, IDekamProjeTakipService dekamProjeTakipService,   UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            this.f = f;
            _mapper = mapper;
            _dekamProjeTakipService = dekamProjeTakipService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Post;
            return View(_mapper.Map<List<DekamProjeTakipListDto>>(_dekamProjeTakipService.DekamProjeTakipServiceList()));
        }

        public IActionResult Create()
        {
            TempData["Active"] = TempdataInfo.Post;
       //     ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View(new DekamProjeTakipCreateDto());
        }
        /*
        [HttpPost]
        public async Task<IActionResult> Create(PostAddDto model, IFormFile picture)
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            if (ModelState.IsValid)
            {


                 _postService.SaveReturn(new Posts
                {
                    PostTitle = model.PostTitle,
                    PostContent = model.PostContent,
                    PostExcerpt = model.PostExcerpt,
                    PostSlug = SlugHelper(model.PostTitle),
                    AppUserId = user.Id,
                     CategoryId = model.CategoryId
                 });

                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["Active"] = TempdataInfo.Post;
            var post = _postService.GetirIdile(id);
            if (post != null)
            {
               // var catID = _categoryBlogService.GetCategoryPostIDListSingle(id);
                ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name", post.CategoryId);
                return View(_mapper.Map<PostUpdateDto>(post));
            }
            else
            {
                f.Flash(Types.Danger, "Böyle bir veri bulunamadı", dismissable: true);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(PostUpdateDto model, IFormFile picture)
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            string pictureDb = null;

          //  string CategoryID = HttpContext.Request.Form["CategoryID"];

            using var context = new StncCMSContext();

            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    string pictureName = await Uploader(picture, "img").ConfigureAwait(false);
                    pictureDb = pictureName;
                }

                _postService.Guncelle(new Posts
                {
                    Id = model.Id,
                    PostTitle = model.PostTitle,
                    PostContent = model.PostContent,
                    PostExcerpt = model.PostExcerpt,
                    PostSlug = SlugHelper(model.PostSlug),
                    Picture = pictureDb,
                    AppUserId = user.Id,
                    CategoryId = model.CategoryId
                });

                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_postService.GetAll(), "Id", "Name", model.CategoryId);
            return View(model);
        }

        public IActionResult DeletePost(int id)
        {
            _postService.Sil(new Posts { Id = id });
            return Json(null);
        }
        */
    }
}