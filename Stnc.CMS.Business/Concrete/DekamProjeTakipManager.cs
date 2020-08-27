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

        public List<DekamProjeTakip> GetAll()
        {
            return _dekamProjeTakipDal.GetAll();
        }

        public DekamProjeTakip GetirIdile(int id)
        {
            throw new System.NotImplementedException();
        }

        public int GetProjectTotal()
        {
            throw new System.NotImplementedException();
        }

        public void Guncelle(DekamProjeTakip tablo)
        {
            throw new System.NotImplementedException();
        }

        public void Kaydet(DekamProjeTakip tablo)
        {
            throw new System.NotImplementedException();
        }

        public List<DekamProjeTakip> ProjeList()
        {
            throw new System.NotImplementedException();
        }

        public DekamProjeTakip SaveReturn(DekamProjeTakip tablo)
        {
            throw new System.NotImplementedException();
        }

        public void Sil(DekamProjeTakip tablo)
        {
            throw new System.NotImplementedException();
        }
    }
}