﻿using Stnc.CMS.Business.Interfaces;
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
            return _aciliyetDal.GetID(id);
        }

        public void Guncelle(Aciliyet tablo)
        {
            _aciliyetDal.Update(tablo);
        }

        public void Kaydet(Aciliyet tablo)
        {
            _aciliyetDal.Save(tablo);
        }

        public Aciliyet SaveReturn(Aciliyet tablo)
        {
          return  _aciliyetDal.SaveReturn(tablo);
        }

        public void Sil(Aciliyet tablo)
        {
            _aciliyetDal.Delete(tablo);
        }
    }
}
