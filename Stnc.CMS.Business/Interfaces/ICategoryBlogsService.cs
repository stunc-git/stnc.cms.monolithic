using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.Business.Interfaces
{
    public interface ICategoryBlogsService : IGenericService<CategoryBlog>
    {

        List<CategoryBlog> GetCategoryPostIDList(int PostID);
    }
}
