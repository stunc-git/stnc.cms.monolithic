using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class DeneyHayvaniIrkFiyatManager : IDeneyHayvaniIrkFiyatService
    {
        private readonly IDeneyHayvaniIrkFiyatDal _deneyHayvaniIrkFiyatDal;
        public DeneyHayvaniIrkFiyatManager(IDeneyHayvaniIrkFiyatDal deneyHayvaniIrkFiyatDal)
        {
            _deneyHayvaniIrkFiyatDal = deneyHayvaniIrkFiyatDal;
        }

        public List<DeneyHayvaniIrkFiyatListAllDto> DeneyHayvaniIrkFiyatListesi()
        {
            return _deneyHayvaniIrkFiyatDal.DeneyHayvaniIrkFiyatListesi();
        }

        public List<DekamProjeDeneyHayvaniIrkFiyat> GetAll()
        {
            return _deneyHayvaniIrkFiyatDal.GetAll();
        }

        public DekamProjeDeneyHayvaniIrkFiyat GetirIdile(int id)
        {
            return _deneyHayvaniIrkFiyatDal.GetirIdile(id);
        }

        public void Guncelle(DekamProjeDeneyHayvaniIrkFiyat tablo)
        {
            _deneyHayvaniIrkFiyatDal.Guncelle(tablo);
        }

        public void Kaydet(DekamProjeDeneyHayvaniIrkFiyat tablo)
        {
            _deneyHayvaniIrkFiyatDal.Kaydet(tablo);
        }

        public DekamProjeDeneyHayvaniIrkFiyat SaveReturn(DekamProjeDeneyHayvaniIrkFiyat tablo)
        {
          return _deneyHayvaniIrkFiyatDal.SaveReturn(tablo);
        }

        public void Sil(DekamProjeDeneyHayvaniIrkFiyat tablo)
        {
            _deneyHayvaniIrkFiyatDal.Sil(tablo);
        }
    }
}
