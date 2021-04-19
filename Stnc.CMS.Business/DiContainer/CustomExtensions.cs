using Microsoft.Extensions.DependencyInjection;
using Stnc.CMS.Business.Concrete;
using Stnc.CMS.Business.CustomLogger;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.DataAccess.Interfaces;

namespace Stnc.CMS.Business.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {



            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IDosyaService, DosyaManager>();

      

      

 



            services.AddScoped<IShopDal, EfCartRepository>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
   

            services.AddScoped<ISiparislerService, SiparislerManager>();
            services.AddScoped<ISiparislerDal, EfSiparislerRepository>();


            services.AddScoped<IDeneyHayvaniIrkFiyatService, DeneyHayvaniIrkFiyatManager>();
            services.AddScoped<IDeneyHayvaniIrkFiyatDal, EfDekamProjeDeneyHayvaniIrkFiyatRepository>();

            //options 
            services.AddScoped<IOptionsService, OptionsManager>();
            services.AddScoped<IOptionsDal, EfOptionsRepository>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}