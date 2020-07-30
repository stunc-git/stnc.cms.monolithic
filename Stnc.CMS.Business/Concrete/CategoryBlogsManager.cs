using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class CategoryBlogsManager : ICategoryBlogService
    {

        private readonly ICategoryBlogsDal _categoryBlogsDal;

        public CategoryBlogsManager(ICategoryBlogsDal categoryBlogsDal)
        {
            _categoryBlogsDal = categoryBlogsDal;
        }

        public List<CategoryBlogs> GetCategoryPostIDList(int PostID)
        {
            return _categoryBlogsDal.GetCategoryPostIDList(PostID);
        }

        public int GetCategoryPostIDListSingle(int PostID)
        {
            return _categoryBlogsDal.GetCategoryPostIDListSingle(PostID);
        }

        public List<CategoryBlogs> GetAll()
        {
            return _categoryBlogsDal.GetAll();
        }

        public CategoryBlogs GetirIdile(int id)
        {
            return _categoryBlogsDal.GetirIdile(id);
        }

        public void Guncelle(CategoryBlogs tablo)
        {
            _categoryBlogsDal.Guncelle(tablo);
        }

        public void Kaydet(CategoryBlogs tablo)
        {
            _categoryBlogsDal.Kaydet(tablo);
        }

        public CategoryBlogs SaveReturn(CategoryBlogs tablo)
        {
            throw new System.NotImplementedException();
        }

        public void Sil(CategoryBlogs tablo)
        {
            _categoryBlogsDal.Sil(tablo);
        }

    }
}