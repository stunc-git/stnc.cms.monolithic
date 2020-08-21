using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class DekamProjeTakipManager : IDekamProjeTakipService
    {
        private readonly IDekamProjeTakipDal _dekamProjeTakipDal;

        public DekamProjeTakipManager(IDekamProjeTakipDal dekamProjeTakipDal)
        {
            _dekamProjeTakipDal = dekamProjeTakipDal;
        }

        public List<DekamProjeTakip> DekamProjeTakipServiceList()
        {
            return _dekamProjeTakipDal.ProjeTakipList();
        }

        public List<DekamProjeTakip> GetAll()
        {
            return _dekamProjeTakipDal.GetAll();
        }

        public DekamProjeTakip GetirIdile(int id)
        {
            return _dekamProjeTakipDal.GetirIdile(id);
        }

        public int GetTotalProjeTakip()
        {
            return _dekamProjeTakipDal.GetTotalProjeTakip();
        }

        public void Guncelle(DekamProjeTakip tablo)
        {
            _dekamProjeTakipDal.Guncelle(tablo);
        }

        public void Kaydet(DekamProjeTakip tablo)
        {
            _dekamProjeTakipDal.Kaydet(tablo);
        }

        public DekamProjeTakip SaveReturn(DekamProjeTakip tablo)
        {
            return _dekamProjeTakipDal.SaveReturn(tablo);
        }

        public void Sil(DekamProjeTakip tablo)
        {
            _dekamProjeTakipDal.Sil(tablo);
        }
    }
}