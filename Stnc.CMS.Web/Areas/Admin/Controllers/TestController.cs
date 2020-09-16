using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DTO.DTOs.CategoryDtos;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Web.BaseControllers;
using Stnc.CMS.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Stnc.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class TestController : BaseIdentityController
    {
        public TestController(UserManager<AppUser> userManager) : base(userManager)
        {
        }

        /*


        using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public class CityInformation
    {
        public int Id { get; set; }

        public int Population { get; set; }

        public string OtherName { get; set; }

        public string MayorName { get; set; }

        public List<City> City { get; set; }

    }
}


        using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public  class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityInformationId { get; set; }

        public CityInformation CityInformation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{

    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}

        using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AddressId { get; set; } // notice nullabe foreign key!
        public virtual Address Address { get; set; }
    }
}



        public DbSet<City> City { get; set; }
      public DbSet<CityInformation> CityInformation { get; set; }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }


                    // one to many Person - Address
            modelBuilder.Entity<Person>()
                .HasOne(x => x.Address).WithMany()
                .HasForeignKey(x => x.AddressId);

            // one to many Address - Person
            modelBuilder.Entity<Address>()
                .HasOne(x => x.Person).WithMany()
                .HasForeignKey(x => x.PersonId);


            modelBuilder.Entity<City>()
                .HasOne(x => x.CityInformation)
                .WithMany(I => I.City)
                .HasForeignKey(x => x.CityInformationId);

                    //modelBuilder.Entity<City>()
            //    .HasOne(e => e.CityInformation)
            //    .WithMany(e => e.City)
            //    .HasForeignKey<City>(e => e.CityInformationId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired();




        */
        public IActionResult City()
        {
            TempData["Active"] = TempdataInfo.Category;
            using var context = new StncCMSContext();
            //   return View(context.Set<DekamProjeDeneyHayvaniIrk>().OrderByDescending(I => I.Id).ToList());

            // var all = context.City.Include(I => I.CityInformation).OrderByDescending(I => I.Id).ToList();

            // var all = context.Blogs.Include(I => I.BlogImages).OrderByDescending(I => I.BlogId).ToList();

            // return View();

            //  return View(context.City.Where(c => c.CityInformation.Id == c.CityInformationId).ToList());

           //  AddOnePerson(context);

            // IList<City> orderedList  = context.City.Include(x=>x.CityInformation).ToList();



            //  List<Person> orderedList = context.Persons.Include(x=>x.Address).ToList();




           // orderedList.ForEach(p => Console.WriteLine($"{p.Address.StreetName:C} - {p.Name} )"));
           // orderedList.ForEach(p => Console.WriteLine($"{p.Address.StreetName:C} - {p.Name} )"));


            //foreach (Person person in orderedList)
            //{
            //    Console.WriteLine($"   {person.Address.StreetName}");
            //}

            //Console.WriteLine("We have " + c.Count + " people in db.");
            //foreach (var item in orderedList)
            //    Console.WriteLine("---------------------------");
            //    Console.Write(orderedList);


            //Console.WriteLine(c);
            //Console.ReadKey();

            return Ok();
          //    return View(orderedList);
        }


        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Category;
            using var context = new StncCMSContext();
            //   return View(context.Set<DekamProjeDeneyHayvaniIrk>().OrderByDescending(I => I.Id).ToList());

            // var all = context.City.Include(I => I.CityInformation).OrderByDescending(I => I.Id).ToList();

            // var all = context.Blogs.Include(I => I.BlogImages).OrderByDescending(I => I.BlogId).ToList();

            // return View();

            //  return View(context.City.Where(c => c.CityInformation.Id == c.CityInformationId).ToList());

            // AddOnePerson(context);

            //var people = context.Persons.Include(x => x.Address).ToList();
            //Console.WriteLine("We have " + people.Count + " people in db.");

            //Console.WriteLine("done.");
            //Console.ReadKey();

            //return Ok(people.Count);
            return Ok("");
        }

        private static void AddOnePerson(StncCMSContext context)
        {
            // We need to create new Person without AddressId, save that to db to get its Id
            // and then create Address and fill both ends of relationship (PersonId and AddressId)
            // That's why Person.AddressId is nullable.



            //var john = new Person { Name = "john" };
            //context.Persons.Add(john);
            //context.SaveChanges();

            //var address = new Address() { StreetName = "street", PersonId = john.Id };
            //john.Address = address;
            //context.Addresses.Add(address);
            //context.SaveChanges();

        }


        public IActionResult Create()
        {
            TempData["Active"] = TempdataInfo.Category;
            return View(new DekamProjeDeneyHayvaniIrk());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DekamProjeDeneyHayvaniIrk model)
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                using var context = new StncCMSContext();
                context.Set<DekamProjeDeneyHayvaniIrk>().Add(new DekamProjeDeneyHayvaniIrk()
                {
                    Name = model.Name,
                    AppUserId = user.Id,
                });
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["Active"] = TempdataInfo.Category;
            using var context = new StncCMSContext();
            return View(context.Set<DekamProjeDeneyHayvaniIrk>().Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(DekamProjeDeneyHayvaniIrk model)
        {
            var user = await GetUserLoginInfo().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                using var context = new StncCMSContext();
                var std = context.DekamProjeDeneyHayvaniIrk.First<DekamProjeDeneyHayvaniIrk>();
                std.Name = model.Name;
                std.AppUserId = user.Id;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            using var context = new StncCMSContext();
            context.Set<DekamProjeDeneyHayvaniIrk>().Remove(new DekamProjeDeneyHayvaniIrk { Id = id });
            context.SaveChanges();
            return Json(null);
        }
    }
}