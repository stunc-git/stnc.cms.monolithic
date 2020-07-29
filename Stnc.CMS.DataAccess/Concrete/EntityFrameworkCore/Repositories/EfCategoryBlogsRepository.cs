using Microsoft.EntityFrameworkCore;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryBlogsRepository : EfGenericRepository<CategoryBlogs>, ICategoryBlogsDal

    {


      public List<CategoryBlogs> GetCategoryPostIDList(int PostID)
        {
               using var context = new StncCMSContext();
               return context.CategoryBlogs.Where(I => I.PostID == PostID)
                .TagWith("Get post counts for blogs")
                .ToList();
        }
    }
}
