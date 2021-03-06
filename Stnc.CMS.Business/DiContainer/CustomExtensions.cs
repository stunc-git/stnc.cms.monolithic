﻿using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IGorevService, GorevManager>();

            services.AddScoped<IAciliyetService, AciliyetManager>();
            services.AddScoped<IAciliyetDal, EfAciliyetRepository>();

            services.AddScoped<IRaporService, RaporManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IDosyaService, DosyaManager>();
            services.AddScoped<IBildirimService, BildirimManager>();

            //post
            services.AddScoped<IPostService, PostManager>();
            services.AddScoped<IPostDal, EfPostRepository>();

            //Slider
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDal, EfSliderRepository>();

            //category
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IGorevDal, EfGorevRepository>();

            services.AddScoped<IRaporDal, EfRaporRepository>();

            services.AddScoped<IShopDal, EfCartRepository>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IBildirimDal, EfBildirimRepository>();

            services.AddScoped<IDekamProjeTakipService, DekamProjeTakipManager>();
            services.AddScoped<IDekamProjeTakipDal, EfDekamProjeTakipRepository>();


            services.AddScoped<IDeneyHayvaniIrkFiyatService, DeneyHayvaniIrkFiyatManager>();
            services.AddScoped<IDeneyHayvaniIrkFiyatDal, EfDekamProjeDeneyHayvaniIrkFiyatRepository>();

            //options 
            services.AddScoped<IOptionsService, OptionsManager>();
            services.AddScoped<IOptionsDal, EfOptionsRepository>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}