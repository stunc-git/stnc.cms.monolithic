using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfDekamProjeDeneyHayvaniIrkFiyatRepository : EfGenericRepository<DekamProjeDeneyHayvaniIrkFiyat>, IDeneyHayvaniIrkFiyatDal
    {
        public List<DeneyHayvaniIrkFiyatListAllDto> DeneyHayvaniIrkFiyatListesi()
        {
            using var context = new StncCMSContext();
            //return context.DekamProjeDeneyHayvaniIrkFiyat.Include(I => I.DekamProjeDeneyHayvaniIrk).Include(I => I.DekamProjeDeneyHayvaniTur).Include(I => I.AppUser).OrderByDescending(I => I.CreatedAt).ToList();
            return context.DekamProjeDeneyHayvaniIrkFiyat
                .OrderByDescending(I => I.CreatedAt)
                .Select(I => new DeneyHayvaniIrkFiyatListAllDto()
                {
                    Id = I.Id,
                    Isım = I.Isım,
                    UserName = I.AppUser.Name,
                    HayvaniTurAdi = I.DekamProjeDeneyHayvaniTur.Name,
                    HayvaniIrkAdi = I.DekamProjeDeneyHayvaniIrk.Name,
                    Fiyat = I.Fiyat,
                }).ToList();

        }



        public List<DeneyHayvaniAjaxListDto> DeneyHayvaniIrkFiyatListesiTurID(int TurID)
        {
            using var context = new StncCMSContext();
            return context.DekamProjeDeneyHayvaniIrkFiyat

                      .Where(s => s.DekamProjeDeneyHayvaniTur.Id == TurID)
                      .Where(s => s.DekamProjeDeneyHayvaniIrk.Id == s.DekamProjeDeneyHayvaniIrkId)
                      .OrderByDescending(I => I.CreatedAt)
                      .Select(I => new DeneyHayvaniAjaxListDto()
                      {
                          Id = I.Id,
                          Isim = I.Isım,
                          TurAdi = I.DekamProjeDeneyHayvaniTur.Name,
                          GunlukBakimUcreti = I.DekamProjeDeneyHayvaniTur.GunlukBakimUcret,
                          OtenaziUcret = I.DekamProjeDeneyHayvaniTur.OtenaziUcret,
                          IrkAdi = I.DekamProjeDeneyHayvaniIrk.Name,
                          Fiyat = I.Fiyat,
                      }).ToList();


        }

        public List<DeneyHayvaniAjaxListDto> DeneyHayvaniIrkFiyatListesiID(int ID)
        {
            using var context = new StncCMSContext();
            //return context.DekamProjeDeneyHayvaniIrkFiyat.Include(I => I.DekamProjeDeneyHayvaniIrk).Include(I => I.DekamProjeDeneyHayvaniTur).Include(I => I.AppUser).OrderByDescending(I => I.CreatedAt).ToList();
           return context.DekamProjeDeneyHayvaniIrkFiyat
                      .Where(s => s.Id == ID)
                      .OrderByDescending(I => I.CreatedAt)
                      .Select(I => new DeneyHayvaniAjaxListDto()
                      {
                          Id = I.Id,
                          Isim = I.Isım,
                          TurAdi = I.DekamProjeDeneyHayvaniTur.Name,
                          GunlukBakimUcreti = I.DekamProjeDeneyHayvaniTur.GunlukBakimUcret,
                          OtenaziUcret = I.DekamProjeDeneyHayvaniTur.OtenaziUcret,
                          IrkAdi = I.DekamProjeDeneyHayvaniIrk.Name,
                          Fiyat = I.Fiyat,
                      }).ToList();
        }



        public List<DeneyHayvaniAjaxListDto> DeneyHayvaniIrkFiyatListesiIrkID(int IrkID)
        {
            using var context = new StncCMSContext();
           return  context.DekamProjeDeneyHayvaniIrkFiyat
                      .Where(s => s.DekamProjeDeneyHayvaniTur.Id == IrkID)
                      .Where(s => s.DekamProjeDeneyHayvaniIrk.Id == s.DekamProjeDeneyHayvaniIrkId)
                      .OrderByDescending(I => I.CreatedAt)
                      .Select(I => new DeneyHayvaniAjaxListDto()
                      {
                          Id = I.Id,
                          Isim = I.Isım,
                          TurAdi = I.DekamProjeDeneyHayvaniTur.Name,
                          GunlukBakimUcreti = I.DekamProjeDeneyHayvaniTur.GunlukBakimUcret,
                          OtenaziUcret = I.DekamProjeDeneyHayvaniTur.OtenaziUcret,
                          IrkAdi = I.DekamProjeDeneyHayvaniIrk.Name,
                          Fiyat = I.Fiyat,
                      }).ToList();
        }


        public DeneyHayvaniAjaxListDto GetDeneyHayvaniIrkFiyatID(int ID)
        {
            using var context = new StncCMSContext();
            return context.DekamProjeDeneyHayvaniIrkFiyat
           .Where(s => s.Id == ID)
           .OrderByDescending(I => I.CreatedAt)
           .Select(I => new DeneyHayvaniAjaxListDto()
           {
               Id = I.Id,
               Isim = I.Isım,
               TurAdi = I.DekamProjeDeneyHayvaniTur.Name,
               GunlukBakimUcreti = I.DekamProjeDeneyHayvaniTur.GunlukBakimUcret,
               OtenaziUcret = I.DekamProjeDeneyHayvaniTur.OtenaziUcret,
               IrkAdi = I.DekamProjeDeneyHayvaniIrk.Name,
               Fiyat = I.Fiyat,
           })
           .FirstOrDefault();
        }



    }


}

