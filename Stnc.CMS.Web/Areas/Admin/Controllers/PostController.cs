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
        private readonly IMapper _mapper;
        public PostController(IPostService postService, ICategoryService categoryService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
   
            _postService = postService;
            _categoryService = categoryService;
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



        [HttpPost]
        public async Task<IActionResult> AddPost(PostAddDto model, IFormFile picture)
        {
            var user = await GetirGirisYapanKullanici();
            string pictureDb=null;
            if (ModelState.IsValid)
            {

                if (picture != null)
                {
                    string FileExtension = Path.GetExtension(picture.FileName);
                    string pictureName = Guid.NewGuid() + FileExtension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + pictureName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await picture.CopyToAsync(stream);
                    }

                    pictureDb  = pictureName;
                }

               // model.Picture = pictureDb;

                _postService.Kaydet(new Posts
                {
                    PostTitle = model.PostTitle,
                    PostContent = model.PostContent,
                    PostExcerpt = model.PostExcerpt,
                    Picture = pictureDb,
                    AppUserId = user.Id,
                    //AciliyetId = model.AciliyetId,

                }); ;

                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryService.GetirHepsi(), "Id", "Name");
            return View(model);
        }
        



    }
}