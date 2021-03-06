﻿using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Stnc.CMS.Business.Concrete
{
    public class GorevManager : IGorevService
    {
        private readonly IGorevDal _gorevDal;

        public GorevManager(IGorevDal gorevDal)
        {
            _gorevDal = gorevDal;
        }

        public Gorev GetirAciliyetileId(int id)
        {
            return _gorevDal.GetirAciliyetileId(id);
        }

        public List<Gorev> GetirAciliyetIleTamamlanmayan()
        {
            return _gorevDal.GetirAciliyetIleTamamlanmayan();
        }

        public int GetirGorevSayisiAtanmayiBekleyen()
        {
            return _gorevDal.GetirGorevSayisiAtanmayiBekleyen();
        }

        public int GetirGorevSayisiTamamlananileAppUserId(int id)
        {
            return _gorevDal.GetirGorevSayisiTamamlananileAppUserId(id);
        }

        public int GetirGorevSayisiTamamlanmasiGerekenileAppUserId(int id)
        {
            return _gorevDal.GetirGorevSayisiTamamlanmasiGerekenileAppUserId(id);
        }

        public int GetirGorevTamamlanmis()
        {
            return _gorevDal.GetirGorevTamamlanmis();
        }

        public List<Gorev> GetAll()
        {
            return _gorevDal.GetAll();
        }

        public Gorev GetirIdile(int id)
        {
            return _gorevDal.GetID(id);
        }

        public List<Gorev> GetirileAppUserId(int appUserId)
        {
            return _gorevDal.GetirileAppUserId(appUserId);
        }

        public Gorev GetirRaporlarileId(int id)
        {
            return _gorevDal.GetirRaporlarileId(id);
        }

        public List<Gorev> GetirTumTablolarla()
        {
            return _gorevDal.GetirTumTablolarla();
        }

        public List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter)
        {
            return _gorevDal.GetirTumTablolarla(filter);
        }

        public List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa)
        {
            return _gorevDal.GetirTumTablolarlaTamamlanmayan(out toplamSayfa, userId, aktifSayfa);
        }

        public void Guncelle(Gorev tablo)
        {
            _gorevDal.Update(tablo);
        }

        public void Kaydet(Gorev tablo)
        {
            _gorevDal.Save(tablo);
        }

        public Gorev SaveReturn(Gorev tablo)
        {
         return  _gorevDal.SaveReturn(tablo);
        }

        public void Sil(Gorev tablo)
        {
            _gorevDal.Delete(tablo);
        }
    }
}