using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class AciliyetManager : IAciliyetService
    {
        private readonly IAciliyetDal _aciliyetDal;
        public AciliyetManager(IAciliyetDal aciliyetDal)
        {
            _aciliyetDal = aciliyetDal;
        }

        public List<Aciliyet> GetAll()
        {
            return _aciliyetDal.GetAll();
        }

        public Aciliyet GetirIdile(int id)
        {
            return _aciliyetDal.GetirIdile(id);
        }

        public void Guncelle(Aciliyet tablo)
        {
            _aciliyetDal.Guncelle(tablo);
        }

        public void Kaydet(Aciliyet tablo)
        {
            _aciliyetDal.Kaydet(tablo);
        }

        public Aciliyet SaveReturn(Aciliyet tablo)
        {
            throw new System.NotImplementedException();
        }

        public void Sil(Aciliyet tablo)
        {
            _aciliyetDal.Sil(tablo);
        }
    }
}
