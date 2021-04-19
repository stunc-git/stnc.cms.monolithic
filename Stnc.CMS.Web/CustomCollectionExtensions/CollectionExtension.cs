﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Stnc.CMS.Business.ValidationRules.FluentValidation;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DTO.DTOs.AppUserDtos;
using Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos;
using Stnc.CMS.DTO.DTOs.SiparislerDtos;
using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.Web.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<StncCMSContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "StncCRMCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/adminpanel";
            });
        }

        public static void AddCustomValidator(this IServiceCollection services)
        {


            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();




            services.AddTransient<IValidator<SiparislerCreateDto>, SiparislerCreateValidator>();
            services.AddTransient<IValidator<SiparislerUpdateDto>, SiparislerUpdateValidator>();

            services.AddTransient<IValidator<DeneyHayvaniIrkFiyatCreateDto>, DeneyHayvaniIrkFiyatCreateValidator>();
            services.AddTransient<IValidator<DeneyHayvaniIrkFiyatUpdateDto>, DeneyHayvaniIrkFiyatUpdateValidator>();


        }
    }
}