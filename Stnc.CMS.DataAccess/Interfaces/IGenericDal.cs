using Stnc.CMS.Entities.Interfaces;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IGenericDal<Tablo> where Tablo : class, ITablo, new()
    {
        void Save(Tablo tablo);

        void Delete(Tablo tablo);

        void Update(Tablo tablo);

        Tablo GetID(int id);

        Tablo SaveReturn(Tablo tablo);

        List<Tablo> GetAll();
    }
}