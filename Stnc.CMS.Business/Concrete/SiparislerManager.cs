using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class SiparislerManager : ISiparislerService
    {
        private readonly ISiparislerDal _siparislerDal;

        public SiparislerManager(ISiparislerDal siparislerDal)
        {
            _siparislerDal = siparislerDal;
        }

        public List<Siparisler> GetAll()
        {
            return _siparislerDal.GetAll();
        }

        public Siparisler GetirIdile(int id)
        {
            return _siparislerDal.GetID(id);
        }

        public int GetProjectTotal()
        {
            return _siparislerDal.GetProjectTotal();
        }

        public void Guncelle(Siparisler tablo)
        {
            _siparislerDal.Update(tablo);
        }

        public void Kaydet(Siparisler tablo)
        {
            _siparislerDal.Save(tablo);
        }

        public List<Siparisler> ProjeList()
        {
            return _siparislerDal.ProjeList();
        }

        public Siparisler SaveReturn(Siparisler tablo)
        {
            return _siparislerDal.SaveReturn(tablo);
        }

        public void Sil(Siparisler tablo)
        {
             _siparislerDal.Delete(tablo);
        }
    }
}