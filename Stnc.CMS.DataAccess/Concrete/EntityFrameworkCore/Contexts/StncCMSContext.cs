using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Stnc.CMS.Entities.Concrete;
using System.IO;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class StncCMSContext : IdentityDbContext<AppUser, AppRole, int>
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=bloggg; user id=sa; password=1;");
            // optionsBuilder.UseSqlServer("server=.; database=cmsCore1; integrated security=True;");
            //kaynak https://www.gencayyildiz.com/blog/asp-net-core-3-0-cok-katmanli-mimaride-migration-islemleri/
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Stnc.CMS.Web"))
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("SQLProvider"));

            base.OnConfiguring(optionsBuilder);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GorevMap());
            modelBuilder.ApplyConfiguration(new AciliyetMap());
            modelBuilder.ApplyConfiguration(new RaporMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CategoryPostsMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new SliderMap());
            modelBuilder.ApplyConfiguration(new DekamProjeTakipMap());
            modelBuilder.ApplyConfiguration(new DekamProjeDeneyHayvaniTurMap());
            modelBuilder.ApplyConfiguration(new DekamProjeDeneyHayvaniIrkMap());
            modelBuilder.ApplyConfiguration(new DekamProjeLaboratuvarlarMap());
            modelBuilder.ApplyConfiguration(new DekamProjeTeknikDestekTalepSureMap());
            modelBuilder.ApplyConfiguration(new DekamProjeDeneyHayvanSayisiMap());



            modelBuilder.Entity<StShoppingCartItem>()
                .HasOne(sci => sci.StCart);


            //     modelBuilder.Entity<City>()
            //    .HasOne(e => e.CityInformation)
            //    .WithMany(e => e.City)
            //    .HasForeignKey<City>(e => e.CityInformationId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired();



            //one to many Person - Address
            modelBuilder.Entity<Person>()
                .HasOne(x => x.Address).WithMany()
                .HasForeignKey(x => x.AddressId);


            // one to many Address - Person
            modelBuilder.Entity<Address>()
                .HasOne(x => x.Person).WithMany()
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<City>()
          .HasOne(x => x.CityInformation).WithMany().HasForeignKey(x => x.CityInformationId);

         //   modelBuilder.Entity<Cheese>()
         //.HasOne(x => x.CheeseCategory).WithMany(e => e.Cheese).HasForeignKey(x => x.CatID);





//modelBuilder.Entity<Cheese>()
//            .HasOne<CheeseCategory>(e => e.CheeseCategory)
//            .WithMany(d => d.Cheese)
//            .HasForeignKey(e => e.CatID).IsRequired(false);


            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }
        public DbSet<Aciliyet> Aciliyetler { get; set; }
        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<Bildirim> Bildirimler { get; set; }

        public DbSet<Slider> Slider { get; set; }
        public DbSet<Category> Categories { get; set; }
      //  public DbSet<CategoryBlogs> CategoryBlogs { get; set; }
        public DbSet<Comments> Comments { get; set; }

        // DEKAM Kurum içi proje takip
        public DbSet<DekamProjeTakip> DekamProjeTakip { get; set; }
        public DbSet<DekamProjeLaboratuvarlar> DekamProjeLaboratuvarlar { get; set; }
        public DbSet<DekamProjeTeknikDestekTalepTur> DekamProjeTeknikDestekTalepTur { get; set; }
        public DbSet<DekamProjeTeknikDestekTalepSure> DekamProjeTeknikDestekTalepSure { get; set; }
        public DbSet<DekamProjeTeknikDestekTalepHayvanSayisi> DekamProjeDeneyHayvanSayisi { get; set; }
        public DbSet<DekamProjeDeneyHayvaniTur> DekamProjeDeneyHayvaniTur { get; set; }
        public DbSet<DekamProjeDeneyHayvaniIrk> DekamProjeDeneyHayvaniIrk { get; set; }

        public DbSet<StShoppingCartItem> StShoppingCartItem { get; set; }
        public DbSet<StCart> StCart { get; set; }

        public DbSet<City> City { get; set; }
        public DbSet<CityInformation> CityInformation { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }


        //public DbSet<Cheese> Cheeses { get; set; }
        //public DbSet<CheeseCategory> CheeseCategories { get; set; }



    }
}