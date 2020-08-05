using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IPostDal : IGenericDal<Posts>
    {

        int GetTotalPost();
        List<Posts> PostList();
        Posts GetSlugPost(string Slug);
    }
}
