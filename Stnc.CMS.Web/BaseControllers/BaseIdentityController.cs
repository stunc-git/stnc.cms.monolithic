using System;
using System.Collections.Generic;
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

        protected async  Task<AppUser> GetLoginUserID()
        {
         ///   return  User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
        //var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

           return await _userManager.GetUserAsync(User);
           // string userEmail = applicationUser?.Email; // will give the user's Email


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