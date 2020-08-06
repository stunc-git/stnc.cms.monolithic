using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin").ConfigureAwait(false);
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" }).ConfigureAwait(false);
            }

            var memberRole = await roleManager.FindByNameAsync("Member").ConfigureAwait(false);
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" }).ConfigureAwait(false);
            }

            var adminUser = await userManager.FindByNameAsync("selman").ConfigureAwait(false);
            if (adminUser==null)
            {
                AppUser user = new AppUser
                {
                    Name = "selman",
                    Surname = "tunç",
                    UserName = "stnc",
                    Email = "selmantunc@gmail.com"
                };
                await userManager.CreateAsync(user,"1").ConfigureAwait(false);
                await userManager.AddToRoleAsync(user, "Admin").ConfigureAwait(false);
            }
/*
            var memberUser = await userManager.FindByNameAsync("member");
            if (memberUser == null)
            {
                AppUser member = new AppUser
                {
                    Name = "selman2",
                    Surname = "tunç",
                    UserName = "member",
                    Email = "selmantunc@yahoo.com"
                };
                await userManager.CreateAsync(member, "1");
                await userManager.AddToRoleAsync(member, "Member");
            }
*/
        }
    }
}
