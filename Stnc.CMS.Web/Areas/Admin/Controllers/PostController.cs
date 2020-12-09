using AutoMapper;
using Core.Flash;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
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
    public class PostController : BaseIdentityController
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IFlasher f;

        public PostController(IFlasher f, IPostService postService, ICategoryService categoryService,
            UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            this.f = f;
            _mapper = mapper;
            _postService = postService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Post;
            ViewBag.GeneralTitle = "Sayfalar";
            return Json(_mapper.Map<List<PostListAllDto>>(_postService.PostList()));
        }

        public IActionResult AddPost()
        {
            TempData["Active"] = TempdataInfo.Post;
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View(new PostAddDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(PostAddDto model, IFormFile picture)
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);
            ViewBag.GeneralTitle = "Sayfa Ekleme";
            if (ModelState.IsValid)
            {
                string pictureDb = null;
                if (picture != null)
                {
                    pictureDb = await Uploader(picture, "img").ConfigureAwait(false);
                }

                 _postService.SaveReturn(new Posts
                {
                    PostTitle = model.PostTitle,
                    PostContent = model.PostContent,
                    PostExcerpt = model.PostExcerpt,
                    PostSlug = SlugHelper(model.PostTitle),
                    Picture = pictureDb,
                    AppUserId = user.Id,
                     CategoryId = model.CategoryId
                 });

                //string CategoryID = HttpContext.Request.Form["CategoryID"];
                //if (CategoryID != "-1")
                //{
                //    using var context = new StncCMSContext();
                //    var categoryBlogs = new CategoryBlogs
                //    {
                //        PostID = success.Id,
                //        CategoryID = int.Parse(CategoryID)
                //    };

                //  context.CategoryBlogs.Add(categoryBlogs);

                //  context.SaveChanges();
                //}
                f.Flash(Types.Success, "Kaydınız başarı ile eklendi", dismissable: true);

                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View(model);
        }


        public IActionResult UpdatePost(int id)
        {
            TempData["Active"] = TempdataInfo.Post;
            ViewBag.GeneralTitle = "Sayfa Ekleme";
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
        public async Task<IActionResult> UpdatePost(PostUpdateDto model, IFormFile picture)
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);
            ViewBag.GeneralTitle = "Sayfa Düzenleme";
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

                //if (CategoryID != "-1")
                //{
                //    var entity = context.CategoryBlogs.FirstOrDefault(item => item.PostID == model.Id);
                //    if (entity != null)
                //    {
                //        entity.CategoryID = int.Parse(CategoryID);

                //        context.CategoryBlogs.Update(entity);

                //        context.SaveChanges();
                //    }
                //}
                f.Flash(Types.Success, "Kaydınız başarı ile düzenlendi", dismissable: true);

                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_postService.GetAll(), "Id", "Name", model.CategoryId);
            return View(model);
        }

        public IActionResult DeletePost(int id)
        {
            f.Flash(Types.Success, "Kaydınız başarı ile silindi", dismissable: true);

            _postService.Sil(new Posts { Id = id });
            return Json(null);
        }


        public async Task<IActionResult> UploadFile(IFormFile aUploadedFile)
        {
            //todo: burada json return donmesi gerekli
            string name = await Uploader(aUploadedFile, "file").ConfigureAwait(false);
            string vReturnImagePath = "/upload/file/" + name;
            return Ok(vReturnImagePath);
        }
    }
}