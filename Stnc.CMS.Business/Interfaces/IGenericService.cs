using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.Entities.Interfaces;

namespace Stnc.CMS.Business.Interfaces
{
    public interface IGenericService<Tablo> where Tablo : class, ITablo, new()
    {
        void Kaydet(Tablo tablo);
        Tablo SaveReturn(Tablo tablo);
        void Sil(Tablo tablo);
        void Guncelle(Tablo tablo);
        Tablo GetirIdile(int id);
        List<Tablo> GetAll();
    }
}
