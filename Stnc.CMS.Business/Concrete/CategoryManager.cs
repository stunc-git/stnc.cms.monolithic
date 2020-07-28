using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetirHepsi()
        {
            return _categoryDal.GetirHepsi();
        }

        public Category GetirIdile(int id)
        {
            return _categoryDal.GetirIdile(id);
        }

        public void Guncelle(Category tablo)
        {
            _categoryDal.Guncelle(tablo);
        }

        public void Kaydet(Category tablo)
        {
            _categoryDal.Kaydet(tablo);
        }

        public Category KaydetReturn(Category tablo)
        {
            throw new System.NotImplementedException();
        }

        public void Sil(Category tablo)
        {
            _categoryDal.Sil(tablo);
        }
    }
}
