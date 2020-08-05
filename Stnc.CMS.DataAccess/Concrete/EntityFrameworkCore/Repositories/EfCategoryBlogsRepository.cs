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
                .TagWith("Get category post id list ")
                .ToList();
            //  var CategoryID = catList[0].CategoryID;
        }

        public int GetCategoryPostIDListSingle(int PostID)
        {
            using var context = new StncCMSContext();
            var returnData = context.CategoryBlogs.SingleOrDefault(I => I.PostID == PostID);
            if (returnData == null)
                return 1;
             else
                return returnData.CategoryID;
        }
    }
}