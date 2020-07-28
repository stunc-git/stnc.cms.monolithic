using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface ICategoryBlogsDal : IGenericDal<CategoryBlog>
    {
        List<CategoryBlog> GetCategoryPostIDList(int PostID);
    }
}
