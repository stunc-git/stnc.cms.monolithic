using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPostRepository : EfGenericRepository<Posts>, IPostDal
    {
        public int GetTotalPost()
        {
            using var context = new StncCMSContext();
            return context.Posts.Count();
        }

        public List<Posts> PostList()
        {
            using var context = new StncCMSContext();
            return context.Posts.Where(I => I.PostStatus).OrderByDescending(I => I.Id).ToList();
        }

        public Posts GetSlugPost(string Slug)
        {
            using var context = new StncCMSContext();
            return context.Posts.Where(I => I.PostSlug == Slug).OrderByDescending(I => I.Id).FirstOrDefault();
            //          // return context.DekamProjeTakip.Select(u => u.DekamProjeDeneyHayvaniTur.Name).ToList();

        }
    }
}