using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Slugify;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.BaseControllers
{
    public class BaseIdentityController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;

        public BaseIdentityController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<AppUser> GetUserLoginInfo()
        {
            return await _userManager.FindByNameAsync(User.Identity.Name).ConfigureAwait(false);
        }

        protected string SlugHelper(string value)
        {
            SlugHelper.Config config = new SlugHelper.Config();
            config.StringReplacements.Add("ı", "i");
            SlugHelper helper = new SlugHelper(config);
            return helper.GenerateSlug(value);
        }

        protected async Task<string> Uploader(IFormFile file, string pathName)
        {
            string FileExtension = Path.GetExtension(file.FileName);
            string FileRealName = Path.GetFileNameWithoutExtension(file.FileName);
            string fileName = SlugHelper(FileRealName) + FileExtension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + pathName + "/" + fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream).ConfigureAwait(false);
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