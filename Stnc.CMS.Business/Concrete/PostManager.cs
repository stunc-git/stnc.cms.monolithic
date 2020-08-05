using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public int GetTotalPost()
        {
            return _postDal.GetTotalPost();
        }



        public List<Posts> PostList()
        {
            return _postDal.PostList();
        }

        public void Guncelle(Posts tablo)
        {
            _postDal.Guncelle(tablo);
        }

        public void Kaydet(Posts tablo)
        {
            _postDal.Kaydet(tablo);
        }

        public void Sil(Posts tablo)
        {
            _postDal.Sil(tablo);
        }

        public Posts GetirIdile(int id)
        {
            return _postDal.GetirIdile(id);

        }

        public List<Posts> GetAll()
        {
            return _postDal.GetAll();

        }

        public Posts SaveReturn(Posts tablo)
        {
            return _postDal.SaveReturn(tablo);
        }

        public Posts GetSlugPost(string slug)
        {
            return _postDal.GetSlugPost(slug);
        }
    }
}
