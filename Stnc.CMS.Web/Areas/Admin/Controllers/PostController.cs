﻿using AutoMapper;
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
using System.Linq;
using System.Threading.Tasks;

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
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
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
            
            if (ModelState.IsValid)
            {

                string pictureDb = null;
                if (picture != null)
                {
                    string pictureName = await Uploader(picture, "img");
                    pictureDb = pictureName;
                }


                var success = _postService.SaveReturn(new Posts
                {
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
                    using var context = new StncCMSContext();
                    var categoryBlogs = new CategoryBlogs
                    {
                        PostID = success.Id,
                        CategoryID = int.Parse(category)
                    };
                   
                  context.CategoryBlogs.Add(categoryBlogs);
              

                    context.SaveChanges();
                }



                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View(model);
        }


        public IActionResult UpdatePost(int id)
        {
            TempData["Active"] = TempdataInfo.Post;
            var post = _postService.GetirIdile(id);
            var catID = _categoryBlogService.GetCategoryPostIDListSingle(id);
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name", catID);
            return View(_mapper.Map<PostUpdateDto>(post));
        }



        [HttpPost]
        public async Task<IActionResult> UpdatePost(PostUpdateDto model, IFormFile picture)
        {
            var user = await GetUserLoginInfo();
   
            string pictureDb = null;

            string category = HttpContext.Request.Form["category"];

            using var context = new StncCMSContext();

            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    string pictureName = await Uploader(picture, "img");
                    pictureDb = pictureName;
                }


               _postService.Guncelle(new Posts
                {
                    Id = model.Id,
                    PostTitle = model.PostTitle,
                    PostContent = model.PostContent,
                    PostExcerpt = model.PostExcerpt,
                    Picture = pictureDb,
                    AppUserId = user.Id,
                });

                //TODO: many to many yapılacak
               
                if (category != "-1")
                {
                    var entity = context.CategoryBlogs.FirstOrDefault(item => item.PostID == model.Id);
                    if (entity != null)
                    {
                        entity.CategoryID = int.Parse(category);

                        context.CategoryBlogs.Update(entity);

                        context.SaveChanges();
                    }




                }


                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_postService.GetAll(), "Id", "Name", int.Parse(category));
            return View(model);
        }

        public IActionResult DeletePost(int id)
        {
            _postService.Sil(new Posts { Id = id });
            return Json(null);
        }


        //Deprecated
        private void AddUpdatePost(PostAddDto model, string picture, int user, string method)
        {

            var success = _postService.SaveReturn(new Posts
            {
                PostTitle = model.PostTitle,
                PostContent = model.PostContent,
                PostExcerpt = model.PostExcerpt,
                Picture = picture,
                AppUserId = user,
            });

            //TODO: many to many yapılacak
            string category = HttpContext.Request.Form["category"];
            if (category != "-1")
            {
                using var context = new StncCMSContext();
                var categoryBlogs = new CategoryBlogs
                {
                    PostID = success.Id,
                    CategoryID = int.Parse(category)
                };
                if (method == "add")
                    context.CategoryBlogs.Add(categoryBlogs);
                else
                    context.CategoryBlogs.Update(categoryBlogs);

                context.SaveChanges();
            }
        }

    }
}