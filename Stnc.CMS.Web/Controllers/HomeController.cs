using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DTO.DTOs.AppUserDtos;
using Stnc.CMS.DTO.DTOs.PostDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using System;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomLogger _customLogger;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public HomeController(IPostService postService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomLogger customLogger, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
            _customLogger = customLogger;
            _signInManager = signInManager;
            _postService = postService;
        }

        [Route("icerik/{slug}")]
        public IActionResult GetPostDetails(string Slug)
        {
            var post = _postService.GetSlugPost(Slug);
            if (post == null)
            {
                Response.StatusCode = 404;
                return View("PageNotFound");
            }
            else
            {
                return View("~/Views/Post/GetPostDetails.cshtml", _mapper.Map<PostUpdateDto>(post));
                //return RedirectToAction("Index");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("adminpanel")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("iletism")]
        public IActionResult İletisim()
        {
            return View();
        }

        [Route("icerik/yonetim")]
        public IActionResult Yonetim()
        {
            return View("~/Views/Staff/Yonetim.cshtml");
        }

        [Route("icerik/komisyon-uyeleri")]
        public IActionResult KomisyonUyeleri()
        {
            return View("~/Views/Staff/KomisyonUyeleri.cshtml");
        }

        [Route("icerik/personel")]
        public IActionResult Personel()
        {
            return View("~/Views/Staff/Personel.cshtml");
        }


        [Route("galeri")]
        public IActionResult Galeri()
        {
            return View("~/Views/Gallery/Index.cshtml");
        }

        //https://colorlib.com/preview/theme/wiser/single-blog.html
        [Route("demo-template/{UsersName}")]
        public IActionResult DemoTemplate(string UsersName)
        {
            ViewBag.UsersName = UsersName;

            return View("~/Views/Post/DemoTemplate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName).ConfigureAwait(false);
                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false).ConfigureAwait(false);
                    if (identityResult.Succeeded)
                    {
                        var roller = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

                        if (roller.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View("Login", model);
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname
                };
                var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);

                if (result.Succeeded)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "Member").ConfigureAwait(false);
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    HataEkle(addRoleResult.Errors);
                }
                HataEkle(result.Errors);
            }
            return View(model);
        }

        public async Task<IActionResult> CikisYap()
        {
            await _signInManager.SignOutAsync().ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Sayfa bulunamadı";
            }

            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _customLogger.LogError($"Hatanın oluştuğu yer :{exceptionHandler.Path}\nHatanın mesajı :{exceptionHandler.Error.Message}\nStack Trace :{exceptionHandler.Error.StackTrace}");

            ViewBag.Path = exceptionHandler.Path;
            ViewBag.Message = exceptionHandler.Error.Message;

            return View();
        }

        public void Hata()
        {
            throw new Exception("Bu bir hata");
        }
    }
}