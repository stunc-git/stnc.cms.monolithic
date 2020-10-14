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
                .Where(s =>s.AppUser.Id == s.AppUserId)
                .Where(s =>s.DekamProjeDeneyHayvaniTur.Id == s.DekamProjeDeneyHayvaniTurId)
                .Where(s =>s.DekamProjeDeneyHayvaniIrk.Id == s.DekamProjeDeneyHayvaniIrkId)
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
    }


}

