using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class PostController : BaseIdentityController
    {

        private readonly IPostService _postService;

        private readonly ICategoryService _categoryService;
        private readonly ICategoryBlogService _categoryBlogService;
        private readonly IMapper _mapper;
        public PostController(IPostService postService, ICategoryService categoryService, ICategoryBlogService categoryBlogService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
            _postService = postService;
            _categoryService = categoryService;
            _categoryBlogService = categoryBlogService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Post;
            return View(_mapper.Map<List<PostListAllDto>>(_postService.PostList()));
        }

        public IActionResult AddPost()
        {
            TempData["Active"] = TempdataInfo.Post;
            ViewBag.Categories = new SelectList(_categoryService.GetirHepsi(), "Id", "Name");
            return View(new PostAddDto());
        }


        public async Task<IActionResult> UploadFile(IFormFile aUploadedFile)
        {
            //todo: burada json return donmesi gerekli 
            string name=await Uploader(aUploadedFile, "file");
           string  vReturnImagePath = "/upload/file/" + name;
            return Ok(vReturnImagePath);
        }



        [HttpPost]
        public async Task<IActionResult> AddPost(PostAddDto model, IFormFile picture)
        {
            var user = await GetUserLoginInfo();
            string pictureDb=null;
            if (ModelState.IsValid)
            {

                if (picture != null)
                {
                    string pictureName = await Uploader(picture,"img");
                    pictureDb  = pictureName;
                }

            var  success = _postService.SaveReturn(new Posts {
                    PostTitle = model.PostTitle,
                    PostContent = model.PostContent,
                    PostExcerpt = model.PostExcerpt,
                    Picture = pictureDb,
                    AppUserId = user.Id,
                });

                //TODO: many to many yapılacak 
                string category = HttpContext.Request.Form["category"];
                if (category != "-1")
                {
                    using (var context = new StncCMSContext())
                    {
                        var categoryBlogs = new CategoryBlogs
                        {
                            PostID = success.Id,
                            CategoryID = int.Parse(category)
                        };
                        context.CategoryBlogs.Add(categoryBlogs);
                        context.SaveChanges();
                    }
                }


                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryService.GetirHepsi(), "Id", "Name");
            return View(model);
        }

        
        public IActionResult UpdatePost(int id)
        {
            TempData["Active"] = TempdataInfo.Post;
            var post = _postService.GetirIdile(id);
            var catList = _categoryBlogService.GetCategoryPostIDList(id);
         //   ViewBag.Categories = new SelectList(_categoryService.GetirHepsi(), "Id", "Tanim", post.AciliyetId);


            return View(_mapper.Map<PostUpdateDto>(post));



            //TempData["Active"] = TempdataInfo.Gorev;
            //var gorev = _gorevService.GetirIdile(id);
            //ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim", gorev.AciliyetId);
            //return View(_mapper.Map<GorevUpdateDto>(gorev));


        }
        /*
        [HttpPost]
        public IActionResult GuncelleGorev(GorevUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _gorevService.Guncelle(new Gorev()
                {
                    Id = model.Id,
                    Aciklama = model.Aciklama,
                    AciliyetId = model.AciliyetId,
                    Ad = model.Ad

                });

                return RedirectToAction("Index");
            }
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim", model.AciliyetId);
            return View(model);
        }

        public IActionResult SilGorev(int id)
        {
            _gorevService.Sil(new Gorev { Id = id });
            return Json(null);
        }
        */

    }
}