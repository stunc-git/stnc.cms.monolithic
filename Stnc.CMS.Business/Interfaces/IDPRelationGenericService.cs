using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.Entities.Interfaces;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Interfaces
{
    public interface IDPRelationGenericService<Tablo> where Tablo : class, ITablo, new()
        //: IGenericService<DPRelationGenericsEntity>
    {
        void Kaydet(Tablo tablo);
        Tablo SaveReturn(Tablo tablo);
        void Sil(Tablo tablo);
        void Guncelle(Tablo tablo);
        Tablo GetirIdile(int id);

        List<Tablo> GetAll();
    }
}