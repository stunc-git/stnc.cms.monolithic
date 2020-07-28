using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryBlogsRepository : EfGenericRepository<CategoryBlog>, ICategoryBlogsDal

    {

 
        public List<CategoryBlog> GetCategoryPostIDList(int PostID)
        {
              using var context = new StncCMSContext();
            return context.CategoryBlog.Where(I => I.PostID == PostID).ToList();

        }
    }
}
