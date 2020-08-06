using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IPostDal : IGenericDal<Posts>
    {
        int GetTotalPost();

        List<Posts> PostList();

        Posts GetSlugPost(string Slug);
    }
}