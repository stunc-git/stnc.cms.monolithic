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

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetirIdile(int id)
        {
            return _categoryDal.GetID(id);
        }

        public void Guncelle(Category tablo)
        {
            _categoryDal.Update(tablo);
        }

        public void Kaydet(Category tablo)
        {
            _categoryDal.Save(tablo);
        }

        public Category SaveReturn(Category tablo)
        {
          return  _categoryDal.SaveReturn(tablo);
        }

        public void Sil(Category tablo)
        {
            _categoryDal.Delete(tablo);
        }
    }
}
