using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Interfaces
{
    public interface IPostService : IGenericService<Posts>
    {
        int GetTotalPost();
        List<Posts> PostList();
        Posts GetSlugPost(string slug);
    }
}
