using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class CategoryBlogsManager : ICategoryBlogsService
    {

        private readonly ICategoryBlogsDal _categoryBlogsDal;
        public CategoryBlogsManager(ICategoryBlogsDal categoryBlogsDal)
        {
            _categoryBlogsDal = categoryBlogsDal;
        }

        public List<CategoryBlog> GetCategoryPostIDList(int PostID)
        {
            throw new System.NotImplementedException();
        }


        public List<CategoryBlog> GetirHepsi()
        {
            return _categoryBlogsDal.GetirHepsi();
        }

        public CategoryBlog GetirIdile(int id)
        {
            return _categoryBlogsDal.GetirIdile(id);
        }

        public void Guncelle(CategoryBlog tablo)
        {
            _categoryBlogsDal.Guncelle(tablo);
        }

        public void Kaydet(CategoryBlog tablo)
        {
            _categoryBlogsDal.Kaydet(tablo);
        }

        public CategoryBlog KaydetReturn(CategoryBlog tablo)
        {
            throw new System.NotImplementedException();
        }


        public void Sil(CategoryBlog tablo)
        {
            _categoryBlogsDal.Sil(tablo);
        }

    }
}
