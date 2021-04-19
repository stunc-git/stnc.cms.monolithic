using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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

            optionsBuilder
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
              .UseSqlServer(config.GetConnectionString("SQLProvider"));
            //   optionsBuilder.UseSqlServer(config.GetConnectionString("HomeSQLProvider"));
            // optionsBuilder.UseMySql(config.GetConnectionString("MysqlConnection"));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.ApplyConfiguration(new GorevMap());
          //  modelBuilder.ApplyConfiguration(new AciliyetMap());
          //  modelBuilder.ApplyConfiguration(new RaporMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());

            modelBuilder.ApplyConfiguration(new SiparislerMap());
            modelBuilder.ApplyConfiguration(new DekamProjeDeneyHayvaniTurMap());
            modelBuilder.ApplyConfiguration(new DekamProjeDeneyHayvaniIrkMap());
            modelBuilder.ApplyConfiguration(new DekamProjeLaboratuvarlarMap());
            //modelBuilder.ApplyConfiguration(new OptionsMap());
            modelBuilder.ApplyConfiguration(new StShoppingCartItemMap());
            modelBuilder.ApplyConfiguration(new DekamProjeDeneyHayvaniIrkFiyatMap());
         
            base.OnModelCreating(modelBuilder);
        }

       
    
 
     




        // DEKAM Kurum içi proje takip
        public DbSet<Siparisler> Siparisler { get; set; }

        public DbSet<DekamProjeLaboratuvarlar> DekamProjeLaboratuvarlar { get; set; }
        public DbSet<DekamProjeTeknikDestekTalepTur> DekamProjeTeknikDestekTalepTur { get; set; }

        public DbSet<DekamProjeDeneyHayvaniTur> DekamProjeDeneyHayvaniTur { get; set; }

        public DbSet<DekamProjeDeneyHayvaniIrk> DekamProjeDeneyHayvaniIrk { get; set; }

        public DbSet<StShoppingCartItem> StShoppingCartItem { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<DekamProjeDeneyHayvaniIrkFiyat> DekamProjeDeneyHayvaniIrkFiyat { get; set; }
        //public DbSet<StCart> StCart { get; set; }

    }
}