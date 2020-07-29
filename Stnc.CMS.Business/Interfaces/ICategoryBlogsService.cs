using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.Business.Interfaces
{
    public interface ICategoryBlogService : IGenericService<CategoryBlogs>
    {

        List<CategoryBlogs> GetCategoryPostIDList(int PostID);
    }
}
