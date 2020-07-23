﻿using Stnc.CMS.Business.Interfaces;
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
            throw new System.NotImplementedException();
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

        public List<Posts> GetirHepsi()
        {
            return _postDal.GetirHepsi();

        }

    }
}
