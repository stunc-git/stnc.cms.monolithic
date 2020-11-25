using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.Business.Concrete
{
    public class RaporManager : IRaporService
    {
        private readonly IRaporDal _raporDal;

        public RaporManager(IRaporDal raporDal)
        {
            _raporDal = raporDal;
        }

        public Rapor GetirGorevileId(int id)
        {
            return _raporDal.GetirGorevileId(id);
        }

        public List<Rapor> GetAll()
        {
            return _raporDal.GetAll();
        }

        public Rapor GetirIdile(int id)
        {
            return _raporDal.GetID(id);
        }

        public int GetirRaporSayisi()
        {
            return _raporDal.GetirRaporSayisi();
        }

        public int GetirRaporSayisiileAppUserId(int id)
        {
            return _raporDal.GetirRaporSayisiileAppUserId(id);
        }

        public void Guncelle(Rapor tablo)
        {
            _raporDal.Update(tablo);
        }

        public void Kaydet(Rapor tablo)
        {
            _raporDal.Save(tablo);
        }

        public Rapor SaveReturn(Rapor tablo)
        {
            throw new NotImplementedException();
        }

        public void Sil(Rapor tablo)
        {
            _raporDal.Delete(tablo);
        }
    }
}
