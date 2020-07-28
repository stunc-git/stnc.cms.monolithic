using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.Web.BaseControllers
{
    public class BaseIdentityController : Controller
    {
       
        protected readonly UserManager<AppUser> _userManager;
        public BaseIdentityController(UserManager<AppUser> userManager)
        {

            _userManager = userManager;
        }

        protected async Task<AppUser> GetirGirisYapanKullanici()
        {
          return  await _userManager.FindByNameAsync(User.Identity.Name);
        }


        protected async  Task<string> Uploader(IFormFile file,string pathName)
        {
            string FileExtension = Path.GetExtension(file.FileName);
            string fileName = Guid.NewGuid() + FileExtension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/"+ pathName+"/" + fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }



        protected void HataEkle(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
    }
}