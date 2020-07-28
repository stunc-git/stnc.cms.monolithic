using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.Entities.Interfaces;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IGenericDal<Tablo> where Tablo : class, ITablo, new()
    {
        void Kaydet(Tablo tablo);
        void Sil(Tablo tablo);
        void Guncelle(Tablo tablo);
        Tablo GetirIdile(int id);

        Tablo KaydetReturn(Tablo tablo);

        List<Tablo> GetirHepsi();
       
    }
}
