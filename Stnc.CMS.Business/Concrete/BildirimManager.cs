﻿using System.Collections.Generic;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.Business.Concrete
{
    public class BildirimManager : IBildirimService
    {
        private readonly IBildirimDal _bildirimDal;
        public BildirimManager(IBildirimDal bildirimDal)
        {
            _bildirimDal = bildirimDal;
        }

        public List<Bildirim> GetAll()
        {
            return _bildirimDal.GetAll();
        }

        public Bildirim GetirIdile(int id)
        {
            return _bildirimDal.GetirIdile(id);
        }

        public List<Bildirim> GetirOkunmayanlar(int AppUserId)
        {
            return _bildirimDal.GetirOkunmayanlar(AppUserId);
        }

        public int GetirOkunmayanSayisiileAppUserId(int AppUserId)
        {
            return _bildirimDal.GetirOkunmayanSayisiileAppUserId(AppUserId);
        }

        public void Guncelle(Bildirim tablo)
        {
            _bildirimDal.Guncelle(tablo);
        }

        public void Kaydet(Bildirim tablo)
        {
            _bildirimDal.Kaydet(tablo);
        }

        public Bildirim SaveReturn(Bildirim tablo)
        {
            throw new System.NotImplementedException();
        }

        public void Sil(Bildirim tablo)
        {
            _bildirimDal.Sil(tablo);
        }

 
    }
}
