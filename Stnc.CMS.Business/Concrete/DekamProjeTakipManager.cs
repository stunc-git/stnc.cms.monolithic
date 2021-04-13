using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class SiparislerManager : ISiparislerService
    {
        private readonly ISiparislerDal _dekamProjeTakipDal;

        public SiparislerManager(ISiparislerDal dekamProjeTakipDal)
        {
            _dekamProjeTakipDal = dekamProjeTakipDal;
        }

        public List<Siparisler> GetAll()
        {
            return _dekamProjeTakipDal.GetAll();
        }

        public Siparisler GetirIdile(int id)
        {
            return _dekamProjeTakipDal.GetID(id);
        }

        public int GetProjectTotal()
        {
            return _dekamProjeTakipDal.GetProjectTotal();
        }

        public void Guncelle(Siparisler tablo)
        {
            _dekamProjeTakipDal.Update(tablo);
        }

        public void Kaydet(Siparisler tablo)
        {
            _dekamProjeTakipDal.Save(tablo);
        }

        public List<Siparisler> ProjeList()
        {
            return _dekamProjeTakipDal.ProjeList();
        }

        public Siparisler SaveReturn(Siparisler tablo)
        {
            return _dekamProjeTakipDal.SaveReturn(tablo);
        }

        public void Sil(Siparisler tablo)
        {
             _dekamProjeTakipDal.Delete(tablo);
        }
    }
}