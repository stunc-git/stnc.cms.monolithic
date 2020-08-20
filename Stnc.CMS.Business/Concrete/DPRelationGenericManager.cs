using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class DPRelationGenericManager
    {
        private readonly IDPRelationGenericDal _IDPRelationGenericDal;

        public DPRelationGenericManager(IDPRelationGenericDal iDPRelationGenericDal)
        {
            _IDPRelationGenericDal = iDPRelationGenericDal;
        }

        public List<DPRelationGenericsEntity> GetAll()
        {
            return _IDPRelationGenericDal.GetAll();
        }

        public DPRelationGenericsEntity GetirIdile(int id)
        {
            return _IDPRelationGenericDal.GetirIdile(id);
        }

        public void Guncelle(DPRelationGenericsEntity tablo)
        {
            _IDPRelationGenericDal.Guncelle(tablo);
        }

        public void Kaydet(DPRelationGenericsEntity tablo)
        {
            _IDPRelationGenericDal.Kaydet(tablo);
        }

        public DPRelationGenericsEntity SaveReturn(DPRelationGenericsEntity tablo)
        {
            return _IDPRelationGenericDal.SaveReturn(tablo);
        }

        public void Sil(DPRelationGenericsEntity tablo)
        {
            _IDPRelationGenericDal.Sil(tablo);
        }
    }
}
