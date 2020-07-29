using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface ICategoryBlogsDal : IGenericDal<CategoryBlogs>
    {
        List<CategoryBlogs> GetCategoryPostIDList(int PostID);
    }
}
